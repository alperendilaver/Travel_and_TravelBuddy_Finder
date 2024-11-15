using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Context
{
      public class JourneyCloudContext : IdentityDbContext<AppUser, IdentityRole, string>
      {
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                  var serverVersion = new MySqlServerVersion(new Version(8, 2, 0));
                  optionsBuilder.UseMySql("server=127.0.0.1;port=3306;database=journeycloud;user=root;password=1453", serverVersion);
            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                  base.OnModelCreating(modelBuilder);

                  // TravelDestination Entity
                  modelBuilder.Entity<TravelDestination>(entity =>
                  {
                        entity.HasKey(td => td.TravelDestinationId);

                        entity.HasOne(td => td.Country)
                        .WithMany() // TravelDestination aslında City ile direkt ilişkili
                        .HasForeignKey(td => td.CountryId);

                        entity.HasOne(td => td.City)
                        .WithMany(c => c.TravelDestinations)
                        .HasForeignKey(td => td.CityId);

                        entity.HasMany(td => td.UserTravelHistories)
                        .WithOne(uth => uth.TravelDestination)
                        .HasForeignKey(uth => uth.TravelDestinationId);

                  });

                  // TravelSuggestion Entity
                  modelBuilder.Entity<TravelSuggestion>(entity =>
                  {
                        entity.HasKey(ts => ts.SuggestionId);

                        entity.HasOne(ts => ts.User)
                        .WithMany()
                        .HasForeignKey(ts => ts.UserId);

                        entity.HasOne(ts => ts.Route)
                        .WithOne(r => r.Suggestion)
                        .HasForeignKey<TravelRoute>(r => r.SuggestionId);
                  });

                  // TravelRoute Entity
                  modelBuilder.Entity<TravelRoute>(entity =>
                  {
                        entity.HasKey(tr => tr.RouteId);

                        entity.HasMany(tr => tr.Destinations)
                        .WithMany()
                        .UsingEntity(j => j.ToTable("RouteDestinations")); // Many-to-many ilişki için ara tablo

                        entity.HasMany(tr => tr.Hotels)
                        .WithMany()
                        .UsingEntity(j => j.ToTable("RouteHotels")); // Many-to-many ilişki için ara tablo

                        entity.HasMany(tr => tr.Foods)
                        .WithMany()
                        .UsingEntity(j => j.ToTable("RouteFoods")); // Many-to-many ilişki için ara tablo
                  });

                  // Match Entity
                  modelBuilder.Entity<Match>(entity =>
                  {
                        entity.HasKey(m => m.MatchId);

                        entity.HasOne(m => m.Liker)
                        .WithMany(m => m.Matches)
                        .HasForeignKey(m => m.LikerId)
                        .OnDelete(DeleteBehavior.Restrict); // Cascade silinmesini önlemek için
                        ;

                        entity.HasOne(m => m.Likee)
                        .WithMany()
                        .HasForeignKey(m => m.LikeeId)
                        .OnDelete(DeleteBehavior.Restrict);

                        entity.HasOne(m => m.Destination)
                        .WithMany()
                        .HasForeignKey(m => m.TravelDestinaitonId);
                  });

                  // Hotel Entity
                  modelBuilder.Entity<Hotel>(entity =>
                  {
                        entity.HasKey(h => h.HotelId);

                        entity.HasOne(h => h.City)
                        .WithMany()
                        .HasForeignKey(h => h.CityId);
                  });

                  // Hobby Entity
                  modelBuilder.Entity<Hobby>(entity =>
                  {
                        entity.HasKey(h => h.HobbyId);


                        entity.HasMany(h => h.UserHobbies)
                        .WithOne(uh => uh.Hobby)
                        .HasForeignKey(uh => uh.HobbyId);
                  });

                  // AppUserHobby Entity
                  modelBuilder.Entity<UserHobby>(entity =>
                  {
                        entity.HasKey(uh => uh.UserHobbyId);

                        entity.HasOne(uh => uh.User)
                        .WithMany(u => u.Hobbies)
                        .HasForeignKey(uh => uh.UserId);

                        entity.HasOne(uh => uh.Hobby)
                        .WithMany(h => h.UserHobbies)
                        .HasForeignKey(uh => uh.HobbyId);
                  });



                  // UserTravelHistory Entity
                  modelBuilder.Entity<UserTravelHistory>(entity =>
                  {
                        entity.HasKey(uth => uth.LogId);

                        entity.HasOne(uth => uth.User)
                        .WithMany(u => u.TravelHistories)
                        .HasForeignKey(uth => uth.UserId);

                        entity.HasOne(uth => uth.TravelDestination)
                        .WithMany(td => td.UserTravelHistories)
                        .HasForeignKey(uth => uth.TravelDestinationId);
                  });

                  // AppUser Entity
                  modelBuilder.Entity<AppUser>(entity =>
                  {
                        entity.HasMany(u => u.Hobbies)
                        .WithOne(uh => uh.User)
                        .HasForeignKey(uh => uh.UserId);

                        entity.HasMany(u => u.TravelHistories)
                        .WithOne(uth => uth.User)
                        .HasForeignKey(uth => uth.UserId);
                  });
                  modelBuilder.Entity<SuggestedUsers>(entity =>
           {
                 entity.HasKey(e => e.SuggestId);

                 // Configuring the relationship for RequestingUser -> SuggestedUsers
                 entity.HasOne(e => e.RequestingUser)
                      .WithMany(u => u.SuggestedUsers)
                      .HasForeignKey(e => e.RequestingUserId)
                      .OnDelete(DeleteBehavior.Restrict);

                 // Configuring the relationship for SuggestedUser -> SuggestedUsers
                 entity.HasOne(e => e.SuggestedUser)
                      .WithMany() // Assuming SuggestedUser has no collection in AppUser
                      .HasForeignKey(e => e.SuggestedUserId)
                      .OnDelete(DeleteBehavior.Restrict);
           });
                  modelBuilder.Entity<ChatMessage>(entity =>
                  {
                        entity.HasKey(e => e.Id);

                        entity.HasOne(x => x.SenderUser)
                        .WithMany(u => u.SentMessages) // Gönderen mesajlarıyla ilişki
                        .HasForeignKey(e => e.SenderUserId)
                        .OnDelete(DeleteBehavior.Cascade);

                        entity.HasOne(x => x.ReceiverUser)
                            .WithMany(u => u.ReceivedMessages) // Alıcı mesajlarıyla ilişki
                            .HasForeignKey(e => e.ReceiverUserId)
                            .OnDelete(DeleteBehavior.Cascade);
                  });
                   
            }
            public DbSet<Blog> Blogs { get; set; }
            public DbSet<City> Cities { get; set; }
            public DbSet<Country> Countries { get; set; }
            public DbSet<Food> Foods { get; set; }
            public DbSet<Hobby> Hobbies { get; set; }
              public DbSet<UserKey> UserKeys { get; set; }
            public DbSet<Hotel> Hotels { get; set; }
            public DbSet<Match> Matches { get; set; }
            public DbSet<Post> Posts { get; set; }
            public DbSet<TravelDestination> TravelDestinations { get; set; }
            public DbSet<TravelRoute> TravelRoutes { get; set; }
            public DbSet<TravelSuggestion> TravelSuggestions { get; set; }
            public DbSet<UserHobby> UserHobbies { get; set; }
            public DbSet<UserTravelHistory> UserTravelHistories { get; set; }
            public DbSet<SuggestedUsers> SuggestedUsers { get; set; }
            public DbSet<Notification> Notifications { get; set; }
            public DbSet<ChatMessage> ChatMessages { get; set; }

      }
}