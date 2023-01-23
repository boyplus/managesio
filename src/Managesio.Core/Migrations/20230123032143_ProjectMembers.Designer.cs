﻿// <auto-generated />
using System;
using Managesio.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Managesio.Core.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    [Migration("20230123032143_ProjectMembers")]
    partial class ProjectMembers
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Managesio.Core.Entities.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("owner_id");

                    b.HasKey("Id")
                        .HasName("pk_project");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_project_owner_id");

                    b.ToTable("project", (string)null);
                });

            modelBuilder.Entity("Managesio.Core.Entities.ProjectMember", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uuid")
                        .HasColumnName("project_id");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_project_member");

                    b.HasIndex("ProjectId")
                        .HasDatabaseName("ix_project_member_project_id");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_project_member_user_id");

                    b.ToTable("project_member", (string)null);
                });

            modelBuilder.Entity("Managesio.Core.Entities.Todo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("note");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_todo");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_todo_user_id");

                    b.ToTable("todo", (string)null);
                });

            modelBuilder.Entity("Managesio.Core.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("firstname");

                    b.Property<bool>("IsVerified")
                        .HasColumnType("boolean")
                        .HasColumnName("is_verified");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("lastname");

                    b.Property<int?>("Otp")
                        .HasColumnType("integer")
                        .HasColumnName("otp");

                    b.Property<DateTime?>("OtpExpireAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("otp_expire_at");

                    b.Property<string>("Password")
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.HasKey("Id")
                        .HasName("pk_user");

                    b.ToTable("user", (string)null);
                });

            modelBuilder.Entity("Managesio.Core.Entities.Project", b =>
                {
                    b.HasOne("Managesio.Core.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_project_user_owner_id");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Managesio.Core.Entities.ProjectMember", b =>
                {
                    b.HasOne("Managesio.Core.Entities.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_project_member_project_project_id");

                    b.HasOne("Managesio.Core.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_project_member_user_user_id");

                    b.Navigation("Project");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Managesio.Core.Entities.Todo", b =>
                {
                    b.HasOne("Managesio.Core.Entities.User", null)
                        .WithMany("Todos")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_todo_user_user_id");
                });

            modelBuilder.Entity("Managesio.Core.Entities.User", b =>
                {
                    b.Navigation("Todos");
                });
#pragma warning restore 612, 618
        }
    }
}