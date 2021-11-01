 using System.Collections.Generic;

namespace JobsnContractors.Interfaces

{

public interface IRepository<T>

{

/// <summary>
/// Get all items in the collection
/// </summary>

List<T> Get();

/// <summary>
/// Get a single item by its id
/// <param name='id'></param>
/// </summary>

T Get(int id);

/// <summary>
/// Adds data to the database and returns the data with its id
/// <param name='data'></param>
/// <param name='id'></param>
/// </summary>

T Create(T data);

/// <summary>
/// Finds an item by its id and updates it to the passed in data
/// <param name='data'></param>
/// </summary>

T Edit(int id, T data);

/// <summary>
/// Finds an item by its id to be removed
/// <param name='id'></param>
/// </summary>

void Delete(int id);

}

}
