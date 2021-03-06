// <auto-generated />


#nullable disable

using System;
using APISistemaTickets.Modules.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
namespace APISistemaTickets.Migrations.SqliteMigrations
{
    [DbContext(typeof(SqliteDataContext))]
    [Migration("20220530020125_AppModels")]
    partial class AppModels
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.5");

            modelBuilder.Entity("APISistemaTickets.Data.Models.Auth.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Role")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("APISistemaTickets.Data.Models.Comment", b =>
                {
                    b.Property<long>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long>("TicketId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CommentId");

                    b.HasIndex("TicketId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("APISistemaTickets.Data.Models.KnowledgeBaseArticle", b =>
                {
                    b.Property<long>("KnowledgeBaseArticleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("KnowledgeBaseArticleId");

                    b.HasIndex("UserId");

                    b.ToTable("KnowledgeBaseArticles");
                });

            modelBuilder.Entity("APISistemaTickets.Data.Models.Tag", b =>
                {
                    b.Property<long>("TagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("KnowledgeBaseArticleId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("TagId");

                    b.HasIndex("KnowledgeBaseArticleId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("APISistemaTickets.Data.Models.Ticket", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("ClosedAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long?>("EngineerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.Property<long>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("EngineerId");

                    b.HasIndex("UserId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("TagTicket", b =>
                {
                    b.Property<long>("TagsTagId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("TicketsId")
                        .HasColumnType("INTEGER");

                    b.HasKey("TagsTagId", "TicketsId");

                    b.HasIndex("TicketsId");

                    b.ToTable("TagTicket");
                });

            modelBuilder.Entity("APISistemaTickets.Data.Models.Comment", b =>
                {
                    b.HasOne("APISistemaTickets.Data.Models.Ticket", "Ticket")
                        .WithMany("Comments")
                        .HasForeignKey("TicketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APISistemaTickets.Data.Models.Auth.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ticket");

                    b.Navigation("User");
                });

            modelBuilder.Entity("APISistemaTickets.Data.Models.KnowledgeBaseArticle", b =>
                {
                    b.HasOne("APISistemaTickets.Data.Models.Auth.User", "Author")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("APISistemaTickets.Data.Models.Tag", b =>
                {
                    b.HasOne("APISistemaTickets.Data.Models.KnowledgeBaseArticle", "KnowledgeBaseArticle")
                        .WithMany("Tags")
                        .HasForeignKey("KnowledgeBaseArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KnowledgeBaseArticle");
                });

            modelBuilder.Entity("APISistemaTickets.Data.Models.Ticket", b =>
                {
                    b.HasOne("APISistemaTickets.Data.Models.Auth.User", "Engineer")
                        .WithMany()
                        .HasForeignKey("EngineerId");

                    b.HasOne("APISistemaTickets.Data.Models.Auth.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Engineer");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TagTicket", b =>
                {
                    b.HasOne("APISistemaTickets.Data.Models.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsTagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APISistemaTickets.Data.Models.Ticket", null)
                        .WithMany()
                        .HasForeignKey("TicketsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("APISistemaTickets.Data.Models.KnowledgeBaseArticle", b =>
                {
                    b.Navigation("Tags");
                });

            modelBuilder.Entity("APISistemaTickets.Data.Models.Ticket", b =>
                {
                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}
