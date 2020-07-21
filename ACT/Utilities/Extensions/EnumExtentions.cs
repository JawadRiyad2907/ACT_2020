using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ACT.Utilities.Extensions
{
    public static class EnumExtentions
    {
        public static List<SelectListItem> ToSelectList<T>(this T enumVal, bool markAsSelected = false, int[] excludeValues = null) where T : struct
        {
            if (!typeof(T).IsEnum)
                throw new ArgumentException("The object you are trying to parse is not enum", nameof(enumVal));

            var vals = from T enumValue in System.Enum.GetValues(typeof(T))
                       where excludeValues == null || !excludeValues.Contains(Convert.ToInt32(enumValue))
                       select new SelectListItem
                       {
                           Text = enumValue.GetLocalizedValue(),
                           Value = Convert.ToInt32(enumValue).ToString(),
                           Selected = markAsSelected && Convert.ToInt32(enumVal) == Convert.ToInt32(enumValue)
                       };

            return vals.ToList();
        }

        public static string GetLocalizedValue<T>(this T item) where T : struct
        {
            string result = "";
            string enumName = typeof(T).Name;
            string name = System.Enum.GetName(typeof(T), item);
            result = Resources.EnumResource.ResourceManager.GetString(string.Format("{0}_{1}", enumName, name));
            if (string.IsNullOrWhiteSpace(result))
                result = ConvertEnum(item.ToString());

            return result;
        }
        private static string ConvertEnum(string str)
        {
            if (string.IsNullOrEmpty(str)) return string.Empty;
            string result = string.Empty;
            foreach (var c in str)
                if (c.ToString() != c.ToString().ToLower())
                    result += " " + c.ToString();
                else
                    result += c.ToString();
            return result;
        }

        public static T Parse<T>(this T item, string text) where T : struct
        {
            string filteredText = text.Trim().ToLower().RemoveSpecialCharacters();

            var vals = from T enumValue in System.Enum.GetValues(typeof(T))
                       where enumValue.ToString().Trim().ToLower().RemoveSpecialCharacters() == filteredText
                       select enumValue;
            return vals.FirstOrDefault();
        }

        private static string RemoveSpecialCharacters(this string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        public static string GetEnumStringById(Type EnumType, int EnumId)
        {
            string enumName = EnumType.Name;
            string name = System.Enum.GetName(EnumType, EnumId);
            return Resources.EnumResource.ResourceManager.GetString(string.Format("{0}_{1}", enumName, name));
        }

    }
}