using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using Workwear.Data;
using Workwear.Models;
using Workwear.Repository;
using Workwear.Repository.IRepository;
using Workwear.Utility;
using Workwear.ViewModels;

namespace Workwear.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class ProductSizeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductSizeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<ProductSize> objProductSizeList = _unitOfWork.ProductSize.GetAll(includeProperties:"Product").ToList();
            return View(objProductSizeList);
        }
        public IActionResult Upsert(int? id)
        {
            ProductSizeVM sizeVM = new()
            {
                ProductList = _unitOfWork.Product.GetAll().Select(x => new SelectListItem
                {
                    Text = x.Title,
                    Value = x.Id.ToString(),
                }),
                ProductSize = new ProductSize()
            };
            if (id == null || id == 0)
            {
                return View(sizeVM);
            }
            else
            {
                sizeVM.ProductSize = _unitOfWork.ProductSize.Get(x => x.Id == id);
                return View(sizeVM);
            }
            
        }

        [HttpPost]
        public IActionResult Upsert(ProductSizeVM SizeVM)
        {
            if (ModelState.IsValid)
            {
                if (SizeVM.ProductSize.Id == 0) // Проверка на новую запись
                {
                    _unitOfWork.ProductSize.Add(SizeVM.ProductSize);
                }
                else
                {
                    _unitOfWork.ProductSize.Update(SizeVM.ProductSize);
                }

                _unitOfWork.Save();
                TempData["success"] = "Успешно";
                return RedirectToAction("Index");
            }
            else
            {
                SizeVM.ProductList = _unitOfWork.Product.GetAll().Select(x => new SelectListItem
                {
                    Text = x.Title,
                    Value = x.Id.ToString(),
                });
                return View(SizeVM);
            }
        }



        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            ProductSize? productsizeFromDb = _unitOfWork.ProductSize.Get(x => x.Id == id);
            if (productsizeFromDb == null)
            {
                return NotFound();
            }
            return View(productsizeFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            ProductSize? obj = _unitOfWork.ProductSize.Get(x => x.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.ProductSize.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Успешно";
            return RedirectToAction("Index");
        }
    }
}
