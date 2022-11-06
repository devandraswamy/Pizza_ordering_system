using DpizzaProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace DpizzaProject.Controllers
{
    public class OrderController : Controller
    {
        private readonly DpizzadbContext db; //connecting db to controller
        public OrderController(DpizzadbContext db)
        {
            this.db = db;
        }

        public IActionResult orderpage(int id)   //orderpage where user can do order
        {
            PizzaDataTb pid = db.PizzaDataTbs.Find(id);
            if (pid == null)
            {
                return NotFound();
            }
            else
            {
                return View(pid);

            }
        }
        [HttpPost]
        public IActionResult orderpage(int id, string name, int quantity, string toppings, string noofslice, decimal pprice, string slice, string address)
        {
            PizzaDataTb findid = db.PizzaDataTbs.Find(id);
            if (findid == null)
            {
                return NotFound();
            }
            else
            {
                ViewBag.id = findid.PizzaId;
                TempData["id"] = findid.PizzaId;
                var totalprice = Convert.ToDecimal(findid.PizzaPrice * quantity);
                db.Orderdatatales.Add(new Orderdatatale
                {
                    Pizzaid = Convert.ToInt32(ViewBag.id),
                    Quantity = quantity,
                    Customername = name,
                    Dateoforder = DateTime.Now,
                    Price = totalprice,
                    Toppins = toppings,
                    Slices = slice,
                    CustomerAddress = address

                });

                db.SaveChanges();

                return RedirectToAction("orderstaus" , "OrderStatus");
            }
        }
    }
}
