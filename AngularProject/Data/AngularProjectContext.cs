using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AngularProject.Models;

namespace AngularProject.Data
{
    public class AngularProjectContext : DbContext
    {
        public AngularProjectContext (DbContextOptions<AngularProjectContext> options)
            : base(options)
        {
        }

        public DbSet<AngularProject.Models.Creature> Creature { get; set; }
    }
}
