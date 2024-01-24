using System.Numerics;

namespace Vspt.Common.Api.Contract.Postgrees.DTO.Filters
{
    public record GetFilterIdLongNameDTO
    {
        public ulong Id { get; init; }
        public string Name { get; init; }
    }

}
