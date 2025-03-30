using System;
using Microsoft.EntityFrameworkCore;

//сущность/валидация
public class Person
{
    public int Id { get; set; }

    private string _name;
    public string Name
    {
        get => _name;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Name cannot be empty");
            _name = value;
        }
    }

    public string SecondName { get; set; }
    public string Phone { get; set; }
}

//bd
public class AppDbContext : DbContext
{
    public DbSet<Person> People { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=people.db");
    }
}

class Program
{
    static void Main()
    {
        using var db = new AppDbContext();
        db.Database.EnsureCreated();

        try
        {
            var person = new Person
            {
                Name = "Дб",
                SecondName = "123",
                Phone = "98765"
            };

            db.People.Add(person);
            db.SaveChanges();
            Console.WriteLine("Сохранено");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"0: {ex.Message}");
        }
    }
}

