# NET_CORE
Projetos em Net CORE

SIGA OS SEGUINTES PASSOS:

**CONFIGURANDO FRONT**
1) Clonar o repositório do GIT (https://github.com/alveselton/NET_CORE.git);
``` 
git clone https://github.com/alveselton/NET_CORE.git
```
2) Pelo **Prompt de comando do Windows** acesse o diretório do projeto;

3) Ainda no **Prompt de comando do Windows**, acesse a pasta do projeto web **"Empresa -> ClientApp"** e execute o comando:
``` 
npm install
```
4) no próprio **Prompt de comando do Windows**, execute o seguinte comando:
```
ng serve --port 50000
```

**BANCO DE DADOS - SQL SERVER - DOCKER**

Foi utilizado um docker com banco de dados SQL Server

1) Abra o **Prompt de comando do Windows** e digite na linha de comando:
```
docker pull mcr.microsoft.com/mssql/server
```
2) Após o download da imagem, para que seja iniciado o container com a versão do banco, digite o seguinte comando:
```
docker run -v ~/docker --name sqlserver -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=1q2w3e4r@#$" -p 1433:1433 -d mcr.microsoft.com/mssql/server
```

3) Verificar se o container está ativo digitando o seguinte comando no **Prompt de comandos do Windows**
```
docker ps
```

**CONFIGURANDO O BACKEND**
1) Pelo **Prompt de comando do Windows** acesse o diretório do projeto;

2) Ainda no **Prompt de comando do Windows**, acesse a pasta do projeto **"empresa-api"** e execute o comando:
```
dotnet restore
```
3) Em seguida, digite o comando
```
dotnet run
```

**ACESSANDO A APLICAÇÃO**
1) Abra o navegador de sua preferência e digita http://localhost:50000/empresa


**REQUISITO**
.NET CORE 5 - https://dotnet.microsoft.com/download/dotnet/5.0

NODEJS 14.17.5 - https://nodejs.org/dist/v14.17.5/node-v14.17.5-x64.msi

ANGULAR 12 - 
```
npm i @angular/cli
```
