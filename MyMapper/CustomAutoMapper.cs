using System.Reflection;

namespace MyMapper;
public class CustomAutoMapper
{

    public T Map<T>(object obj) where T : class, new()
    {
        var props = obj.GetType().GetProperties();
        var ObjRT = new T();

        foreach (PropertyInfo dtoprop in props)
        {
            PropertyInfo? retprop = ObjRT.GetType().GetProperty(dtoprop.Name);
            if (retprop != null)
            {
                var t = dtoprop.PropertyType.Name;
                var t1 = retprop.PropertyType.Name;
                if ( t== t1)
                    retprop.SetValue(ObjRT, dtoprop.GetValue(obj));
            }
        }
        return ObjRT;


    }
}
