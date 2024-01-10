﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using waterwatch.Data;

#nullable disable

namespace waterwatch.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("waterwatch.Models.WaterConsumption", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<int>("averageMonthlyKL")
                        .HasColumnType("integer");

                    b.Property<string>("coordinates")
                        .HasColumnType("text");

                    b.Property<string>("neighbourhood")
                        .HasColumnType("text");

                    b.Property<string>("suburb_group")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("Consumptions");
                });
#pragma warning restore 612, 618
        }
    }
}