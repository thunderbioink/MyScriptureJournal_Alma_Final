using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyScriptureJournal_Alma.Data;
using MyScriptureJournal_Alma.Models;

namespace MyScriptureJournal_Alma.Pages.Scriptures
{
    public class DetailsModel : PageModel
    {
        private readonly MyScriptureJournal_Alma.Data.MyScriptureJournal_AlmaContext _context;

        public DetailsModel(MyScriptureJournal_Alma.Data.MyScriptureJournal_AlmaContext context)
        {
            _context = context;
        }

      public Scripture Scripture { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Scripture == null)
            {
                return NotFound();
            }

            var scripture = await _context.Scripture.FirstOrDefaultAsync(m => m.ID == id);
            if (scripture == null)
            {
                return NotFound();
            }
            else 
            {
                Scripture = scripture;
            }
            return Page();
        }
    }
}
