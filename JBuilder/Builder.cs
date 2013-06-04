using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JBuilder
{
    public static class Builder
    {
        public static dynamic BuildSingle(Type type)
        {
            dynamic TObject = Activator.CreateInstance(type); // default(T);
            IList<PropertyInfo> props = TObject.GetType().GetProperties();
            props.ToList().ForEach(prop =>
                {
                    if (prop.PropertyType.Namespace == "System")
                    {
                        TObject.GetType().InvokeMember(prop.Name, BindingFlags.SetProperty, null,
                            TObject, new object[] { prop.Name + "1" });
                    }
                    else
                    {
                        
                        TObject.GetType().InvokeMember(prop.Name, BindingFlags.SetProperty, null,
                            TObject, new object[] {BuildSingle(prop.PropertyType.UnderlyingSystemType)});                        
                    }

                });
            return TObject;
        }
    }
}
