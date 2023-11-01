using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyScriptureJournal_Alma.Models;

namespace MyScriptureJournal_Alma.Data
{
    public class MyScriptureJournal_AlmaContext : DbContext
    {
        public MyScriptureJournal_AlmaContext (DbContextOptions<MyScriptureJournal_AlmaContext> options)
            : base(options)
        {
        }

        public DbSet<MyScriptureJournal_Alma.Models.Scripture> Scripture { get; set; } = default!;
    }
}
