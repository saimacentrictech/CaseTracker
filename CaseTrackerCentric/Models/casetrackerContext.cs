using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CaseTrackerCentric.Models
{
    //comment
    public partial class casetrackerContext : DbContext
    {
        public casetrackerContext()
        {
        }

        public casetrackerContext(DbContextOptions<casetrackerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CTracker> CTrackers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CTracker>(entity =>
            {
                entity.ToTable("C_tracker");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AssistantCons)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Assistant_Cons");

                entity.Property(e => e.CaseSummary)
                    .HasColumnType("text")
                    .HasColumnName("Case_Summary");

                entity.Property(e => e.ClientName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Client_Name");

                entity.Property(e => e.ConsultantStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Consultant_Status");

                entity.Property(e => e.ConsultationId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Consultation_Id");

                entity.Property(e => e.ConsultationName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Consultation_Name");

                entity.Property(e => e.DateOfTransfer)
                    .HasColumnType("datetime")
                    .HasColumnName("Date_Of_Transfer");

                entity.Property(e => e.DocSubDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Doc_Sub_Date");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email")
                    .IsFixedLength();

                entity.Property(e => e.FillingDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Filling_Date");

                entity.Property(e => e.HearningDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Hearning_Date");

                entity.Property(e => e.LeadConsultant)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Lead_Consultant");

                entity.Property(e => e.PaymentRec).HasColumnName("Payment_Rec");

                entity.Property(e => e.Phone).HasColumnName("phone");

                entity.Property(e => e.TimeShare)
                    .HasColumnType("datetime")
                    .HasColumnName("Time_Share");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
