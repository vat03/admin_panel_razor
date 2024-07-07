//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using admin_panel_razor.Data;
using admin_panel_razor.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace admin_panel_razor.Pages.GeneralSettings
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        [BindProperty]
        public GeneralSetting GeneralSettings { get; set; }

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            GeneralSettings = await _context.GeneralSettings.FirstAsync();

            // Ensure GeneralSettings is not null
            if (GeneralSettings == null)
            {
                GeneralSettings = new GeneralSetting();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Check if GeneralSettings exists in the database
            var settingsInDb = await _context.GeneralSettings.FirstOrDefaultAsync();
            if (settingsInDb == null)
            {
                _context.GeneralSettings.Add(GeneralSettings);
            }
            else
            {
                settingsInDb.WebsiteName = GeneralSettings.WebsiteName;
                settingsInDb.WebsiteURL = GeneralSettings.WebsiteURL;
                settingsInDb.WebsiteTagline = GeneralSettings.WebsiteTagline;
                settingsInDb.WebsiteKeyword = GeneralSettings.WebsiteKeyword;
                settingsInDb.WebsiteDescription = GeneralSettings.WebsiteDescription;
                settingsInDb.FooterCopyright = GeneralSettings.FooterCopyright;
                

                _context.Attach(settingsInDb).State = EntityState.Modified;
            }

            await _context.SaveChangesAsync();
            return RedirectToPage();
        }
    }
}
