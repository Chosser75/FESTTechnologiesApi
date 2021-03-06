// <auto-generated />
using System;
using FESTTechnologiesApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace FESTTechnologiesApi.Migrations
{
    [DbContext(typeof(FestDbContext))]
    [Migration("20210720120331_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("FESTTechnologiesApi.Models.Data.CityTemperatureQuery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CityName")
                        .HasColumnType("text");

                    b.Property<DateTime?>("Requested")
                        .HasColumnType("timestamp without time zone");

                    b.Property<float>("Temp")
                        .HasColumnType("real");

                    b.Property<string>("TimeZoneName")
                        .HasColumnType("text");

                    b.Property<string>("ZipCode")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("CityTemperatureQueries");
                });
#pragma warning restore 612, 618
        }
    }
}
