using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ScriptureJournal.Data;
using ScriptureJournal.Models;

namespace ScriptureJournal.Pages.JournalEntries
{
    public class CreateModel : PageModel
    {
        private readonly ScriptureJournal.Data.ScriptureJournalContext _context;

        public CreateModel(ScriptureJournal.Data.ScriptureJournalContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public JournalEntry JournalEntry { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.JournalEntry == null || JournalEntry == null)
            {
                return Page();
            }

            _context.JournalEntry.Add(JournalEntry);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
