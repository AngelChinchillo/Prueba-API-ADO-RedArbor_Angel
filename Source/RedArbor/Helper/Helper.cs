using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace RedArbor.Helper
{

    public static class Helper
    {
        #region Insertar los valores de un datareader a su clase equivalente
        public static TEntity ReflectType<TEntity>(IDataRecord dr) where TEntity : class, new()
        {
            TEntity instanceToPopulate = new TEntity();

            PropertyInfo[] propertyInfos = typeof(TEntity).GetProperties
            (BindingFlags.Public | BindingFlags.Instance);

            //for each public property on the original
            foreach (PropertyInfo pi in propertyInfos)
            {
                DataFieldAttribute[] datafieldAttributeArray = pi.GetCustomAttributes
                (typeof(DataFieldAttribute), false) as DataFieldAttribute[];

                //this attribute is marked with AllowMultiple=false
                if (datafieldAttributeArray != null && datafieldAttributeArray.Length == 1)
                {
                    DataFieldAttribute dfa = datafieldAttributeArray[0];

                    //this will blow up if the datareader does not contain the item keyed dfa.Name
                    object dbValue = dr[dfa.Name];

                    if (dbValue != null)
                    {
                        pi.SetValue(instanceToPopulate, Convert.ChangeType
                        (dbValue, pi.PropertyType, CultureInfo.InvariantCulture), null);
                    }
                }
            }
            return instanceToPopulate;
        }

        #endregion
        #region Castear una clase a otra
        public static T Cast<T>(this object myobj)
        {
            Type objectType = myobj.GetType();
            Type target = typeof(T);
            var x = Activator.CreateInstance(target, false);
            var z = from source in objectType.GetMembers().ToList()
                    where source.MemberType == MemberTypes.Property
                    select source;
            var d = from source in target.GetMembers().ToList()
                    where source.MemberType == MemberTypes.Property
                    select source;
            List<MemberInfo> members = d.Where(memberInfo => d.Select(c => c.Name)
               .ToList().Contains(memberInfo.Name)).ToList();
            PropertyInfo propertyInfo;
            object value;
            foreach (var memberInfo in members)
            {
                propertyInfo = typeof(T).GetProperty(memberInfo.Name);
                value = myobj.GetType().GetProperty(memberInfo.Name).GetValue(myobj, null);

                propertyInfo.SetValue(x, value, null);
            }
            return (T)x;
        }

        #endregion
    }

}
