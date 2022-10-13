﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using OdczytDanych.entities;

#nullable disable

namespace OdczytDanych.Migrations
{
    [DbContext(typeof(PgsqlDbContext))]
    partial class PgsqlDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("OdczytDanych.entities.Temperatury", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("ID"));

                    b.Property<bool>("CzyGrzanieZalaczone")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("DataPomiaru")
                        .HasColumnType("timestamp without time zone");

                    b.Property<float>("TemperaturaGleby")
                        .HasColumnType("real");

                    b.Property<float>("TemperaturaPowietrza")
                        .HasColumnType("real");

                    b.HasKey("ID");

                    b.ToTable("temperaturies");
                });
#pragma warning restore 612, 618
        }
    }
}