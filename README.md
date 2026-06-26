## 🚀 Api2-Dapper-docker
Exemplo de API em C# ASP.NET Core 2 com banco de dados MySQL.

#### 📋 O que você vai encontrar neste projeto
| Tecnologia | Descrição |
|-----------|-----------|
| **Dapper** | Utilização de mapeamento rápido de resultados de consultas SQL diretas pela aplicação. |

#### 💬 Requisitos do Projeto
- Necessário **Docker** instalado.
- Inicialização automatica banco de dados -> Na pasta **database** esta pasta contém um arquivo, (script_inicial.sql), que será executado quando o container da imagem MySQL for instanciado.

#### 🔄 Executar a aplicação
- Criar o Container **VSCode**:
```bash
docker compose up --build
```
- Fechar o container **VSCode**:
```bash
docker compose down
```

- Para executar a aplicação é necessário executar o container MySQL. 
- Restaurar dependencias .Net 
```bash
dotnet restore
```
- Executar Build do Projeto 
```bash
dotnet run
```

#### ⚙️ Configuração SSL para Driver MySQL IDE (**DBeaver** ou Workbench) 

Navegue até Propriedades do driver: Clique na guia Propriedades do driver (ao lado da guia “Principal”).
Habilitar recuperação:

- Encontre a propriedade chamada permitir **PublicKeyRetrieval**. 
Mude seu valor de falso para **verdadeiro**.

- Alternativa (guia SSL): Nas versões mais recentes do DBeaver, você também pode ir até a aba **SSL** e marcar a caixa **Permitir recuperação de chave pública**.

Desativar verificação de certificado (correção rápida) 
Se você estiver em um ambiente de desenvolvimento e não precisar de validação **SSL** rigorosa:

- Clique com o botão direito na sua conexão > Editar conexão.
Navegue até as configurações de **SSL**.
Desmarque Verificar certificado do servidor.
