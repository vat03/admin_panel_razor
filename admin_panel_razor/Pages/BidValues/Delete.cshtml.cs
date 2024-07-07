//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using Microsoft.EntityFrameworkCore;
//using admin_panel_razor.Data;
//using admin_panel_razor.Models;

//namespace admin_panel_razor.Pages.BidValues
//{
//    public class DeleteModel : PageModel
//    {
//        private readonly admin_panel_razor.Data.ApplicationDbContext _context;

//        public DeleteModel(admin_panel_razor.Data.ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        [BindProperty]
//        public BidValue BidValue { get; set; } = default!;

//        public async Task<IActionResult> OnGetAsync(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var bidvalue = await _context.BidValues.FirstOrDefaultAsync(m => m.Id == id);

//            if (bidvalue == null)
//            {
//                return NotFound();
//            }
//            else
//            {
//                BidValue = bidvalue;
//            }
//            return Page();
//        }

//        public async Task<IActionResult> OnPostAsync(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var bidvalue = await _context.BidValues.FindAsync(id);
//            if (bidvalue != null)
//            {
//                BidValue = bidvalue;
//                _context.BidValues.Remove(BidValue);
//                await _context.SaveChangesAsync();
//            }

//            return RedirectToPage("./Index");
//        }
//    }
//}














using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using admin_panel_razor.Data;
using admin_panel_razor.Models;

namespace admin_panel_razor.Pages.BidValues
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BidValue BidValue { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BidValue = await _context.BidValues.FirstOrDefaultAsync(m => m.Id == id);

            if (BidValue == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BidValue = await _context.BidValues.FindAsync(id);

            if (BidValue != null)
            {
                _context.BidValues.Remove(BidValue);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
