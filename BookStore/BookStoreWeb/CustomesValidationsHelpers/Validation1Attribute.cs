using System.ComponentModel.DataAnnotations;

namespace BookStoreWeb.CustomesValidationsHelpers
{
    public class Validation1Attribute: ValidationAttribute
    {
        public Validation1Attribute(string text)
        {
            this.text = text;
        }
        public string text { get; set; }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string bookName = (string)value;
                if (bookName.Contains(text))
                {
                    return ValidationResult.Success;
                }
            }
            return new ValidationResult(ErrorMessage ?? "Book name not compatible");
        }
    }
}
