using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using admin_panel_razor.Data;
using admin_panel_razor.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace admin_panel_razor.Pages
{
    public class PrivacyPoliciesModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public PrivacyPoliciesModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public admin_panel_razor.Models.PrivacyPolicy PrivacyPolicy { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            PrivacyPolicy = await _context.privacyPolicies.FirstOrDefaultAsync();

            if (PrivacyPolicy == null)
            {
                PrivacyPolicy = new admin_panel_razor.Models.PrivacyPolicy();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var existingTerms = await _context.privacyPolicies.FirstOrDefaultAsync();

            if (existingTerms != null)
            {
                existingTerms.Title = PrivacyPolicy.Title;
                existingTerms.Slug = PrivacyPolicy.Slug;
                existingTerms.Description = PrivacyPolicy.Description;

                _context.privacyPolicies.Update(existingTerms);
            }
            else
            {
                _context.privacyPolicies.Add(PrivacyPolicy);
            }

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
