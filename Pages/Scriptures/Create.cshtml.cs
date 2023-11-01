using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyScriptureJournal_Alma.Data;
using MyScriptureJournal_Alma.Models;

namespace MyScriptureJournal_Alma.Pages.Scriptures
{
    public class CreateModel : PageModel
    {
        private readonly MyScriptureJournal_Alma.Data.MyScriptureJournal_AlmaContext _context;

        public CreateModel(MyScriptureJournal_Alma.Data.MyScriptureJournal_AlmaContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Scripture Scripture { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Scripture == null || Scripture == null)
            {
                return Page();
            }

            _context.Scripture.Add(Scripture);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
