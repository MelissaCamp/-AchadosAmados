
$(document).ready(function () {
    const urlBase = "https://adotadosapi20250328203822.azurewebsites.net/api";
    const cloudinaryUrl = "https://api.cloudinary.com/v1_1/ddgxpeqjq/image/upload";
    const uploadPreset = "imgCliente";

    const params = new URL(document.location.toString()).searchParams;
    const idCliente = params.get("id");

    $.ajax({
        url: urlBase + "/Cliente/ClienteLogado",
        type: "GET",
        contentType: 'application/json',
        headers: { 'Authorization': 'Bearer ' + localStorage.getItem('token') },
        success: function (dados) {
            console.log("Os dados do cliente são: ", dados);

            let sectionPerfil = $('.perfiluau');
            dados.forEach(cliente => {
                let cardPerfil = `
                <div class="perfilFoto">
                    <img id="fotoPerfil" src="${cliente.urlImgCliente}" alt="Foto de Perfil">
                </div>
                <div class="infPerfil">
                    <p id="nome">Nome: ${cliente.nome}</p>
                    <p id="email">Email: ${cliente.email}</p>
                    <p id="telefone">Telefone: ${cliente.telefone}</p>
                    <br>
                    <hr>
                    <br>
                    <a href="PerfilEditar.html?id=${cliente.idCliente}" id="editarinf">Editar informações</a>
                </div>
                <a href="index.html" id="logout">LogOut</a>
                `;
                sectionPerfil.append(cardPerfil);
            });
        },
        error: function (erro) {
            console.log("Erro ao carregar os dados do cliente: ", erro);
            if (erro.status == 401) {
                alert("Sessão expirada. Faça o Login");
                location.href = 'login.html';
            } else {
                alert("Erro ao Carregar informações");
            }
        }
    });

    // Atualizar os dados do cliente
    $(document).on('click', '#btnAtualizar', async function () {
        if ($('#nome').val().trim() === "" || $('#email').val().trim() === "" || $('#telefone').val().trim() === "" || $('#cpf').val().trim() === "" || $('#endereco').val().trim() === "" || $('#nro').val().trim() === "" || $('#bairro').val().trim() === "" || $('#cidade').val().trim() === "" || $('#estado').val().trim() === "") {
            alert("Preencha todos os campos por favor, caso queira atualizar");
            return;
        }

        let urlImgCliente = document.getElementById("file-upload").src; 
        const fileUpload = $('#file-upload')[0].files[0];

       
        if (fileUpload) {
            const formData = new FormData();
            formData.append("file", fileUpload);
            formData.append("upload_preset", uploadPreset); 

            try {
                const cloudinaryResponse = await fetch(cloudinaryUrl, {
                    method: "POST",
                    body: formData
                });
                const cloudinaryData = await cloudinaryResponse.json();

                if (cloudinaryData.secure_url) {
                    urlImgCliente = cloudinaryData.secure_url; 
                } else {
                    alert("Erro ao enviar a nova imagem. Tente novamente.");
                    return;
                }
            } catch (error) {
                console.error("Erro ao enviar a imagem para o Cloudinary:", error);
                alert("Erro ao enviar a imagem.");
                return;
            }
        }

      
        let dadosCliente = {
            idCliente: parseInt(idCliente),
            nome: $('#nome').val(),
            email: $('#email').val(),
            senha: $('#senha').val(),
            dtaNascimento: $('#dtaNasc').val(),
            telefone: $('#telefone').val(),
            cpf: $('#cpf').val(),
            endereco: $('#endereco').val(),
            nro: $('#nro').val(),
            bairro: $('#bairro').val(),
            cidade: $('#cidade').val(),
            estado: $('#estado').val(),
            urlImgCliente: urlImgCliente 
        };

        $.ajax({
            url: urlBase + "/Cliente/" + dadosCliente.idCliente,
            type: "PUT",
            contentType: "application/json",
            data: JSON.stringify(dadosCliente),
            headers: { 'Authorization': 'Bearer ' + localStorage.getItem('token') },
            success: function () {
                alert("Dados atualizados com sucesso!");
                location.href = 'perfil.html';
            },
            error: function (erro) {
                if (erro.status == 401) {
                    alert("Sessão expirada. Faça login novamente.");
                    location.href = 'login.html';
                } else {
                    alert("Erro ao Atualizar informações");
                }
                console.log("Erro:", erro.responseText);
            }
        });
    });


    $.ajax({
        url: urlBase + "/Cliente/" + idCliente,
        type: "GET",
        contentType: 'application/json',
        headers: { 'Authorization': 'Bearer ' + localStorage.getItem('token') },
        success: function (dados) {
            document.getElementById("nome").value = dados.nome;
            document.getElementById("dtaNasc").value = dados.dtaNascimento.split("T")[0];
            document.getElementById("cpf").value = dados.cpf;
            document.getElementById("email").value = dados.email;
            document.getElementById("senha").value = dados.senha;
            document.getElementById("telefone").value = dados.telefone;
            document.getElementById("endereco").value = dados.endereco;
            document.getElementById("nro").value = dados.nro;
            document.getElementById("bairro").value = dados.bairro;
            document.getElementById("cidade").value = dados.cidade;
            document.getElementById("estado").value = dados.estado;
            document.getElementById("file-upload").src = dados.urlImgCliente;
        },
        error: function (erro) {
            console.log("Erro ao carregar os dados do cliente:", erro);
        }
    });

    // Logout do cliente
    $(document).on('click', '#logout', function () {
        localStorage.removeItem('token');
        localStorage.removeItem('idCliente');
        location.href = 'siteAE/index.html';
    });
});
