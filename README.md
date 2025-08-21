<div align="center">
  <h1 align="center">Calculadora de Notas POO</h1>
  <p align="center">
    <img src="https://img.shields.io/badge/.NET-9.0-blueviolet" alt=".NET Version">
    <img src="https://img.shields.io/badge/language-C%23-green" alt="Language">
    <img src="https://img.shields.io/badge/license-MIT-blue" alt="License">
  </p>
</div>

---

### 📖 Índice

- [Sobre o Projeto](#-sobre-o-projeto)
- [✨ Features](#-features)
- [🛠️ Tecnologias Utilizadas](#️-tecnologias-utilizadas)
- [🚀 Começando](#-começando)
  - [Pré-requisitos](#-pré-requisitos)
  - [Instalação](#-instalação)
- [🔥 Uso](#-uso)
- [🤝 Como Contribuir](#-como-contribuir)
- [📄 Licença](#-licença)

---

### 💻 Sobre o Projeto

O **Calculadora de Notas POO** é um sistema de console desenvolvido em C# com .NET, focado no gerenciamento de matérias e notas acadêmicas. O projeto aplica conceitos de Programação Orientada a Objetos (POO) para criar uma estrutura organizada e de fácil manutenção, separando as responsabilidades em camadas de Serviços, Repositórios e Modelos. Ele permite que o usuário realize um controle completo sobre suas matérias, lance notas, e utilize calculadoras para prever o desempenho necessário para aprovação.

Este projeto resolve o problema da falta de uma ferramenta simples e local para estudantes gerenciarem seu progresso acadêmico, permitindo não apenas o armazenamento de notas, mas também o cálculo de cenários futuros (quanto é preciso tirar no exame final, por exemplo).

---

### ✨ Features

- **Gerenciamento de Matérias:**
  - [x] Cadastrar novas matérias com nome, professor e período.
  - [x] Listar todas as matérias cadastradas.
  - [x] Editar as informações de uma matéria existente.
  - [x] Excluir matérias do sistema.

- **Gerenciamento de Notas:**
  - [x] Lançar notas do primeiro e segundo bimestre para uma matéria.
  - [x] Cadastrar a nota de exame final, se necessário.
  - [x] Listar todas as notas lançadas.
  - [x] Editar notas existentes.
  - [x] Excluir um registro de notas.

- **Cálculos Acadêmicos:**
  - [x] Calcular a nota mínima necessária no 2º bimestre para ser aprovado.
  - [x] Calcular a nota mínima necessária no exame final.
  - [x] Verificar o status de aprovação com base nas notas lançadas.

---

### 🛠️ Tecnologias Utilizadas

- **[.NET 9](https://dotnet.microsoft.com/pt-br/download)**: Framework principal para a construção da aplicação.
- **[C#](https://docs.microsoft.com/en-us/dotnet/csharp/)**: Linguagem de programação utilizada.
- **[SQL Server](https://www.microsoft.com/pt-br/sql-server)**: Banco de dados para persistência dos dados. (O projeto está configurado para usar a instância `SQLEXPRESS`).
- **Entity Framework Core (via `Microsoft.Data.SqlClient`)**: Para a comunicação com o banco de dados.

---

### 🚀 Começando

Siga estas instruções para configurar e rodar o projeto em sua máquina local.

#### Pré-requisitos

- **.NET 9 SDK** ou superior.
- Uma instância do **SQL Server** rodando (o projeto está configurado para `.\\SQLEXPRESS`).
- Um gerenciador de banco de dados como o **SQL Server Management Studio (SSMS)** ou **Azure Data Studio** para criar o banco de dados e as tabelas.

#### Instalação

1.  **Clone o repositório:**
    ```bash
    git clone [https://github.com/arielm11/calculadora-de-notas-poo.git](https://github.com/arielm11/calculadora-de-notas-poo.git)
    cd calculadora-de-notas-poo
    ```

2.  **Configure o Banco de Dados:**
    - Abra seu gerenciador de banco de dados e crie um novo banco chamado `MeuBancoTeste`.
    - Execute os seguintes scripts SQL para criar as tabelas `Materias` e `Notas`:

    ```sql
    CREATE TABLE Materias (
        COD_MATERIA INT PRIMARY KEY IDENTITY(1,1),
        NOM_MATERIA VARCHAR(100) NOT NULL,
        NOM_PROFESSOR VARCHAR(100),
        PERIODO INT
    );

    CREATE TABLE Notas (
        COD_NOTA INT PRIMARY KEY IDENTITY(1,1),
        COD_MATERIA INT NOT NULL,
        PRIMEIRA_NOTA DECIMAL(5, 2),
        SEGUNDA_NOTA DECIMAL(5, 2),
        EXAME_FINAL DECIMAL(5, 2),
        NOTA_FINAL DECIMAL(5, 2),
        FOREIGN KEY (COD_MATERIA) REFERENCES Materias(COD_MATERIA) ON DELETE CASCADE
    );
    ```

3.  **Restaure as dependências do .NET:**
    O .NET restaurará os pacotes automaticamente ao construir o projeto, mas você pode fazer isso manualmente com o comando:
    ```bash
    dotnet restore
    ```

---

### 🔥 Uso

Após a instalação e configuração do banco de dados, você pode iniciar a aplicação. O projeto é uma aplicação de console interativa.

1.  **Execute o projeto:**
    ```bash
    dotnet run
    ```
2.  **Navegue pelo menu:**
    O console exibirá um menu principal onde você poderá escolher entre gerenciar "Matérias" ou "Notas". Siga as instruções numéricas para navegar entre as opções de cadastrar, consultar, editar, excluir e realizar cálculos.

---

### 🤝 Como Contribuir

Contribuições são o que tornam a comunidade de código aberto um lugar incrível para aprender, inspirar e criar. Qualquer contribuição que você fizer será **muito apreciada**.

1.  **Faça um Fork** do projeto.
2.  **Crie sua Feature Branch** (`git checkout -b feature/AmazingFeature`).
3.  **Faça o Commit** de suas alterações (`git commit -m 'Add some AmazingFeature'`).
4.  **Faça o Push** para a Branch (`git push origin feature/AmazingFeature`).
5.  **Abra um Pull Request**.

---

### 📄 Licença

Distribuído sob a licença MIT. Veja `LICENSE` para mais informações.