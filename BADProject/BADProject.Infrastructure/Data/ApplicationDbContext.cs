using BADProject.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SportStore.Infrastructure.Identity;

namespace BADProject.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Reviews> Reviews { get; set; }
        public DbSet<Anime> Animes { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<WatchList> Watchlists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Reviews>()
                .HasOne(r => r.Anime)
                .WithMany(a => a.Reviews)
                .HasForeignKey(r => r.AnimeId);

            modelBuilder.Entity<Reviews>()
                .HasOne<ApplicationUser>()
                .WithMany()
                .HasForeignKey(r => r.UserId);

            modelBuilder.Entity<Anime>()
                .HasOne(a => a.Genre)
                .WithMany(g => g.Animes)
                .HasForeignKey(a => a.GenreId);

            SeedUserData(modelBuilder);
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            // Seed genres
            modelBuilder.Entity<Genre>().HasData(
                new Genre { Id = 1, Name = "Action" },
                new Genre { Id = 2, Name = "Adventure" },
                new Genre { Id = 3, Name = "Comedy" },
                new Genre { Id = 4, Name = "Drama" },
                new Genre { Id = 5, Name = "Fantasy" },
                new Genre { Id = 6, Name = "Horror" },
                new Genre { Id = 7, Name = "Mystery" },
                new Genre { Id = 8, Name = "Romance" },
                new Genre { Id = 9, Name = "Sci-Fi" },
                new Genre { Id = 10, Name = "Thriller" },
                new Genre { Id = 11, Name = "Animation" },
                new Genre { Id = 12, Name = "Crime" },
                new Genre { Id = 13, Name = "Documentary" },
                new Genre { Id = 14, Name = "Family" },
                new Genre { Id = 15, Name = "Historical" }
            );
            modelBuilder.Entity<Anime>().HasData(
                new Anime { Id = 1, Title = "Attack on Titan", Description = "Humans retreat behind enormous walls from the monstrous Titans, but a young man vows revenge after a personal loss.", Release_date = new DateTime(2013, 1, 1), GenreId = 1, ImageURL = "/AttackOnTitan.jpg" },
                new Anime { Id = 2, Title = "Naruto", Description = "An energetic ninja who is shunned by his village for housing a fearsome beast works hard to earn his village's respect.", Release_date = new DateTime(2002, 1, 1), GenreId = 1 , ImageURL = "/Naruto.jpg" },
                new Anime { Id = 3, Title = "Spirited Away", Description = "A young girl stumbles into a mystical world where she must work in a bathhouse for the gods to free herself and her transformed parents.", Release_date = new DateTime(2001, 1, 1), GenreId = 5 , ImageURL = "/SpiritedAway.jpg" },
                new Anime { Id = 4, Title = "Death Note", Description = "A brilliant teen finds a notebook with which he can kill anyone by writing their name, initiating a cat-and-mouse game with authorities.", Release_date = new DateTime(2006, 1, 1), GenreId = 6, ImageURL = "/DeathNote.jpg" },
                new Anime { Id = 5, Title = "My Hero Academia", Description = "In a world where nearly everyone has superpowers, a powerless boy enrolls in an academy for heroes, aiming to become the greatest.", Release_date = new DateTime(2016, 1, 1), GenreId = 1 , ImageURL = "/MyHeroAcademia.jpg" },
                new Anime { Id = 6, Title = "One Piece", Description = "A young pirate and his crew embark on a quest to find the greatest treasure ever left by the legendary Pirate, Gold Roger.", Release_date = new DateTime(1999, 1, 1), GenreId = 2 , ImageURL = "/OnePiece.jpg" },
                new Anime { Id = 7, Title = "Tokyo Ghoul", Description = "A college student gains supernatural abilities after a ghoul organ transplant, finding himself torn between two worlds.", Release_date = new DateTime(2014, 1, 1), GenreId = 6 , ImageURL = "/TokyoGhoul.jpg" },
                new Anime { Id = 8, Title = "Your Name", Description = "Two teenagers share a profound, magical connection upon discovering they are swapping bodies with each other.", Release_date = new DateTime(2016, 1, 1), GenreId = 8 , ImageURL = "/YourName.jpg" },
                new Anime { Id = 9, Title = "Fullmetal Alchemist: Brotherhood", Description = "Two brothers use alchemy to try to resurrect their mother, but instead they unleash a series of tragic events.", Release_date = new DateTime(2009, 1, 1), GenreId = 1 , ImageURL = "/FullMetalAlchemist.jpg" },
                new Anime { Id = 10, Title = "Cowboy Bebop", Description = "A ragtag crew of bounty hunters chase down the galaxy's most dangerous criminals; they'll save the world for the right price.", Release_date = new DateTime(1998, 1, 1), GenreId = 9 , ImageURL = "/CowboyBebop.jpg" },
                new Anime { Id = 11, Title = "Neon Genesis Evangelion", Description = "Teens pilot giant mechs to protect Earth from mysterious beings, but the pilots' own traumas might pose a greater danger.", Release_date = new DateTime(1995, 1, 1), GenreId = 9 , ImageURL = "/NeonGenesisEvangelion.jpg" },
                new Anime { Id = 12, Title = "Steins;Gate", Description = "A group of friends discovers a way to send messages to the past, but their tampering with time leads to unforeseen, dark consequences.", Release_date = new DateTime(2011, 1, 1), GenreId = 9 , ImageURL = "/SteinsGate.jpg" },
                new Anime { Id = 13, Title = "Hunter x Hunter", Description = "A young boy follows in his missing father’s footsteps to become a Hunter, facing perilous tasks and dangerous creatures along the way.", Release_date = new DateTime(2011, 1, 1), GenreId = 2 , ImageURL = "/HunterXHunter.jpg" },
                new Anime { Id = 14, Title = "Samurai Champloo", Description = "An unlikely trio of adventurers in a hip-hop infused version of Edo-era Japan search for a samurai who smells of sunflowers.", Release_date = new DateTime(2004, 1, 1), GenreId = 12 , ImageURL = "/SamuraiChamploo.jpg" },
                new Anime { Id = 15, Title = "Psycho-Pass", Description = "In a future Japan, the Sibyl System assesses everyone’s threat level, but what happens when the system itself is flawed?", Release_date = new DateTime(2012, 1, 1), GenreId = 10 , ImageURL = "/PsychoPass.jpg" },
                new Anime { Id = 16, Title = "Haikyuu!!", Description = "A passionate high school student with dreams of volleyball glory faces challenges and builds friendships on his journey to the top.", Release_date = new DateTime(2014, 1, 1), GenreId = 14 , ImageURL = "/Haikyuu.jpg" },
                new Anime { Id = 17, Title = "Clannad: After Story", Description = "Continuing from Clannad, the story follows the challenges and heartwarming moments of life after high school.", Release_date = new DateTime(2008, 1, 1), GenreId = 4 , ImageURL = "/Clanned.jpg" },
                new Anime { Id = 18, Title = "Made in Abyss", Description = "A girl and her mysterious robot friend descend into the Abyss, a terrifyingly deep chasm, to uncover the truth about her mother.", Release_date = new DateTime(2017, 1, 1), GenreId = 5 , ImageURL = "/MadeInAbyss.jpg" },
                new Anime { Id = 19, Title = "Gintama", Description = "In an Edo-era Japan conquered by aliens, the samurai Gintoki navigates the oddities of life with humor and heart.", Release_date = new DateTime(2006, 1, 1), GenreId = 3 , ImageURL = "/Gintama.jpg" },
                new Anime { Id = 20, Title = "Demon Slayer", Description = "A kind-hearted boy becomes a demon slayer to avenge his family slaughtered by demons and to cure his demon-turned sister.", Release_date = new DateTime(2009, 1, 1), GenreId = 1 , ImageURL = "/DemonSlayer.jpg" }
            );
        }


        private void SeedUserData(ModelBuilder modelBuilder)
        {
            string userMetClaimId = Guid.NewGuid().ToString();
            string userZonderClaimId = Guid.NewGuid().ToString();

            PasswordHasher<ApplicationUser> hasher = new PasswordHasher<ApplicationUser>();

            ApplicationUser userMetClaim = new ApplicationUser
            {
                Id = userMetClaimId,
                FirstName = "John",
                LastName = "Doe",
                DateOfBirth = new DateTime(1992, 1, 1),
                UserName = "user@admin.com",
                NormalizedUserName = "USER@ADMIN.COM",
                Email = "user@admin.com",
                NormalizedEmail = "USER@ADMIN.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Admin12?")
            };

            ApplicationUser userZonderClaim = new ApplicationUser
            {
                Id = userZonderClaimId,
                FirstName = "John",
                LastName = "Wick",
                DateOfBirth = new DateTime(1990, 2, 15),
                UserName = "user@gmail.com",
                NormalizedUserName = "USER@GMAIL.COM",
                Email = "user@gmail.com",
                NormalizedEmail = "USER@GMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Password123!")
            };

            modelBuilder.Entity<ApplicationUser>().HasData(userMetClaim, userZonderClaim);
            modelBuilder.Entity<IdentityUserClaim<string>>().HasData(
                new IdentityUserClaim<string>
                {
                    Id = 1,
                    UserId = userMetClaimId,
                    ClaimType = "CanManageCatalog",
                    ClaimValue = "true"
                }
            );

        }
    }
}
