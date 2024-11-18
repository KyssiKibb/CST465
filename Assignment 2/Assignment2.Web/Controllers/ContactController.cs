using System;
public class ContactController : Controller
{
    public IActionResult ContactHTML() 
    {
         return View(); 
    }
    
    public IActionResult ContactTagHelper() 
    {
         return View(); 
    }
}