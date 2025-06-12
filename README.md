# 📚 Clube da Leitura – Console App em C#

Projeto desenvolvido como atividade prática da **Academia do Programador**, com o objetivo de aplicar todos os pilares da **Programação Orientada a Objetos (POO)**: **encapsulamento**, **abstração**, **herança** e **polimorfismo**, em uma aplicação performática, funcional e bem estruturada.

---

## 🧠 Objetivo do Projeto

Substituir planilhas manuais de controle de empréstimos de revistas por um sistema de gerenciamento completo, com navegação via console e estrutura modular. O sistema simula o funcionamento de um clube de leitura, controlando **amigos**, **caixas**, **revistas**, **empréstimos**, **multas** e **reservas**.

---

## 🛠️ Tecnologias e Conceitos Utilizados

- ✅ **C# com .NET Console Application**
- ✅ **Visual Studio**
- ✅ **Programação Orientada a Objetos (POO)**
- ✅ **Regex para validação de telefone**
- ✅ **Arquitetura em Três Camadas**
  - `Apresentacao/` (interface via console)
  - `Dados/` (repositórios e armazenamento em memória)
  - `Dominio/` (entidades do sistema)
- ✅ **Validações consistentes por classe**
- ✅ **Regras de negócio integradas ao fluxo do sistema**
- ✅ **Controle de multas e reservas com impacto direto nos empréstimos**

---

## 📁 Estrutura do Projeto

```text
Academia_Programador_ClubeDaLeitura
│
├── Apresentacao/
│   ├── TelaAmigo.cs
│   ├── TelaCaixa.cs
│   ├── TelaRevista.cs
│   ├── TelaEmprestimo.cs
│   ├── TelaMulta.cs
│   └── TelaReserva.cs
│
├── Dados/
│   ├── RepositorioAmigo.cs
│   ├── RepositorioCaixa.cs
│   ├── RepositorioRevista.cs
│   ├── RepositorioEmprestimo.cs
│   ├── RepositorioMulta.cs
│   └── RepositorioReserva.cs
│
├── Dominio/
│   ├── Amigo.cs
│   ├── Caixa.cs
│   ├── Revista.cs
│   ├── Emprestimo.cs
│   ├── Multa.cs
│   └── Reserva.cs
│
└── Program.cs


````


# 📌 Regras de Negócio Implementadas

## 👥 Módulo de Amigos

Nome e telefone obrigatórios e únicos

Formato de telefone validado com Regex

Não permite exclusão de amigos com empréstimos vinculados

## 📦 Módulo de Caixas
Etiqueta única (identificação da caixa)

Define os dias de empréstimo das revistas associadas

Não pode ser excluída se houver revistas vinculadas

## 📚 Módulo de Revistas
Título + número da edição devem ser únicos

Status: Disponível, Emprestada, Reservada

Sempre vinculada a uma caixa

Ao ser cadastrada, status padrão é “Disponível”


## 🔄 Módulo de Empréstimos
Apenas um empréstimo ativo por amigo

Calcula automaticamente a data de devolução com base na caixa

Registra devoluções e detecta atrasos

Empréstimos atrasados geram multas automaticamente

Bloqueia empréstimo para amigos com multa pendente

Bloqueia empréstimo se a revista tiver reserva ativa (exceto do mesmo amigo)

## 💰 Módulo de Multas

Valor da multa: R$ 2,00 por dia de atraso

Geração automática após devolução com atraso

Status: Pendente / Quitada

Permite visualizar todas as multas e filtrá-las por amigo

Permite quitar multas

Amigos com multas pendentes não podem pegar novas revistas


## 🔒 Módulo de Reservas

Permite criar e cancelar reservas

Só é possível reservar revistas com status “Disponível”

Amigo não pode reservar se tiver multa pendente

Revistas com reserva ativa não podem ser emprestadas para outro amigo

Se o amigo com reserva ativa retira a revista, a reserva é concluída automaticamente



------------


