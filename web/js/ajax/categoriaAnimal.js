
$(document).ready(function(){

    const params = new URL(document.location.toString()).searchParams;

    const idTpAnimal = params.get("id");

    const urlBase = "https://adotadosapi20250328203822.azurewebsites.net/api";
 


    console.log("ID do Tipo de Animal:", idTpAnimal);
 
    if (!idTpAnimal) {

        alert("ID do tipo de animal não encontrado na URL.");

        return;

    }
 
    $.ajax({

        url: `${urlBase}/Animal/`,

        type: "GET",

        contentType: 'application/json',

        success: function(dados){

            const divCard = $('.row');

            const filtro = dados.filter(animal => animal.idTpAnimal == idTpAnimal);
 
            if(filtro.length === 0){

                divCard.append('<p>Nenhum pet encontrado para esta categoria.</p>');

            } else {

                filtro.forEach(animal => {

                    const card = `
<div class="m-auto p-5" style="width: 29em;">
                                <div class="col">
                                    <div class="card">
                                        <div class="card h-100" style="background-color:#f8a475" id="Pet">
                                            <img class="card-img-top animais" src="${animal.urlImgAnimal}" width="450"
                                                alt="..." id="imagem" />
                                            <div class="card-body p-4">
                                                <div class="text-center">
                                                    <h6 id="nomePet">Nome: ${animal.nome}</h6>
                                                    <h6 id="idadePet">Idade: ${animal.idade}</h6>
                                                </div>
                                            </div>
                                            <div class="text-center" id="categoria">
                                                <a class="btn m-4"
                                                    href="petsDetalhes.html?id=${animal.idAnimal}">Ver Mais</a>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>`;

                    divCard.append(card);

                });

            }

        },

        error: function(error){

            alert("Erro ao carregar categoria");

        }

    });
 
    $.ajax({

        url: `${urlBase}/TipoAnimal/${idTpAnimal}`,

        type: "GET",

        contentType: 'application/json',

        success: function(dados){

            const divCard = $('.titulo');

            const tituloCategoria = `<h1>Pets</h1>
                <p id="tipoPet">${dados.nome}s</p>
                <p>--------------------------------------------</p>`;

            divCard.append(tituloCategoria);

        },

        error: function(error){

            console.log("Erro ao carregar nome da categoria:", error);

        }

    });

});
 