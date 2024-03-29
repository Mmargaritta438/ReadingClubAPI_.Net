﻿using Microsoft.EntityFrameworkCore;
using ReadingClubSPI_.Net.DataReadClBookLayer.Models;

namespace ReadingClubSPI_.Net.DataReadClBookLayer.Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) { }

        public DbSet<ReadingClBook> ReadingClBooks { get; set; }

        public DbSet<UserBook> UserBooks { get; set; }
    }
}
