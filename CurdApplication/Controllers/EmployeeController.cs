using CurdApplication.Models;
using CurdApplication.Models.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurdApplication.Controllers
{
    public class EmployeeController : Controller
    {

        private ApplicationDbContext dbContext; //dbContext is the property name

        public EmployeeController(ApplicationDbContext context)
        {
           this.dbContext = context;
        }
        public IActionResult Index()
        {
            var result = dbContext.Employees.ToList();
           // var emps = dbContext.Employees
           // return View(emps);
            return View(result);
        }
        // for data loading by default HttpGet method be call by this method;
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee model)
        {
            if (ModelState.IsValid) {
                var emp = new Employee() {
                    Name = model.Name,
                    City=model.City,
                    State=model.State,
                    Salary=model.Salary,
            };
                dbContext.Employees.Add(emp);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = "empty feild can't be submit";
                return View(model);
            }
           
        }
        public IActionResult Delete(int id)
        {
            var emp = dbContext.Employees.SingleOrDefault(e => e.Id == id);
            dbContext.Employees.Remove(emp);
            dbContext.SaveChanges();
            TempData["error"] = "record deleated !";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var emp = dbContext.Employees.SingleOrDefault(e => e.Id == id);
            var result = new Employee()
            {
                Name = emp.Name,
                City = emp.City,
                State = emp.State,
                Salary = emp.Salary,

            };
            return View(result);
        }

        [HttpPost]
        public IActionResult Edit(Employee model)
        {
            var result = new Employee()
            {
                //because data is posted behalf of Id,
                Id=model.Id,
                Name = model.Name,
                City = model.City,
                State = model.State,
                Salary = model.Salary,

            };
            dbContext.Employees.Update(result);
            dbContext.SaveChanges();
            TempData["error"] = "record updated";
            return RedirectToAction("Index");
        }

    }
}
