using Microsoft.AspNetCore.Mvc;

namespace ShoppingCart.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShoppingController : ControllerBase
    {
        [HttpGet]
        public void Index()
        {
           // return View();
        }
    }
}
