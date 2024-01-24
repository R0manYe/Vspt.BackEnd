namespace Vspt.Common.Api.Contract.Postgrees.DTO.Claim;

public record GetRoleRequest
{
    public byte Id { get; set; }
    public string RoleName { get; set; }

}
