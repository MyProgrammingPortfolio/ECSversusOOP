using System.Collections.Generic;

class Entity
{
    public int Id { get; }
    private Dictionary<Type, object> components = new Dictionary<Type, object>();

    public Entity(int id)
    {
        Id = id;
    }

    public void AddComponent<T>(T component)
    {
        components[typeof(T)] = component;
    }

    public T GetComponent<T>()
    {
        return (T)components[typeof(T)];
    }
}

class Position
{
    public float X { get; set; }
    public float Y { get; set; }

    public Position(float x, float y)
    {
        X = x;
        Y = y;
    }
}

class Velocity
{
    public float Vx { get; set; }
    public float Vy { get; set; }

    public Velocity(float vx, float vy)
    {
        Vx = vx;
        Vy = vy;
    }
}

class MovementSystem
{
    public void Update(List<Entity> entities)
    {
        foreach (var entity in entities)
        {
            var pos = entity.GetComponent<Position>();
            var vel = entity.GetComponent<Velocity>();
            if (pos != null && vel != null)
            {
                pos.X += vel.Vx;
                pos.Y += vel.Vy;
            }
        }
    }
}

class Program
{
    static void Main()
    {
        var entities = new List<Entity>();
        for (int i = 0; i < 1000; i++)
        {
            var entity = new Entity(i);
            entity.AddComponent(new Position(0, 0));
            entity.AddComponent(new Velocity(1, 1));
            entities.Add(entity);
        }

        var movementSystem = new MovementSystem();
        var startTime = DateTime.Now;
        movementSystem.Update(entities);
        var ecsDuration = DateTime.Now - startTime;

        Console.WriteLine($"ECS Duration: {ecsDuration.TotalMilliseconds} ms");
        Console.ReadKey();
    }

}