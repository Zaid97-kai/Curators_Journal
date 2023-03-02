﻿// <auto-generated />
using System;
using API.Models.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(CuratorMagazineContext))]
    partial class CuratorMagazineContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("API.Models.Entities.Domains.Division", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Divisions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "УВР"
                        },
                        new
                        {
                            Id = 2,
                            Name = "ИАНТЭ"
                        },
                        new
                        {
                            Id = 3,
                            Name = "ФМФ"
                        },
                        new
                        {
                            Id = 4,
                            Name = "ИАЭП"
                        },
                        new
                        {
                            Id = 5,
                            Name = "ИКТЗИ"
                        },
                        new
                        {
                            Id = 6,
                            Name = "КИТ"
                        },
                        new
                        {
                            Id = 7,
                            Name = "ТК"
                        });
                });

            modelBuilder.Entity("API.Models.Entities.Domains.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Comment")
                        .HasColumnType("text");

                    b.Property<DateTime?>("DateEvent")
                        .HasColumnType("timestamp with time zone");

                    b.Property<byte[]>("EventPhoto")
                        .HasColumnType("bytea");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Events");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Студвесна"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Первый код"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Мистер КИТ"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Мисс КИТ"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Квартирник"
                        });
                });

            modelBuilder.Entity("API.Models.Entities.Domains.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Groups");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "4101"
                        },
                        new
                        {
                            Id = 2,
                            Name = "4102"
                        },
                        new
                        {
                            Id = 3,
                            Name = "4131"
                        },
                        new
                        {
                            Id = 4,
                            Name = "4132"
                        },
                        new
                        {
                            Id = 5,
                            Name = "3101"
                        },
                        new
                        {
                            Id = 6,
                            Name = "3101"
                        },
                        new
                        {
                            Id = 7,
                            Name = "2101"
                        });
                });

            modelBuilder.Entity("API.Models.Entities.Domains.GroupEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("EventId")
                        .HasColumnType("integer");

                    b.Property<int?>("GroupId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("GroupId");

                    b.ToTable("GroupEvents");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EventId = 1,
                            GroupId = 2
                        },
                        new
                        {
                            Id = 2,
                            EventId = 2,
                            GroupId = 2
                        },
                        new
                        {
                            Id = 3,
                            EventId = 2,
                            GroupId = 2
                        },
                        new
                        {
                            Id = 4,
                            EventId = 2,
                            GroupId = 2
                        },
                        new
                        {
                            Id = 5,
                            EventId = 2,
                            GroupId = 2
                        });
                });

            modelBuilder.Entity("API.Models.Entities.Domains.Parent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("WorkName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Parents");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Иванов Иван Иванович",
                            Phone = "3(67)992-09-22",
                            WorkName = "Ассистент менеджера по продажам"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Иванова Инна Ивановна",
                            Phone = "429(521)755-17-83",
                            WorkName = "Преподаватель"
                        });
                });

            modelBuilder.Entity("API.Models.Entities.Domains.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Administrator"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Deputy Director"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Curator"
                        });
                });

            modelBuilder.Entity("API.Models.Entities.Domains.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("DivisionId")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("EventId")
                        .HasColumnType("integer");

                    b.Property<int?>("FatherId")
                        .HasColumnType("integer");

                    b.Property<int?>("GroupId")
                        .HasColumnType("integer");

                    b.Property<int?>("MotherId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<byte[]>("ProfilePhoto")
                        .HasColumnType("bytea");

                    b.Property<int?>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("DivisionId");

                    b.HasIndex("EventId");

                    b.HasIndex("FatherId");

                    b.HasIndex("GroupId");

                    b.HasIndex("MotherId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "342340, Волгоградская область, город Москва, пл. Ленина, 80",
                            DivisionId = 1,
                            Email = "ripogroyippe-2863@yopmail.com",
                            Name = "Administrator",
                            Password = "Administrator",
                            Phone = "9(421)001-31-15",
                            RoleId = 1
                        },
                        new
                        {
                            Id = 2,
                            Address = "383478, Брянская область, город Люберцы, ул. Ломоносова, 72",
                            DivisionId = 6,
                            Email = "croummauroicegeu-1550@yopmail.com",
                            Name = "Associate Director",
                            Password = "Associate Director",
                            Phone = "608(51)713-94-41",
                            RoleId = 2
                        },
                        new
                        {
                            Id = 3,
                            Address = "342340, Волгоградская область, город Москва, пл. Ленина, 80",
                            DivisionId = 6,
                            Email = "treledoddoiseu-5434@yopmail.com",
                            FatherId = 1,
                            GroupId = 4,
                            MotherId = 2,
                            Name = "Рахимов Ранис Рамилевич",
                            Password = "Рахимов Ранис Рамилевич",
                            Phone = "9(421)001-31-15",
                            RoleId = 3
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.DataProtection.EntityFrameworkCore.DataProtectionKey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("FriendlyName")
                        .HasColumnType("text");

                    b.Property<string>("Xml")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("DataProtectionKeys");
                });

            modelBuilder.Entity("API.Models.Entities.Domains.GroupEvent", b =>
                {
                    b.HasOne("API.Models.Entities.Domains.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId");

                    b.HasOne("API.Models.Entities.Domains.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId");

                    b.Navigation("Event");

                    b.Navigation("Group");
                });

            modelBuilder.Entity("API.Models.Entities.Domains.User", b =>
                {
                    b.HasOne("API.Models.Entities.Domains.Division", "Division")
                        .WithMany("Users")
                        .HasForeignKey("DivisionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("API.Models.Entities.Domains.Event", "Event")
                        .WithMany("Users")
                        .HasForeignKey("EventId");

                    b.HasOne("API.Models.Entities.Domains.Parent", "Father")
                        .WithMany("FatherChildrens")
                        .HasForeignKey("FatherId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("API.Models.Entities.Domains.Group", "Group")
                        .WithMany("Users")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("API.Models.Entities.Domains.Parent", "Mother")
                        .WithMany("MotherChildrens")
                        .HasForeignKey("MotherId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("API.Models.Entities.Domains.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Division");

                    b.Navigation("Event");

                    b.Navigation("Father");

                    b.Navigation("Group");

                    b.Navigation("Mother");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("API.Models.Entities.Domains.Division", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("API.Models.Entities.Domains.Event", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("API.Models.Entities.Domains.Group", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("API.Models.Entities.Domains.Parent", b =>
                {
                    b.Navigation("FatherChildrens");

                    b.Navigation("MotherChildrens");
                });

            modelBuilder.Entity("API.Models.Entities.Domains.Role", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
