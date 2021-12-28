﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using common;

namespace common
{
    [DbContext(typeof(BankdbContext))]
    [Migration("20211228094354_version19")]
    partial class version19
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("common.Balances", b =>
                {
                    b.Property<int>("Balance_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Account_id")
                        .HasColumnType("int");

                    b.Property<double>("balance")
                        .HasColumnType("float");

                    b.HasKey("Balance_id");

                    b.ToTable("Balances");
                });

            modelBuilder.Entity("common.BankAccounts", b =>
                {
                    b.Property<int>("BankAccount_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Account_Date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Account_Status")
                        .HasColumnType("bit");

                    b.Property<string>("Account_type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomersCustomer_id")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("BankAccount_id");

                    b.HasIndex("CustomersCustomer_id");

                    b.ToTable("BankAccounts");
                });

            modelBuilder.Entity("common.Customers", b =>
                {
                    b.Property<string>("Customer_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Customer_age")
                        .HasColumnType("int");

                    b.Property<string>("Customer_email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Customer_identity")
                        .HasColumnType("int");

                    b.Property<string>("Customer_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Customer_phone")
                        .HasColumnType("int");

                    b.Property<bool>("Customer_status")
                        .HasColumnType("bit");

                    b.HasKey("Customer_id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("common.Departments", b =>
                {
                    b.Property<int>("Department_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Department_name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Department_id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("common.Employees", b =>
                {
                    b.Property<Guid>("Employee_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Department_id")
                        .HasColumnType("int");

                    b.Property<string>("Employee_Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Employee_identity")
                        .HasColumnType("int");

                    b.Property<string>("Employee_password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Employee_phone")
                        .HasColumnType("int");

                    b.Property<string>("Employee_username")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role_id")
                        .HasColumnType("int");

                    b.HasKey("Employee_id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("common.Roles", b =>
                {
                    b.Property<int>("Role_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Role_name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Role_id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("common.BankAccounts", b =>
                {
                    b.HasOne("common.Customers", null)
                        .WithMany("BankAccounts")
                        .HasForeignKey("CustomersCustomer_id");
                });

            modelBuilder.Entity("common.Customers", b =>
                {
                    b.Navigation("BankAccounts");
                });
#pragma warning restore 612, 618
        }
    }
}
