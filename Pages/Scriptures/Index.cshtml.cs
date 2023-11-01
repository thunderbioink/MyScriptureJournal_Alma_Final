using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyScriptureJournal_Alma.Data;
using MyScriptureJournal_Alma.Models;

namespace MyScriptureJournal_Alma.Pages.Scriptures
{
    public class IndexModel : PageModel
    {
        private readonly MyScriptureJournal_Alma.Data.MyScriptureJournal_AlmaContext _context;

        public IndexModel(MyScriptureJournal_Alma.Data.MyScriptureJournal_AlmaContext context)
        {
            _context = context;
        }

        public IList<Scripture> Scripture { get;set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Book { get; set; }
        [BindProperty(SupportsGet = true)]
        public string EntryTitle{ get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> genreQuery = from s in _context.Scripture
                                            orderby s.Book
                                            select s.Book;

            var scriptures = from s in _context.Scripture
                        select s;
          
            if (!string.IsNullOrEmpty(SearchString))
            {

                scriptures = scriptures.Where(s => s.Book.Contains(SearchString));

            }

            if (!string.IsNullOrEmpty(SearchString))
            {

                scriptures = scriptures.Where(x => x.Book == SearchString);

            }

            Book = new SelectList(await genreQuery.Distinct().ToListAsync());
            Scripture = await _context.Scripture.ToListAsync();
        }
    }
}
