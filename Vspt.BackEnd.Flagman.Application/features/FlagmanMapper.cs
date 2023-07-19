using AutoMapper;
using Vspt.BackEnd.Flagman.Application.features.DTO;
using Vspt.BackEnd.Flagman.Domain.Entity;

namespace Vspt.BackEnd.Application.features.Authentication
{
    internal sealed class FlagmanMapper : Profile
    {
        public FlagmanMapper() 
        {
            CreateMap<GetDislokaciaRequestItem, Dislokacia>();
            CreateMap<Dislokacia, GetDislokaciaRequestItem>();
        }
    }
}
