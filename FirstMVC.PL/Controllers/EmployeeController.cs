using AutoMapper;
using FirstMVC.BLL.Interfaces;
using FirstMVC.DAL.Model;
using FirstMVC.PL.Helpers;
using FirstMVC.PL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace FirstMVC.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _EmployeeRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeRepository employeeRepository,
            IDepartmentRepository departmentRepository,
            IMapper mapper)
        {
            _EmployeeRepository = employeeRepository;
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public IActionResult Index(string searchQuery)
        {

            if (string.IsNullOrEmpty(searchQuery))

            {


                var employee = _EmployeeRepository.GetAll();
                var MappedEmployee=_mapper.Map<IEnumerable<Employee>,IEnumerable<EmployeeViewModel>>(employee);
                return View(MappedEmployee);
            }
            else
            {
                var employee = _EmployeeRepository.search(searchQuery.ToLower());

                var MappedEmployee = _mapper.Map < IEnumerable<Employee>, IEnumerable< EmployeeViewModel >> (employee);
                return View(MappedEmployee);
            }



        }

        public IActionResult Create()
        {
            
            return View();


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EmployeeViewModel employeeVm)
        {
            employeeVm.ImageName = DocumentSettings.UploadFile(employeeVm.Image, "Images");

            if (ModelState.IsValid)
            {
              var MappedEmployee=  _mapper.Map<EmployeeViewModel, Employee>(employeeVm);
                 
                var count = _EmployeeRepository.Add(MappedEmployee);
                if (count > 0)
                {
                  

                    return RedirectToAction(nameof(Index));


                }


            }
            return View(employeeVm);

        }

        public IActionResult Details(int? id, string viewName = "Details")
        {
            if (!id.HasValue)
                return BadRequest();

            var employee = _EmployeeRepository.GetById(id.Value);

            if (employee == null)
                return NotFound();
            var MappedEmployee = _mapper.Map <Employee,  EmployeeViewModel > (employee);
            return View(viewName, MappedEmployee);


        }

        public IActionResult Edit(int? id)

        {
            return Details(id, "Edit");


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EmployeeViewModel employee)


        {
            if (employee.Image != null)
            {
                
                if (!string.IsNullOrEmpty(employee.ImageName))
                {
                    DocumentSettings.DeleteFile(employee.ImageName, "Images");
                }

                
                employee.ImageName = DocumentSettings.UploadFile(employee.Image, "Images");
            }
            if (!ModelState.IsValid)

                return View(employee);
            var MappedEmployee = _mapper.Map <EmployeeViewModel,Employee> (employee);
          _EmployeeRepository.Update(MappedEmployee);
      

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)

        {
            return Details(id, "Delete");


        }

        [HttpPost]

        public IActionResult Delete(EmployeeViewModel employee)
        {
            var MappedEmployee = _mapper.Map <EmployeeViewModel,Employee> (employee);
        var count= _EmployeeRepository.Delete(MappedEmployee);

            if (count > 0)
            {
                DocumentSettings.DeleteFile(employee.ImageName, "Images");
            }

            return RedirectToAction(nameof(Index));

        }

    }
}
