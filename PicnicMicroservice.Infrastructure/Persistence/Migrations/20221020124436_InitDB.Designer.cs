// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PicnicMicroservice.Infrastructure.Persistence;

#nullable disable

namespace PicnicMicroservice.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20221020124436_InitDB")]
    partial class InitDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PicnicMicroservice.Domain.Entities.Picnic", b =>
                {
                    b.Property<Guid>("PicnicId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("LocationLat")
                        .HasColumnType("decimal(8,6)");

                    b.Property<decimal>("LocationLong")
                        .HasColumnType("decimal(9,6)");

                    b.Property<Guid>("MemberId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<short>("PicnicType")
                        .HasColumnType("smallint");

                    b.HasKey("PicnicId");

                    b.ToTable("Picnics");
                });

            modelBuilder.Entity("PicnicMicroservice.Domain.Entities.PicnicCollaboration", b =>
                {
                    b.Property<Guid>("CollaborationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("InviteId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CollaborationId");

                    b.ToTable("PicnicCollaborations");
                });

            modelBuilder.Entity("PicnicMicroservice.Domain.Entities.PicnicInvite", b =>
                {
                    b.Property<Guid>("InviteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MemberId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PicnicId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("InviteId");

                    b.ToTable("PicnicInvites");
                });
#pragma warning restore 612, 618
        }
    }
}
