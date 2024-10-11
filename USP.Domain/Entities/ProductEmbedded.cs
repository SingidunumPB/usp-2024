using MongoDB.Entities;
using USP.Domain.Enums;

namespace USP.Domain.Entities;

public class ProductEmbedded : Entity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public User User { get; set; }
    public User ReferencedOneToOneUser { get; set; }
    public List<User> ReferencedOneToManyUser { get; set; }
    public List<User> ReferencedManyToManyUser { get; set; }
}