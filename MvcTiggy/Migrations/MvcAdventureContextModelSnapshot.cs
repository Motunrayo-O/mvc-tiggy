﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MvcTiggy.Models;

namespace MvcTiggy.Migrations
{
    [DbContext(typeof(MvcAdventureContext))]
    partial class MvcAdventureContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846");

            modelBuilder.Entity("MvcTiggy.Models.Adventure", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<decimal>("EstimatedCost");

                    b.Property<string>("Name");

                    b.Property<DateTime>("PlannedDate");

                    b.HasKey("ID");

                    b.ToTable("Adventure");
                });
#pragma warning restore 612, 618
        }
    }
}