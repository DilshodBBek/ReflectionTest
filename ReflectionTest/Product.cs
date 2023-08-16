using ReflectionTest.Interfaces;

namespace ReflectionTest;
public class Product //<T> where T : class, IProductRepository, new()
{
    
    public string Id { get; set; }
    public string Name { get;  set; }
    public string Description { get; set; }

    public void Delete()
    {
        //var myobj = new T();
        Console.WriteLine("Deleted product");
    }
}
