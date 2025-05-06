using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TestDemo.Models;

namespace TestDemo.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MaterialTypeImport> MaterialTypeImports { get; set; }

    public virtual DbSet<PartnerProductsImport> PartnerProductsImports { get; set; }

    public virtual DbSet<PartnersImport> PartnersImports { get; set; }

    public virtual DbSet<ProductTypeImport> ProductTypeImports { get; set; }

    public virtual DbSet<ProductsImport> ProductsImports { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=DemoTest;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MaterialTypeImport>(entity =>
        {
            entity.HasKey(e => e.MaterialType);

            entity.ToTable("Material_type_import");

            entity.Property(e => e.MaterialType)
                .HasMaxLength(50)
                .HasColumnName("material_type");
            entity.Property(e => e.PercentageOfDefectiveMaterial)
                .HasMaxLength(50)
                .HasColumnName("percentage_of_defective_material");
        });

        modelBuilder.Entity<PartnerProductsImport>(entity =>
        {
            entity.ToTable("Partner_products_import");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.PartnerName)
                .HasMaxLength(50)
                .HasColumnName("partner_name");
            entity.Property(e => e.ProductName)
                .HasMaxLength(100)
                .HasColumnName("product_name");
            entity.Property(e => e.QuantityOfProducts).HasColumnName("quantity_of_products");
            entity.Property(e => e.SaleDate).HasColumnName("sale_date");

            entity.HasOne(d => d.PartnerNameNavigation).WithMany(p => p.PartnerProductsImports)
                .HasForeignKey(d => d.PartnerName)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Partner_products_import_Partners_import");

            entity.HasOne(d => d.ProductNameNavigation).WithMany(p => p.PartnerProductsImports)
                .HasForeignKey(d => d.ProductName)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Partner_products_import_Products_import");
        });

        modelBuilder.Entity<PartnersImport>(entity =>
        {
            entity.HasKey(e => e.PartnerName);

            entity.ToTable("Partners_import");

            entity.Property(e => e.PartnerName)
                .HasMaxLength(50)
                .HasColumnName("partner_name");
            entity.Property(e => e.Director)
                .HasMaxLength(50)
                .HasColumnName("director");
            entity.Property(e => e.Discount).HasColumnName("discount");
            entity.Property(e => e.PartnerEmail)
                .HasMaxLength(50)
                .HasColumnName("partner_email");
            entity.Property(e => e.PartnerPhone)
                .HasMaxLength(50)
                .HasColumnName("partner_phone");
            entity.Property(e => e.PartnerType)
                .HasMaxLength(50)
                .HasColumnName("partner_type");
            entity.Property(e => e.PartnersLegalAddress)
                .HasMaxLength(100)
                .HasColumnName("partners_legal_address");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.Tin)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("TIN");
        });

        modelBuilder.Entity<ProductTypeImport>(entity =>
        {
            entity.HasKey(e => e.ProductType);

            entity.ToTable("Product_type_import");

            entity.Property(e => e.ProductType)
                .HasMaxLength(50)
                .HasColumnName("product_type");
            entity.Property(e => e.ProductTypeCoefficient)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("product_type_coefficient");
        });

        modelBuilder.Entity<ProductsImport>(entity =>
        {
            entity.HasKey(e => e.ProductName);

            entity.ToTable("Products_import");

            entity.Property(e => e.ProductName)
                .HasMaxLength(100)
                .HasColumnName("product_name");
            entity.Property(e => e.Article).HasColumnName("article");
            entity.Property(e => e.MinimumCostForPartner)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("minimum_cost_for_partner");
            entity.Property(e => e.ProductType)
                .HasMaxLength(50)
                .HasColumnName("product_type");

            entity.HasOne(d => d.ProductTypeNavigation).WithMany(p => p.ProductsImports)
                .HasForeignKey(d => d.ProductType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_import_Product_type_import");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
