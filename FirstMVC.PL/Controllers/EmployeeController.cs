using FirstMVC.BLL.Interfaces;
using FirstMVC.DAL.Model;
using Microsoft.AspNetCore.Mvc;

namespace FirstMVC.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _EmployeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _EmployeeRepository = employeeRepository;
        }

        public IActionResult Index(string searchQuery)
        {

            if (string.IsNullOrEmpty(searchQuery))

            {
                var employee = _EmployeeRepository.GetAll();
                return View(employee);
            }
            else
            {
                var employee = _EmployeeRepository.search(searchQuery.ToLower());


                return View(employee);
            }



        }

        public IActionResult Create()
        {
            return View();


        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {

            if (ModelState.IsValid)
            {

                var count = _EmployeeRepository.Add(employee);
                if (count > 0)
                {

                    return RedirectToAction(nameof(Index));


                }


            }
            return View(employee);

        }

        public IActionResult Details(int? id, string viewName = "Details")
        {
            if (!id.HasValue)
                return BadRequest();

            var employee = _EmployeeRepository.GetById(id.Value);

            if (employee == null)
                return NotFound();
            return View(viewName, employee);


        }

        public IActionResult Edit(int? id)

        {
            return Details(id, "Edit");


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employee employee)


        {

            if (!ModelState.IsValid)

                return View(employee);

            _EmployeeRepository.Update(employee);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)

        {
            return Details(id, "Delete");


        }

        [HttpPost]

        public IActionResult Delete(Employee employee)
        {
            _EmployeeRepository.Delete(employee);

            return RedirectToAction(nameof(Index));

        }

    }
}
