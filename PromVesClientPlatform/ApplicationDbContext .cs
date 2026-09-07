using Microsoft.EntityFrameworkCore;
using PromVesClientPlatform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromVesClientPlatform
{
    public  class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
       DbContextOptions<ApplicationDbContext> options)
       : base(options)
        {
        }

        public DbSet<User> Users => Set<User>();
        public DbSet<Receipt> Receipts => Set<Receipt>();
        public DbSet<Weighing> Weighings => Set<Weighing>();
    }
}
