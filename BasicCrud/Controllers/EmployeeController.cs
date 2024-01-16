using BasicCrud.Data;
using BasicCrud.Models;
using Microsoft.AspNetCore.Mvc;

namespace BasicCrud.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Employee> objCatList = _context.Employees;
            return View(objCatList);
        }
        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee obj) 
        {
            if (ModelState.IsValid)
            {
                _context.Employees.Add(obj);
                _context.SaveChanges();
                TempData["ResultOk"] = "Record Added Successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public IActionResult Edit(int? id) 
        {
            if (id==null||id==0) 
            {
                return NotFound();
            }
            var empObj=_context.Employees.Find(id);
            if (empObj==null) 
            {
                return NotFound();
            }
            return View(empObj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employee empObj)
        {
            if (ModelState.IsValid)
            {
                _context.Employees.Update(empObj);
                _context.SaveChanges();
                TempData["ResultOk"] = "Data Update SuccessFully";
                return RedirectToAction("Index");
            }
            return View(empObj);
        }
        public ActionResult Delete(int id) 
        {
            if (id==null || id==0)
            {
                return NotFound();
            }
            var empObj=_context.Employees.Find(id); 
            if (empObj==null)
            {
                return NotFound();
            }
            return View(empObj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteData(int?id)
        {
            var deleteRecord=_context.Employees.Find(id);
            if (deleteRecord == null) 
            {
                return NotFound();
            }
            _context.Employees.Remove(deleteRecord);
            _context.SaveChanges();
            TempData["ResultOk"] = "Deleted SuccessFully";
            return RedirectToAction("Index");
        }
    }
}
