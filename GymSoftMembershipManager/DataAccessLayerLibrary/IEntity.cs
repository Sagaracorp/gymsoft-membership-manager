using System;
namespace DataAccessLayerLibrary
{
    interface IEntity
    {
        bool Delete(int user);
        int Id { get; }
        DateTime InsertedAt { get; }
        int InsertedBy { get; set; }
        bool IsDeleted { get; set; }
        bool Save(int user);
        DateTime UpdatedAt { get; }
        int UpdatedBy { get; set; }
    }
}
