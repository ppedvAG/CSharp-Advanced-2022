using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PizzaService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        static List<Pizza> pizzaDb = new List<Pizza>();

        static PizzaController()
        {
            pizzaDb.Add(new Pizza() { Id = 1, Name = "Salami", Price = 9.5m });
            pizzaDb.Add(new Pizza() { Id = 2, Name = "Ham", Price = 9.3m });
            pizzaDb.Add(new Pizza() { Id = 3, Name = "Fishfingers", Price = 12.5m });
        }

        [HttpPut]
        public void Update(Pizza pizza)
        {
            Delete(pizza.Id);
            pizzaDb.Add(pizza);
        }


        [HttpDelete()]
        public void Delete(int id)
        {
            pizzaDb.Remove(pizzaDb.First(x => x.Id == id));
        }


        [HttpPost()]
        public void Add(Pizza pizza)
        {
            pizzaDb.Add(pizza);
        }

        [HttpGet()]
        public IEnumerable<Pizza> Get()
        {
            return pizzaDb;
        }
    }

    public class Pizza
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}
