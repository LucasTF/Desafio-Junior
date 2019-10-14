using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace OrbiumDesafioRH.Resources
{
    public class EmployeeResource
    {
        [StringLength(40, MinimumLength = 2, ErrorMessage = "O nome precisa ter no mínimo 2 e não mais que 40 caracteres.")]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [RegularExpression(@"^[.\p{L}\s]*$", ErrorMessage = "O nome não deve conter números ou caracteres especiais.")]
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [MaxLength(60, ErrorMessage = "O email precisa ter no máximo 60 caracteres.")]
        [EmailAddress(ErrorMessage = "O email inserido não é válido.")]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [DataMember(Name = "email")]
        public string Email { get; set; }

        [MinLength(2, ErrorMessage = "O cargo precisa ter no mínimo 2 caracteres.")]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [DataMember(Name = "job")]
        public string Job { get; set; }

        [Range(0, 999999, ErrorMessage = "O valor do salário não pode ser negativo ou maior que 999999.")]
        [DataMember(Name = "salary")]
        [DataType(DataType.Currency, ErrorMessage = "Esse valor não é válido.")]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public double Salary { get; set; }
    }
}
