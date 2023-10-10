using MassTransit.Initializers;
using MassTransit.Saga;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using Vspt.BackEnd.Domain.Contract;
using Vspt.BackEnd.Domain.Entity;
using Vspt.BackEnd.Infrastructure.Database.EntityConfigurations;
using Vspt.Box.EfCore;
using Vspt.Common.Api.Contract.Postgrees.DTO.Filters;

namespace Vspt.BackEnd.Infrastructure.Repositories;

public class FilialsStationsDistrictsRepository : EntityRepository<PgContext, FilialsStationsDistricts>, IFilialsStationsDistrictsRepository
{
    public FilialsStationsDistrictsRepository(PgContext context) : base(context)
    {
    }

    public async Task<IReadOnlyList<GetFilterIdResponseDTO>> GetFilialStation(IReadOnlyList<GetFilterIdResponseDTO> existingFilials, CancellationToken cancellationToken)
    {
       return await  _entityDbSet.Where(c =>existingFilials.Select(x=>x.Id).Contains(c.BuId)).Select(s=> new GetFilterIdResponseDTO
       {
           Id=s.StationECPId
       }).ToListAsync(cancellationToken);
            
      
       

       
         


    }
}

   
