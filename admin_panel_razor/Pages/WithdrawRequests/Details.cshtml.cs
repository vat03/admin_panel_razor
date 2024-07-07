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
    public class DetailsModel : PageModel
    {
        private readonly admin_panel_razor.Data.ApplicationDbContext _context;

        public DetailsModel(admin_panel_razor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
