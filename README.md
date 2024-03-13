# Projeto Emprestimos de Livros

## Objetivo
- Cadastrar - Editar - Listar e Excluir Usuários
- Cadastrar - Editar - Listar e Excluir Livros
- Cadastrar novo empréstimo associando as entidades usuários e livros, respeitando regras de negócios das quais o fornecedor do empréstimo deve ser diferente do recebedor e o livro deve pertencer ao fornecedor.
### Outras Regras
  - O Sistema não deve permitir a exclusão de um usuário do qual tenha livros cadastrados.
  - O Sistema não deve permitir a exclusão de um usuário do qual tenha empréstimos cadastradas, tanto atuando como fornecedor ou recebedor.
  - O Sistema nâo deve permitir a exclusão de um livro que esteja envolvido em um empréstimo ativo.
## Tecnologias
- C# .NET SQLServer Entity Framework

## Arquitetura MVC 
Utilizei o padrão de arquitetura mvc nesse projeto por acreditar ser a melhor maneira de lidar com os objetivos finais, separando as responsabilidades dentro do sistema garantindo um bom desempenho.
