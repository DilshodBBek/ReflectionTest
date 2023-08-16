using MyMapper;
using System.Reflection;

namespace ReflectionTest;

internal class Program
{
    static void Main(string[] args)
    {
        var _mapper = new CustomAutoMapper();

        var productdto = new ProductDTO()
        {
            Id = 1,
            Name = "Bread",
            Price=12.699
        };

        Product product= _mapper.Map<Product>(productdto);

        Console.WriteLine(product.Id);
        Console.WriteLine(product.Name);
    }

    public static void Print(object obj)
    {
        Type type = obj.GetType();
        Console.WriteLine(type.Name);
        Console.WriteLine(type.FullName);

        PropertyInfo? props = obj.GetType().GetProperty("Name");

        props.SetValue(obj, "Bread");

        type.GetRuntimeProperties().First(x=>x.Name.Contains(""));
        Console.WriteLine(obj.GetType().GetProperty("Name").GetValue(obj));
        var events = obj.GetType().GetEvents();
        MethodInfo? delete = obj.GetType().GetMethod("Delete");


        object? product = Activator.CreateInstance(type);

        product.GetType().GetProperty("Name").SetValue(product, "test");

        ConstructorInfo? constructors = type.GetConstructor(Assembly.GetExecutingAssembly().GetTypes().Where(x => x.IsClass).ToArray());
        //Console.WriteLine(constructors.Name);
    }
}
