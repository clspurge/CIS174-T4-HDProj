using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Team4_FinalProject.Models
{
    public class TicketManagerDbContext : DbContext
    {
        public TicketManagerDbContext(DbContextOptions<TicketManagerDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Note> Notes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<User>().Property(p => p.IsTechnician).HasDefaultValue(false);
            modelBuilder.Entity<Ticket>().Property(t => t.DateOpened).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<Note>().Property(t => t.DateCreated).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<Ticket>().Property(t => t.Status).HasDefaultValue("In Progress");


            //Seed Users
            User user1 = new();
            user1.UserId = 1;
            user1.Username = "Chasidy";
            user1.Password = "password";
            user1.FirstName = "Chasidy";
            user1.LastName = "Spurgeon";
            user1.IsTechnician = true;
            modelBuilder.Entity<User>().HasData(user1);

            User user2 = new();
            user2.UserId = 2;
            user2.Username = "Wade";
            user2.Password = "password";
            user2.FirstName = "Wade";
            user2.LastName = "Shafer";
            user2.IsTechnician = true;
            modelBuilder.Entity<User>().HasData(user2);

            User user3 = new();
            user3.UserId = 3;
            user3.Username = "John";
            user3.Password = "password";
            user3.FirstName = "John";
            user3.LastName = "Ryan";
            user3.IsTechnician = true;
            modelBuilder.Entity<User>().HasData(user3);

            User user4 = new();
            user4.UserId = 4;
            user4.Username = "Logan";
            user4.Password = "password";
            user4.FirstName = "Logan";
            user4.LastName = "Riedell";
            user4.IsTechnician = true;
            modelBuilder.Entity<User>().HasData(user4);

            User reg_user = new();
            reg_user.UserId = 5;
            reg_user.Username = "GoodJoe12";
            reg_user.Password = "passWord1";
            reg_user.FirstName = "Tom";
            reg_user.LastName = "Hanks";
            modelBuilder.Entity<User>().HasData(reg_user);

            //Seed Tickets

            Ticket ticket3 = new();
            ticket3.TicketId = 3;
            ticket3.Issue = "Life?";
            ticket3.UserId = 5;
            ticket3.Status = "In Progress";
            modelBuilder.Entity<Ticket>().HasData(ticket3);

            Ticket ticket1 = new();
            ticket1.TicketId = 1;
            ticket1.Issue = "Electronics?";
            ticket1.UserId = 4;
            ticket1.Status = "In Progress";
            modelBuilder.Entity<Ticket>().HasData(ticket1);

            Ticket ticket2 = new();
            ticket2.TicketId = 2;
            ticket2.Issue = "Toaster?";
            ticket2.UserId = 5;
            ticket2.Status = "Completed";
            modelBuilder.Entity<Ticket>().HasData(ticket2);

            Ticket ticket4 = new();
            ticket4.TicketId = 4;
            ticket4.Issue = "Printer?";
            ticket4.UserId = 1;
            ticket4.Status = "Completed";
            modelBuilder.Entity<Ticket>().HasData(ticket4);

            //Seeding Notes
            Note note1 = new();
            note1.NoteId = 1;
            note1.Content = "Fixed the... whatever it is.";
            note1.TicketId = 4;
            modelBuilder.Entity<Note>().HasData(note1);

            Note note2 = new();
            note2.NoteId = 2;
            note2.Content = "Fixed the... whatever it is.";
            note2.TicketId = 2;
            modelBuilder.Entity<Note>().HasData(note2);

            Note note3= new();
            note3.NoteId = 3;
            note3.Content = "Fixed the... whatever it is.";
            note3.TicketId = 4;
            modelBuilder.Entity<Note>().HasData(note3);

            Note note4 = new();
            note4.NoteId = 4;
            note4.Content = "Fixed the... whatever it is.";
            note4.TicketId = 1;
            modelBuilder.Entity<Note>().HasData(note4);

            base.OnModelCreating(modelBuilder);
        }
    }
}
