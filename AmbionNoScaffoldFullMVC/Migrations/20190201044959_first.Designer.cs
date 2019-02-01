﻿// <auto-generated />
using AmbionNoScaffoldFullMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AmbionNoScaffoldFullMVC.Migrations
{
    [DbContext(typeof(AmbionNoScaffoldFullMVCContext))]
    [Migration("20190201044959_first")]
    partial class first
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AmbionNoScaffoldFullMVC.Models.Ambion", b =>
                {
                    b.Property<int>("AmbionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AmbionName");

                    b.HasKey("AmbionId");

                    b.ToTable("Ambion");
                });

            modelBuilder.Entity("AmbionNoScaffoldFullMVC.Models.Grade", b =>
                {
                    b.Property<int>("GradeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GradeName");

                    b.HasKey("GradeId");

                    b.ToTable("Grade");
                });

            modelBuilder.Entity("AmbionNoScaffoldFullMVC.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("StudentName");

                    b.HasKey("Id");

                    b.ToTable("Student");
                });
#pragma warning restore 612, 618
        }
    }
}
