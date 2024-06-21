﻿using Microsoft.EntityFrameworkCore;
using ScreenSound.Models;
using ScreenSound.Shared.Models.Models;

namespace ScreenSound.DB;

public class ScreenSoundContext: DbContext
{
    public DbSet<Artist> Artists { get; set; }
    public DbSet<Music> Musics { get; set; }

    public DbSet<Gender> Genres { get; set; }

    private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;" +
        "Initial Catalog=ScreenSoundV0;Integrated Security=True;" +
        "Encrypt=False;" +
        "Trust Server Certificate=False;" +
        "Application Intent=ReadWrite;" +
        "Multi Subnet Failover=False";


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlServer(connectionString)
            .UseLazyLoadingProxies(false);
    }
}
