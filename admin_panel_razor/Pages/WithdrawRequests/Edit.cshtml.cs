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

namespace admin_panel_razor.Pages.WithdrawRequests
{
    public class EditModel : PageModel
    {
        private readonly admin_panel_razor.Data.ApplicationDbContext _context;

        public EditModel(admin_panel_razor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public WithdrawRequest WithdrawRequest { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var withdrawrequest =  await _context.WithdrawRequests.FirstOrDefaultAsync(m => m.RequestId == id);
            if (withdrawrequest == null)
            {
                return NotFound();
            }
            WithdrawRequest = withdrawrequest;
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

            _context.Attach(WithdrawRequest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WithdrawRequestExists(WithdrawRequest.RequestId))
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

        private bool WithdrawRequestExists(int id)
        {
            return _context.WithdrawRequests.Any(e => e.RequestId == id);
        }
    }
}
