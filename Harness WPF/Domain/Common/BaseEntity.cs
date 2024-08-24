using System.ComponentModel.DataAnnotations;

namespace Harness_WPF.Domain.Common;
public abstract class BaseEntity
{
    [Required]
    [Key]
    public int Id { get; init; }
}
