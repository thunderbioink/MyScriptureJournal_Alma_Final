using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyScriptureJournal_Alma.Models
{
    public class Scripture
    {

        public int ID { get; set; }

        [Display(Name = "Entry Title")]
        public string EntryTitle { get; set; }

        [Display(Name = "Date Added")]
        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; }
        public string Book { get; set; }
        //public decimal Price { get; set; }
    }
}
