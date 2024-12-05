using Microsoft.AspNetCore.Mvc.RazorPages; // To use PageModel.
using Microsoft.AspNetCore.Mvc; // To use [BindProperty], IActionResult.
using Tasks.EntityModels;

namespace Tasks.Web.Pages;

public class TasksModel : PageModel
{

  private TasksContext _db;

  public TasksModel(TasksContext db)
  {
    _db = db;
  }

  public IEnumerable<EntityModels.Task>? Tasks { get; set; }

  [BindProperty]
  public EntityModels.Task? Task { get; set; }

  public void OnGet()
  {
    ViewData["title"] = "Tareas";
    Tasks = _db.Tasks.OrderBy(t => t.TaskName);
  }

  public IActionResult OnPostAdd()
  {
    if (Task is not null && ModelState.IsValid)
    {
      bool exists = _db.Tasks.Any(t => t.TaskName.ToLower() == Task.TaskName.ToLower());

      if (exists)
      {
        return BadRequest(); // Task already exists
      }

      if (exists)
      {
        return BadRequest();
      }
      _db.Tasks.Add(Task);
      _db.SaveChanges();
      return RedirectToPage("Tasks");
    }
    else
    {
      return BadRequest();
    }
  }
}