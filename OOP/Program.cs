using System.Collections.Generic;

class Particle
{
    public float X { get; set; }
    public float Y { get; set; }
    public float Vx { get; set; }
    public float Vy { get; set; }

    public Particle(float x, float y, float vx, float vy)
    {
        X = x;
        Y = y;
        Vx = vx;
        Vy = vy;
    }

    public void Update()
    {
        X += Vx;
        Y += Vy;
    }
}

class Program
{
    static void Main()
    {
        var particles = new List<Particle>();
        for (int i = 0; i < 1000; i++)
        {
            particles.Add(new Particle(0, 0, 1, 1));
        }

        var startTime = DateTime.Now;
        foreach (var particle in particles)
        {
            particle.Update();
        }
        var oopDuration = DateTime.Now - startTime;

        Console.WriteLine($"OOP Duration: {oopDuration.TotalMilliseconds} ms");
        Console.ReadKey();
    } }
