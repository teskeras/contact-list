using System;

namespace ContactList.Data.Repository
{
    public interface IEntity<out TKey>
       where TKey : IComparable<TKey>
    {
        TKey Id { get; }
    }

    public interface IEntity : IEntity<int> { }
}
