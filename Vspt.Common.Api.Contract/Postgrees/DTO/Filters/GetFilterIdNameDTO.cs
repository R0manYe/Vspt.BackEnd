namespace Vspt.Common.Api.Contract.Postgrees.DTO.Filters
{
    public record GetFilterIdNameDTO
    {
        public uint Id { get; init; }
        public string Name { get; init; }
    }

}
