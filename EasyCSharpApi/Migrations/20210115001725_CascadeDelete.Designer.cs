﻿// <auto-generated />
using System;
using EasyCSharpApi.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EasyCSharpApi.Migrations
{
    [DbContext(typeof(EasyCSharpDBContext))]
    [Migration("20210115001725_CascadeDelete")]
    partial class CascadeDelete
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:Collation", "Ukrainian_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("EasyCSharpApi.DAL.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("AttemtpSequence")
                        .HasColumnType("int");

                    b.Property<decimal?>("CorrectnessPercent")
                        .HasColumnType("decimal(5,2)");

                    b.Property<DateTime?>("DateOfAnswer")
                        .HasColumnType("datetime");

                    b.Property<int>("TaskId")
                        .HasColumnType("int");

                    b.Property<int?>("TimeOfExecution")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TaskId");

                    b.HasIndex("UserId");

                    b.ToTable("Answer");
                });

            modelBuilder.Entity("EasyCSharpApi.DAL.AnswerItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("AnswerId")
                        .HasColumnType("int");

                    b.Property<int?>("AnswerOptionId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<decimal?>("CorrectnessPercent")
                        .HasColumnType("decimal(5,2)");

                    b.Property<int?>("Order")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AnswerId");

                    b.HasIndex("AnswerOptionId");

                    b.ToTable("AnswerItem");
                });

            modelBuilder.Entity("EasyCSharpApi.DAL.AnswerOptionEtalon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Content")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<int?>("Order")
                        .HasColumnType("int");

                    b.Property<int>("TaskId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("XPKAnswerOption_Etalon_");

                    b.HasIndex("TaskId");

                    b.ToTable("AnswerOption_Etalon_");
                });

            modelBuilder.Entity("EasyCSharpApi.DAL.Progress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime?>("SavingDate")
                        .HasColumnType("datetime");

                    b.Property<int>("TaskId")
                        .HasColumnType("int");

                    b.Property<int?>("TimeOfExecution")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("XPKProgres");

                    b.HasIndex("TaskId");

                    b.HasIndex("UserId");

                    b.ToTable("Progres");
                });

            modelBuilder.Entity("EasyCSharpApi.DAL.ProgressItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("AnswerOptionId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<int?>("Order")
                        .HasColumnType("int");

                    b.Property<int>("ProgresId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AnswerOptionId");

                    b.HasIndex("ProgresId");

                    b.ToTable("ProgresItem");
                });

            modelBuilder.Entity("EasyCSharpApi.DAL.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("RoleName")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("EasyCSharpApi.DAL.Task", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Content")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<decimal?>("DificultyCoef")
                        .HasColumnType("decimal(5,2)");

                    b.Property<int>("TitleId")
                        .HasColumnType("int");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TitleId");

                    b.HasIndex("TypeId");

                    b.ToTable("Task");
                });

            modelBuilder.Entity("EasyCSharpApi.DAL.Title", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("TitleName")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("Title");

                    b.HasKey("Id");

                    b.ToTable("Title");
                });

            modelBuilder.Entity("EasyCSharpApi.DAL.Type", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("TypeName")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("Type");

                    b.HasKey("Id");

                    b.ToTable("Type");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            TypeName = "Orderable"
                        },
                        new
                        {
                            Id = 2,
                            TypeName = "Expended"
                        });
                });

            modelBuilder.Entity("EasyCSharpApi.DAL.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime?>("DateOfRegister")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Login")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Password")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("EasyCSharpApi.DAL.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("User_Role");
                });

            modelBuilder.Entity("EasyCSharpApi.DAL.Answer", b =>
                {
                    b.HasOne("EasyCSharpApi.DAL.Task", "Task")
                        .WithMany("Answers")
                        .HasForeignKey("TaskId")
                        .HasConstraintName("task_answer")
                        .IsRequired();

                    b.HasOne("EasyCSharpApi.DAL.User", "User")
                        .WithMany("Answers")
                        .HasForeignKey("UserId")
                        .HasConstraintName("R_33")
                        .IsRequired();

                    b.Navigation("Task");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EasyCSharpApi.DAL.AnswerItem", b =>
                {
                    b.HasOne("EasyCSharpApi.DAL.Answer", "Answer")
                        .WithMany("AnswerItems")
                        .HasForeignKey("AnswerId")
                        .HasConstraintName("R_31")
                        .IsRequired();

                    b.HasOne("EasyCSharpApi.DAL.AnswerOptionEtalon", "AnswerOption")
                        .WithMany("AnswerItems")
                        .HasForeignKey("AnswerOptionId")
                        .HasConstraintName("R_30");

                    b.Navigation("Answer");

                    b.Navigation("AnswerOption");
                });

            modelBuilder.Entity("EasyCSharpApi.DAL.AnswerOptionEtalon", b =>
                {
                    b.HasOne("EasyCSharpApi.DAL.Task", "Task")
                        .WithMany("AnswerOptionEtalons")
                        .HasForeignKey("TaskId")
                        .HasConstraintName("R_29")
                        .IsRequired();

                    b.Navigation("Task");
                });

            modelBuilder.Entity("EasyCSharpApi.DAL.Progress", b =>
                {
                    b.HasOne("EasyCSharpApi.DAL.Task", "Task")
                        .WithMany("Progresses")
                        .HasForeignKey("TaskId")
                        .HasConstraintName("R_36")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EasyCSharpApi.DAL.User", "User")
                        .WithMany("Progres")
                        .HasForeignKey("UserId")
                        .HasConstraintName("R_32")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Task");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EasyCSharpApi.DAL.ProgressItem", b =>
                {
                    b.HasOne("EasyCSharpApi.DAL.AnswerOptionEtalon", "AnswerOption")
                        .WithMany("ProgresItems")
                        .HasForeignKey("AnswerOptionId")
                        .HasConstraintName("R_39");

                    b.HasOne("EasyCSharpApi.DAL.Progress", "Progres")
                        .WithMany("ProgresItems")
                        .HasForeignKey("ProgresId")
                        .HasConstraintName("R_37")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AnswerOption");

                    b.Navigation("Progres");
                });

            modelBuilder.Entity("EasyCSharpApi.DAL.Task", b =>
                {
                    b.HasOne("EasyCSharpApi.DAL.Title", "Title")
                        .WithMany("Tasks")
                        .HasForeignKey("TitleId")
                        .HasConstraintName("R_28")
                        .IsRequired();

                    b.HasOne("EasyCSharpApi.DAL.Type", "Type")
                        .WithMany("Tasks")
                        .HasForeignKey("TypeId")
                        .HasConstraintName("R_27")
                        .IsRequired();

                    b.Navigation("Title");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("EasyCSharpApi.DAL.UserRole", b =>
                {
                    b.HasOne("EasyCSharpApi.DAL.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("R_13")
                        .IsRequired();

                    b.HasOne("EasyCSharpApi.DAL.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .HasConstraintName("R_11")
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EasyCSharpApi.DAL.Answer", b =>
                {
                    b.Navigation("AnswerItems");
                });

            modelBuilder.Entity("EasyCSharpApi.DAL.AnswerOptionEtalon", b =>
                {
                    b.Navigation("AnswerItems");

                    b.Navigation("ProgresItems");
                });

            modelBuilder.Entity("EasyCSharpApi.DAL.Progress", b =>
                {
                    b.Navigation("ProgresItems");
                });

            modelBuilder.Entity("EasyCSharpApi.DAL.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("EasyCSharpApi.DAL.Task", b =>
                {
                    b.Navigation("AnswerOptionEtalons");

                    b.Navigation("Answers");

                    b.Navigation("Progresses");
                });

            modelBuilder.Entity("EasyCSharpApi.DAL.Title", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("EasyCSharpApi.DAL.Type", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("EasyCSharpApi.DAL.User", b =>
                {
                    b.Navigation("Answers");

                    b.Navigation("Progres");

                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
