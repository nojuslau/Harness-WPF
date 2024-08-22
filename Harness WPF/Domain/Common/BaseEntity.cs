using System.ComponentModel.DataAnnotations;

namespace Harness_WPF.Domain.Common;
public abstract class BaseEntity
{
    [Key]
    public string Id { get; init; }
}
