using DpizzaProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace DpizzaProject.Controllers
{
    public class PizzaController : Controller
    {
        private readonly DpizzadbContext db; //connecting db to controller
        public PizzaController(DpizzadbContext db)
        {
            this.db = db;
        }

        public IActionResult HomePage()  //menu page
        {
            return View(db.PizzaDataTbs.ToList());
        }

        [HttpPost]
        public IActionResult HomePage(string veg, string nonveg) //sorting fuction
        {
            var filter = from m in db.PizzaDataTbs
                         select m;
            if (!String.IsNullOrEmpty(veg) || !String.IsNullOrEmpty(nonveg))
            {
                filter = filter.Where(s => s.VegNon!.Equals(veg));
                filter.Where(d2 => d2.VegNon!.Equals(nonveg));

            }
            return View(filter.ToList());


        }

     


        
    }
}

//Scaffold-DbContext "Server=DESKTOP-DMQ8EIK\SQLEXPRESS;Database=Dpizzadb;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -force
