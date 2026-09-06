using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using URLShorteningService.Data;
using URLShorteningService.DTOs;
using URLShorteningService.Models;
using URLShorteningService.Services;

namespace URLShorteningService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlsController : ControllerBase
    {
        private readonly AppDbContext db;

        public UrlsController(AppDbContext appDbContext)
        {
            db = appDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddUrl(CreateUrlRequest urlRequest)
        {
            bool isValid = Uri.TryCreate(urlRequest.OriginalUrl, UriKind.Absolute, out var uriResult)
    && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

            if (!isValid)
            {
                return BadRequest();
            }

            string shortCode = string.Empty;

            var url = await db.Urls.Where(u => u.OriginalUrl == urlRequest.OriginalUrl).FirstOrDefaultAsync();

            if (url == null)
            {
                do
                {
                    shortCode = ShortCodeGenerator.Generate();
                }
                while (await db.Urls.AnyAsync(u => u.ShortCode == shortCode));

                Url newUrl = new Url
                {
                    OriginalUrl = urlRequest.OriginalUrl,
                    ShortCode = shortCode,
                    CreatedDate = DateTime.UtcNow
                };

                await db.AddAsync(newUrl);
                await db.SaveChangesAsync();
                url = newUrl;
            }

            return Ok($"{Request.Scheme}://{Request.Host}/{url.ShortCode}");
        }

        [HttpGet("/{shortCode}")]
        public async Task<IActionResult> RedirectToOriginal(string shortCode)
        {
            var url = await db.Urls.FirstOrDefaultAsync(s => s.ShortCode == shortCode);

            if (url == null) return NotFound();

            return Redirect(url.OriginalUrl);

        }
    }
}
