using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using admin_panel_razor.Data;
using admin_panel_razor.Models;

namespace admin_panel_razor.Pages.ContactUs
{
    public class DeleteModel : PageModel
    {
        private readonly admin_panel_razor.Data.ApplicationDbContext _context;

        public DeleteModel(admin_panel_razor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public admin_panel_razor.Models.ContactUs ContactUs { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactus = await _context.ContactUs.FirstOrDefaultAsync(m => m.Id == id);

            if (contactus == null)
            {
                return NotFound();
            }
            else
            {
                ContactUs = contactus;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactus = await _context.ContactUs.FindAsync(id);
            if (contactus != null)
            {
                ContactUs = contactus;
                _context.ContactUs.Remove(ContactUs);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
