namespace Portfolio.Backend.Models;

using System.ComponentModel.DataAnnotations;

public abstract class BaseModel
{
    [Key]
    public Guid Id { get; init; }

    public BaseModel()
    {
        Id = Guid.NewGuid();
    }
}