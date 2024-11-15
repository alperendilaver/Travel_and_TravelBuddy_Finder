﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistance.Context;

#nullable disable

namespace Persistance.Migrations
{
    [DbContext(typeof(JourneyCloudContext))]
    [Migration("20241104194237_message")]
    partial class message
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Bio")
                        .HasColumnType("longtext");

                    b.Property<int>("Budget")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Gender")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("GovernmentId")
                        .HasColumnType("longtext");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("Passpart")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("Visa")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Blog", b =>
                {
                    b.Property<int>("BlogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("BlogId"));

                    b.Property<string>("BlogName")
                        .HasColumnType("longtext");

                    b.Property<string>("Context")
                        .HasColumnType("longtext");

                    b.HasKey("BlogId");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("Domain.Entities.ChatMessage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Message")
                        .HasColumnType("longtext");

                    b.Property<string>("ReceiverUserId")
                        .HasColumnType("longtext");

                    b.Property<string>("SenderUserId")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("ChatMessages");
                });

            modelBuilder.Entity("Domain.Entities.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("CityId"));

                    b.Property<string>("CityName")
                        .HasColumnType("longtext");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.HasKey("CityId");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("Domain.Entities.Country", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("CountryId"));

                    b.Property<string>("CountryName")
                        .HasColumnType("longtext");

                    b.HasKey("CountryId");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Domain.Entities.Food", b =>
                {
                    b.Property<int>("FoodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("FoodId"));

                    b.Property<string>("FoodName")
                        .HasColumnType("longtext");

                    b.HasKey("FoodId");

                    b.ToTable("Foods");
                });

            modelBuilder.Entity("Domain.Entities.Hobby", b =>
                {
                    b.Property<int>("HobbyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("HobbyId"));

                    b.Property<string>("HobbyName")
                        .HasColumnType("longtext");

                    b.HasKey("HobbyId");

                    b.ToTable("Hobbies");
                });

            modelBuilder.Entity("Domain.Entities.Hotel", b =>
                {
                    b.Property<int>("HotelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("HotelId"));

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("HotelName")
                        .HasColumnType("longtext");

                    b.HasKey("HotelId");

                    b.HasIndex("CityId");

                    b.ToTable("Hotels");
                });

            modelBuilder.Entity("Domain.Entities.Match", b =>
                {
                    b.Property<int>("MatchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("MatchId"));

                    b.Property<bool>("IsLiked")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsMatched")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("LikeeId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LikerId")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("TravelDestinaitonId")
                        .HasColumnType("int");

                    b.HasKey("MatchId");

                    b.HasIndex("LikeeId");

                    b.HasIndex("LikerId");

                    b.HasIndex("TravelDestinaitonId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("Domain.Entities.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsRead")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Message")
                        .HasColumnType("longtext");

                    b.Property<string>("ReceiverUserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Subject")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ReceiverUserId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("Domain.Entities.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("PostId"));

                    b.Property<int>("BlogId")
                        .HasColumnType("int");

                    b.Property<string>("Context")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("PostedTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("PostId");

                    b.HasIndex("BlogId");

                    b.HasIndex("UserId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Domain.Entities.SuggestedUsers", b =>
                {
                    b.Property<int>("SuggestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("SuggestId"));

                    b.Property<string>("RequestingUserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("SuggestedUserId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("SuggestId");

                    b.HasIndex("RequestingUserId");

                    b.HasIndex("SuggestedUserId");

                    b.ToTable("SuggestedUsers");
                });

            modelBuilder.Entity("Domain.Entities.TravelDestination", b =>
                {
                    b.Property<int>("TravelDestinationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("TravelDestinationId"));

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<int>("PopularityValue")
                        .HasColumnType("int");

                    b.HasKey("TravelDestinationId");

                    b.HasIndex("CityId");

                    b.HasIndex("CountryId");

                    b.ToTable("TravelDestinations");
                });

            modelBuilder.Entity("Domain.Entities.TravelRoute", b =>
                {
                    b.Property<int>("RouteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("RouteId"));

                    b.Property<int>("SuggestionId")
                        .HasColumnType("int");

                    b.HasKey("RouteId");

                    b.HasIndex("SuggestionId")
                        .IsUnique();

                    b.ToTable("TravelRoutes");
                });

            modelBuilder.Entity("Domain.Entities.TravelSuggestion", b =>
                {
                    b.Property<int>("SuggestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("SuggestionId"));

                    b.Property<int>("RouteId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("SuggestionId");

                    b.HasIndex("UserId");

                    b.ToTable("TravelSuggestions");
                });

            modelBuilder.Entity("Domain.Entities.UserHobby", b =>
                {
                    b.Property<int>("UserHobbyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("UserHobbyId"));

                    b.Property<int>("HobbyId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserHobbyId");

                    b.HasIndex("HobbyId");

                    b.HasIndex("UserId");

                    b.ToTable("UserHobbies");
                });

            modelBuilder.Entity("Domain.Entities.UserTravelHistory", b =>
                {
                    b.Property<int>("LogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("LogId"));

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<DateTime>("TravelDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("TravelDestinationId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("LogId");

                    b.HasIndex("TravelDestinationId");

                    b.HasIndex("UserId");

                    b.ToTable("UserTravelHistories");
                });

            modelBuilder.Entity("FoodTravelRoute", b =>
                {
                    b.Property<int>("FoodsFoodId")
                        .HasColumnType("int");

                    b.Property<int>("TravelRouteRouteId")
                        .HasColumnType("int");

                    b.HasKey("FoodsFoodId", "TravelRouteRouteId");

                    b.HasIndex("TravelRouteRouteId");

                    b.ToTable("RouteFoods", (string)null);
                });

            modelBuilder.Entity("HotelTravelRoute", b =>
                {
                    b.Property<int>("HotelsHotelId")
                        .HasColumnType("int");

                    b.Property<int>("TravelRouteRouteId")
                        .HasColumnType("int");

                    b.HasKey("HotelsHotelId", "TravelRouteRouteId");

                    b.HasIndex("TravelRouteRouteId");

                    b.ToTable("RouteHotels", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("TravelDestinationTravelRoute", b =>
                {
                    b.Property<int>("DestinationsTravelDestinationId")
                        .HasColumnType("int");

                    b.Property<int>("TravelRouteRouteId")
                        .HasColumnType("int");

                    b.HasKey("DestinationsTravelDestinationId", "TravelRouteRouteId");

                    b.HasIndex("TravelRouteRouteId");

                    b.ToTable("RouteDestinations", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.City", b =>
                {
                    b.HasOne("Domain.Entities.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Domain.Entities.Hotel", b =>
                {
                    b.HasOne("Domain.Entities.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("Domain.Entities.Match", b =>
                {
                    b.HasOne("Domain.Entities.AppUser", "Likee")
                        .WithMany()
                        .HasForeignKey("LikeeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Domain.Entities.AppUser", "Liker")
                        .WithMany("Matches")
                        .HasForeignKey("LikerId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Domain.Entities.TravelDestination", "Destination")
                        .WithMany()
                        .HasForeignKey("TravelDestinaitonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Destination");

                    b.Navigation("Likee");

                    b.Navigation("Liker");
                });

            modelBuilder.Entity("Domain.Entities.Notification", b =>
                {
                    b.HasOne("Domain.Entities.AppUser", "Receiver")
                        .WithMany("Notifications")
                        .HasForeignKey("ReceiverUserId");

                    b.Navigation("Receiver");
                });

            modelBuilder.Entity("Domain.Entities.Post", b =>
                {
                    b.HasOne("Domain.Entities.Blog", "Blog")
                        .WithMany("Posts")
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.AppUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Blog");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.SuggestedUsers", b =>
                {
                    b.HasOne("Domain.Entities.AppUser", "RequestingUser")
                        .WithMany("SuggestedUsers")
                        .HasForeignKey("RequestingUserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Domain.Entities.AppUser", "SuggestedUser")
                        .WithMany()
                        .HasForeignKey("SuggestedUserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("RequestingUser");

                    b.Navigation("SuggestedUser");
                });

            modelBuilder.Entity("Domain.Entities.TravelDestination", b =>
                {
                    b.HasOne("Domain.Entities.City", "City")
                        .WithMany("TravelDestinations")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Domain.Entities.TravelRoute", b =>
                {
                    b.HasOne("Domain.Entities.TravelSuggestion", "Suggestion")
                        .WithOne("Route")
                        .HasForeignKey("Domain.Entities.TravelRoute", "SuggestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Suggestion");
                });

            modelBuilder.Entity("Domain.Entities.TravelSuggestion", b =>
                {
                    b.HasOne("Domain.Entities.AppUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.UserHobby", b =>
                {
                    b.HasOne("Domain.Entities.Hobby", "Hobby")
                        .WithMany("UserHobbies")
                        .HasForeignKey("HobbyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.AppUser", "User")
                        .WithMany("Hobbies")
                        .HasForeignKey("UserId");

                    b.Navigation("Hobby");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.UserTravelHistory", b =>
                {
                    b.HasOne("Domain.Entities.TravelDestination", "TravelDestination")
                        .WithMany("UserTravelHistories")
                        .HasForeignKey("TravelDestinationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.AppUser", "User")
                        .WithMany("TravelHistories")
                        .HasForeignKey("UserId");

                    b.Navigation("TravelDestination");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FoodTravelRoute", b =>
                {
                    b.HasOne("Domain.Entities.Food", null)
                        .WithMany()
                        .HasForeignKey("FoodsFoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.TravelRoute", null)
                        .WithMany()
                        .HasForeignKey("TravelRouteRouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HotelTravelRoute", b =>
                {
                    b.HasOne("Domain.Entities.Hotel", null)
                        .WithMany()
                        .HasForeignKey("HotelsHotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.TravelRoute", null)
                        .WithMany()
                        .HasForeignKey("TravelRouteRouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Domain.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Domain.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Domain.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TravelDestinationTravelRoute", b =>
                {
                    b.HasOne("Domain.Entities.TravelDestination", null)
                        .WithMany()
                        .HasForeignKey("DestinationsTravelDestinationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.TravelRoute", null)
                        .WithMany()
                        .HasForeignKey("TravelRouteRouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.AppUser", b =>
                {
                    b.Navigation("Hobbies");

                    b.Navigation("Matches");

                    b.Navigation("Notifications");

                    b.Navigation("SuggestedUsers");

                    b.Navigation("TravelHistories");
                });

            modelBuilder.Entity("Domain.Entities.Blog", b =>
                {
                    b.Navigation("Posts");
                });

            modelBuilder.Entity("Domain.Entities.City", b =>
                {
                    b.Navigation("TravelDestinations");
                });

            modelBuilder.Entity("Domain.Entities.Country", b =>
                {
                    b.Navigation("Cities");
                });

            modelBuilder.Entity("Domain.Entities.Hobby", b =>
                {
                    b.Navigation("UserHobbies");
                });

            modelBuilder.Entity("Domain.Entities.TravelDestination", b =>
                {
                    b.Navigation("UserTravelHistories");
                });

            modelBuilder.Entity("Domain.Entities.TravelSuggestion", b =>
                {
                    b.Navigation("Route");
                });
#pragma warning restore 612, 618
        }
    }
}
