using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DangKyHocThuat_Web.Models
{
    public partial class db_ASP_ProjectContext : DbContext
    {
        public db_ASP_ProjectContext()
        {
        }

        public db_ASP_ProjectContext(DbContextOptions<db_ASP_ProjectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Class> Classes { get; set; } = null!;
        public virtual DbSet<Exam> Exams { get; set; } = null!;
        public virtual DbSet<ExamProctor> ExamProctors { get; set; } = null!;
        public virtual DbSet<ExamRegister> ExamRegisters { get; set; } = null!;
        public virtual DbSet<News> News { get; set; } = null!;
        public virtual DbSet<PrizeRegister> PrizeRegisters { get; set; } = null!;
        public virtual DbSet<PrizeType> PrizeTypes { get; set; } = null!;
        public virtual DbSet<Professor> Professors { get; set; } = null!;
        public virtual DbSet<Room> Rooms { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<Team> Teams { get; set; } = null!;

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=db_ASP_Project;Integrated Security=True;Encrypt=False");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.AutoId)
                    .HasName("PK__Account__6B232965AA1BC689");

                entity.ToTable("Account");

                entity.Property(e => e.AutoId).HasColumnName("AutoID");

                entity.Property(e => e.AccountName)
                    .HasMaxLength(50)
                    .HasColumnName("Account_Name")
                    .IsFixedLength();

                entity.Property(e => e.AccountPassword)
                    .HasMaxLength(50)
                    .HasColumnName("Account_Password");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_At");

                entity.Property(e => e.CreatedBy).HasColumnName("Created_By");

                entity.Property(e => e.PersonalId).HasColumnName("Personal_ID");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Updated_At");

                entity.Property(e => e.UpdatedBy).HasColumnName("Updated_By");

                entity.HasOne(d => d.Personal)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.PersonalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_account_professor");

                entity.HasOne(d => d.PersonalNavigation)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.PersonalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_account_student");
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.HasKey(e => e.AutoId)
                    .HasName("PK__Class__6B2329658B42F425");

                entity.ToTable("Class");

                entity.Property(e => e.AutoId).HasColumnName("AutoID");

                entity.Property(e => e.ClassName)
                    .HasMaxLength(10)
                    .HasColumnName("Class_Name")
                    .IsFixedLength();

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_At");

                entity.Property(e => e.CreatedBy).HasColumnName("Created_By");

                entity.Property(e => e.ProfessorId).HasColumnName("Professor_ID");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Updated_At");

                entity.Property(e => e.UpdatedBy).HasColumnName("Updated_By");

                entity.HasOne(d => d.Professor)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.ProfessorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_class_professor");
            });

            modelBuilder.Entity<Exam>(entity =>
            {
                entity.HasKey(e => e.AutoId)
                    .HasName("PK__Exam__6B232965D9CDF02D");

                entity.ToTable("Exam");

                entity.Property(e => e.AutoId).HasColumnName("AutoID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_At");

                entity.Property(e => e.CreatedBy).HasColumnName("Created_By");

                entity.Property(e => e.ExamEndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Exam_EndDate");

                entity.Property(e => e.ExamId)
                    .HasMaxLength(12)
                    .HasColumnName("Exam_ID")
                    .IsFixedLength();

                entity.Property(e => e.ExamName)
                    .HasMaxLength(50)
                    .HasColumnName("Exam_Name");

                entity.Property(e => e.ExamStartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Exam_StartDate");

                entity.Property(e => e.ExamTeamMaxCapacity).HasColumnName("Exam_TeamMaxCapacity");

                entity.Property(e => e.RoomId).HasColumnName("Room_ID");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Updated_At");

                entity.Property(e => e.UpdatedBy).HasColumnName("Updated_By");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Exams)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_exam_room");
            });

            modelBuilder.Entity<ExamProctor>(entity =>
            {
                entity.HasKey(e => e.AutoId)
                    .HasName("PK__ExamProc__6B232965C833CEFF");

                entity.ToTable("ExamProctor");

                entity.Property(e => e.AutoId).HasColumnName("AutoID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_At");

                entity.Property(e => e.CreatedBy).HasColumnName("Created_By");

                entity.Property(e => e.ExamId).HasColumnName("Exam_ID");

                entity.Property(e => e.ProctorId).HasColumnName("Proctor_ID");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Updated_At");

                entity.Property(e => e.UpdatedBy).HasColumnName("Updated_By");

                entity.HasOne(d => d.Exam)
                    .WithMany(p => p.ExamProctors)
                    .HasForeignKey(d => d.ExamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_examproc_exam");

                entity.HasOne(d => d.Proctor)
                    .WithMany(p => p.ExamProctors)
                    .HasForeignKey(d => d.ProctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_examproc_proctor");
            });

            modelBuilder.Entity<ExamRegister>(entity =>
            {
                entity.HasKey(e => e.AutoId)
                    .HasName("PK__ExamRegi__6B2329650A2F4D94");

                entity.ToTable("ExamRegister");

                entity.Property(e => e.AutoId).HasColumnName("AutoID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_At");

                entity.Property(e => e.CreatedBy).HasColumnName("Created_By");

                entity.Property(e => e.ExamId).HasColumnName("Exam_ID");

                entity.Property(e => e.TeamId).HasColumnName("Team_ID");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Updated_At");

                entity.Property(e => e.UpdatedBy).HasColumnName("Updated_By");

                entity.HasOne(d => d.Exam)
                    .WithMany(p => p.ExamRegisters)
                    .HasForeignKey(d => d.ExamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_examregister_exam");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.ExamRegisters)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_examregister_team");
            });

            modelBuilder.Entity<News>(entity =>
            {
                entity.HasKey(e => e.AutoId)
                    .HasName("PK__News__6B232965A6394FB5");

                entity.Property(e => e.AutoId).HasColumnName("AutoID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_At");

                entity.Property(e => e.CreatedBy).HasColumnName("Created_By");

                entity.Property(e => e.NewsContent).HasColumnName("News_Content");

                entity.Property(e => e.NewsTitle)
                    .HasMaxLength(50)
                    .HasColumnName("News_Title");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Updated_At");

                entity.Property(e => e.UpdatedBy).HasColumnName("Updated_By");
            });

            modelBuilder.Entity<PrizeRegister>(entity =>
            {
                entity.HasKey(e => e.AutoId)
                    .HasName("PK__PrizeReg__6B2329657A374E85");

                entity.ToTable("PrizeRegister");

                entity.Property(e => e.AutoId).HasColumnName("AutoID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_At");

                entity.Property(e => e.CreatedBy).HasColumnName("Created_By");

                entity.Property(e => e.ExamId).HasColumnName("Exam_ID");

                entity.Property(e => e.PrizeTypeId).HasColumnName("PrizeType_ID");

                entity.Property(e => e.TeamId).HasColumnName("Team_ID");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Updated_At");

                entity.Property(e => e.UpdatedBy).HasColumnName("Updated_By");

                entity.HasOne(d => d.Exam)
                    .WithMany(p => p.PrizeRegisters)
                    .HasForeignKey(d => d.ExamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_prizeregister_exam");

                entity.HasOne(d => d.PrizeType)
                    .WithMany(p => p.PrizeRegisters)
                    .HasForeignKey(d => d.PrizeTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_prizeregister_ytpe");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.PrizeRegisters)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_prizeregister_team");
            });

            modelBuilder.Entity<PrizeType>(entity =>
            {
                entity.HasKey(e => e.AutoId)
                    .HasName("PK__PrizeTyp__6B232965D542B592");

                entity.ToTable("PrizeType");

                entity.Property(e => e.AutoId).HasColumnName("AutoID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_At");

                entity.Property(e => e.CreatedBy).HasColumnName("Created_By");

                entity.Property(e => e.PrizeTypeName)
                    .HasMaxLength(50)
                    .HasColumnName("PrizeType_Name");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Updated_At");

                entity.Property(e => e.UpdatedBy).HasColumnName("Updated_By");
            });

            modelBuilder.Entity<Professor>(entity =>
            {
                entity.HasKey(e => e.AutoId)
                    .HasName("PK__Professo__6B232965E264FABB");

                entity.ToTable("Professor");

                entity.Property(e => e.AutoId).HasColumnName("AutoID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_At");

                entity.Property(e => e.CreatedBy).HasColumnName("Created_By");

                entity.Property(e => e.ProfessorEmail)
                    .HasMaxLength(50)
                    .HasColumnName("Professor_Email")
                    .IsFixedLength();

                entity.Property(e => e.ProfessorId)
                    .HasMaxLength(10)
                    .HasColumnName("Professor_ID")
                    .IsFixedLength();

                entity.Property(e => e.ProfessorName)
                    .HasMaxLength(50)
                    .HasColumnName("Professor_Name");

                entity.Property(e => e.ProfessorPhone)
                    .HasMaxLength(10)
                    .HasColumnName("Professor_Phone")
                    .IsFixedLength();

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Updated_At");

                entity.Property(e => e.UpdatedBy).HasColumnName("Updated_By");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.HasKey(e => e.AutoId)
                    .HasName("PK__Room__6B232965C5403DA7");

                entity.ToTable("Room");

                entity.HasIndex(e => e.RoomName, "UQ__Room__D33583E9F30B1CDD")
                    .IsUnique();

                entity.Property(e => e.AutoId).HasColumnName("AutoID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_At");

                entity.Property(e => e.CreatedBy).HasColumnName("Created_By");

                entity.Property(e => e.RoomName)
                    .HasMaxLength(10)
                    .HasColumnName("Room_Name")
                    .IsFixedLength();

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Updated_At");

                entity.Property(e => e.UpdatedBy).HasColumnName("Updated_By");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.AutoId)
                    .HasName("PK__Student__6B23296593214FFC");

                entity.ToTable("Student");

                entity.Property(e => e.AutoId).HasColumnName("AutoID");

                entity.Property(e => e.ClassId).HasColumnName("Class_ID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_At");

                entity.Property(e => e.CreatedBy).HasColumnName("Created_By");

                entity.Property(e => e.StudentDoB)
                    .HasColumnType("datetime")
                    .HasColumnName("Student_DoB");

                entity.Property(e => e.StudentId)
                    .HasMaxLength(11)
                    .HasColumnName("Student_ID")
                    .IsFixedLength();

                entity.Property(e => e.StudentName)
                    .HasMaxLength(50)
                    .HasColumnName("Student_Name");

                entity.Property(e => e.StudentPoB)
                    .HasMaxLength(50)
                    .HasColumnName("Student_PoB");

                entity.Property(e => e.TeamId).HasColumnName("Team_ID");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Updated_At");

                entity.Property(e => e.UpdatedBy).HasColumnName("Updated_By");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_student_class");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_student_team");
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasKey(e => e.AutoId)
                    .HasName("PK__Team__6B23296513C52E68");

                entity.ToTable("Team");

                entity.Property(e => e.AutoId).HasColumnName("AutoID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_At");

                entity.Property(e => e.CreatedBy).HasColumnName("Created_By");

                entity.Property(e => e.TeamName)
                    .HasMaxLength(50)
                    .HasColumnName("Team_Name");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Updated_At");

                entity.Property(e => e.UpdatedBy).HasColumnName("Updated_By");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
