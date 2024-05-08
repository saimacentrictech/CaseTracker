using Microsoft.AspNetCore.Mvc;
using MyApp.DataAccessLayer.Infrastructure.IRepository;
using MyApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyApp.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.IO.Pipes;
namespace MyAppWeb.Areas.Admin.Controllers
{
     public class CategoryController : Controller
    {
        private IUnitofwork _unitofwork;
     
        
        public CategoryController(IUnitofwork unitofwork)
        {
            _unitofwork = unitofwork;
            
        }
        public IActionResult Index()
        {
            CategoryVM categoryvm = new CategoryVM();
            categoryvm.categories = _unitofwork.Category.GetAll();
            return View(categoryvm);
        }
        //[HttpGet]
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Create(Category category)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _unitofwork.Category.Added(category);

        //        _unitofwork.save();
        //        TempData["created"] = "category addedd!";
        //        return Redirect("Index");
        //    }
        //    return View(category);
        //}
        //----edit
        [HttpGet]
        public IActionResult CreateUpdate(int? id)
        {  
            CategoryVM vm = new CategoryVM();
            if (id == null || id == 0)
            {   
                return View(vm);
            }
            else
            {
              vm.Categoryq= _unitofwork.Category.GetT(x => x.Id == id);
                if (vm.Categoryq == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(vm);
                }
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateUpdate(CategoryVM vm)
        {
            if (ModelState.IsValid)
            {
               
                if (vm.Categoryq.Id == 0)
                {
                    _unitofwork.Category.Added(vm.Categoryq);
                }
                else
                {
                    _unitofwork.Category.Update(vm.Categoryq);
                }
                _unitofwork.save();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        //-----------------delete
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();

            }
            var category = _unitofwork.Category.GetT(x => x.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Deletedata(int? id)
        {
            var category = _unitofwork.Category.GetT(x => x.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            _unitofwork.Category.Delete(category);
            _unitofwork.save();
            TempData["created"] = "Category Deleted!!";
            return RedirectToAction("Index");
        }
    }
}
