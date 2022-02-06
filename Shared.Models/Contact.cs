using System;
using System.ComponentModel.DataAnnotations;

namespace Shared.Models;

public class Contact
{
    [Required]
    public string? Name { get; set; } 

    [Required]
    [EmailAddress]
    public string? Email { get; set; }

    [StringLength(25)]
    public string? Phone { get; set; }
}
