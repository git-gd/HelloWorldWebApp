using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorldWebApp.Controllers
{
    [Route("/helloworld/")]
    public class HelloController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            string html = "<form method='post' action='/helloworld/welcome'>" +
                        "<input type='text' name='name' />" +
                        "<select name='language'>" +
                            "<option value='english'>English</option>" +
                            "<option value='french'>French</option>" +
                            "<option value='spanish'>Spanish</option>" +
                            "<option value='german'>German</option>" +
                            "<option value='russian'>Russian</option>" +
                        "</select>" +
                        "<input type='submit' value='Greet Me!' />" +
                        "</form>";

            return Content(html, "text/html");
        }

        [HttpGet("welcome/{name?}")]
        [HttpPost("welcome")]
        public IActionResult Welcome(string name = "DEFAULT", string language = "english")
        {
            Dictionary<string, string> hello = new Dictionary<string, string>();
            hello.Add("english", "Hello");
            hello.Add("french", "Bonjour");
            hello.Add("spanish", "Hola");
            hello.Add("german", "Guten tag");
            hello.Add("russian", "Privet");

            return Content($"<h1 style='color:blue;text-align:center'>{hello[language]} {name}</h1>", "text/html");

            //return Content("<h1>Welcome to my app, " + name + "!</h1>", "text/html");
                       
        }
    }
}
