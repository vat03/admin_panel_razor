using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using admin_panel_razor.Data;
using admin_panel_razor.Models;

namespace admin_panel_razor.Pages.Transactions
{
    public class IndexModel : PageModel
    {
        private readonly admin_panel_razor.Data.ApplicationDbContext _context;

        public IndexModel(admin_panel_razor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Transaction> Transaction { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Transaction = await _context.Transactions.ToListAsync();
        }
    }
}
