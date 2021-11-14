using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ApiPraktika.Models
{
    public partial class praktikaVarvaninContext : DbContext
    {
        public praktikaVarvaninContext()
        {
        }

        public praktikaVarvaninContext(DbContextOptions<praktikaVarvaninContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Building> Buildings { get; set; }
        public virtual DbSet<Cabinet> Cabinets { get; set; }
        public virtual DbSet<CabinetAttribute> CabinetAttributes { get; set; }
        public virtual DbSet<CabinetComposition> CabinetCompositions { get; set; }
        public virtual DbSet<Report> Reports { get; set; }
        public virtual DbSet<ReportType> ReportTypes { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=194.32.248.98;user id=andrv;password=Andrv123!;persistsecurityinfo=True;database=praktikaVarvanin", Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.7.36-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("latin1");

            modelBuilder.Entity<Building>(entity =>
            {
                entity.HasKey(e => e.IdBuilding)
                    .HasName("PRIMARY");

                entity.ToTable("buildings");

                entity.Property(e => e.IdBuilding)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_building");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name")
                    .HasComment("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<Cabinet>(entity =>
            {
                entity.HasKey(e => e.IdCabinet)
                    .HasName("PRIMARY");

                entity.ToTable("cabinets");

                entity.HasIndex(e => e.BuildingId, "building_id");

                entity.Property(e => e.IdCabinet)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_cabinet");

                entity.Property(e => e.BuildingId)
                    .HasColumnType("int(11)")
                    .HasColumnName("building_id");

                entity.Property(e => e.CabinetImage)
                    .IsRequired()
                    .HasMaxLength(5000)
                    .HasColumnName("cabinet_image");

                entity.Property(e => e.CabinetNumber)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("cabinet_number")
                    .HasComment("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.GeneralInformation)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .HasColumnName("general_information")
                    .HasComment("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.HasOne(d => d.Building)
                    .WithMany(p => p.Cabinets)
                    .HasForeignKey(d => d.BuildingId)
                    .HasConstraintName("cabinets_ibfk_1");
            });

            modelBuilder.Entity<CabinetAttribute>(entity =>
            {
                entity.HasKey(e => e.IdAttribute)
                    .HasName("PRIMARY");

                entity.ToTable("cabinet_attributes");

                entity.Property(e => e.IdAttribute)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_attribute");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name")
                    .HasComment("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<CabinetComposition>(entity =>
            {
                entity.HasKey(e => e.IdCabinetCompositions)
                    .HasName("PRIMARY");

                entity.ToTable("cabinet_compositions");

                entity.HasIndex(e => e.AttributeId, "attribute_id");

                entity.HasIndex(e => e.CabinetId, "cabinet_id");

                entity.Property(e => e.IdCabinetCompositions)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_cabinet_compositions");

                entity.Property(e => e.AttributeId)
                    .HasColumnType("int(11)")
                    .HasColumnName("attribute_id");

                entity.Property(e => e.CabinetId)
                    .HasColumnType("int(11)")
                    .HasColumnName("cabinet_id");

                entity.Property(e => e.Value)
                    .HasMaxLength(1000)
                    .HasColumnName("value")
                    .HasComment("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.HasOne(d => d.Attribute)
                    .WithMany(p => p.CabinetCompositions)
                    .HasForeignKey(d => d.AttributeId)
                    .HasConstraintName("cabinet_compositions_ibfk_2");

                entity.HasOne(d => d.Cabinet)
                    .WithMany(p => p.CabinetCompositions)
                    .HasForeignKey(d => d.CabinetId)
                    .HasConstraintName("cabinet_compositions_ibfk_1");
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity.HasKey(e => e.IdReport)
                    .HasName("PRIMARY");

                entity.ToTable("reports");

                entity.HasIndex(e => e.CabinetId, "cabinet_id");

                entity.HasIndex(e => e.ReportTypeId, "report_type_id");

                entity.HasIndex(e => e.UserId, "user_id");

                entity.Property(e => e.IdReport)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_report");

                entity.Property(e => e.CabinetId)
                    .HasColumnType("int(11)")
                    .HasColumnName("cabinet_id");

                entity.Property(e => e.Comment)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .HasColumnName("comment")
                    .HasComment("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.DateOfLocations)
                    .HasColumnType("datetime")
                    .HasColumnName("date_of_locations");

                entity.Property(e => e.Images)
                    .IsRequired()
                    .HasMaxLength(5000)
                    .HasColumnName("images");

                entity.Property(e => e.ReportTypeId)
                    .HasColumnType("int(11)")
                    .HasColumnName("report_type_id");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(11)")
                    .HasColumnName("user_id");

                entity.HasOne(d => d.Cabinet)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(d => d.CabinetId)
                    .HasConstraintName("reports_ibfk_2");

                entity.HasOne(d => d.ReportType)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(d => d.ReportTypeId)
                    .HasConstraintName("reports_ibfk_3");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("reports_ibfk_1");
            });

            modelBuilder.Entity<ReportType>(entity =>
            {
                entity.HasKey(e => e.IdReportType)
                    .HasName("PRIMARY");

                entity.ToTable("report_types");

                entity.Property(e => e.IdReportType)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_report_type");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name")
                    .HasComment("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.IdRole)
                    .HasName("PRIMARY");

                entity.ToTable("roles");

                entity.HasIndex(e => e.Name, "name")
                    .IsUnique();

                entity.Property(e => e.IdRole)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_role");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasComment("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PRIMARY");

                entity.ToTable("users");

                entity.HasIndex(e => e.Login, "login")
                    .IsUnique();

                entity.HasIndex(e => e.RoleId, "role_id");

                entity.Property(e => e.IdUser)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_user");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("first_name")
                    .HasComment("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("last_name")
                    .HasComment("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasColumnName("login")
                    .HasComment("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.MiddleName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("middle_name")
                    .HasComment("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("password")
                    .HasComment("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.RoleId)
                    .HasColumnType("int(11)")
                    .HasColumnName("role_id");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("users_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
