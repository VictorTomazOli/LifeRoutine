using LifeRoutineV0.Domain.Entities;
using LifeRoutineV0.Domain.Repositories;
using LifeRoutineV0.Infra.Context;

namespace LifeRoutineV0.Infra.Repositories;

public class AlimentoRepository(LifeRoutineV0DbContext context) 
    : Repository<Alimento> (context) , IAlimentoRepository
{

}