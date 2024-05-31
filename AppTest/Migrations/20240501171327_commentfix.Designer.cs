﻿// <auto-generated />
using System;
using AppTest.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AppTest.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240501171327_commentfix")]
    partial class commentfix
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AnswerEntityTestResultEntity", b =>
                {
                    b.Property<int>("AnswersId")
                        .HasColumnType("int");

                    b.Property<int>("ResultsId")
                        .HasColumnType("int");

                    b.HasKey("AnswersId", "ResultsId");

                    b.HasIndex("ResultsId");

                    b.ToTable("AnswerEntityTestResultEntity");
                });

            modelBuilder.Entity("AppTest.Models.Entities.AnswerEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TicketId")
                        .HasColumnType("int");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TicketId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("AppTest.Models.Entities.CommentEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("PostId")
                        .HasColumnType("int");

                    b.Property<int?>("TestId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("TestId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("AppTest.Models.Entities.ImageEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AnswerId")
                        .HasColumnType("int");

                    b.Property<int?>("TicketId")
                        .HasColumnType("int");

                    b.Property<string>("src")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AnswerId")
                        .IsUnique()
                        .HasFilter("[AnswerId] IS NOT NULL");

                    b.HasIndex("TicketId")
                        .IsUnique()
                        .HasFilter("[TicketId] IS NOT NULL");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("AppTest.Models.Entities.PostEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserPageId")
                        .HasColumnType("int");

                    b.Property<DateTime>("time")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("UserPageId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("AppTest.Models.Entities.RoleEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("AppTest.Models.Entities.TestEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAuthorized")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Rating")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Tests");
                });

            modelBuilder.Entity("AppTest.Models.Entities.TestResultEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ResultInt")
                        .HasColumnType("int");

                    b.Property<string>("ResultString")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TestId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TestId");

                    b.HasIndex("UserId");

                    b.ToTable("TestResultEntity");
                });

            modelBuilder.Entity("AppTest.Models.Entities.TicketEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CorrectAnswer")
                        .HasColumnType("int");

                    b.Property<int?>("TestId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TestId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("AppTest.Models.Entities.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Town")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AppTest.Models.Entities.UserPageEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<bool>("isAuthorized")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserPages");
                });

            modelBuilder.Entity("CommentEntityImageEntity", b =>
                {
                    b.Property<int>("CommentsId")
                        .HasColumnType("int");

                    b.Property<int>("ImagesId")
                        .HasColumnType("int");

                    b.HasKey("CommentsId", "ImagesId");

                    b.HasIndex("ImagesId");

                    b.ToTable("CommentEntityImageEntity");
                });

            modelBuilder.Entity("ImageEntityPostEntity", b =>
                {
                    b.Property<int>("ImagesId")
                        .HasColumnType("int");

                    b.Property<int>("PostsId")
                        .HasColumnType("int");

                    b.HasKey("ImagesId", "PostsId");

                    b.HasIndex("PostsId");

                    b.ToTable("ImageEntityPostEntity");
                });

            modelBuilder.Entity("RoleEntityUserEntity", b =>
                {
                    b.Property<int>("RolesId")
                        .HasColumnType("int");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("RolesId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("RoleEntityUserEntity");
                });

            modelBuilder.Entity("AnswerEntityTestResultEntity", b =>
                {
                    b.HasOne("AppTest.Models.Entities.AnswerEntity", null)
                        .WithMany()
                        .HasForeignKey("AnswersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppTest.Models.Entities.TestResultEntity", null)
                        .WithMany()
                        .HasForeignKey("ResultsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AppTest.Models.Entities.AnswerEntity", b =>
                {
                    b.HasOne("AppTest.Models.Entities.TicketEntity", "Ticket")
                        .WithMany("Answers")
                        .HasForeignKey("TicketId");

                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("AppTest.Models.Entities.CommentEntity", b =>
                {
                    b.HasOne("AppTest.Models.Entities.PostEntity", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId");

                    b.HasOne("AppTest.Models.Entities.TestEntity", "Test")
                        .WithMany("Comments")
                        .HasForeignKey("TestId");

                    b.HasOne("AppTest.Models.Entities.UserEntity", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("Test");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AppTest.Models.Entities.ImageEntity", b =>
                {
                    b.HasOne("AppTest.Models.Entities.AnswerEntity", "Answer")
                        .WithOne("Image")
                        .HasForeignKey("AppTest.Models.Entities.ImageEntity", "AnswerId");

                    b.HasOne("AppTest.Models.Entities.TicketEntity", "Ticket")
                        .WithOne("Image")
                        .HasForeignKey("AppTest.Models.Entities.ImageEntity", "TicketId");

                    b.Navigation("Answer");

                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("AppTest.Models.Entities.PostEntity", b =>
                {
                    b.HasOne("AppTest.Models.Entities.UserPageEntity", "UserPage")
                        .WithMany("Posts")
                        .HasForeignKey("UserPageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserPage");
                });

            modelBuilder.Entity("AppTest.Models.Entities.TestEntity", b =>
                {
                    b.HasOne("AppTest.Models.Entities.UserEntity", "Author")
                        .WithMany("Tests")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("AppTest.Models.Entities.TestResultEntity", b =>
                {
                    b.HasOne("AppTest.Models.Entities.TestEntity", "Test")
                        .WithMany("TestResults")
                        .HasForeignKey("TestId");

                    b.HasOne("AppTest.Models.Entities.UserEntity", "User")
                        .WithMany("Results")
                        .HasForeignKey("UserId");

                    b.Navigation("Test");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AppTest.Models.Entities.TicketEntity", b =>
                {
                    b.HasOne("AppTest.Models.Entities.TestEntity", "Test")
                        .WithMany("TestContents")
                        .HasForeignKey("TestId");

                    b.Navigation("Test");
                });

            modelBuilder.Entity("AppTest.Models.Entities.UserPageEntity", b =>
                {
                    b.HasOne("AppTest.Models.Entities.UserEntity", "User")
                        .WithOne("Page")
                        .HasForeignKey("AppTest.Models.Entities.UserPageEntity", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CommentEntityImageEntity", b =>
                {
                    b.HasOne("AppTest.Models.Entities.CommentEntity", null)
                        .WithMany()
                        .HasForeignKey("CommentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppTest.Models.Entities.ImageEntity", null)
                        .WithMany()
                        .HasForeignKey("ImagesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ImageEntityPostEntity", b =>
                {
                    b.HasOne("AppTest.Models.Entities.ImageEntity", null)
                        .WithMany()
                        .HasForeignKey("ImagesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppTest.Models.Entities.PostEntity", null)
                        .WithMany()
                        .HasForeignKey("PostsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RoleEntityUserEntity", b =>
                {
                    b.HasOne("AppTest.Models.Entities.RoleEntity", null)
                        .WithMany()
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppTest.Models.Entities.UserEntity", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AppTest.Models.Entities.AnswerEntity", b =>
                {
                    b.Navigation("Image");
                });

            modelBuilder.Entity("AppTest.Models.Entities.PostEntity", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("AppTest.Models.Entities.TestEntity", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("TestContents");

                    b.Navigation("TestResults");
                });

            modelBuilder.Entity("AppTest.Models.Entities.TicketEntity", b =>
                {
                    b.Navigation("Answers");

                    b.Navigation("Image");
                });

            modelBuilder.Entity("AppTest.Models.Entities.UserEntity", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Page")
                        .IsRequired();

                    b.Navigation("Results");

                    b.Navigation("Tests");
                });

            modelBuilder.Entity("AppTest.Models.Entities.UserPageEntity", b =>
                {
                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}
