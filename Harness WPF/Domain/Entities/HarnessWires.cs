using Harness_WPF.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Harness_WPF.Domain.Entities;
public class HarnessWires : BaseEntity
{
    public int HarnessID { get; set; }
    [MaxLength(EntityConstants.DEFAULT_VARCHAR_LENGHT)]
    public string? Length { get; set; }
    [MaxLength(EntityConstants.DEFAULT_VARCHAR_LENGHT)]
    public string? Color { get; set; }
    [MaxLength(EntityConstants.DEFAULT_VARCHAR_LENGHT)]
    public string? Housing1 { get; set; }
    [MaxLength(EntityConstants.DEFAULT_VARCHAR_LENGHT)]
    public string? Housing2 { get; set; }


    public HarnessWires()
    {

    }

    public HarnessWires(
        int harnessID,
        string? length,
        string? housing1,
        string? housing2
    )
    {
        HarnessID = harnessID;
        Length = length;
        Housing1 = housing1;
        Housing2 = housing2;
    }
}
