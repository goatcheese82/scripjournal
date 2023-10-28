using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ScriptureJournal.Data;
using ScriptureJournal.Models;

namespace ScriptureJournal.Pages.JournalEntries
{
    public class EditModel : PageModel
    {
        private readonly ScriptureJournal.Data.ScriptureJournalContext _context;

        public EditModel(ScriptureJournal.Data.ScriptureJournalContext context)
        {
            _context = context;
        }

        [BindProperty]
        public JournalEntry JournalEntry { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.JournalEntry == null)
            {
                return NotFound();
            }

            var journalentry =  await _context.JournalEntry.FirstOrDefaultAsync(m => m.ID == id);
            if (journalentry == null)
            {
                return NotFound();
            }
            JournalEntry = journalentry;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(JournalEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JournalEntryExists(JournalEntry.ID))
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

        private bool JournalEntryExists(int id)
        {
          return (_context.JournalEntry?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
