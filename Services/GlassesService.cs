using GlassesApi.Models;

namespace GlassesApi.Services;

public static class GlassesService
{
    static List<Glasses> Glasses { get; }
    static int nextId = 4;
    static GlassesService()
    {
        Glasses = new List<Glasses>
        {
            new Glasses { Id = 1, Name = "Ray-Ban Clubmaster", Color = "Brown / Gold", Shape = "Browline"},
            new Glasses { Id = 2, Name = "Ottoto Bellona", Color = "Pink / Gold", Shape = "Oval"},
            new Glasses { Id = 3, Name = "Oakley Socket 5.5", Color = "Gunmetal", Shape = "Rectangle"}
        };
    }

    public static List<Glasses> GetAll() => Glasses;

    public static Glasses? Get(int id) => Glasses.FirstOrDefault(g => g.Id == id);

    public static void Add(Glasses glasses)
    {
        glasses.Id = nextId++;
        Glasses.Add(glasses);
    }

    public static void Delete(int id)
    {
        var glasses = Get(id);
        if (glasses is null)
            return;

        Glasses.Remove(glasses);
    }

    public static void Update(Glasses glasses)
    {
        var index = Glasses.FindIndex(g => g.Id == glasses.Id);
        if (index == -1)
            return;
        
        Glasses[index] = glasses;
    }
}