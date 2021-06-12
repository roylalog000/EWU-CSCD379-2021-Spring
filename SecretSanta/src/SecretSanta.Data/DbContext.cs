using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using DbContext = SecretSanta.Data.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Serilog.Extensions.Logging;
using Serilog.Extensions.Hosting;
using Serilog.Sinks.SystemConsole.Themes;


namespace SecretSanta.Data
{
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext, IDisposable
    {
        public DbContext()
            : base(new DbContextOptionsBuilder<DbContext>().UseSqlite("Data Source=main.db").Options)
        {  
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
public DbContext(DbContextOptions<DbContext> options)
            : base(options)
        { }
       
        public DbSet<User> Users => Set<User>();
        public DbSet<Group> Groups => Set<Group>();
        public DbSet<Gift> Gift => Set<Gift>();
        public DbSet<Assignment> Assignments => Set<Assignment>();
        public DbSet<Gift> Gifts => Set<Gift>();
        public DbSet<GroupUser> GroupUsers => Set<GroupUser>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder is null)
            {
                throw new ArgumentNullException(nameof(optionsBuilder));
            }

            
        }

        


        

       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder is null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }
         
            
            

           

            

            
                
            modelBuilder.Entity<User>()
                .HasAlternateKey(user => new { user.FirstName, user.LastName});
            modelBuilder.Entity<Gift>()
                .HasAlternateKey(gift => new {gift.Title, gift.UserId});
            modelBuilder.Entity<Group>()
                .HasAlternateKey(group => new {group.Name});
            modelBuilder.Entity<Assignment>()
                .HasAlternateKey(assignment => new {assignment.GiverId, assignment.ReceiverId});
            modelBuilder.Entity<GroupUser>()
                .HasAlternateKey(group => new {group.GroupId, group.UserId});
                
               // modelBuilder.Entity<GroupUsers>()



            
            //modelBuilder.Entity<User>().HasData(DbData.Users());
        }
    }
}