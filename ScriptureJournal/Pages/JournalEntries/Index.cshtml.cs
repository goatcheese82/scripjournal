using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ScriptureJournal.Data;
using ScriptureJournal.Models;

namespace ScriptureJournal.Pages.JournalEntries
{
    public class IndexModel : PageModel
    {
        private readonly ScriptureJournal.Data.ScriptureJournalContext _context;

        public IndexModel(ScriptureJournal.Data.ScriptureJournalContext context)
        {
            _context = context;
        }

        public IList<JournalEntry> JournalEntry { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Books { get; set; }
        [BindProperty(SupportsGet = true)]
        public string JournalEntryBook { get; set; }


        public async Task OnGetAsync(string sortOrder)
        {
            ViewData["DateSortParam"] = String.IsNullOrEmpty(sortOrder) ? "date_desc" : "";
            ViewData["BookSortParam"] = sortOrder == "book" ? "book_desc" : "book";

            IQueryable<string> bookQuery = from e in _context.JournalEntry
                                           orderby e.Book
                                           select e.Book;

            IQueryable<DateTime> dateQuery = from e in _context.JournalEntry
                                             orderby e.Date
                                             select e.Date;

            var entries = from e in _context.JournalEntry
                          select e;

            switch (sortOrder)
            {
                case "date_desc":
                    entries = entries.OrderByDescending(e => e.Date);
                    break;
                case "book":
                    entries = entries.OrderBy(e => e.Book);
                    break;
                case "book_desc":
                    entries = entries.OrderByDescending(e => e.Book);
                    break;
                default:
                    entries = entries.OrderBy(e => e.Book);
                    break;
            }

            if (!string.IsNullOrEmpty(SearchString))
            {
                entries = entries.Where(s => s.Note.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(JournalEntryBook))
            {
                entries = entries.Where(x => x.Book == JournalEntryBook);
            }
            Books = new SelectList(await bookQuery.Distinct().ToListAsync());
            JournalEntry = await entries.ToListAsync();
        }
    }
}
