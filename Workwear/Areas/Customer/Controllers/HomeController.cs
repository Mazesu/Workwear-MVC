using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using System.Security.Claims;
using Workwear.Models;
using Workwear.Repository.IRepository;
using Workwear.Utility;
using Workwear.ViewModels;

namespace Workwear.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            if (claim != null)
            {
                HttpContext.Session.SetInt32(SD.SessionCart,
                                            _unitOfWork.ShoppingCart.GetAll(x => x.ApplicationUserId == claim.Value).Count());
            }

            IEnumerable<Product> productList = _unitOfWork.Product.GetAll(includeProperties: "Category");
            return View(productList);
        }

        public IActionResult Details(int productId)
        {
            Product product = _unitOfWork.Product.Get(
                filter: p => p.Id == productId,
                includeProperties: "Category,ProductSize"
            );

            if (product == null)
            {
                return NotFound(); // Return a 404 Not Found response if the product is not found
            }

            ProductSize productSize = product.ProductSize.FirstOrDefault();

            ShoppingCart cart = new ShoppingCart
            {
                ProductSizeId = productSize.Id,
                ProductSize = productSize,
                Count = 1
            };

            return View(cart);
        }


        [HttpPost]
        [Authorize]
        public IActionResult Details(ShoppingCart shoppingCart, string selectedSize, int productId)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            shoppingCart.ApplicationUserId = userId;

            var productSizeId = _unitOfWork.ProductSize.GetProductSizeIdBySelectedSize(selectedSize, productId);

            if (productSizeId != null)
            {
                ShoppingCart cartFromDb = _unitOfWork.ShoppingCart.Get(x => x.ApplicationUserId == userId && x.ProductSizeId == productSizeId && x.Size == selectedSize);

                if (cartFromDb != null)
                {
                    cartFromDb.Count += shoppingCart.Count; 
                    _unitOfWork.ShoppingCart.Update(cartFromDb);
                    _unitOfWork.Save();
                }
                else
                {
                    shoppingCart.ProductSizeId = productSizeId; // Set the ProductSizeId based on the selected size
                    shoppingCart.Size = selectedSize; // Set the selected size of the product in the shopping cart object
                    _unitOfWork.ShoppingCart.Add(shoppingCart);
                    _unitOfWork.Save();
                    HttpContext.Session.SetInt32(SD.SessionCart, _unitOfWork.ShoppingCart.GetAll(x => x.ApplicationUserId == userId).Count());
                }

                TempData["success"] = "Корзина успешно обновлена";
            }
            else
            {
                TempData["error"] = "Выбранный размер товара не найден";
            }

            return RedirectToAction(nameof(Index));
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}