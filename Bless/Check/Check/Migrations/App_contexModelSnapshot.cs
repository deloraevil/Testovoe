﻿// <auto-generated />
using System;
using Check;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Check.Migrations
{
    [DbContext(typeof(App_contex))]
    partial class App_contexModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Check.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Fio")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.Property<DateOnly>("dateOnly")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("Fio");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
