@ModelType WebMVC.LoginViewModel
@Code
    ViewData("Title") = "Login"
End Code

<h2>Login</h2>

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()

    @<div class="form-horizontal">
         <form method="post">
             <hr />
             @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
             <div class="form-group">
                 @Html.LabelFor(Function(model) model.Email, htmlAttributes:=New With {.class = "control-label col-md-2"})
                 <div class="col-md-10">
                     @Html.EditorFor(Function(model) model.Email, New With {.htmlAttributes = New With {.type = "text", .name = "u"}})
                     @Html.ValidationMessageFor(Function(model) model.Email, "", New With {.class = "text-danger"})
                 </div>
             </div>

             <div class="form-group">
                 @Html.LabelFor(Function(model) model.Senha, htmlAttributes:=New With {.class = "control-label col-md-2"})
                 <div class="col-md-10">
                     @Html.PasswordFor(Function(model) model.Senha, New With {.htmlAttributes = New With {.type = "password", .name = "p"}})
                     @Html.ValidationMessageFor(Function(model) model.Senha, "", New With {.class = "text-danger"})
                 </div>
             </div>

             <div class="form-group">
                 <div class="col-md-offset-2 col-md-10">
                     <input type="submit" value="Login" class="btn btn-default" />
                 </div>
             </div>
         </form>
</div>
End Using

@Code
    If TempData("SuccessMessage") IsNot Nothing Then
        @<div class="alert alert-success">@TempData("SuccessMessage")</div>
    End If
End Code


<div>
    @Html.ActionLink("Voltar", "Index", "Home")
</div>

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section