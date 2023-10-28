using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ScriptureJournal.Data;
using ScriptureJournal.Models;

namespace ScriptureJournal.Pages.JournalEntries
{
    public class DetailsModel : PageModel
    {
        private readonly ScriptureJournal.Data.ScriptureJournalContext _context;

        public DetailsModel(ScriptureJournal.Data.ScriptureJournalContext context)
        {
            _context = context;
        }

      public JournalEntry JournalEntry { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.JournalEntry == null)
            {
                return NotFound();
            }

            var journalentry = await _context.JournalEntry.FirstOrDefaultAsync(m => m.ID == id);
            if (journalentry == null)
            {
                return NotFound();
            }
            else 
            {
                JournalEntry = journalentry;
            }
            return Page();
        }
    }
}
