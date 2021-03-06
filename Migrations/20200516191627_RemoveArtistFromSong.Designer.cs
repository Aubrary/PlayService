﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PlayService.Data;

namespace PlayService.Migrations
{
    [DbContext(typeof(PlayServiceContext))]
    [Migration("20200516191627_RemoveArtistFromSong")]
    partial class RemoveArtistFromSong
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:PostgresExtension:pgcrypto", ",,")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("PlayService.Models.Album", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ArtistId")
                        .HasColumnType("uuid");

                    b.Property<int>("Rating")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.ToTable("Albums");
                });

            modelBuilder.Entity("PlayService.Models.Artist", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("Rating")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Artists");
                });

            modelBuilder.Entity("PlayService.Models.Genre", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("AlbumId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<Guid?>("SongId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.HasIndex("SongId");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("PlayService.Models.Playlist", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Playlists");
                });

            modelBuilder.Entity("PlayService.Models.Song", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AlbumId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ArtistId")
                        .HasColumnType("uuid");

                    b.Property<int>("Minutes")
                        .HasColumnType("integer");

                    b.Property<Guid?>("PlaylistId")
                        .HasColumnType("uuid");

                    b.Property<int>("Seconds")
                        .HasColumnType("integer");

                    b.Property<int>("StreamCount")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.HasIndex("ArtistId");

                    b.HasIndex("PlaylistId");

                    b.ToTable("Songs");
                });

            modelBuilder.Entity("PlayService.Models.Album", b =>
                {
                    b.HasOne("PlayService.Models.Artist", "Artist")
                        .WithMany("Albums")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PlayService.Models.Genre", b =>
                {
                    b.HasOne("PlayService.Models.Album", null)
                        .WithMany("Genre")
                        .HasForeignKey("AlbumId");

                    b.HasOne("PlayService.Models.Song", null)
                        .WithMany("Genre")
                        .HasForeignKey("SongId");
                });

            modelBuilder.Entity("PlayService.Models.Song", b =>
                {
                    b.HasOne("PlayService.Models.Album", "Album")
                        .WithMany("Songs")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PlayService.Models.Artist", null)
                        .WithMany("Songs")
                        .HasForeignKey("ArtistId");

                    b.HasOne("PlayService.Models.Playlist", null)
                        .WithMany("Songs")
                        .HasForeignKey("PlaylistId");
                });
#pragma warning restore 612, 618
        }
    }
}
