using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tasks.EntityModels;

public class ActivityDetail
{
    [Column("taskID")]
    public int TaskID { set; get; }

    [Column("personID")]
    public int PersonID { set; get; }

    [Column("activityID")]
    public int ActivityID { set; get; }
}