using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using admin_panel_razor.Data;
using admin_panel_razor.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace admin_panel_razor.Pages
{
    public class AboutUsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public AboutUsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public admin_panel_razor.Models.AboutUs AboutUs { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            AboutUs = await _context.AboutUs.FirstOrDefaultAsync();

            if (AboutUs == null)
            {
                AboutUs = new admin_panel_razor.Models.AboutUs();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var existingTerms = await _context.AboutUs.FirstOrDefaultAsync();

            if (existingTerms != null)
            {
                existingTerms.Title = AboutUs.Title;
                existingTerms.Slug = AboutUs.Slug;
                existingTerms.Description = AboutUs.Description;

                _context.AboutUs.Update(existingTerms);
            }
            else
            {
                _context.AboutUs.Add(AboutUs);
            }

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
