using BAGA.Repository.Interfaces;

namespace BAGA.Repository.Repositories
{
  public class UnitOfWork
  {
     private readonly IContext _context;


     public UnitOfWork()  
        {
            _context = new BAEntities();
        }

        public UnitOfWork(IContext context)
        {
            _context = context;
        }
    public string Save()
    {
      return _context.Save();
    }

    internal IContext Context
    {
      get { return _context; }
    }
  }
}
