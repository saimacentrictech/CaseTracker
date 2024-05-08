
using webapp.Model.ViewModel;
using Microsoft.AspNetCore.Mvc;
using ecommerce.Infrastructure.IRepository;


namespace webapp.Model.Controllers
{
    //[Area("Admin")]
    public class CategoryController : Controller
    {
        private IUnitofwork Unitofwork;

        public CategoryController(IUnitofwork _Unitofwork)
        {
            Unitofwork = _Unitofwork;
                
        }
        public IActionResult Index()
        {
            CategoryVM vm = new CategoryVM();
           vm.Category = Unitofwork.CategoryRepository.GetAll();
            return View(vm);
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
        //        Unitofwork.CategoryRepository.Added(category);
        //        Unitofwork.save();
        //        TempData["created"] = "created successfully!!";
        //        return RedirectToAction("Index");
        //    }
        //    return View(category);
        //}
        // edit
        [HttpGet]
        public IActionResult CreateUpdate(int? id)
        {
            CategoryVM vm  = new CategoryVM();
            if (id == null || id == 0)
            {
                return View(vm);
            }
            var EditCategory = Unitofwork.CategoryRepository.GetT(x => x.Id==id);
            if (EditCategory == null)
            {
                return NotFound();
            }
            else
            {
                return View(EditCategory);

            }
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateUpdate(CategoryVM vm)

        {
            Unitofwork.CategoryRepository.Added(vm.category);
            Unitofwork.save();
            TempData["edited"] = "Edited successfully!!";
            return RedirectToAction("Index");
        }
        //delete
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var category = Unitofwork.CategoryRepository.GetT(x => x.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteData(int? id)
        {
            var data = Unitofwork.CategoryRepository.GetT(x => x.Id == id);
            if (data == null)
            {
                return NotFound();

            }
            Unitofwork.CategoryRepository.Delete(data);
            Unitofwork.save();
            TempData["delete"] = "category deleted!!";
            return RedirectToAction("Index");
        }
    }
}

