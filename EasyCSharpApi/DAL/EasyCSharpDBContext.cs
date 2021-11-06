using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace EasyCSharpApi.DAL
{
    public partial class EasyCSharpDBContext : DbContext
    {
        public EasyCSharpDBContext()
        {
        }

        public EasyCSharpDBContext(DbContextOptions<EasyCSharpDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<AnswerItem> AnswerItems { get; set; }
        public virtual DbSet<AnswerOptionEtalon> AnswerOptionEtalons { get; set; }
        public virtual DbSet<Progress> Progres { get; set; }
        public virtual DbSet<ProgressItem> ProgresItems { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<Title> Titles { get; set; }
        public virtual DbSet<Type> Types { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Ukrainian_CI_AS");

            modelBuilder.Entity<Answer>(entity =>
            {
                entity.ToTable("Answer");

                entity.Property(e => e.CorrectnessPercent).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.DateOfAnswer).HasColumnType("datetime");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Answers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R_33");

                entity.HasOne(d => d.Task)
                .WithMany(p => p.Answers)
                .HasForeignKey(d => d.TaskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("task_answer");
            });

            modelBuilder.Entity<AnswerItem>(entity =>
            {
                entity.ToTable("AnswerItem");

                entity.Property(e => e.Content).IsUnicode(false);

                entity.Property(e => e.CorrectnessPercent).HasColumnType("decimal(5, 2)");

                entity.HasOne(d => d.Answer)
                    .WithMany(p => p.AnswerItems)
                    .HasForeignKey(d => d.AnswerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R_31");

                entity.HasOne(d => d.AnswerOption)
                    .WithMany(p => p.AnswerItems)
                    .HasForeignKey(d => d.AnswerOptionId)
                    .HasConstraintName("R_30");
            });

            modelBuilder.Entity<AnswerOptionEtalon>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("XPKAnswerOption_Etalon_");

                entity.ToTable("AnswerOption_Etalon_");

                entity.Property(e => e.Content).IsUnicode(false);

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.AnswerOptionEtalons)
                    .HasForeignKey(d => d.TaskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R_29");
            });

            modelBuilder.Entity<Progress>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("XPKProgres");

                entity.Property(e => e.SavingDate).HasColumnType("datetime");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Progres)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("R_32");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.Progresses)
                    .HasForeignKey(d => d.TaskId)
                    .HasConstraintName("R_36");
            });

            modelBuilder.Entity<ProgressItem>(entity =>
            {
                entity.ToTable("ProgresItem");

                entity.Property(e => e.Content).IsUnicode(false);

                entity.HasOne(d => d.AnswerOption)
                    .WithMany(p => p.ProgresItems)
                    .HasForeignKey(d => d.AnswerOptionId)
                    .HasConstraintName("R_39");

                entity.HasOne(d => d.Progres)
                    .WithMany(p => p.ProgresItems)
                    .HasForeignKey(d => d.ProgresId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("R_37");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.RoleName).IsUnicode(false);
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.ToTable("Task");

                entity.Property(e => e.Content).IsUnicode(false);

                entity.Property(e => e.DificultyCoef).HasColumnType("decimal(5, 2)");

                entity.HasOne(d => d.Title)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.TitleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R_28");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R_27");
            });

            modelBuilder.Entity<Title>(entity =>
            {
                entity.ToTable("Title");

                entity.Property(e => e.TitleName)
                    .IsUnicode(false)
                    .HasColumnName("Title");
            });

            modelBuilder.Entity<Type>(entity =>
            {
                entity.ToTable("Type");

                entity.Property(e => e.TypeName)
                    .IsUnicode(false)
                    .HasColumnName("Type");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.DateOfRegister).HasColumnType("datetime");

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Login).IsUnicode(false);

                entity.Property(e => e.Password).IsUnicode(false);

                entity.Property(e => e.PhoneNumber).IsUnicode(false);
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.ToTable("User_Role");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R_13");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R_11");
            });
            modelBuilder.Entity<Type>().HasData(new Type() { Id = 1, TypeName = "Orderable" });
            modelBuilder.Entity<Type>().HasData(new Type() { Id = 2, TypeName = "Expended" });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
