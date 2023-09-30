using DomainLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {

        public AppDbContext(DbContextOptions<AppDbContext> con) : base(con) { }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }

        public DbSet<IngredientRecipe> IngredientsRecipes { get; set; }

        public DbSet<FeedBack> FeedBacks { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedRoles(builder);


            builder.Entity<IngredientRecipe>()
                .HasOne(r => r.Recipe)
                .WithMany(In => In.IngredientRecipes)
                .HasForeignKey(ri => ri.RecipesId);


            builder.Entity<IngredientRecipe>()
                .HasOne(r => r.Ingredient)
                .WithMany(In => In.IngredientRecipes)
                .HasForeignKey(ri => ri.IngredientsId);

            builder.Entity<IngredientRecipe>()
               .HasIndex(p => new { p.IngredientsId, p.RecipesId }).IsUnique();

            
            builder.Entity<FeedBack>()
                .HasOne(r => r.Recipe)
                .WithMany(In => In.FeedBacks)
                .HasForeignKey(ri => ri.RecipeId);
            

            
        }
        private static void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData
                (
                new IdentityRole() { Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },
                new IdentityRole() { Name = "User", ConcurrencyStamp = "2", NormalizedName = "User" },
                new IdentityRole() { Name = "HR", ConcurrencyStamp = "3", NormalizedName = "Hr" }
                );
        }

    }

}