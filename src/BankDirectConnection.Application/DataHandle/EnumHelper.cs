using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.BaseApplication.DataHandle
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/1/25 17:10:53
	===============================================================================================================================*/
    public static class EnumHelper
    {

        public static string GetEnumValue<T>(T EnumValue)
        {
            Type type = EnumValue.GetType();
            FieldInfo info = type.GetField(EnumValue.ToString());
            if (info == null) return null;
            return (info.GetCustomAttributes(typeof(DefaultValueAttribute), true)[0] as DefaultValueAttribute).Value.ToString();
        }

        public static T GetEnumValue<T>(string Value)
        {
            Type type = typeof(T);
            T emValue = default(T);
            bool IsExists = false;
            foreach (var field in type.GetFields())
            {
                if (field.FieldType == typeof(T))
                    if ((field.GetCustomAttributes(typeof(DefaultValueAttribute), true)[0] as DefaultValueAttribute).Value.ToString() == Value)
                    {
                        IsExists = true;
                        emValue = (T)Enum.Parse(typeof(T), field.Name.ToString());
                    }
            }
            if (IsExists)
                return emValue;
            else
                throw (new Exception("枚举数据值不存在。"));
        }

        public static string GetEnumDescription<T>(T EnumValue)
        {
            Type type = EnumValue.GetType();
            FieldInfo info = type.GetField(EnumValue.ToString());
            if (info == null) return null;
            return (info.GetCustomAttributes(typeof(DescriptionAttribute), true)[0] as DescriptionAttribute).Description.ToString();
        }
    }
}
