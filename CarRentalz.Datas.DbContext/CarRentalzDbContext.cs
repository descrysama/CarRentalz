using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using CarRentalz.Datas.Entities;

namespace CarRentalz.Datas.CarRentalzDbContextNameSpace;

public partial class CarRentalzDbContext : DbContext, IDisposable
{
    public CarRentalzDbContext()
    {
    }

    public CarRentalzDbContext(DbContextOptions<CarRentalzDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<AdminGrade> AdminGrades { get; set; }

    public virtual DbSet<Agency> Agencies { get; set; }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Car> Cars { get; set; }

    public virtual DbSet<CarRating> CarRatings { get; set; }

    public virtual DbSet<CarSetting> CarSettings { get; set; }

    public virtual DbSet<FuelEnum> FuelEnums { get; set; }

    public virtual DbSet<GearboxEnum> GearboxEnums { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Rent> Rents { get; set; }

    public virtual DbSet<TypeEnum> TypeEnums { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRating> UserRatings { get; set; }

    public virtual DbSet<Verification> Verifications { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("admin");

            entity.HasIndex(e => e.AdminGradeId, "admin_admin_grade_id");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.AdminGradeId)
                .HasDefaultValueSql("'1'")
                .HasColumnType("int(11)")
                .HasColumnName("admin_grade_id");
            entity.Property(e => e.Email)
                .HasMaxLength(256)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .HasMaxLength(256)
                .HasColumnName("password");
            entity.Property(e => e.ProfilePicture)
                .HasMaxLength(256)
                .HasColumnName("profile_picture");
            entity.Property(e => e.Pseudo)
                .HasMaxLength(256)
                .HasColumnName("pseudo");

            entity.HasOne(d => d.AdminGrade).WithMany(p => p.Admins)
                .HasForeignKey(d => d.AdminGradeId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("admin_admin_grade_id	");
        });

        modelBuilder.Entity<AdminGrade>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("admin_grade");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Value)
                .HasMaxLength(256)
                .HasColumnName("value");
        });

        modelBuilder.Entity<Agency>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("agency");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasMaxLength(256)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("brands");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.BrandName)
                .HasMaxLength(256)
                .HasColumnName("brand_name");
        });

        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("car");

            entity.HasIndex(e => e.AgencyId, "car_agency_id");

            entity.HasIndex(e => e.BrandId, "car_brand_id");

            entity.HasIndex(e => e.UserId, "car_user_id");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.AgencyId)
                .HasColumnType("int(11)")
                .HasColumnName("agency_id");
            entity.Property(e => e.BrandId)
                .HasColumnType("int(11)")
                .HasColumnName("brand_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasMaxLength(256)
                .HasColumnName("description");
            entity.Property(e => e.Model)
                .HasMaxLength(256)
                .HasColumnName("model");
            entity.Property(e => e.UserId)
                .HasColumnType("int(11)")
                .HasColumnName("user_id");

            entity.HasOne(d => d.Agency).WithMany(p => p.Cars)
                .HasForeignKey(d => d.AgencyId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("agency_id");

            entity.HasOne(d => d.Brand).WithMany(p => p.Cars)
                .HasForeignKey(d => d.BrandId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("car");

            entity.HasOne(d => d.User).WithMany(p => p.Cars)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("car_id");
        });

        modelBuilder.Entity<CarRating>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("car_rating");

            entity.HasIndex(e => e.CarId, "car_rating_car_id");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.CarId)
                .HasColumnType("int(11)")
                .HasColumnName("car_id");
            entity.Property(e => e.Message)
                .HasMaxLength(256)
                .HasColumnName("message");
            entity.Property(e => e.NoteValue)
                .HasColumnType("int(11)")
                .HasColumnName("note_value");

            entity.HasOne(d => d.Car).WithMany(p => p.CarRatings)
                .HasForeignKey(d => d.CarId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("car_rating_car_id");
        });

        modelBuilder.Entity<CarSetting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("car_settings");

            entity.HasIndex(e => e.CarId, "car_settings_car_id");

            entity.HasIndex(e => e.FuelId, "car_settings_fuel_id");

            entity.HasIndex(e => e.GearboxId, "car_settings_gearbox_id");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.AirConditioning).HasColumnName("air_conditioning");
            entity.Property(e => e.AllowedKilometers)
                .HasColumnType("int(11)")
                .HasColumnName("allowed_kilometers");
            entity.Property(e => e.CarId)
                .HasColumnType("int(11)")
                .HasColumnName("car_id");
            entity.Property(e => e.DailyCost).HasColumnName("daily_cost");
            entity.Property(e => e.DrivingAssist)
                .HasColumnType("int(11)")
                .HasColumnName("driving_assist");
            entity.Property(e => e.FuelId)
                .HasColumnType("int(11)")
                .HasColumnName("fuel_id");
            entity.Property(e => e.GearboxId)
                .HasColumnType("int(11)")
                .HasColumnName("gearbox_id");

            entity.HasOne(d => d.Car).WithMany(p => p.CarSettings)
                .HasForeignKey(d => d.CarId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("car_settings_car_id");

            entity.HasOne(d => d.Fuel).WithMany(p => p.CarSettings)
                .HasForeignKey(d => d.FuelId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("car_settings_fuel_id");

            entity.HasOne(d => d.Gearbox).WithMany(p => p.CarSettings)
                .HasForeignKey(d => d.GearboxId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("car_settings_gearbox_id");
        });

        modelBuilder.Entity<FuelEnum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("fuel_enum");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Value)
                .HasMaxLength(256)
                .HasColumnName("value");
        });

        modelBuilder.Entity<GearboxEnum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("gearbox_enum");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Value)
                .HasMaxLength(256)
                .HasColumnName("value");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("notification");

            entity.HasIndex(e => e.TypeId, "notification_type_id");

            entity.HasIndex(e => e.UserId, "notification_user_id");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Message)
                .HasMaxLength(256)
                .HasColumnName("message");
            entity.Property(e => e.TypeId)
                .HasColumnType("int(11)")
                .HasColumnName("type_id");
            entity.Property(e => e.UserId)
                .HasColumnType("int(11)")
                .HasColumnName("user_id");

            entity.HasOne(d => d.Type).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("notification_type_id");

            entity.HasOne(d => d.User).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("notification_user_id");
        });

        modelBuilder.Entity<Rent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("rent");

            entity.HasIndex(e => e.CarId, "rent_car_id");

            entity.HasIndex(e => e.UserId, "rent_user_id");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.CarId)
                .HasColumnType("int(11)")
                .HasColumnName("car_id");
            entity.Property(e => e.EndingDate)
                .HasColumnType("date")
                .HasColumnName("ending_date");
            entity.Property(e => e.StartingDate)
                .HasColumnType("date")
                .HasColumnName("starting_date");
            entity.Property(e => e.UserId)
                .HasColumnType("int(11)")
                .HasColumnName("user_id");

            entity.HasOne(d => d.Car).WithMany(p => p.Rents)
                .HasForeignKey(d => d.CarId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("rent_car_id");

            entity.HasOne(d => d.User).WithMany(p => p.Rents)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("rent_user_id");
        });

        modelBuilder.Entity<TypeEnum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("type_enum");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Value)
                .HasMaxLength(256)
                .HasColumnName("value");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("user");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(256)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .HasMaxLength(256)
                .HasColumnName("password");
            entity.Property(e => e.ProfilePicture)
                .HasMaxLength(256)
                .HasColumnName("profile_picture");
            entity.Property(e => e.Pseudo)
                .HasMaxLength(256)
                .HasColumnName("pseudo");
        });

        modelBuilder.Entity<UserRating>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("user_rating");

            entity.HasIndex(e => e.UserId, "user_rating_user_id");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Message)
                .HasMaxLength(256)
                .HasColumnName("message");
            entity.Property(e => e.NoteValue)
                .HasColumnType("int(11)")
                .HasColumnName("note_value");
            entity.Property(e => e.UserId)
                .HasColumnType("int(11)")
                .HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.UserRatings)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("user_rating_user_id");
        });

        modelBuilder.Entity<Verification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("verification");

            entity.HasIndex(e => e.UserId, "verification_user_id");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Status)
                .HasColumnType("int(11)")
                .HasColumnName("status");
            entity.Property(e => e.UserId)
                .HasColumnType("int(11)")
                .HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Verifications)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("verification_user_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
