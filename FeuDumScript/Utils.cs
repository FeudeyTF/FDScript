using System.Reflection;

namespace FeuDumScript
{
    internal static class Utils
    {
        public static void FillInterfaceCollection<TBase>(ref List<TBase> collection, Type[]? types = null, object[]? args = null)
        {
            types ??= [];
            args ??= [];
            var components = Assembly.GetExecutingAssembly().GetTypes();
            foreach (var type in components)
                if (!type.IsInterface && !type.IsAbstract)
                {
                    if (type.IsAssignableTo(typeof(TBase)))
                    {
                        var constructor = type.GetConstructor(types);
                        if (constructor != null)
                        {
                            TBase component = (TBase)constructor.Invoke(args);
                            if (component != null)
                                collection.Add(component);
                        }
                    }
                }
        }
    }
}
