# OVERVIEW
This second ASP.NET CORE application was really nothing special. Except a demo
to help have a feel of what ASP.NET Core dev looked like. it was a great reminder
of working using the MVC architecture. In fact, the project was built using the mvc
template using the shell:
```
    dotnet new globaljson --sdk-version 6.0.100 --output PartyInvites
    dotnet new mvc --no-https --output PartyInvites --framework net6.0
    dotnet new sln -o PartyInvites
    dotnet sln PartyInvites add PartyInvites
```

***

# Key Learning Points

These are all stuff I knew how to do prior to starting this chapter. I just only didn't knew
how to implement the same thing, using C# syntax, even though I Had some C# experience. Nor did
I know how to blend C# and HTML or other technologies, taking advantage of the powerful abilities
of views.

1. Creating a data Model.

    Most of the time, data model will take the shape of a class:
    ```
        public class GuestResponse {

            // These are auto-implemented properties in C#
            public string? Name { get; set; }
            public string? Email { get; set; }
            public string? Phone {get; set; }
            public bool? WillAttend { get; set; }
        }
    ```

2. Defining Action Methods.

    Action Methods are defined in controllers and specify the view that will get rendered to the browser.
    They are defined within a controller class like so:
    ```
        public class HomeController: Controller {
            public IActionResult Index() {  // This is an action method
                return View();
            }

            // This is another action method
            public ViewResult RsvpForm() {
                return View();
            }
        }
    ```
    The razor view engine, when not explicity specified, look at the name of the method to decide which
    view to render the correct view file, which must have the same name.

3. Adding Validation to Data Entries in a Form.

    It is done by simnply adding the following line, in the model class, on top of the property
    we want to check:
    ```
        [Required(ErrorMessage = "Please enter your email address")]
        [EmailAddress] // getting specific about the nature of the data
    ```

4. Adding Style.

    It is done directly in the view, just like you would normally do in HTML
    ```
        <link rel="stylesheet" href="/lib/bootstrap/dist/css/bootstrap.css">
        // This example uses the css bootstrap library that comes with the template
        // to style the view content.
    ```