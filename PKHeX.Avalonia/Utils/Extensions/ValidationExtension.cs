using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PKHeX.Avalonia.Utils;

public static class ValidationExtension
{
    /// <summary>
    /// Validates whether specific value is not null, and throws an exception if it is null.
    /// </summary>
    /// <param name="v">The value to validate.</param>
    /// <param name="name">Name of the value</param>
    public static T CheckNotNull<T>(this T? v, string name)
    {
        if (v == null)
        {
            throw new ArgumentNullException(name);
        }
        return v;
    }

    /// <summary>
    /// Validates an object based on its DataAnnotations and throws an exception if the object is not valid.
    /// </summary>
    /// <param name="v">The object to validate.</param>
    public static T ValidateAndThrow<T>(this T v)
    {
        v.CheckNotNull(nameof(v));
        Validator.ValidateObject(v, new ValidationContext(v), true);
        return v;
    }

    /// <summary>
    /// Validates an object based on its DataAnnotations and returns a list of validation errors.
    /// </summary>
    /// <param name="v">The object to validate.</param>
    /// <returns>A list of validation errors.</returns>
    public static ICollection<ValidationResult>? Validate<T>(this T v)
    {
        v.CheckNotNull(nameof(v));
        var results = new List<ValidationResult>();
        var context = new ValidationContext(v);
        if (!Validator.TryValidateObject(v, context, results, true))
        {
            return results;
        }
        return null;
    }
}
