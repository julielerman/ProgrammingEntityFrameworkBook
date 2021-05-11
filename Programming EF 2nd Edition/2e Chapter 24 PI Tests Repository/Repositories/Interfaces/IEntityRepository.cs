using System.Collections.Generic;

namespace BAGA.Repository.Interfaces
{
  public interface IEntityRepository<TEntity>
  {
   // IContext Context { get; }
    TEntity GetById(int id);
    void Add(TEntity entity);
    void Attach(TEntity entity);
    void Delete(TEntity entity);
    IList<TEntity> All();
    
  }
}