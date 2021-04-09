using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lab4new.Models;

namespace Lab4new.Pages.Cards
{
    public class DetailsModel : PageModel
    {
        private readonly Lab4new.Models.MtgContext _context;

        public DetailsModel(Lab4new.Models.MtgContext context)
        {
            _context = context;
        }

        public Card Card { get; set; }

        public async Task<IActionResult> OnGetAsync(uint? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Card = await _context.Cards.FirstOrDefaultAsync(m => m.CardID == id);

            if (Card == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
