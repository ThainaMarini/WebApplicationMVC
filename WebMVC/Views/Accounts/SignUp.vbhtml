@ModelType WebMVC.Users
@Code
    ViewData("Title") = "Cadastrar"
End Code

<h2>Cadastrar</h2>

@Using (Html.BeginForm()) 
    @Html.AntiForgeryToken()

    @<div class="form-horizontal">
         <form method="post">
             <hr />
             @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
             <div class="form-group">
                 @Html.LabelFor(Function(model) model.email, htmlAttributes:=New With {.class = "control-label col-md-2"})
                 <div class="col-md-10">
                     @Html.EditorFor(Function(model) model.email, New With {.htmlAttributes = New With {.type = "text"}})
                     
                 </div>
             </div>

             <div class="form-group">
                 @Html.LabelFor(Function(model) model.senha, htmlAttributes:=New With {.class = "control-label col-md-2"})
                 <div class="col-md-10">
                     @Html.EditorFor(Function(model) model.senha, New With {.htmlAttributes = New With {.type = "password"}})
                     
                 </div>
             </div>

             <div class="form-group">
                 @Html.LabelFor(Function(model) model.nome, htmlAttributes:=New With {.class = "control-label col-md-2"})
                 <div class="col-md-10">
                     @Html.EditorFor(Function(model) model.nome, New With {.htmlAttributes = New With {.type = "text"}})
                     
                 </div>
             </div>

             <div class="form-group">
                 <div class="col-md-offset-2 col-md-10">
                     <input type="submit" value="Cadastrar" class="btn btn-default" />
                 </div>
             </div>
         </form>
</div>
End Using

<div>
    @Html.ActionLink("Voltar", "Index", "Home")
</div>

@Section Scripts 
    @Scripts.Render("~/bundles/jqueryval")
End Section
