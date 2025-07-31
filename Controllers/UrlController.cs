using Microsoft.AspNetCore.Mvc;
using URL_Shortener.Model;

namespace URL_Shortener.Controllers
{
    public class UrlController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("api/shorten")]
        public IActionResult Shorten([FromBody] UrlRequest request)
        {
            Console.WriteLine(request.Url);

            if (string.IsNullOrEmpty(request.Url))
            {
                return BadRequest("URL cannot be empty.");
            }

            return Ok(new
            {
                originalUrl = request.Url,
                shortUrl = "test"
            });
        }
    }
}
