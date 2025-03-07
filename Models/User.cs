using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace VintageGameLibrary.Models
{
    [TypeConverter(typeof(UserTypeConverter))]
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public bool IsAdmin { get; set; } = false;
    }

    public class UserTypeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType)
        {
            return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
        }

        public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
        {
            if (value is string stringValue)
            {
                // Implement conversion logic here
                return new User { Username = stringValue };
            }
            return base.ConvertFrom(context, culture, value);
        }
    }
}
