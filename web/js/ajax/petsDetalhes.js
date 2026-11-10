
$(document).ready(function () {
    const urlBase = "https://adotadosapi20250328203822.azurewebsites.net/api";
    const params = new URL(document.location.toString()).searchParams;
    const idAnimal = params.get("id");
    const idCliente = params.get("idCliente");

    console.log("ID do Animal:", idAnimal);
    console.log("ID do Cliente:", localStorage.getItem("idCliente"));
    if (!idAnimal) {
        alert("ID do animal não encontrado na URL.");
        return;
    }
    $.ajax({
        url: `${urlBase}/Animal/${idAnimal}`,
        type: "GET",
        contentType: 'application/json',
        success: function (dados) {
            if (!dados || dados.length === 0) {
                console.log("Nenhum animal encontrado.");
                alert("Nenhum animal encontrado.");
                return;
            }
            let vacina;
        
            if(dados.ehVacinado === true){
                vacina = " Sim";
                
            }else if(dados.ehVacinado === false){
                vacina = " Não";
                
            }
            else{
                console.log("o estado da vacina é: ", vacina);
            }
            let castrado;
        
            if(dados.ehCastrado === true){
                castrado = " Sim";
                
            }else if(dados.ehCastrado === false){
                castrado = " Não";
                
            }
            else{
                console.log("o estado da vacina é: ", vacina);
            }
            // Atualizar informações técnicas
            const divInf = $('.infTecnicas');
            const cardInf = `<h2>Mais Informações</h2>
                <ul>
                    <li>
                        <p id="vacina">Vacinas: ${vacina}</p>
                    </li>
                    <li>
                        <p id="sexo">Sexo: ${dados.sexo}</p>
                    </li>
                    <li>
                        <p id="raca">Raça: ${dados.raca}</p>
                    </li>
                    <li>
                        <p id="raca">Castrado(a)?: ${castrado}</p>
                    </li>
                </ul>`;
            divInf.append(cardInf);



            // Atualizar detalhes do animal
            if (dados.urlImgAnimal) {
                $('.animais').attr('src', dados.urlImgAnimal);
            } else {
                console.log("Imagem do animal não disponível.");
            }
            const divCard = $('.petDetalhes');
            const card = `<div class="col-md-5">
                            <img class="card-img-top mb-5 mb-md-0" src="${dados.urlImgAnimal}" alt="..." id="imagem" />
                        </div>
                        <div class="col-md-6" id="InfPet">
                            <h1 class="display-5" id="nomePet">Nome: ${dados.nome}</h1>
                            <div class="fs-5 mb-5">
                                <span id="idadePet">Idade: ${dados.idade}</span>
                            </div>
                            <p class="lead" id="descricaoPet">${dados.descricao}</p>
                            <div class="d-flex">
                                <button class="btn btn-outline-danger flex-shrink-0" type="button" id="btnAdotar">
                                    <i class="bi bi-whatsapp"></i>
                                    Quero adotar!
                                </button>
                            </div>
                        </div>`;
            divCard.append(card);
        },
        error: function (error) {
            console.log(error);
        }
    });
    $(document).on('click', '#btnAdotar', function confirmarAcao() {
        const params = new URL(document.location.toString()).searchParams;
        const idAnimal = params.get("id");
        const idCliente = params.get(localStorage.getItem("idCliente"));
        const resultado = confirm("Você tem certeza que quer continuar?");
        if (!resultado) {
            alert("Ação cancelada.");
            return;
        }

    
        // const idCliente = params.get("idCliente");
        // const idAnimal = params.get("idAnimal");
        const DadosAdocao = {
            idAnimal: idAnimal,
            idCliente: localStorage.getItem("idCliente"),
            dtaAdocao: new Date().toISOString()
        };
        $.ajax({
            url: `${urlBase}/Adotado` ,
            type: "POST",
            contentType: 'application/json',
            data: JSON.stringify(DadosAdocao),
            success: function () {
                alert('Solicitação de adoção feita com sucesso, em breve enviaremos um email. Obrigado!');
            },
            error: function (erro) {
                if (erro.status == 400) {
                    alert("Sessão expirada");
                    
                    location.href = 'login.html';
                } else {
                    alert('Erro ao adotar');
                    console.log(DadosAdocao)
                }
            }
        });
       
        });
    
    });

 