﻿// <auto-generated />
using System;
using Forpost.Store.Postgres;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Forpost.Store.Migrations.Migrations
{
    [DbContext(typeof(ForpostContextPostgres))]
    partial class ForpostContextPostgresModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Forpost.Domain.Catalogs.Category.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Forpost.Domain.Catalogs.Contractors.Contractor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("DeletedById")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UpdatedById")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Contractors");
                });

            modelBuilder.Entity("Forpost.Domain.Catalogs.Employees.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("DeletedById")
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<string>("Patronymic")
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<string>("Post")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UpdatedById")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Forpost.Domain.Catalogs.Operations.Operation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Operations");
                });

            modelBuilder.Entity("Forpost.Domain.Catalogs.Products.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("DeletedById")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UpdatedById")
                        .HasColumnType("uuid");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Forpost.Domain.Catalogs.Roles.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Forpost.Domain.Catalogs.Steps.Step", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal>("Cost")
                        .HasColumnType("numeric");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("interval");

                    b.Property<Guid>("OperationId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TechCardId")
                        .HasColumnType("uuid");

                    b.Property<int>("UnitOfMeasure")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("OperationId");

                    b.HasIndex("TechCardId");

                    b.ToTable("Steps");
                });

            modelBuilder.Entity("Forpost.Domain.Catalogs.Storages.Storage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("DeletedById")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<Guid>("ResponsibleId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UpdatedById")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ResponsibleId")
                        .IsUnique();

                    b.ToTable("Storages");
                });

            modelBuilder.Entity("Forpost.Domain.Catalogs.TechCardItems.TechCardItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<Guid>("TechCardId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("TechCardId");

                    b.ToTable("TechCardItems");
                });

            modelBuilder.Entity("Forpost.Domain.Catalogs.TechCardSteps.TechCardStep", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Number")
                        .HasColumnType("integer");

                    b.Property<Guid>("StepId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TechCardId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("StepId");

                    b.HasIndex("TechCardId");

                    b.ToTable("TechCardSteps");
                });

            modelBuilder.Entity("Forpost.Domain.Catalogs.TechCards.TechCard", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("DeletedById")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UpdatedById")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("ProductId");

                    b.ToTable("TechCards");
                });

            modelBuilder.Entity("Forpost.Domain.FileStorage.File", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ContentType")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<Guid>("ParentId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("Forpost.Domain.InvoiceManagement.Invoice", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ContractorId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("DateShipment")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("DaysShipment")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("DeletedById")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<decimal>("PaymentPercentage")
                        .HasColumnType("numeric");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UpdatedById")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ContractorId");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("Forpost.Domain.ProductCreating.CompletedProduct.CompletedProduct", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("InvoiceId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ManufacturingProcessId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ManufacturingProcessId")
                        .IsUnique();

                    b.HasIndex("ProductId");

                    b.ToTable("CompletedProducts");
                });

            modelBuilder.Entity("Forpost.Domain.ProductCreating.Issue.Issue", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uuid");

                    b.Property<int>("CurrentQuantity")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("DeletedById")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset?>("EndTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("ExecutorId")
                        .HasColumnType("uuid");

                    b.Property<int>("IssueStatus")
                        .HasColumnType("integer");

                    b.Property<Guid>("ManufacturingProcessId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ResponsibleId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("StartTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("StepId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UpdatedById")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ExecutorId");

                    b.HasIndex("ManufacturingProcessId");

                    b.HasIndex("ResponsibleId");

                    b.HasIndex("StepId");

                    b.ToTable("Issues");
                });

            modelBuilder.Entity("Forpost.Domain.ProductCreating.ManufacturingProcesses.ManufacturingProcess", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("BatchNumber")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uuid");

                    b.Property<int>("CurrentQuantity")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("DeletedById")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("EndTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("StartTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<int>("TargetQuantity")
                        .HasColumnType("integer");

                    b.Property<Guid>("TechnologicalCardId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UpdatedById")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("TechnologicalCardId");

                    b.ToTable("ManufacturingProcesses");
                });

            modelBuilder.Entity("Forpost.Domain.ProductCreating.ProductDevelopment.ProductDevelopment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ManufacturingProcessId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<string>("SerialNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("SettingOption")
                        .HasColumnType("integer");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("ProductDevelopments");
                });

            modelBuilder.Entity("Forpost.Domain.SortOut.InvoiceProduct", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("InvoiceId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceId");

                    b.HasIndex("ProductId");

                    b.ToTable("InvoiceProducts");
                });

            modelBuilder.Entity("Forpost.Domain.SortOut.ProductVersion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("DeletedById")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UpdatedById")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductVersions");
                });

            modelBuilder.Entity("Forpost.Domain.SortOut.StorageProduct", b =>
                {
                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("StorageId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<string>("StorageName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UnitOfMeasure")
                        .HasColumnType("integer");

                    b.HasKey("ProductId", "StorageId");

                    b.HasIndex("StorageId");

                    b.HasIndex("ProductId", "StorageId")
                        .IsUnique();

                    b.ToTable("StorageProducts");
                });

            modelBuilder.Entity("Forpost.Store.Postgres.OutboxMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Error")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("OccuredOnUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset?>("ProcessedOnUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("OutboxMessages");
                });

            modelBuilder.Entity("Forpost.Domain.Catalogs.Employees.Employee", b =>
                {
                    b.HasOne("Forpost.Domain.Catalogs.Roles.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Forpost.Domain.Catalogs.Products.Product", b =>
                {
                    b.HasOne("Forpost.Domain.Catalogs.Category.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoryId");
                });

            modelBuilder.Entity("Forpost.Domain.Catalogs.Steps.Step", b =>
                {
                    b.HasOne("Forpost.Domain.Catalogs.Operations.Operation", null)
                        .WithMany()
                        .HasForeignKey("OperationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Forpost.Domain.Catalogs.TechCards.TechCard", null)
                        .WithMany()
                        .HasForeignKey("TechCardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Forpost.Domain.Catalogs.Storages.Storage", b =>
                {
                    b.HasOne("Forpost.Domain.Catalogs.Employees.Employee", null)
                        .WithOne()
                        .HasForeignKey("Forpost.Domain.Catalogs.Storages.Storage", "ResponsibleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Forpost.Domain.Catalogs.TechCardItems.TechCardItem", b =>
                {
                    b.HasOne("Forpost.Domain.Catalogs.Products.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Forpost.Domain.Catalogs.TechCards.TechCard", null)
                        .WithMany()
                        .HasForeignKey("TechCardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Forpost.Domain.Catalogs.TechCardSteps.TechCardStep", b =>
                {
                    b.HasOne("Forpost.Domain.Catalogs.Steps.Step", null)
                        .WithMany()
                        .HasForeignKey("StepId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Forpost.Domain.Catalogs.TechCards.TechCard", null)
                        .WithMany()
                        .HasForeignKey("TechCardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Forpost.Domain.Catalogs.TechCards.TechCard", b =>
                {
                    b.HasOne("Forpost.Domain.Catalogs.Employees.Employee", null)
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Forpost.Domain.Catalogs.Products.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Forpost.Domain.InvoiceManagement.Invoice", b =>
                {
                    b.HasOne("Forpost.Domain.Catalogs.Contractors.Contractor", null)
                        .WithMany()
                        .HasForeignKey("ContractorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Forpost.Domain.ProductCreating.CompletedProduct.CompletedProduct", b =>
                {
                    b.HasOne("Forpost.Domain.ProductCreating.ManufacturingProcesses.ManufacturingProcess", null)
                        .WithOne()
                        .HasForeignKey("Forpost.Domain.ProductCreating.CompletedProduct.CompletedProduct", "ManufacturingProcessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Forpost.Domain.Catalogs.Products.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Forpost.Domain.ProductCreating.Issue.Issue", b =>
                {
                    b.HasOne("Forpost.Domain.Catalogs.Employees.Employee", null)
                        .WithMany()
                        .HasForeignKey("ExecutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Forpost.Domain.ProductCreating.ManufacturingProcesses.ManufacturingProcess", null)
                        .WithMany()
                        .HasForeignKey("ManufacturingProcessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Forpost.Domain.Catalogs.Employees.Employee", null)
                        .WithMany()
                        .HasForeignKey("ResponsibleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Forpost.Domain.Catalogs.Steps.Step", null)
                        .WithMany()
                        .HasForeignKey("StepId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Forpost.Domain.ProductCreating.ManufacturingProcesses.ManufacturingProcess", b =>
                {
                    b.HasOne("Forpost.Domain.Catalogs.TechCards.TechCard", null)
                        .WithMany()
                        .HasForeignKey("TechnologicalCardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Forpost.Domain.SortOut.InvoiceProduct", b =>
                {
                    b.HasOne("Forpost.Domain.InvoiceManagement.Invoice", null)
                        .WithMany()
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Forpost.Domain.Catalogs.Products.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Forpost.Domain.SortOut.ProductVersion", b =>
                {
                    b.HasOne("Forpost.Domain.Catalogs.Products.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Forpost.Domain.SortOut.StorageProduct", b =>
                {
                    b.HasOne("Forpost.Domain.Catalogs.Products.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Forpost.Domain.Catalogs.Storages.Storage", null)
                        .WithMany()
                        .HasForeignKey("StorageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
