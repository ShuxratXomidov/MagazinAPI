using MagazinAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MagazinAPI.Models;
using Bogus;

namespace MagazinAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DataContext dbContext;

        public ProductController(DataContext dataContext)
        {
            this.dbContext = dataContext;
        }

        [HttpPost]
        [Route("")]  //api/Product
        public Product Create()
        {
            Product product = new Product();
            product.Title = "Choy";

            dbContext.Products.Add(product);
            dbContext.SaveChanges();

            return product;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            //create fake product

            var faker = new Faker<Product> ("en");
            .RuleFor(p => p.Name, f = f.Commerce.Product())
        }


        [HttpGet]
        [Route("")]  //api/Product
        public List<Product> Read()
        {
            List<Product> product = dbContext.Products.ToList();

            return product;
        }

        [HttpPut]
        [Route("{id}")]  //api/Product/id
        public string Update([FromRoute] int id)
        {
            var product = dbContext.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return id + " Topilmadi!!!";
            }

            product.Title = "Novot";
            dbContext.SaveChanges();

            return "O'zgartirildi!!!";
        }

        [HttpDelete]
        [Route("{id}")]  //api/Product/id
        public string Delete([FromRoute] int id)
        {
            var product = dbContext.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return id + " Topilmadi!!!";
            }

            dbContext.Remove(product);
            dbContext.SaveChanges();

            return "O'chirildi!!!";
        }
    }
}
