//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using Microsoft.EntityFrameworkCore;
//using admin_panel_razor.Data;
//using admin_panel_razor.Models;

//namespace admin_panel_razor.Pages.ShopCoins
//{
//    public class DeleteModel : PageModel
//    {
//        private readonly admin_panel_razor.Data.ApplicationDbContext _context;

//        public DeleteModel(admin_panel_razor.Data.ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        [BindProperty]
//        public ShopCoin ShopCoin { get; set; } = default!;

//        public async Task<IActionResult> OnGetAsync(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var shopcoin = await _context.ShopCoins.FirstOrDefaultAsync(m => m.Id == id);

//            if (shopcoin == null)
//            {
//                return NotFound();
//            }
//            else
//            {
//                ShopCoin = shopcoin;
//            }
//            return Page();
//        }

//        public async Task<IActionResult> OnPostAsync(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var shopcoin = await _context.ShopCoins.FindAsync(id);
//            if (shopcoin != null)
//            {
//                ShopCoin = shopcoin;
//                _context.ShopCoins.Remove(ShopCoin);
//                await _context.SaveChangesAsync();
//            }

//            return RedirectToPage("./Index");
//        }
//    }
//}

















using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using admin_panel_razor.Data;
using admin_panel_razor.Models;
using System.Threading.Tasks;

namespace admin_panel_razor.Pages.ShopCoins
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ShopCoin ShopCoin { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            ShopCoin = await _context.ShopCoins.FindAsync(id);
            if (ShopCoin == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            ShopCoin = await _context.ShopCoins.FindAsync(id);
            if (ShopCoin != null)
            {
                _context.ShopCoins.Remove(ShopCoin);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("Index");
        }
    }
}

