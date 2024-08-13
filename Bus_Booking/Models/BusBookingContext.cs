using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace rashi_try.Models;

public partial class BusBookingContext : DbContext
{
    public BusBookingContext()
    {
    }

    public BusBookingContext(DbContextOptions<BusBookingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bus> Buses { get; set; }

    public virtual DbSet<Seat> Seats { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\ProjectModels;Initial Catalog=Bus_Booking;Integrated Security=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bus>(entity =>
        {
            entity.HasKey(e => e.BusId).HasName("PK__Bus__6AD3C495434F0833");

            entity.ToTable("Bus");

            entity.Property(e => e.BusId)
                .ValueGeneratedNever()
                .HasColumnName("bus_Id");
            entity.Property(e => e.BusNumber).HasColumnName("bus_Number");
            entity.Property(e => e.BusType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("bus_Type");
            entity.Property(e => e.Capacity).HasColumnName("capacity");
        });

        modelBuilder.Entity<Seat>(entity =>
        {
            entity.HasKey(e => e.SeatId).HasName("PK__Seat__906CE87486DBC165");

            entity.ToTable("Seat");

            entity.Property(e => e.SeatId)
                .ValueGeneratedNever()
                .HasColumnName("seat_Id");
            entity.Property(e => e.BusId).HasColumnName("bus_Id");
            entity.Property(e => e.IsAvailable).HasColumnName("is_Available");
            entity.Property(e => e.SeatNumber).HasColumnName("seatNumber");

            entity.HasOne(d => d.Bus).WithMany(p => p.Seats)
                .HasForeignKey(d => d.BusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Seat_Bus");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__B9BF3327B5100F31");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("user_Id");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.IsLoggedIn).HasColumnName("is_Logged_In");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("user_Name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
