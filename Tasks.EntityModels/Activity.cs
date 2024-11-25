using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tasks.EntityModels;

public class Activity
{
    [Key]
    [Column("activityID")]
    public int ActivityID { set; get; }

    
    [Column("activityName", TypeName = "nvarchar (50)")]
    [StringLength(50)]
    [Required]
    public string ActivityName { set; get; } = null!;

    [Column("date", TypeName = "date")]
    [Required]
    public DateTime Date { set; get; }

    [Column("description", TypeName = "nvarchar (100)")]
    [StringLength(100)]
    public string Description { set; get; } = null!;

    //TO DO agregar un ICollection con las Tasks que tenga la actividad para ordenarlas
} 