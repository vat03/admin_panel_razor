using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using admin_panel_razor.Data;
using admin_panel_razor.Models;

namespace admin_panel_razor.Pages.WithdrawRequests
{
    public class DeleteModel : PageModel
    {
        private readonly admin_panel_razor.Data.ApplicationDbContext _context;

        public DeleteModel(admin_panel_razor.Data.ApplicationDbContext context)
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

            var withdrawrequest = await _context.WithdrawRequests.FirstOrDefaultAsync(m => m.RequestId == id);

            if (withdrawrequest == null)
            {
                return NotFound();
            }
            else
            {
                WithdrawRequest = withdrawrequest;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var withdrawrequest = await _context.WithdrawRequests.FindAsync(id);
            if (withdrawrequest != null)
            {
                WithdrawRequest = withdrawrequest;
                _context.WithdrawRequests.Remove(WithdrawRequest);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
