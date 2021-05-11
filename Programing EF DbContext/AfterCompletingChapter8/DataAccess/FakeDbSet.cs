using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Testing
{
  public abstract class FakeDbSet<T> : IDbSet<T>
    where T : class, new()
  {
    readonly ObservableCollection<T> _items;
    readonly IQueryable _query;

    public FakeDbSet()
    {
      _items = new ObservableCollection<T>();
      _query = _items.AsQueryable();
    }

    public T Add(T entity)
    {
      _items.Add(entity);
      return entity;
    }

    public T Attach(T entity)
    {
      _items.Add(entity);
      return entity;
    }

    public TDerivedEntity Create<TDerivedEntity>()
      where TDerivedEntity : class, T
    {
      return Activator.CreateInstance<TDerivedEntity>();
    }

    public T Create()
    {
      return new T();
    }

    public abstract T Find(params object[] keyValues);

    public ObservableCollection<T> Local
    {
      get
      {
        return _items;
      }
    }

    public T Remove(T entity)
    {
      _items.Remove(entity);
      return entity;
    }

    public IEnumerator<T> GetEnumerator()
    {
      return _items.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return _items.GetEnumerator();
    }

    public Type ElementType
    {
      get { return _query.ElementType; }
    }

    public Expression Expression
    {
      get { return _query.Expression; }
    }

    public IQueryProvider Provider
    {
      get { return _query.Provider; }
    }
  }
}