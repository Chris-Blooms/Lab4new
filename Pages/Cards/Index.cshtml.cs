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
    public class IndexModel : PageModel
    {
        private readonly Lab4new.Models.MtgContext _context;

        public IndexModel(Lab4new.Models.MtgContext context)
        {
            _context = context;
        }

        public IList<Card> Card { get;set; }

        public async Task OnGetAsync()
        {
            Card = await _context.Cards.ToListAsync();
        }
    }
}
