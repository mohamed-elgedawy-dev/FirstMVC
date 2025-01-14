using FirstMVC.BLL.Interfaces;
using FirstMVC.DAL.Model;
using Microsoft.AspNetCore.Mvc;

namespace FirstMVC.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public IActionResult Index(string searchQuery)
        {

            if (string.IsNullOrEmpty(searchQuery))

            {
                var department = _departmentRepository.GetAll();
                return View(department);
            }
            else
            {
                var department = _departmentRepository.search(searchQuery.ToLower());


                return View(department);
            }



        }

        public IActionResult Create()
        {
            return View();


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Department department)
        {

            if (ModelState.IsValid)
            {

                var count = _departmentRepository.Add(department);
                if (count > 0)
                {

                    return RedirectToAction(nameof(Index));


                }


            }
            return View(department);

        }

        public IActionResult Details(int? id, string viewName = "Details")
        {
            if (!id.HasValue)
                return BadRequest();

            var department = _departmentRepository.GetById(id.Value);

            if (department == null)
                return NotFound();
            return View(viewName, department);


        }

        public IActionResult Edit(int? id)

        {
            return Details(id, "Edit");


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Department department)


        {

            if (!ModelState.IsValid)

                return View(department);

            _departmentRepository.Update(department);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)

        {
            return Details(id, "Delete");


        }

        [HttpPost]

        public IActionResult Delete(Department department)
        {
            _departmentRepository.Delete(department);

            return RedirectToAction(nameof(Index));

        }



    }
}
