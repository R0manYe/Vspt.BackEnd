using Vspt.BackEnd.Flagman.Domain.Entity;

namespace Vspt.BackEnd.Flagman.Domain.Contract
{
    public interface IVsptSubjectPersoneRepository
    {

        Task<List<Vspt_subject_persone>> GetVsptSubjectPersone(CancellationToken cancellationToken);
        Task<IReadOnlyList<Vspt_subject_personeFIODTO>> GetVsptSubjectPersoneFIO(CancellationToken cancellationToken);

    }
}