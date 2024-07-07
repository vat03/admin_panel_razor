using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using admin_panel_razor.Data;
using admin_panel_razor.Models;

namespace admin_panel_razor.Pages.WithdrawRequests
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<WithdrawRequest> WithdrawRequest { get; set; }

        public async Task OnGetAsync()
        {
            WithdrawRequest = await _context.WithdrawRequests.ToListAsync();
        }
    }
}

