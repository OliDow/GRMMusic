using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace GrmMusic.Infrastructure
{
    public static class GrmExtensions

    {
        public static string RemoveDateTimeChars(this String str)
        {
            return str
                .Replace("st", "")
                .Replace("nd", "")
                .Replace("rd", "")
                .Replace("th", "");
        }

        public static string FirstFromSplit(this String str, char delimiter)
        {
            var i = str.IndexOf(delimiter);

            return i == -1 ? str : str.Substring(0, i);
        }

        public static string GetDisplayName(this Enum enumValue)
        {
            return enumValue.GetType().GetMember(enumValue.ToString())
                           .First()
                           .GetCustomAttribute<DisplayAttribute>()
                           .Name;
        }
    }
}

