using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AngelAPI.Entities;

public partial class PostgresContext : DbContext
{
    public PostgresContext()
    {
    }

    public PostgresContext(DbContextOptions<PostgresContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AppUser> AppUsers { get; set; }

    public virtual DbSet<AppVisitor> AppVisitors { get; set; }

    public virtual DbSet<Application> Applications { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Purpose> Purposes { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Subdivision> Subdivisions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Visitor> Visitors { get; set; }

    public virtual DbSet<Worker> Workers { get; set; }

    public virtual DbSet<WorkerSubdivision> WorkerSubdivisions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=195.191.83.168;database=postgres;username=postgres;password=P@ssw0rd32168");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("pg_catalog", "adminpack");

        modelBuilder.Entity<AppUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("app_user_pk");

            entity.ToTable("app_user");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.IdApp).HasColumnName("id_app");
            entity.Property(e => e.IdUser).HasColumnName("id_user");

            entity.HasOne(d => d.IdAppNavigation).WithMany(p => p.AppUsers)
                .HasForeignKey(d => d.IdApp)
                .HasConstraintName("app_user_fk_1");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.AppUsers)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("app_user_fk");
        });

        modelBuilder.Entity<AppVisitor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("app_visitor_pk");

            entity.ToTable("app_visitor");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.IdApp).HasColumnName("id_app");
            entity.Property(e => e.IdVisitor).HasColumnName("id_visitor");

            entity.HasOne(d => d.IdAppNavigation).WithMany(p => p.AppVisitors)
                .HasForeignKey(d => d.IdApp)
                .HasConstraintName("app_visitor_fk_1");

            entity.HasOne(d => d.IdVisitorNavigation).WithMany(p => p.AppVisitors)
                .HasForeignKey(d => d.IdVisitor)
                .HasConstraintName("app_visitor_fk");
        });

        modelBuilder.Entity<Application>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("application_pk");

            entity.ToTable("application");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.ArrivalTime).HasColumnName("arrival_time");
            entity.Property(e => e.IdPurpose).HasColumnName("id_purpose");
            entity.Property(e => e.IdSubdivision).HasColumnName("id_subdivision");
            entity.Property(e => e.IsSingle).HasColumnName("is_single");
            entity.Property(e => e.LeavingTime).HasColumnName("leaving_time");
            entity.Property(e => e.Passport).HasColumnName("passport");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.ValidatyFrom).HasColumnName("validaty_from");
            entity.Property(e => e.ValidatyTo).HasColumnName("validaty_to");

            entity.HasOne(d => d.IdPurposeNavigation).WithMany(p => p.Applications)
                .HasForeignKey(d => d.IdPurpose)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("application_fk_1");

            entity.HasOne(d => d.IdSubdivisionNavigation).WithMany(p => p.Applications)
                .HasForeignKey(d => d.IdSubdivision)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("application_fk");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("newtable_pk");

            entity.ToTable("employees");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Code)
                .HasColumnType("character varying")
                .HasColumnName("code");
            entity.Property(e => e.IdRole).HasColumnName("id_role");

            entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.IdRole)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("employees_fk");
        });

        modelBuilder.Entity<Purpose>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("purposes_pk");

            entity.ToTable("purposes");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("roles_pk");

            entity.ToTable("roles");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<Subdivision>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("subdivisions_pk");

            entity.ToTable("subdivisions");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pk");

            entity.ToTable("users");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Login)
                .HasColumnType("character varying")
                .HasColumnName("login");
            entity.Property(e => e.Password)
                .HasColumnType("character varying")
                .HasColumnName("password");
            entity.Property(e => e.Token)
                .HasColumnType("character varying")
                .HasColumnName("token");
        });

        modelBuilder.Entity<Visitor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("visitors_pk");

            entity.ToTable("visitors");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.DateBirth).HasColumnName("date_birth");
            entity.Property(e => e.Email)
                .HasColumnType("character varying")
                .HasColumnName("email");
            entity.Property(e => e.IsBlacklist).HasColumnName("is_blacklist");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.Notes)
                .HasColumnType("character varying")
                .HasColumnName("notes");
            entity.Property(e => e.Numbers)
                .HasColumnType("character varying")
                .HasColumnName("numbers");
            entity.Property(e => e.Organization)
                .HasColumnType("character varying")
                .HasColumnName("organization");
            entity.Property(e => e.Patronymic)
                .HasColumnType("character varying")
                .HasColumnName("patronymic");
            entity.Property(e => e.Phone)
                .HasColumnType("character varying")
                .HasColumnName("phone");
            entity.Property(e => e.Series)
                .HasColumnType("character varying")
                .HasColumnName("series");
            entity.Property(e => e.Surname)
                .HasColumnType("character varying")
                .HasColumnName("surname");
        });

        modelBuilder.Entity<Worker>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("workers_pk");

            entity.ToTable("workers");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Fullname)
                .HasColumnType("character varying")
                .HasColumnName("fullname");
        });

        modelBuilder.Entity<WorkerSubdivision>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("worker_subdivision_pk");

            entity.ToTable("worker_subdivision");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.IdSubdivision).HasColumnName("id_subdivision");
            entity.Property(e => e.IdWorker).HasColumnName("id_worker");

            entity.HasOne(d => d.IdSubdivisionNavigation).WithMany(p => p.WorkerSubdivisions)
                .HasForeignKey(d => d.IdSubdivision)
                .HasConstraintName("worker_subdivision_fk_1");

            entity.HasOne(d => d.IdWorkerNavigation).WithMany(p => p.WorkerSubdivisions)
                .HasForeignKey(d => d.IdWorker)
                .HasConstraintName("worker_subdivision_fk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
