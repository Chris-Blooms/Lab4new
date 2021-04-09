using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab4new.Models;
using Microsoft.AspNetCore.Identity;

namespace Lab4new.Pages.Cards
{
    public class EditModel : PageModel
    {
        private readonly Lab4new.Models.MtgContext _context;
        private UserManager<TcgUser> _userManager;
        public EditModel(Lab4new.Models.MtgContext context, UserManager<TcgUser> userManager)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }

                _context.Attach(Card).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CardExists(Card.CardID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToPage("./Index");
            }
            else
            {
                ViewData["error"] = "Not Logged in!";
                return Page();
            }
        }

        private bool CardExists(uint id)
        {
            return _context.Cards.Any(e => e.CardID == id);
        }
    }
}
