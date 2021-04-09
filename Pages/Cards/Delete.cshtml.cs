using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lab4new.Models;
using Microsoft.AspNetCore.Identity;

namespace Lab4new.Pages.Cards
{
    public class DeleteModel : PageModel
    {
        private readonly Lab4new.Models.MtgContext _context;
        private UserManager<TcgUser> _userManager;
        public DeleteModel(Lab4new.Models.MtgContext context, UserManager<TcgUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(uint? id)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (id == null)
                {
                    return NotFound();
                }

                Card = await _context.Cards.FindAsync(id);

                if (Card != null)
                {
                    _context.Cards.Remove(Card);
                    await _context.SaveChangesAsync();
                }

                return RedirectToPage("./Index");
            }
            else
            {
                ViewData["error"] = "Not Logged in!";
                return Page();
            }
        }
    }
}
