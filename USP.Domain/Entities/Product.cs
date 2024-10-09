using MongoDB.Entities;
using USP.Domain.Enums;

namespace USP.Domain.Entities;

public class Product : Entity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public User User { get; set; }
    
    public One<User> ReferencedOneToOneUser { get; set; }
    public Category Category { get; set; }
}