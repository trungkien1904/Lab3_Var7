using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_Var7.Infrastructure.SQLiteDatabase.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddMusicCatalogContext(this IServiceCollection services,
        string relativePath = "..")
    {
        string dbFile = Path.Combine(relativePath, "mc.db");
        services.AddDbContext<MusicContext>(op => op.UseSqlite($"Data Source={dbFile}"));

        return services;
    }
}
