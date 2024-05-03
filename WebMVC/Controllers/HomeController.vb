<Authorize>
Public Class HomeController
    Inherits System.Web.Mvc.Controller


    <AllowAnonymous>
    Function Index() As ActionResult
        Return View()
    End Function

    <AllowAnonymous>
    Function About() As ActionResult
        ViewData("Message") = "Your application description page."

        Return View()
    End Function

    <AllowAnonymous>
    Function Contact() As ActionResult
        ViewData("Message") = "Your contact page."

        Return View()
    End Function
End Class
