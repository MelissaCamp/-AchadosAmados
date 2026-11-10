$(document).ready(function(){
    urlBase = "https://adotadosapi20250328203822.azurewebsites.net/api";
    
    $(document).on('click', '#btnAdotar', function(){

        let DadosAdocao={
            idAnimal: localStorage.getItem('idAnimal'),
            idCliente: localStorage.getItem('idCliente'),
            data: new Date
            
        }
        $.ajax({
            url: urlBase + "/Adotado",
            type: "POST",
            contentType: 'application/json',
            data: JSON.stringify(DadosAdocao),
            success: function(){
                alert('Solicitação de adoção feita com sucesso, em breve entraremos em contato, Obrigado');
            },
            error: function(erro){
                if(erro.status === 401){
                    alert("Sessão expirada");
                    location.href = 'login.html';
                }
                else{
                    alert('Erro ao adotar')
                    console.log(DadosAdocao, 'token',);
                }
            }

        });
    });
});


