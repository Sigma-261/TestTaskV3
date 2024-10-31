﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TestTaskV3.Data;

#nullable disable

namespace TestTaskV3.Data.Migrations
{
    [DbContext(typeof(TubeContext))]
    [Migration("20241030084458_InitCommit")]
    partial class InitCommit
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TestTask.Models.Pack", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("ID");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateUpdate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("IdTube")
                        .HasColumnType("uuid")
                        .HasColumnName("ID_TUBE");

                    b.Property<int>("Number")
                        .HasColumnType("integer")
                        .HasColumnName("NUMBER");

                    b.HasKey("Guid");

                    b.HasIndex("IdTube");

                    b.ToTable("PACK");
                });

            modelBuilder.Entity("TestTask.Models.SteelGrade", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("ID");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateUpdate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("WEIGHT");

                    b.HasKey("Guid");

                    b.ToTable("STEEL_GRADE");
                });

            modelBuilder.Entity("TestTask.Models.Tube", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("ID");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateUpdate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("IdGrade")
                        .HasColumnType("uuid")
                        .HasColumnName("ID_GRADE");

                    b.Property<bool>("IsDefect")
                        .HasColumnType("boolean")
                        .HasColumnName("IS_DEFECT");

                    b.Property<int>("Number")
                        .HasColumnType("integer")
                        .HasColumnName("NUMBER");

                    b.Property<decimal>("Weight")
                        .HasColumnType("numeric")
                        .HasColumnName("WEIGHT");

                    b.HasKey("Guid");

                    b.HasIndex("IdGrade");

                    b.ToTable("TUBE");
                });

            modelBuilder.Entity("TestTask.Models.Pack", b =>
                {
                    b.HasOne("TestTask.Models.Tube", "Tube")
                        .WithMany()
                        .HasForeignKey("IdTube")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tube");
                });

            modelBuilder.Entity("TestTask.Models.Tube", b =>
                {
                    b.HasOne("TestTask.Models.SteelGrade", "Grade")
                        .WithMany()
                        .HasForeignKey("IdGrade")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Grade");
                });
#pragma warning restore 612, 618
        }
    }
}
