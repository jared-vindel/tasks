using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Tasks.EntityModels;

namespace Tasks.Web.Pages;

public class IndexModel : PageModel{

  private TasksContext _db { get; set; }

  public IndexModel(TasksContext db){
    _db = db; 
  }

  public IEnumerable<Activity>? Activities { get; set; }

  [BindProperty] 
  public Activity? Activity {get; set;}

  public void OnGet(){
    ViewData["title"] = "Inicio";
    Activities = _db.Activities;
  }

}