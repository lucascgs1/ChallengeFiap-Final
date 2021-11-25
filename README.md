# IGirls



# ChallengeFinal

```
TECNAR

86084 - Alan Oliveira
84177 - Lucas Coutinho Gonçalves de Souza
85928 - Natália Batista dos Santos
85818 - Rafael Silva Romualdo
```

## Desafio
- Desenvolver um projeto que colabore com uma ODS da ONU

## Tecnologias utilizadas

- .NET 5
- SQL SERVER

## Arquivos do projeto

Slide da apresentação
https://docs.google.com/presentation/d/1xrpCjo9cPi1R0bgi6wQ7ba1M50IxMMokcC77OiJn11w/edit#slide=id.gfc17449fa5_0_25

Wireframe da apliacação
https://www.figma.com/file/Lk4T2bNMnFa3G2SRNV9jl6/Wireframe?node-id=0%3A1

### Dependências de projeto

Para abrir a aplicação é necessário instalar o [visual studio] com o pacote de desenvolvimento .net web

### Execução

 - Criar um banco SQL
 - Alterar a string de conexão no appsettings.json
 - Executar o comando "dotnet ef database update" no console apontando para a pasta do ChallengeFiap.Data
 - Executar a API apertando f5 ou clicando no botão verde no centro superior da tela
 - Abrir a url https://localhost:44375/swagger/index.html para visualizar o Swagger 
 - Para realizar as operações que necessitam de autenticação é necessário logar atráves do endpoint 'conta/autenticar'
 - Pegar a string do token e colocar no campo authorize com o prefixo 'bearer'

[visual studio]: <https://visualstudio.microsoft.com/pt-br/downloads/>
