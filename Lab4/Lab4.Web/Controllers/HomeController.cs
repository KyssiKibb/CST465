using Lab4.Objects;
using System;

public class HomeController : Controller

{

    public IActionResult Index() 

    {

         return View(); 

    }

    public IActionResult Laborers()
    {
        ChoreWorkforce myWorkforce = new ChoreWorkforce();
        myWorkforce.Laborers.Add(new ChoreLaborer(){   Name = "Bob", Age = 7, Difficulty = 5 });
        myWorkforce.Laborers.Add(new ChoreLaborer(){   Name = "Jack", Age = 15, Difficulty = 2 });
        myWorkforce.Laborers.Add(new ChoreLaborer(){   Name = "Jill", Age = 14, Difficulty = 3 });
        myWorkforce.Laborers.Add(new ChoreLaborer(){   Name = "Hardy", Age = 25, Difficulty = 8 });
        for(int i = 0; i < 30; ++i)
        {
            myWorkforce.AddRandomLaborer();
        }

        ChoreWorkforce FilteredWorkforce = new ChoreWorkforce();

        IEnumerable<ChoreLaborer> workforce = myWorkforce.Laborers.Where(Laborer => (Laborer?.Age ?? 0) > 2 && Laborer?.Age < 11 && Laborer?.Difficulty < 8);
        workforce = workforce.OrderBy(Laborer => Laborer?.Name);
        foreach(var Laborer in workforce)
        {
            FilteredWorkforce.Laborers.Add(Laborer);
        }
        return View(FilteredWorkforce);
    }

}