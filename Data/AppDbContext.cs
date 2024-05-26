﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace StoreApi;

public class AppDbContext : IdentityDbContext<AppUser>
{
    public AppDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {

    }

    public DbSet<Store> Stores {get; set;}

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        List<IdentityRole> roles = new List<IdentityRole>{
            new IdentityRole{
                Name="Admin",
                NormalizedName="ADMIN"
            },
            new IdentityRole{
                Name="User",
                NormalizedName="USER"
            }
        };
        builder.Entity<IdentityRole>().HasData(roles);
    }
}
