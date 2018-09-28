using System;

namespace Monona.Core.Entities
{
    public interface IEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        TKey Id { get; }
    }
}
