using Microsoft.AspNetCore.Mvc;
using URL_Shortener.Data;
using URL_Shortener.Model.Request;
using URL_Shortener.Model.Url;
using URL_Shortener.Util;

namespace URL_Shortener.Controllers
{
    public class UrlController : Controller
    {

        private readonly UrlContext _context;

        public UrlController(UrlContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("api/shorten")]
        public IActionResult Shorten([FromBody] UrlRequest request)
        {

            if (string.IsNullOrEmpty(request.Url))
                return BadRequest("URL cannot be empty.");

            if (!request.Url.StartsWith("http://") && !request.Url.StartsWith("https://"))
            {
                request.Url = "http://" + request.Url;
            }

            var existing = _context.Urls.FirstOrDefault(u => u.OriginalUrl == request.Url);
            if (existing != null)
            {
                return Ok(new
                {
                    originalUrl = request.Url,
                    shortUrl = $"http://localhost:5080/{existing.ShortUrl}"
                });
            }

            var newUrl = new Url
            {
                OriginalUrl = request.Url
            };

            _context.Urls.Add(newUrl);
            _context.SaveChanges();

            newUrl.ShortUrl = CodeGenerator.Encode(newUrl.Id);
            _context.SaveChanges();

            return Ok(new
            {
                originalUrl = request.Url,
                shortUrl = $"http://localhost:5080/{newUrl.ShortUrl}"
            });

        }

        [HttpGet]
        [Route("{code}")]
        public IActionResult GoToOriginalUrl(string code)
        {
            var id = CodeGenerator.Decode(code);
            var link = _context.Urls.FirstOrDefault(l => l.Id == id);
            if (link == null)
                return NotFound("Url not founded");

            return Redirect(link.OriginalUrl);
        }
    }
}
