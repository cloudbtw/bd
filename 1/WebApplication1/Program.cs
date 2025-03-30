// создание сущности и валидация 
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

class Program
{
    static void Main()
    {
        try
        {
            var person = new Person
            {
                Name = "",
                SecondName = "Doe",
                Phone = "1234567890"
            };
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Validation error: {ex.Message}");
        }
    }
}



