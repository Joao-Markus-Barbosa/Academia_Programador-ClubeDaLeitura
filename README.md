# 📚 Clube da Leitura – Console App em C#

Projeto desenvolvido como atividade prática da **Academia do Programador**, com o objetivo de aplicar **todos os princípios da Programação Orientada a Objetos (POO)**, incluindo **encapsulamento**, **abstração**, **herança** e **polimorfismo**, em uma aplicação funcional, performática e bem estruturada.

---

## 🧠 Objetivo do Projeto

Substituir planilhas manuais de controle de empréstimos de revistas por um sistema orientado a objetos, em **C# com Visual Studio**, utilizando menus interativos via console.

---

## 🛠️ Tecnologias e Conceitos Utilizados

- ✅ **C#**
- ✅ **.NET Console Application**
- ✅ **Programação Orientada a Objetos**
- ✅ **Regex para validação de telefone**
- ✅ **Validações completas por classe**
- ✅ **Arquitetura em Três Camadas**:
  - Apresentação (`TelaX`)
  - Repositório (`RepositorioX`)
  - Entidade (`Domínio`)

---

## 🧱 Estrutura do Projeto
````
Academia_Programador_ClubeDaLeitura
│
├── Apresentacao/
│ ├── TelaAmigo.cs
│ ├── TelaCaixa.cs
│ ├── TelaRevista.cs
│ └── TelaEmprestimo.cs
│
├── Dados/
│ ├── RepositorioAmigo.cs
│ ├── RepositorioCaixa.cs
│ ├── RepositorioRevista.cs
│ └── RepositorioEmprestimo.cs
│
├── Dominio/
│ ├── Amigo.cs
│ ├── Caixa.cs
│ ├── Revista.cs
│ └── Emprestimo.cs
│
└── Program.cs

````
---

## 📌 Regras de Negócio Implementadas

### Módulo de Amigos
- Nome e telefone não podem se repetir
- Valida formato de telefone com Regex
- Não permite excluir amigo com empréstimos ativos

### Módulo de Caixas
- Etiqueta única
- Caixa define prazo de devolução
- Bloqueia exclusão se houver revistas vinculadas

### Módulo de Revistas
- Título + edição não podem repetir
- Status: Disponível, Emprestada, Reservada
- Sempre vinculada a uma caixa

### Módulo de Empréstimos
- Apenas 1 empréstimo ativo por amigo
- Data de devolução calculada com base na caixa
- Registra devoluções e destaca atrasos

