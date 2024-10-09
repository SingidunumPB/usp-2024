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

    public Many<User, Product> ReferencedOneToManyUser { get; set; }

    [OwnerSide] 
    public Many<User, Product> ReferencedManyToManyUser { get; set; }

    // public Category Category { get; set; }

    public Product()
    {
        this.InitOneToMany(() => ReferencedOneToManyUser);
        this.InitManyToMany(() => ReferencedManyToManyUser, user => user.ReferencedManyToManyProducts);
    }
}