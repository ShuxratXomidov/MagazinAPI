using MagazinAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MagazinAPI.Models;

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
        [Route("")]  //api/Product
        public List<Product> Read()
        {
            List<Product> product = dbContext.Products.ToList();

            return product;
        }

        [HttpPut]
        [Route("{id}")]  //api/Product/id
        public string Update(int id)
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
        public string Delete(int id)
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
