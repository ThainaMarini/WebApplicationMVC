@Code
    Dim entity As New AppMVCEntities

    ' Variável booleana de controle para verificar se usuário está logado
    Dim isLoggedIn As Boolean = True

    ' Verifica se o nome do usuário está vazio ou nulo
    If String.IsNullOrWhiteSpace(User.Identity.Name) Then
        ' Então nao está logado e troca variável de controle
        isLoggedIn = False
    End If

    Dim userEmail As String = User.Identity.Name

    ' Obtém os dados do usuário com base no email
    Dim u = entity.Users.FirstOrDefault(Function(x) x.email = userEmail)



End Code

<!DOCTYPE html>
<html>
<head>
    <meta charset = "utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <title>@ViewBag.Title</title>
    @Styles.Render("~/Content/css")
    @Scripts.Render("~/bundles/modernizr")
</head>
<body>
    <div class="navbar navbar-inverse navbar-fixed-top">
        <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                @Html.ActionLink("Aplicação MVC", "Index", "Home", New With {.area = ""}, New With {.class = "navbar-brand"})
            </div>
            <div class="navbar-collapse collapse">
                <ul class="nav navbar-nav">
                    <li>@Html.ActionLink("Home", "Index", "Home")</li>
                    <li>@Html.ActionLink("Sobre", "About", "Home")</li>
                    <li>@Html.ActionLink("Contato", "Contact", "Home")</li>
                    @Code
                        ' Se o usuário está logado, trocar opções de navegação do header
                        If (isLoggedIn) Then
                            @<li>@Html.ActionLink(u.nome, "Index", "Home")</li>
                            @<li>@Html.ActionLink("Alterar senha", "ChangePassword", "Accounts")</li>
                            @<li>@Html.ActionLink("Sair", "SignOut", "Accounts")</li>
                        Else
                            @<li>@Html.ActionLink("Entrar", "Login", "Accounts")</li>
                            @<li>@Html.ActionLink("Cadastrar", "SignUp", "Accounts")</li>
                        End If
                    End Code
                </ul>
            </div>
        </div>
    </div>
    <div class="container body-content">
        @RenderBody()
        <hr />
        <footer>
            <p>&copy; @DateTime.Now.Year - Aplicação A</p>
        </footer>
    </div>

    @Scripts.Render("~/bundles/jquery")
    @Scripts.Render("~/bundles/bootstrap")
    @RenderSection("scripts", required:=False)
</body>
</html>
