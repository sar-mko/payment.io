using System.ComponentModel.DataAnnotations;

namespace Payments.Models;

public class Purchase
{
    //unique id to grab items
    public int Id { get; set; }
    // actual money
    public decimal Amount {get; set;}
    //add required so description is mandatory
    
    [Required]
    // description of what it was
    public string? Description { get; set; }
    
    public string Category { get; set; }
    
    
    
    
}