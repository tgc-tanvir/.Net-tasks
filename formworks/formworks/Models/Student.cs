using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace formworks.Models
{
    public class Student
    {
        [Required(ErrorMessage = "Please provide Id")]
        [RegularExpression(@"^\d{2}-\d{5}-\d{1}$", ErrorMessage = "Id must follow the pattern XX-XXXXX-X (where X is a digit).")]
        public string Id { get; set; }
        [Required]
        [RegularExpression(@"^[A-Za-z .-]+$", ErrorMessage = "Name must only contain alphabets, dots, dashes and spaces.")]
        public string Name { get; set; }
   
        [CustomEmailValidation(ErrorMessage = "Email must start with the same ID and follow the format XX-XXXXX-X@student.aiub.edu.")]
        public string Email { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Profession { get; set; }
        [Required]
        [CustomAgeValidation(ErrorMessage = "You must be over 18 years old")]
        public DateTime Dob { get; set; }
        [Required]
        public string[] Hobbies { get; set; }
    }
    public class CustomAgeValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null || !(value is string))
            {
                return false;
            }
            var dob = (DateTime)value;
            var diff = DateTime.Today.DayOfYear - dob.DayOfYear;
            if (diff > 18)
            {
                return true;
            }
            return false;
        }
    }
    public class CustomEmailValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || !(value is string email))
            {
                return new ValidationResult("Invalid email format");
            }
            var student = (Student)validationContext.ObjectInstance;


            var id = student.Id.ToString();

            var expectedEmail = "@student.aiub.edu";

            if (email.StartsWith(id) && email.EndsWith(expectedEmail))
            {
                if (email.Length == id.Length + expectedEmail.Length)
                {
                    return ValidationResult.Success;
                }
            }

            return new ValidationResult(ErrorMessage);
        }
    }
}