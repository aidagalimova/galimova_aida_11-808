using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace posts
{
    public class Validation
    {
		public ValidationResult Validate(object obj)
		{
			Type type = obj.GetType();
			var fields = type.GetProperties();
			foreach(var field in fields)
			{
				var attrs = Attribute.GetCustomAttributes(field);
				foreach (ValidationAttribute attr in attrs)
				{
						if (!attr.IsValid(field.GetValue(obj)))
						{
							return new ValidationResult(false, attr.ErrorMessage);
						}
				}
			}

			return new ValidationResult(true);
		}
	}
}
