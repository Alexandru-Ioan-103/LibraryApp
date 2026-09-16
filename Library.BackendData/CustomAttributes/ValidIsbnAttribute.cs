using System.ComponentModel.DataAnnotations;

namespace Library.BackendData.CustomAttributes
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

                // vrem cod numai de lungime 10 / 13;
                if (cleanIsbn.Length != 10 && cleanIsbn.Length != 13)
                {
                    return new ValidationResult("Cod ISBN invalid");
                }

                // vrem cod numa idin cifre;
                foreach (char caracter in cleanIsbn)
                {
                    if (!char.IsDigit(caracter))
                    {
                        return new ValidationResult("Cod ISBN invalid");
                    }
                }
            }

            return ValidationResult.Success;
        }
    }
}