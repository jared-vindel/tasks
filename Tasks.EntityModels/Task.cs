using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tasks.EntityModels;

public class Task
{
    [Key]
    [Column("taskID")]
    public int TaskID { set; get; }

    
    [Column("taskName", TypeName = "nvarchar (50)")]
    [StringLength(50)]
    [Required]
    public string TaskName { set; get; } = null!;

    [Column("description", TypeName = "nvarchar (100)")]
    [StringLength(100)]
    public string Description { set; get; } = null!;

} 