O que é o Validator?
=====================
O Validator é um projeto open-source escrito em .NET core

O objetivo da implementação deste projeto a princípio é a validação de uma senha, mas pode se estender a outras validaçãos como por exemplo CPF, CNPJ e Etc. 

A senha deve ser uma string e possuir as seguintes caracteristicas:

- Nove ou mais caracteres
- Ao menos 1 dígito
- Ao menos 1 letra minúscula
- Ao menos 1 letra maiúscula
- Ao menos 1 caractere especial
- Seguintes caracteres especiais: !@#$%^&*()-+
- Não possuir caracteres repetidos dentro do conjunto

###### Raciocinio
Para que fosse possível realizar a validação da senha, construi uma Regular Expression (REGEX) que valida os padrões mencionadas acima, porém houve um problema.
A Regex que construi identifica apenas caracteres duplicados que são consecutivos, então como solução realizei a ordenação e apliquei a regex para realizar a validação dos padrões e deu certo \o/

## Dê uma estrela :star:
Se você gostou deste projeto ou se o Validator te ajudou, por favor, dê uma estrela ;)

## Como usar:
- Você vai precisar da versão mais recente do Visual Studio 2019 ou se preferir, pode ser utilizado o Visual Studio Code.
- Além das IDE's, será preciso instalar o SDK do .NET mais atualizado.
- ***Verifique se você tem instalado a mesma versão do runtime (SDK) da aplicação***
- Você pode realizar o download das ultimas versões de ferramentas e SDK através do site https://dot.net/core.

Comandos .NET CLI que podem ser executados no diretório do projeto:
- **Limpar projetos**: ```dotnet clean```
- **Restaurar pacotes Nuget**: ```dotnet restore```
- **Buildar projetos**: ```dotnet build```
- **Executar Testes Unitarios e de Integração**: ```dotnet test```

Para levantar o localhost no projeto Validator.Api, é neccessário entrar no diretorio onde o projeto esteja e executar o comando:
- **Executar Projeto**: ```dotnet run```

Você também pode executar este projeto em qualquer SO, sendo ele Windows, Linux ou MacOs.

Para saber mais sobre como realizar o setup do ambiente .NET visite [Microsoft .NET Download Guide](https://www.microsoft.com/net/download) 

## Tecnologias implementadas:
- ASP.NET 5.0 (with .NET Core 5.0)
- ASP.NET MVC Core 
- ASP.NET WebApi Core
- .NET Core Native DI
- Swagger UI

## Arquitetura:
- Toda arquitetura baseada em separação de responsabilidade, SOLID e Clean Code
- Domain Driven Design (Layers)
- CQRS (Commands)
- Clean Architecture (UseCase)