using System.ComponentModel.DataAnnotations;

using System;
using System.ComponentModel.DataAnnotations;

namespace Library.BackendData.Models
{
    /// <summary>
    /// Valideaza ca anul introdus nu depaseste anul curent
    /// </summary>
    public class PastOrCurrentYearAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is int year && year > DateTime.Now.Year)
            {
                return new ValidationResult("An invalid");
            }
            return ValidationResult.Success;
        }
    }
}