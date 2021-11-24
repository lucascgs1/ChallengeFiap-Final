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
- Desenvolver um projeto que colabore com uma ods da onu

## Tecnologias utilizadas

- .NET 5
- SQL SERVER

## Arquivo do projeto

slide da apresentacao
https://docs.google.com/presentation/d/1xrpCjo9cPi1R0bgi6wQ7ba1M50IxMMokcC77OiJn11w/edit#slide=id.gfc17449fa5_0_25

wireframe da apliacacao
https://www.figma.com/file/Lk4T2bNMnFa3G2SRNV9jl6/Wireframe?node-id=0%3A1

### Dependencias de projeto

Para abrir a aplicação é necessario Instalar o [visual studio] com o pacote de desenvolvimento .net web

### Execução

 - Criar um banco sql
 - alterar a string de conexao no appsettings.json
 - executar o comando "dotnet ef database update" no console apontando para a pasta do ChallengeFiap.Data
 - executar a api apertando f5 ou clicando no botao verde no centro superior da tela
 - abrir a url https://localhost:44375/swagger/index.html para visualizar o swagger 
 - para realizar as operacoes que necessitam de autenticacao é necessario logar atraves do endpoint 'conta/autenticar'
 - pegar a string do token e colocar no campo authorize com o prefixo 'bearer '

[visual studio]: <https://visualstudio.microsoft.com/pt-br/downloads/>
