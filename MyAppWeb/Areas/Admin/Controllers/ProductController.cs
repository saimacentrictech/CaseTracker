using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyApp.DataAccessLayer.Infrastructure.IRepository;
using MyApp.Models;
using MyApp.Models.ViewModels;
namespace MyAppWeb.Areas.Admin.Controllers
{
     public class ProductController : Controller
    {
        private IUnitofwork _unitofwork;
        private  IWebHostEnvironment _webHostEnvironment;
        public ProductController(IUnitofwork unitofwork, IWebHostEnvironment webHostEnvironment)
        {
            _unitofwork = unitofwork;
            _webHostEnvironment = webHostEnvironment;
        }
        #region APICALL
        public IActionResult ALLPRODUCTS() 
        {
            var products = _unitofwork.Product.GetAll();
            return Json(new { data = products });

        }
        #endregion
        public IActionResult Index()
        {
            ProductVM productvm = new ProductVM();
            productvm.products = _unitofwork.Product.GetAll();
            return View(productvm);
        }
        [HttpGet]
        public IActionResult CreateUpdate(int? id)
        {  
            ProductVM vm = new ProductVM() {
                Products=new (),
                Categories=_unitofwork.Category.GetAll().Select(x => new SelectListItem { 
                  Text = x.Name,
                  Value=x.Id.ToString(),

                }) 
            };
         
            if (id == null || id == 0)
            {   
                return View(vm);
            }
            else
            {
              vm.Products = _unitofwork.Product.GetT(x => x.Id == id);
                if (vm.products == null)
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
        public IActionResult CreateUpdate(ProductVM vm, IFormFile? File )
        {

            if (ModelState.IsValid)
            {
                string filename = String.Empty;
                if (File != null)
                {
                    string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "ProductImage");
                    filename = Guid.NewGuid().ToString() + "-" + File.FileName;
                    string filepath = Path.Combine(uploadDir, filename);
                    using (var filestream = new FileStream(filepath, FileMode.Create))
                    {
                        File.CopyTo(filestream);
                    }
                    vm.Products .ImageUrl = @"\ProductImage\" + filename;
                }

           
                if (vm.Products.Id == 0)
                {
                    _unitofwork.Product.Added(vm.Products);
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
