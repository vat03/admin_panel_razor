using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using admin_panel_razor.Data;
using admin_panel_razor.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace admin_panel_razor.Pages.ShopCoins
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ShopCoin ShopCoin { get; set; }
        public IList<ShopCoin> ShopCoinList { get; set; }

        public async Task OnGetAsync()
        {
            ShopCoinList = await _context.ShopCoins.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ShopCoins.Add(ShopCoin);
            await _context.SaveChangesAsync();
            return RedirectToPage();
        }
    }
}

