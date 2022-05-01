using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP7Web.Models;

namespace TP7Web.Controllers
{
    public class EmployeeController : Controller
    {
        TempDataEntities tm = new TempDataEntities();
        // GET: Employee
        public ActionResult Index()
        {
            var data = tm.EmployeeDetails.ToList();
            return View(data);
        }
        public ActionResult Create()
        { 
            return View();
        }

        [HttpPost]
        public ActionResult Create(EmployeeDetail e)
        {
            if (ModelState.IsValid == true)
            {
                tm.EmployeeDetails.Add(e);
                int a = tm.SaveChanges();
                if (a > 0)
                {
                    TempData["InsertMessage"] = "<script>alert('Inserted !!')</script>";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["InsertMessage"] = "<script>alert('Not Inserted !!')</script>";
                }
            }
            return View();

        }

        public ActionResult Edit(int id)
        {
            var row = tm.EmployeeDetails.Where(model => model.EmployeeID == id).FirstOrDefault();
            return View(row);
        }

        [HttpPost]
        public ActionResult Edit(EmployeeDetail e)
        {
            if (ModelState.IsValid == true)
            {
                tm.Entry(e).State = EntityState.Modified;
                int a = tm.SaveChanges();
                if (a > 0)
                {
                    TempData["UpdateMessage"] = "<script>alert('Updated !!')</script>";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["UpdateMessage"] = "<script>alert('Not Updated !!')</script>";
                }
            }
            return View();
        }
        public ActionResult Delete(int id)
        {
            if (id > 0)
            {
                var DeleteRow = tm.EmployeeDetails.Where(model => model.EmployeeID == id).FirstOrDefault();
                if(DeleteRow != null)
                {
                    tm.Entry(DeleteRow).State = EntityState.Deleted;
                    int a = tm.SaveChanges();
                    if (a > 0)
                    {
                        TempData["DeleteMessage"] = "<script>alert('Deleted !!')</script>";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["DeleteMessage"] = "<script>alert('Not Deleted !!')</script>";
                    }
                }
            }
            return View();
        }

        //[HttpPost]
        //public ActionResult Delete(EmployeeDetail e)
        //{
        //    tm.Entry(e).State = EntityState.Deleted;
        //    int a = tm.SaveChanges();
        //    if (a > 0)
        //    {
        //        TempData["DeleteMessage"] = "<script>alert('Deleted !!')</script>";
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        TempData["DeleteMessage"] = "<script>alert('Not Deleted !!')</script>";
        //    }
        //    return View();
        //}

        public ActionResult Details(int id)
        {
            var row = tm.EmployeeDetails.Where(model => model.EmployeeID == id).FirstOrDefault();
            return View(row);
        }
    }
}