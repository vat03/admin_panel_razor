using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using admin_panel_razor.Data;
using admin_panel_razor.Models;

namespace admin_panel_razor.Pages.TermsAndConditions
{
    public class EditModel : PageModel
    {
        private readonly admin_panel_razor.Data.ApplicationDbContext _context;

        public EditModel(admin_panel_razor.Data.ApplicationDbContext context)
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

            var termsandconditions =  await _context.TermsAndConditions.FirstOrDefaultAsync(m => m.Id == id);
            if (termsandconditions == null)
            {
                return NotFound();
            }
            TermsAndConditions = termsandconditions;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TermsAndConditions).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TermsAndConditionsExists(TermsAndConditions.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TermsAndConditionsExists(int id)
        {
            return _context.TermsAndConditions.Any(e => e.Id == id);
        }
    }
}
