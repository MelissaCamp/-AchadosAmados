$(document).ready(function () {
    //url Base:
    urlBase = "https://adotadosapi20250328203822.azurewebsites.net/api";



    $.ajax({
        url: `${urlBase}/TipoAnimal`,
        type: "GET",
        contentType: 'application/json',
        success: function (dados) {
            let divCards = $('.categoria');

            dados.forEach(TipoAnimal => {
                let menuItem = `<li><a class="dropdown-item" href="pets.html?id=${TipoAnimal.idTpAnimal}">${TipoAnimal.nome}</a></li>`;
                divCards.append(menuItem);
                console.log(TipoAnimal)
            });
        },
        error: function (error) {
            console.log("Erro ao carregar categorias", error);
        }

    });

    var nome;
    if (!localStorage.getItem('token')) {
        nome = `<a class="nav-link" href="login.html">Login</a>`;
        $('.logado').html(nome); 
    } else {
        nome = `<a class="nav-link" href="perfil.html">Perfil</a>`;
        $('.logado').html(nome);
    }
    

});


