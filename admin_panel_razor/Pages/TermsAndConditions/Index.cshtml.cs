using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using admin_panel_razor.Data;
using admin_panel_razor.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace admin_panel_razor.Pages
{
    public class TermsAndConditionsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public TermsAndConditionsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public admin_panel_razor.Models.TermsAndConditions TermsAndConditions { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            TermsAndConditions = await _context.TermsAndConditions.FirstOrDefaultAsync();

            if (TermsAndConditions == null)
            {
                TermsAndConditions = new admin_panel_razor.Models.TermsAndConditions();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var existingTerms = await _context.TermsAndConditions.FirstOrDefaultAsync();

            if (existingTerms != null)
            {
                existingTerms.Title = TermsAndConditions.Title;
                existingTerms.Slug = TermsAndConditions.Slug;
                existingTerms.Description = TermsAndConditions.Description;

                _context.TermsAndConditions.Update(existingTerms);
            }
            else
            {
                _context.TermsAndConditions.Add(TermsAndConditions);
            }

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

