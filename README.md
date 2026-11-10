# 🐾 Achados e Amados – Sistema de Adoção de Animais

## 💡 Objetivo
O projeto **Achados e Amados** foi desenvolvido para uma ONG com o propósito de facilitar o processo de adoção de animais.
A plataforma permite o gerenciamento de cadastros de clientes, funcionários e animais disponíveis, tornando a adoção mais acessível, organizada e eficiente.

---

## ⚙️ Funcionalidades

### 👤 Cadastro de Usuários e Funcionários
- Cadastro e login de clientes interessados em adoção
- Cadastro de funcionários autorizados a gerenciar o sistema de acordo com suas funções

### 🐶 Gerenciamento de Animais
- Registro e gerenciamento de animais disponíveis para adoção
  - Nome, raça, idade, sexo, porte, descrição, tipo, data de cadastro, status (vacinado, castrado), foto
- Atualização do status do animal (disponível ou adotado)

### 📋 Processos Administrativos
- Controle de usuários com diferentes permissões (cliente vs. funcionário)
- Aplicativo desktop, acessível apenas aos funcionários, para acompanhamento do processo de adoção

---

## 🧩 Estrutura do repositório

```
achados-e-amados/
├─ web/       Site para os clientes (HTML5, CSS3, JavaScript + jQuery/AJAX)
├─ api/       API REST em ASP.NET Core 8 (JWT) com camadas AdotadosDAL / AdotadosBLL / AdotadosDTO
└─ desktop/   Aplicativo Windows Forms (.NET Framework 4.7.2) dos funcionários, em camadas UI / BLL / DAL / DTO
```

**Como as partes se conectam:**

```
web (site)  ──►  api (Azure App Service)  ──►  SQL Server (Azure SQL)
desktop     ─────────────────────────────────►  SQL Server (Azure SQL)
```

O site consome a API; o aplicativo desktop acessa o banco diretamente.

---

## 🛠️ Tecnologias Utilizadas

- **Frontend (site):** HTML5, CSS3, JavaScript, jQuery (AJAX)
- **Backend (API):** C# e ASP.NET Core 8, Entity Framework Core, autenticação JWT, Swagger
- **Desktop:** C# Windows Forms (.NET Framework 4.7.2), arquitetura em camadas
- **Banco de Dados:** SQL Server (Azure SQL em produção, LocalDB em desenvolvimento)
- **Ferramentas Adicionais:**
  - Visual Studio Code
  - Visual Studio 2022
  - Cloudinary (armazenamento de imagens)
  - Azure (hospedagem da API e banco de dados)

### Banco de Dados Relacional
- Tabelas principais: `Cliente`, `Funcionario`, `TipoFuncionario`, `Animal`, `TipoAnimal`, `Adotado`
- Chaves estrangeiras e integridade referencial

### Regras de Negócio
- Apenas funcionários podem cadastrar e editar dados dos animais
- Clientes só podem adotar animais com status "disponível"

---

## 🔐 Configuração

Credenciais **não ficam no código**. Configure-as antes de rodar:

### API (`api/`)
Gere uma chave com pelo menos 32 caracteres (ex.: `openssl rand -base64 64`) e guarde-a com *user-secrets*:

```bash
cd api/AdotadosAPI
dotnet user-secrets init
dotnet user-secrets set "Jwt:SecretKey" "<sua-chave>"
dotnet user-secrets set "ConnectionStrings:AdotadosAPIContext" "<sua-string-de-conexao>"   # opcional: o padrão usa LocalDB
dotnet run
```

O Swagger abre em `http://localhost:5099/swagger`.
Em produção (Azure App Service), use as configurações de aplicativo `Jwt__SecretKey` e `ConnectionStrings__AdotadosAPIContext`.

### Desktop (`desktop/`)
Defina a variável de ambiente com a string de conexão do SQL Server e **reinicie o Visual Studio**:

```bat
setx ACHADOS_DB_CONNECTION "Server=SEU_SERVIDOR;Initial Catalog=SEU_BANCO;User ID=SEU_USUARIO;Password=SUA_SENHA;Encrypt=True;"
```

Abra `desktop/AchadosEAmadosPI.sln` no Visual Studio 2022 e execute o projeto `AchadosEamados.UI`.

### Site (`web/`)
Abra `web/index.html` (ou use a extensão Live Server do VS Code). A URL da API fica na variável `urlBase`
dos arquivos em `web/js/ajax/` e `web/js/js/script.js`; altere-a para apontar para a sua API.

---

## 🌟 Impacto Esperado

- Auxiliar a ONG no controle e divulgação dos animais para adoção
- Melhorar o relacionamento com adotantes por meio de um sistema transparente e organizado
- Promover o bem-estar animal com mais rapidez e segurança nos processos de adoção
