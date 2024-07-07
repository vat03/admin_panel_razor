using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using admin_panel_razor.Data;
using admin_panel_razor.Models;

namespace admin_panel_razor.Pages.TermsAndConditions
{
    public class DeleteModel : PageModel
    {
        private readonly admin_panel_razor.Data.ApplicationDbContext _context;

        public DeleteModel(admin_panel_razor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public admin_panel_razor.Models.TermsAndConditions TermsAndConditions { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var termsandconditions = await _context.TermsAndConditions.FirstOrDefaultAsync(m => m.Id == id);

            if (termsandconditions == null)
            {
                return NotFound();
            }
            else
            {
                TermsAndConditions = termsandconditions;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var termsandconditions = await _context.TermsAndConditions.FindAsync(id);
            if (termsandconditions != null)
            {
                TermsAndConditions = termsandconditions;
                _context.TermsAndConditions.Remove(TermsAndConditions);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
