using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using admin_panel_razor.Data;
using admin_panel_razor.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace admin_panel_razor.Pages.LogoSettings
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public LogoSetting LogoSetting { get; set; }

        [BindProperty]
        public IFormFile HeaderLogoFile { get; set; }
        [BindProperty]
        public IFormFile FooterLogoFile { get; set; }
        [BindProperty]
        public IFormFile FaviconFile { get; set; }

        public IndexModel(ApplicationDbContext context, IWebHostEnvironment environment, ILogger<IndexModel> logger)
        {
            _context = context;
            _environment = environment;
            _logger = logger;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            LogoSetting = await _context.LogoSettings.FirstOrDefaultAsync();

            if (LogoSetting == null)
            {
                LogoSetting = new LogoSetting();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var settingsInDb = await _context.LogoSettings.FirstOrDefaultAsync();
            if (settingsInDb == null)
            {
                settingsInDb = new LogoSetting();
                _context.LogoSettings.Add(settingsInDb);
            }

            if (HeaderLogoFile != null)
            {
                var headerLogoPath = Path.Combine(_environment.WebRootPath, "uploads", HeaderLogoFile.FileName);
                using (var stream = new FileStream(headerLogoPath, FileMode.Create))
                {
                    await HeaderLogoFile.CopyToAsync(stream);
                }
                settingsInDb.HeaderLogo = "/uploads/" + HeaderLogoFile.FileName;
            }

            if (FooterLogoFile != null)
            {
                var footerLogoPath = Path.Combine(_environment.WebRootPath, "uploads", FooterLogoFile.FileName);
                using (var stream = new FileStream(footerLogoPath, FileMode.Create))
                {
                    await FooterLogoFile.CopyToAsync(stream);
                }
                settingsInDb.FooterLogo = "/uploads/" + FooterLogoFile.FileName;
            }

            if (FaviconFile != null)
            {
                var faviconPath = Path.Combine(_environment.WebRootPath, "uploads", FaviconFile.FileName);
                using (var stream = new FileStream(faviconPath, FileMode.Create))
                {
                    await FaviconFile.CopyToAsync(stream);
                }
                settingsInDb.Favicon = "/uploads/" + FaviconFile.FileName;
            }

            await _context.SaveChangesAsync();

            return RedirectToPage();
        }
    }
}

