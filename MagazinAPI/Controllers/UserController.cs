using MagazinAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MagazinAPI.Models;


namespace MagazinAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext dbContext;

        public UserController(DataContext dataContext)
        {
            this.dbContext = dataContext;
        }

        [HttpPost]
        [Route("")]  //api/User
        public string Create()
        {
            User user = new User();
            user.FirstName = "Shuxrat";
            user.LastName = "Xomidov";
            user.Age = 31;

            dbContext.Users.Add(user);
            dbContext.SaveChanges();

            return "Ok";
        }

        [HttpGet]
        [Route("")]  //api/User
        public List<User> Get()
        {
            List<User> users = dbContext.Users.ToList();

            return users;
        }

        [HttpPut]
        [Route("{id}")]
        public string Update(int id)
        {
            var user = dbContext.Users.FirstOrDefault(user => user.Id == id);
            if (user == null)
            {
                return " User with id " + id + " not found ";
            }

            user.FirstName = "Dilshod";
            user.LastName = "Sayidov";

            dbContext.SaveChanges();
            return "O`zgartirildi!!!";
        }

        [HttpDelete]
        [Route("{id}")]
        public string Delete(int id)
        {
            var user = dbContext.Users.FirstOrDefault(user => user.Id == id);

            if(user == null)
            {
                return "topilmadi!!!";
            }

            dbContext.Remove(user);
            dbContext.SaveChanges();

            return "O'chirildi!!!";
        }
    }
}
