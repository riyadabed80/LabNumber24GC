using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LabNumber24GC.Models;

namespace LabNumber24GC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ItemAdmin()
        {
            CoffeeShopDBEntities ORM = new CoffeeShopDBEntities();

            ViewBag.ItemList = ORM.Items.ToList();

            return View();


        }

        public ActionResult DeleteItem(string Name)

        {
            CoffeeShopDBEntities ORM = new CoffeeShopDBEntities();

            Item Found = ORM.Items.Find(Name);
            if (Found != null)
            {
                ORM.Items.Remove(Found);
                ORM.SaveChanges();

                return RedirectToAction("ItemAdmin");
            }
            else
            {
                ViewBag.ErrorMessage = "Oops! Something wrong.";
                return View("Error");


            }




        }

        public ActionResult AddItem()
        {
            return View();
        }

        public ActionResult AddNewItem(Item newItem)
        {
            CoffeeShopDBEntities ORM = new CoffeeShopDBEntities();

            ORM.Items.Add(newItem);

            ORM.SaveChanges();
            //ViewBag.ItemList = ORM.Items.ToList();
            return View(ORM.Items.ToList());




        }

        public ActionResult EditItem(Item updatedItem)
        {
            CoffeeShopDBEntities ORM = new CoffeeShopDBEntities();

            Item OldItemRecord = ORM.Items.Find(updatedItem.Name);

            if (OldItemRecord !=null && ModelState.IsValid)
            {
                OldItemRecord.Name = updatedItem.Name;
                OldItemRecord.Description = updatedItem.Description;
                OldItemRecord.Quantity = updatedItem.Quantity;
                OldItemRecord.Price = updatedItem.Price;

                ORM.Entry(OldItemRecord).State = System.Data.Entity.EntityState.Modified;
                ORM.SaveChanges();
                return RedirectToAction("ItemAdmin");
            }
            else
            {
                ViewBag.ErrorMessage = "Oops! Something went wrong.";
                    return View("Error");
            }

            


        }

        public ActionResult ShowItemDetails(string Name)
        {
            CoffeeShopDBEntities ORM = new CoffeeShopDBEntities();

            Item Found = ORM.Items.Find(Name);

            if(Found != null)
            {
                return View(Found);

            }
            else
            {
                ViewBag.ErrorMessage = "Item not found!";
                return View("Error");

            }


        }



       

    }
}
