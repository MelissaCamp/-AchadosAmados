
$(document).ready(function(){
    const urlBase = "https://adotadosapi20250328203822.azurewebsites.net/api";
    const cloudinaryUrl = "https://api.cloudinary.com/v1_1/ddgxpeqjq/image/upload"; 
    $(document).on('click', '#btnCadastrar', async function(){
        const fileUpload = $('#file-upload')[0].files[0];

        if (!fileUpload) {
            alert("Escolha uma imagem!");
            return;
        }


        const formData = new FormData();
        formData.append("file", fileUpload);
        formData.append("upload_preset", "imgCliente");


        try {
            const cloudinaryResponse = await fetch(cloudinaryUrl, {
                method: "POST",
                body: formData
            });

            const cloudinaryData = await cloudinaryResponse.json();

            if (!cloudinaryData) {
                alert("Erro ao enviar a imagem para o Cloudinary");
                return;
            }

            const DadosCadastro = {
                nome: $('#nome').val(),
                email: $('#email').val(),
                telefone: $('#telefone').val(),
                cpf: $('#cpf').val(),
                senha: $('#senha').val(),
                endereco: $('#endereco').val(),
                nro: $('#nro').val(),
                bairro: $('#bairro').val(),
                cidade: $('#cidade').val(),
                estado: $('#estado').val(),
                urlImgCliente: cloudinaryData.secure_url, 

                dtaNascimento: $('#dtaNasc').val()
            };

            if (Object.values(DadosCadastro).some(value => value === "")) {
                alert("Preencha todos os campos!");
                return;
            }

            $.ajax({
                url: `${urlBase}/Cliente`,
                type: "POST",
                contentType: 'application/json',
                data: JSON.stringify(DadosCadastro),
                success: function(dados) {
                    console.log("FormData enviado:", formData);

                    console.log("Dados de Cadastro:", DadosCadastro);
                    alert('Cadastro feito com sucesso');
                }, 
                error: function(erro) {
                    console.log("FormData enviado:", formData);

                    console.log("Ocorreu um erro ao realizar o cadastro:", erro);
                    console.log("Dados de Cadastro:", DadosCadastro);
                    alert('Erro ao cadastrar');
                }
            });
        } catch (error) {
            console.log("FormData enviado:", formData);

            console.error("Erro ao integrar com Cloudinary:", error);
            alert("Erro ao realizar o upload da imagem.");
        }
    });
});
