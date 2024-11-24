using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tasks.EntityModels;
public class Person
{
    [Key]
    [Column("personID")]
    public int PersonID {get; set;}
    
    [Column("firstName", TypeName = "nvarchar (50)")]
    [StringLength(50)]
    [Required]
    public string FirstName {get; set;} = null!;

    [Column("lastName", TypeName = "nvarchar (50)")]
    [StringLength(50)]
    [Required]
    public string LastName {get; set;} = null!;


}