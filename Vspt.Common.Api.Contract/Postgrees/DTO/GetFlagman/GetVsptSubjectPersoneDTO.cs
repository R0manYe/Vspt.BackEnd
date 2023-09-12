using System.ComponentModel.DataAnnotations;

namespace Vspt.Common.Api.Contract.Postgrees.DTO.GetFlagman;

public partial class GetVsptSubjectPersoneDTO
{   
    [Key]
    public string ID { get; set; }

    public string? LAST_NAME { get; set; }

    public string? FIRST_NAME { get; set; }

    public string? SECOND_NAME { get; set; }
    public string? PROF_ID { get; set; }
    public string? PROF { get; set; }
    public string? DIV_ID { get; set; }
    public string? DIV_NAME { get; set; }
    public string? BU { get; set; }
    public string? BU_ID { get; set; }
}
