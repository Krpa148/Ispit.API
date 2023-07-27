using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Ispit.API.Models
{
    public partial class IspitApiDbContext : DbContext
    {
        public IspitApiDbContext()
        {
        }

        public IspitApiDbContext(DbContextOptions<IspitApiDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ToDoList> ToDoLists { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-2BHHQH4\\SQLEXPRESS;Database=IspitApiDb;Trusted_Connection=True;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDoList>(entity =>
            {
                entity.ToTable("ToDoList");

                entity.Property(e => e.Description).HasMaxLength(150);

                entity.Property(e => e.Title).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
