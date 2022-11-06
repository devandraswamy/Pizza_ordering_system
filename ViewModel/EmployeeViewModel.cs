using DpizzaProject.Models;

namespace DpizzaProject.ViewModel
{
    public class EmployeeViewModel
    {
        public IEnumerable<PizzaDataTb> pizzaData { get; set; }
        public IEnumerable<Orderdatatale> orderdatatale { get; set; }
    }
}
