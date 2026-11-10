$(document).ready(function () {
    urlBase = "https://adotadosapi20250328203822.azurewebsites.net/api";

    $(document).on('click', '#btnLogin', function () {
        let dadosLogin = {
            email: $('#email').val(),
            senha: $('#senha').val()
        }
        if (dadosLogin.email == "" || dadosLogin.senha == "") {
            alert("preencha todos os campos!");
        } else {



            $.ajax({
                url: urlBase + "/Login",
                type: "POST",
                contentType: 'application/json',
                data: JSON.stringify(dadosLogin),
                success: function (dados) {

                    
                    localStorage.setItem('token', dados.token);

             
                    localStorage.setItem('idCliente', dados.idCliente);

                    location.href = "perfil.html";
                    console.log("ID do Cliente salvo no localStorage:", localStorage.getItem("idCliente"));


                    // perfil = $('.login').val = "";
                    // perfil = "perfil"
                    // let divPerfil = $('.log');
                    // let divPerfilLogin = ` <a class="nav-link" href="perfil.html">Perfil</a>`;
                    // divPerfil.append(divPerfilLogin)
                    console.log(dados.token, dadosLogin);

                },
                error: function (erro) {

                    if (erro.status == 401) {
                        alert('Email ou senha incorretos');
                    }
                    else {
                        alert('Falha ao logar');
                    }
                    console.log(erro.responseText);
                }
            });
        }
    });
});