$(document).ready(function () {
urlBase = "https://adotadosapi20250328203822.azurewebsites.net/api";

    $.ajax({
        url: `${urlBase}/Animal`,
        type: 'GET',
        contentType: 'application/json',
        success: function (dados) {
            console.log(dados)
            let divCard = $('.cardPet');
            for (let i = 0; i < 3; i++) {
                if (dados[i]) {
                    let animal = dados[i];


                    let card = `<li class="pet">
                        <div class="decoCard"><img src="./img/imgDecorativaCards.png" alt=""></div>
                        <img src="${animal.urlImgAnimal}" alt="pet" class="imagem">
                        <p>Nome: ${animal.nome}</p>
                        <a href="petsDetalhes.html?id=${animal.idAnimal}">Mais detalhes</a>
                    </li>`;
                    divCard.append(card);
                }
            }
        },
        error: function (error) {
            console.log(error);
        }
    });




    $(document).ready(function () {
        $.ajax({
            url: `${urlBase}/Animal`,
            type: 'GET',
            contentType: 'application/json',
            dataType: 'json',
            cache: false,  
            success: function(dados) {



                console.log("Os dados são:", dados);
                if (!dados || dados.length === 0) {
                    console.log("Nenhum animal encontrado.");
                    return;
                }
                let animal = dados[6]; 
               
                if (animal.urlImgAnimal) {
                    $('.animais').attr('src', animal.urlImgAnimal);
                } else {
                    console.log("Imagem do animal não disponível.");
                }
                
                let vacina;

                if(animal.ehVacinado === true){
                    vacina = " Sim";
                    
                }else if(animal.ehVacinado === false){
                    vacina = " Não";
                    
                }
                else{
                    console.log("o estado da vacina é: ", vacina);
                }
                
                let card = `
                <img class="coroa" src="img/imgDecorativaCoroa.png" alt="">
                <img class="animais" src="${animal.urlImgAnimal}" alt="Animal">
                <ul>
                <h1>- - - - - - - - - - - - -</h1>
                <li><p>Nome: ${animal.nome}</p></li>
                <li><p>Idade: ${animal.idade}</p></li>
                <li><p id="vacinadoQuestao">Vacinado?: ${vacina}</p></li>
                <li>
                <p>Se interessou?</p>
                <p class="teste">Clique para mais detalhes para a adoção:</p>
                </li>
                <li><a href="petsDetalhes.html?id=${animal.idAnimal}">Mais detalhes</a></li>
                </ul>`;
                

                $('.petInformacoes').html(card);
                console.log("HTML do card atualizado:", $('.petInformacoes').html());
            },
            error: function(error) {
                console.log("Erro ao buscar dados:", error);
            }
        });





       
    });

});