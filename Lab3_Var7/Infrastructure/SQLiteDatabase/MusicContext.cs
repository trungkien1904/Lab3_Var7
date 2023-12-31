using Lab2_Var7.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_Var7.Infrastructure.SQLiteDatabase;

public class MusicContext : DbContext
{
    public MusicContext() { }
    public MusicContext(string dbPath)
    {
        DbPath = dbPath;
    }
    public DbSet<Music> MusicDatabase { get; set; }
    public string? DbPath { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data Source={DbPath}");
    }
}
