using Xunit;
using Moq;
using Lab2_Var7.Domain.Repository;
using Lab2_Var7.Domain.Models;
using Lab2_Var7.Application.Services;
using Lab2_Var7.Infrastructure.SQLiteDatabase;

namespace Tests;

public class Lab3Test
{
    private MusicContext musicContext;
    private Mock<IMusicRepository> musicRepository;
    private MusicService musicService;
    public Lab3Test()
    {
        musicContext = new MusicContext();
        musicRepository = new Mock<IMusicRepository>();
        musicService = new MusicService(musicRepository.Object);
    }

    [Fact]
    public void TestAddMusic()
    {
        var music = new Music("ABC", "ABSSSS");
        musicService.AddMusic(music);

        musicRepository.Verify(m => m.AddMusic(music), Times.Once);
    }

    [Fact]
    public void TestRemoveMusic()
    {
        var music = new Music("ABC", "ABSSSS");
        musicService.RemoveMusic(music);

        musicRepository.Verify(m => m.DeleteMusic(music), Times.Once);
    }

    [Fact]
    public void TestSearchMusic()
    {
        string request = "ABC";
        musicService.SearchMusic(request);

        musicRepository.Verify(m => m.SearchMusic(request), Times.Once);
    }
}