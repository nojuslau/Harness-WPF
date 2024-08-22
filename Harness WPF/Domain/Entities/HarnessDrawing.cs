using Harness_WPF.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Harness_WPF.Domain.Entities
{
    public class HarnessDrawing : BaseEntity
    {
        [MaxLength(EntityConstants.DEFAULT_VARCHAR_LENGHT)]
        public string? Harness { get; set; }
        [MaxLength(EntityConstants.DEFAULT_VARCHAR_LENGHT)]
        public string? HarnessVersion { get; set; }
        [MaxLength(EntityConstants.DEFAULT_VARCHAR_LENGHT)]
        public string? Drawing { get; set; }
        [MaxLength(EntityConstants.DEFAULT_VARCHAR_LENGHT)]
        public string? DrawingVersion { get; set; }

        public HarnessDrawing()
        {

        }

        public HarnessDrawing(
            string? harness,
            string? harnessVersion,
            string? drawing,
            string? darwingVersion
        )
        {
            Harness = harness;
            HarnessVersion = harnessVersion;
            Drawing = drawing;
            DrawingVersion = DrawingVersion;
        }
    }
}
