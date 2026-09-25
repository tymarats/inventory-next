#nullable disable

namespace Codaxy.Inventory.Entities;

public interface IIdentifiableReadOnly<T>
{
    T Id { get; }
}

public interface IIdentifiableInit<T> : IIdentifiableReadOnly<T>
{
    new T Id { get; init; }
}

public interface IIdentifiable<T> : IIdentifiableReadOnly<T>
{
    new T Id { get; set; }
}
