using DpizzaProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace DpizzaProject.Controllers
{
    public class OrderStatusController : Controller
    {
        private readonly DpizzadbContext db; //connecting db to controller

        public OrderStatusController(DpizzadbContext db)
        {
            this.db = db;
        }

        public IActionResult orderstaus()  //order status 
        {
            var p = DateTime.Now;
            var p2 = p.AddMinutes(-3);          //using time span
            var query = from i in db.Orderdatatales
                        where i.Dateoforder > p2
                        select i;

            if (query == null)
            {
                return NotFound();
            }
            else
            {
                return View(query.ToList());

            }

        }
    }
}
