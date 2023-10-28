using Microsoft.EntityFrameworkCore;
using ScriptureJournal.Data;

namespace ScriptureJournal.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new ScriptureJournalContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<ScriptureJournalContext>>()))
        {
            if (context == null || context.JournalEntry == null)
            {
                throw new ArgumentNullException("Null ScriptureJournalContext");
            }

            // Look for any movies.
            if (context.JournalEntry.Any())
            {
                return;   // DB has been seeded
            }

            context.JournalEntry.AddRange(
                    new JournalEntry
                    {
                        Book = "1 Nephi",
                        Chapter = 3,
                        Verse = 7,
                        Note = "I will go and do!"
                    },

                    new JournalEntry
                    {
                        Book = "Moroni",
                        Chapter = 10,
                        Verse = 5,
                        Note = "Seek truth",
                    },

                    new JournalEntry
                    {
                        Book = "Mosiah",
                        Chapter = 3,
                        Verse = 19,
                        Note = "The natural man",
                    },

                    new JournalEntry
                    {
                        Book = "2 Nephi",
                        Chapter = 2,
                        Verse = 25,
                        Note = "Adam ",
                    }
            );
            context.SaveChanges();
        }
    }
}