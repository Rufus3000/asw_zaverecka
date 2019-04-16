using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pecka_Soundcloud.Entities;
using Pecka_Soundcloud.Models;

namespace Pecka_Soundcloud.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Album> Albums
        {
            get;
            set;
        }


        public DbSet<Song> Songs
        {
            get;
            set;
        }

        public DbSet<Interpret> Interprets
        {
            get;
            set;
        }

    
    }
}
