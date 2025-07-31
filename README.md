
# 🔗 URL Shortener

Um simples encurtador de links construído com **.NET**, **PostgreSQL** e **Docker**.
<br>

## 📌 Sobre

Este projeto permite que você envie uma URL através de um formulário HTML (fornecido na rota principal `/`) e receba um link curto que redireciona automaticamente para o endereço original.

<br>

## 🚀 Como usar

### 1. Clonar o repositório

```bash
git clone https://github.com/Carlossnogueira/URL-Shortener.git
cd Url-Shortener
```

### 2. Subir com Docker Compose

Certifique-se de que você tenha o **Docker** e o **Docker Compose** instalados.

```bash
docker-compose up --build
```

Isso irá:

* Criar o banco PostgreSQL com as configurações apropriadas

Depois: 

-> Rode a aplicação .NET
-> Pronto para usar o serviço em `http://localhost:5080` (ou porta configurada)

<br>

## 🧪 Como funciona

### Criar um link curto

1. Acesse: `http://localhost:5080`
2. Envie a URL desejada usando o formulário na página.
3. Você receberá uma URL curta como retorno, ex:

   ```
   http://localhost:5080/abc123
   ```

### Usar o link curto

* Cole a URL curta no navegador
* Você será redirecionado automaticamente para a URL original

<br>

## ⚙️ Tecnologias utilizadas

* [.NET 8](https://dotnet.microsoft.com/)
* [PostgreSQL](https://www.postgresql.org/)
* [Docker](https://www.docker.com/)
* HTML + CSS simples para a interface

<br>

## 📂 Estrutura do projeto

```
url-shortener/
├── Controllers/
├── Data/
├── Migrations/
├── Model/
    └── Request/
    └── Url
├── Util/
├── wwwroot/
    └── js/
│   └── css/
├── Views/
    └── Url
├── docker-compose.yml
└── README.md
```


