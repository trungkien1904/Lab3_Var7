using Lab2_Var7.Domain.Models;
using Lab2_Var7.Domain.Repository;
using Lab2_Var7.Infrastructure.SQLiteDatabase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_Var7.Infrastructure.Repository;

public class SqlMusicRepository : IMusicRepository
{
    private readonly MusicContext musicContext;
    public SqlMusicRepository(MusicContext musicContext)
    {
        this.musicContext = musicContext;
        musicContext.Database.EnsureCreated();
    }

    public void AddMusic(Music music)
    {
        musicContext.Add(music);
        musicContext.SaveChanges();
    }

    public void DeleteMusic(Music music)
    {
        musicContext.Remove(music);
        musicContext.SaveChanges();
    }

    public IEnumerable<Music> GetAllMusics()
    {
        return musicContext.MusicDatabase.ToList();
    }

    public IEnumerable<Music> SearchMusic(string request)
    {
        return musicContext.MusicDatabase.Where(music => music.ArtistName == request || music.Title == request).ToList();
    }
}
