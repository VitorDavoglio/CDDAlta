# CDDAlta
Para rodar o projeto é necessário executar os seguintes comandos no CMD ou Powershell:

- abrir o arquivo API_CodigoPenal\appsettings.json para apontar a connectionString DefaultConnection para o banco de dados desejado.
EX: "ConnectionStrings": {
    "DefaultConnection": "Data Source={SeuDataSource};Initial Catalog=CDDAlta;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
  },
- Navegar até a pasta da solution : cd {caminho da solution}
EX: C:/Projeto/CodigoPenal_CddAlta

- Buildar o Projeto : dotnet build
- Instalar o CLI do EFCore: dotnet tool install --global dotnet-ef
- Rodar a migration : dotnet ef database update --project .\API_CodigoPenal\

- O projeto consiste em uma API documentada via swagger.
- Não foram adicionadas validações pois as mesmas não foram solicitadas.
- A autenticação é feita baseada no usuário e senha e gera um token JWT que deve ser passado no header Authorization no seguinte formato : Bearer {Token}

- Segue abaixo arquitetura utilizada.


![Arquitetura](https://user-images.githubusercontent.com/26003025/157653739-3681e019-bdbe-40b6-9d7b-cd2fa0e05191.png)
