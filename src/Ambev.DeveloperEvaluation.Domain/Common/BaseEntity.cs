using System.ComponentModel.DataAnnotations;
using Validation;
using Validator = Validation.Validator;

namespace Indt.Proposta.Domain.Common;

public class BaseEntity
{
    [Key]
    public int Id { get; set; }

    public Task<IEnumerable<ValidationErrorDetail>> ValidateAsync()
    {
        return Validator.ValidateAsync(this);
    }
}
