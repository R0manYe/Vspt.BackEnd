using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vspt.BackEnd.Flagman.Domain.Entity;
using Vspt.Common.Api.Contracts.Pagination;

namespace Vspt.BackEnd.Application.Services.SubjectPersone
{
    public interface ISubjectPersoneService
    {
        Task<IReadOnlyList<Vspt_subject_personeDTO>> GetSubjectPersone(Paging request);       
    }
}
