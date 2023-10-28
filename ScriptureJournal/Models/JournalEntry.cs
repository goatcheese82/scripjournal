using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ScriptureJournal.Models
{
    public class JournalEntry
    {
        public int ID { get; set; }
        public DateTime Date = DateTime.Now;
        [StringLength(60)]
        [Required]
        public string? Book { get; set; }
        [Range(1, 178)]
        [Required]
        public int? Chapter { get; set; }
        [Range(1,260)]
        [Required]
        public int? Verse { get; set; }
        public string? Note { get; set; }
    }
}
