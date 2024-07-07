using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using admin_panel_razor.Data;
using admin_panel_razor.Models;

namespace admin_panel_razor.Pages.BidValues
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<BidValue> BidValueList { get; set; }

        [BindProperty]
        public int NewBidValue { get; set; }

        public async Task OnGetAsync()
        {
            BidValueList = await _context.BidValues.ToListAsync();
        }

        public async Task<IActionResult> OnPostCreateAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var bidValue = new BidValue { Value = NewBidValue };
            _context.BidValues.Add(bidValue);
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }
    }
}
