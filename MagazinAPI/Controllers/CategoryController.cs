using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MagazinAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    [HttpPost]
    [Route("a-test/{b}")]
    public int ATest([FromRoute]int b, [FromQuery] int c, [FromBody] int x)
    { 
        return b + c + x;
    }

    [HttpPost]
    [Route("{a}/{word}")]
    public string BTest([FromRoute] int a, [FromRoute] string word, [FromQuery] int q)
    {
        return a+q+" "+word;
    }
}
