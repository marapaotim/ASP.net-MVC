using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee 
       
        public ActionResult Index()
        {
            MVCEntities db = new MVCEntities();
            ViewBag.ListEmployee = db.employees.ToList(); 
            return View();
        }

        public ActionResult NewEmployee()
        {
            return View();
        }

        public ActionResult InsertEmployee(EmployeeModel model)
        {
            try
            {
                MVCEntities db = new MVCEntities();
                employee employ = new employee();
                employ.Name = model.Name;
                employ.Gender = model.Gender;
                employ.Email = model.Email;
                employ.Age = model.Age;
                db.employees.Add(employ);
                db.SaveChanges(); 
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            MVCEntities db = new MVCEntities();
            var data = db.employees.Where(x => x.id == id).First();
            db.employees.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MVCEntities db = new MVCEntities();
            var data = db.employees.Where(x => x.id == id).First();
            employee employ = new employee();
            employ.Name = data.Name.Trim();
            employ.Gender = data.Gender.Trim();
            employ.Email = data.Email.Trim();
            employ.Age = data.Age.Trim(); 
            return View(employ);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(employee model)
        {
            MVCEntities db = new MVCEntities();
            if (ModelState.IsValid)
            { 
                var data = db.employees.Where(x => x.id == model.id).First();
                data.Name = model.Name;
                data.Gender = model.Gender;
                data.Email = model.Email;
                data.Age = model.Age;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}