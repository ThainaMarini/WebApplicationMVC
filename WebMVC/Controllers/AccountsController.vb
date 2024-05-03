Imports System
Imports System.Web.Mvc
Imports System.Collections.Generic
Imports System.Web.Security
Imports WebMVC.LoginViewModel
Imports WebMVC.AppMVCEntities
Imports System.Linq
Imports System.Net
Imports WebMVC.ChangePasswordViewModel


Namespace Controllers
    Public Class AccountsController
        Inherits Controller

        ' Cria uma nova instância do contexto do banco de dados do Entity Framework.
        Dim entity As New AppMVCEntities

        ' GET: Accounts
        Function Index() As ActionResult
            Return View()
        End Function

        Function Login() As ActionResult
            Return View()
        End Function

        Function SignUp() As ActionResult
            Return View()
        End Function

        ' Define que é obrigatório estar logado para acessar a pagina de alterar senha
        <Authorize>
        Function ChangePassword() As ActionResult
            Return View()
        End Function

        ' Método de login
        <HttpPost>
        Function Login(Credentials As LoginViewModel) As ActionResult
            Dim exist As Boolean = entity.Users.Any(Function(x) x.email.Equals(Credentials.Email) And x.senha.Equals(Credentials.Senha))

            ' Verifica se os campos email e senha estão vazios
            If String.IsNullOrWhiteSpace(Credentials.Email) OrElse String.IsNullOrWhiteSpace(Credentials.Senha) Then
                ModelState.AddModelError("", "Email e senha são obrigatórios")
                Return View()
            End If

            ' Se as credenciais existirem no bd, realiza login
            If exist Then
                ' Encontra usuário correspondente no bd
                Dim u As Users = entity.Users.FirstOrDefault(Function(x) x.email.Equals(Credentials.Email) And x.senha.Equals(Credentials.Senha))
                ' Define cookie de autenticação e redireciona para pagina inicial
                FormsAuthentication.SetAuthCookie(u.email, False)
                Return RedirectToAction("Index", "Home")
            Else
                ' Se as credenciais forem invalidas, adiciona erro ao modelo e retorna à pagina de login
                ModelState.AddModelError("", "Email ou Senha incorretos")
                Return View()
            End If
        End Function

        ' Método de cadastro
        <HttpPost>
        Function SignUp(Userinfo As Users) As ActionResult
            ' Verifica se algum campo está nulo
            If Userinfo.nome Is Nothing OrElse Userinfo.email Is Nothing OrElse Userinfo.senha Is Nothing Then
                ' Adiciona erro de modelo se algum campo estiver nulo
                ModelState.AddModelError("", "Todos os campos são obrigatórios")
                Return View()
            Else
                ' Verifica se o email ja existe no bd
                Dim emailExists = entity.Users.Any(Function(u) u.email = Userinfo.email)
                If emailExists Then
                    ' Adiciona erro de melo se o email ja estiver cadastrado 
                    ModelState.AddModelError("", "Este email já está cadastrado")
                    Return View()
                Else
                    ' Adiciona o novo usuário ao bd
                    entity.Users.Add(Userinfo)
                    ' Salva as mudanças no bd e redireciona para a página de login
                    entity.SaveChanges()
                    Return RedirectToAction("Login")
                End If

            End If
        End Function

        ' Método de deslogar usuário
        Function SignOut() As ActionResult
            ' Realiza logout do usuário e redireciona para a página de login
            FormsAuthentication.SignOut()
            Return RedirectToAction("Login")
        End Function

        ' Método de mudar a senha
        <HttpPost>
        Function ChangePassword(Credentials As ChangePasswordViewModel) As ActionResult
            ' Verifica se todos os campos estão preenchidos
            If Credentials.NovaSenha Is Nothing OrElse Credentials.SenhaAtual Is Nothing OrElse Credentials.ConfirmarSenha Is Nothing Then
                ' Adiciona erro de modelo se algum campo estiver nulo
                ModelState.AddModelError("", "Todos os campos são obrigatórios")
                Return View()

            Else
                ' Obtem email do usuário autenticado
                Dim userEmail As String = User.Identity.Name

                ' Obtém os dados do usuário com base no email
                Dim u = entity.Users.FirstOrDefault(Function(x) x.email = userEmail)

                If u.senha.Equals(Credentials.SenhaAtual) Then
                    ' Verifica se a nova senha e a confirmação coincidem
                    If Credentials.NovaSenha.Equals(Credentials.ConfirmarSenha) Then
                        u.senha = Credentials.NovaSenha
                        entity.SaveChanges()
                        Return RedirectToAction("Index", "Home")
                    Else
                        ' Retorna a view com erros de validação se o modelo não for válido
                        ModelState.AddModelError("", "Senhas não coincidem")
                        Return View()

                    End If
                Else
                    ' Retorna a view com erros de validação se o modelo não for válido
                    ModelState.AddModelError("", "Senha atual invalida")
                    Return View()
                End If
            End If


        End Function

    End Class
End Namespace