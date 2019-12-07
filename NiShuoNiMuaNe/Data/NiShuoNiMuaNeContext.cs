using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NiShuoNiMuaNe.Models;

namespace NiShuoNiMuaNe.Data
{
    public class NiShuoNiMuaNeContext : DbContext
    {
        public NiShuoNiMuaNeContext (DbContextOptions<NiShuoNiMuaNeContext> options)
            : base(options)
        {
        }

        public DbSet<NiShuoNiMuaNe.Models.Cai> Cai { get; set; }
    }
}
