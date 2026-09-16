using System.ComponentModel.DataAnnotations;

namespace Library.BackendData.Attributes
{
    /// <summary>
    /// Valideaza formatul codului ISBN introdus
    /// </summary>
    public class ValidIsbnAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is string isbn)
            {
                string cleanIsbn = isbn.Replace("-", "").Replace(" ", "");

                if (cleanIsbn.Length != 10 && cleanIsbn.Length != 13)
                {
                    return new ValidationResult("Codul ISBN trebuie sa contina 10 sau 13 cifre valide");
                }

                foreach (char caracter in cleanIsbn)
                {
                    // Daca gasim macar un caracter care nu este cifra, invalidam totul
                    if (!char.IsDigit(caracter))
                    {
                        return new ValidationResult("Codul ISBN poate contine doar cifre si cratime");
                    }
                }
            }
        }

            return ValidationResult.Success;
        }
    }
}