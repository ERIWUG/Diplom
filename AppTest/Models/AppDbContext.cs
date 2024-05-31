using System.Collections.Generic;
using System.Reflection.Emit;
using System;
using Microsoft.EntityFrameworkCore;
using AppTest.Models.Entities;
using Microsoft.Identity.Client;
using AppTest.Migrations;

namespace AppTest.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
          : base(options){}
        public AppDbContext(){ Database.EnsureCreated();}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connection = "Data Source=DESKTOP-TQLBOGP;Initial Catalog=DiplomDB;Integrated Security=True;Encrypt=False";
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(connection);
        }
        public virtual DbSet<UserEntity> Users { get; set; }
        public virtual DbSet<RoleEntity> Roles { get; set; }
        public virtual DbSet<TestEntity> Tests { get; set; }
        public virtual DbSet<TestResultEntity> TestResults { get; set; }
        public virtual DbSet<TicketEntity> Tickets { get; set; }
        public virtual DbSet<ImageEntity> Images { get; set; }
        public virtual DbSet<AnswerEntity> Answers { get; set; }
        public virtual DbSet<UserPageEntity> UserPages { get; set; }
        public virtual DbSet<CommentEntity> Comments { get; set; }
        public virtual DbSet<PostEntity> Posts { get; set; }
        public virtual DbSet<ReportEntity> Reports { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
