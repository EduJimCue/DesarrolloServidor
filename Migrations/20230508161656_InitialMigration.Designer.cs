﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Prueba.Data;

#nullable disable

namespace Prueba.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230508161656_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Prueba.Models.Gimnasio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MonthPrice")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SignUpDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Gyms");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Calle Julian Sanz Ibañez",
                            Description = "Gimnasio especializado en karate",
                            MonthPrice = 40,
                            Name = "Sankukai",
                            SignUpDate = new DateTime(2023, 5, 8, 18, 16, 55, 938, DateTimeKind.Local).AddTicks(9353)
                        },
                        new
                        {
                            Id = 2,
                            Address = "Paseo Calanda",
                            Description = "Gimnasio especializado en artes marciales mixtas",
                            MonthPrice = 30,
                            Name = "Strong Fist",
                            SignUpDate = new DateTime(2023, 5, 8, 18, 16, 55, 938, DateTimeKind.Local).AddTicks(9358)
                        },
                        new
                        {
                            Id = 3,
                            Address = "Avenida Navarra",
                            Description = "Gimnasio con multiples clases y salas de pesas",
                            MonthPrice = 50,
                            Name = "Gimnasio Delicias",
                            SignUpDate = new DateTime(2023, 5, 8, 18, 16, 55, 938, DateTimeKind.Local).AddTicks(9360)
                        });
                });

            modelBuilder.Entity("Prueba.Models.GimnasioLesson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GimnasioId")
                        .HasColumnType("int");

                    b.Property<int>("LeccionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("GymLesson");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GimnasioId = 1,
                            LeccionId = 1
                        },
                        new
                        {
                            Id = 2,
                            GimnasioId = 1,
                            LeccionId = 2
                        },
                        new
                        {
                            Id = 3,
                            GimnasioId = 2,
                            LeccionId = 3
                        },
                        new
                        {
                            Id = 4,
                            GimnasioId = 3,
                            LeccionId = 4
                        });
                });

            modelBuilder.Entity("Prueba.Models.Leccion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Hour")
                        .HasColumnType("int");

                    b.Property<int>("Minute")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Lessons");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Capacity = 35,
                            Description = "Clase de karate para gente sin experiencia",
                            Hour = 20,
                            Minute = 30,
                            Name = "Karate principiantes",
                            TeacherId = 2
                        },
                        new
                        {
                            Id = 2,
                            Capacity = 35,
                            Description = "Clase de karate para gente que lleva un tiempo practicando karate",
                            Hour = 21,
                            Minute = 30,
                            Name = "Karate avanzado",
                            TeacherId = 2
                        },
                        new
                        {
                            Id = 3,
                            Capacity = 20,
                            Description = "Arte marcial tailandesa que se especializa en codos y rodillas",
                            Hour = 17,
                            Minute = 30,
                            Name = "Muay Thai",
                            TeacherId = 2
                        },
                        new
                        {
                            Id = 4,
                            Capacity = 50,
                            Description = "Clase de zumba para todos los niveles",
                            Hour = 20,
                            Minute = 0,
                            Name = "Zumba",
                            TeacherId = 2
                        });
                });

            modelBuilder.Entity("Prueba.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Admin")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Role")
                        .HasColumnType("bit");

                    b.Property<DateTime>("SignUpDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Admin = true,
                            Name = "admin",
                            Password = "admin",
                            Role = true,
                            SignUpDate = new DateTime(2023, 5, 8, 18, 16, 55, 938, DateTimeKind.Local).AddTicks(9161),
                            Username = "admin"
                        },
                        new
                        {
                            Id = 2,
                            Admin = true,
                            Name = "teacher",
                            Password = "1111",
                            Role = true,
                            SignUpDate = new DateTime(2023, 5, 8, 18, 16, 55, 938, DateTimeKind.Local).AddTicks(9194),
                            Username = "teacher"
                        });
                });

            modelBuilder.Entity("Prueba.Models.UserLesson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("LeccionId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("UsuarioLesson");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            LeccionId = 1,
                            UsuarioId = 2
                        },
                        new
                        {
                            Id = 2,
                            LeccionId = 2,
                            UsuarioId = 2
                        },
                        new
                        {
                            Id = 3,
                            LeccionId = 3,
                            UsuarioId = 2
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
