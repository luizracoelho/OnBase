# OnBase
Framework base para criação do CRUD utilizando o Entity Framework.

## Implementação
Primeiramente é necessário efetuar o download no pacote **OnBase** através do [Nuget](https://www.nuget.org/packages/OnBase).
Você também deverá referenciar a biblioteca em todas as classes que a utilizarem.
```csharp
using OnBase;
```
### Entidades
Todas as entidades mapeadas pelo Entity Framework devem herdar de **Base**.
```csharp
public class Cliente : Base
{
    public string Nome { get; set; }
    public string Email { get; set; }
}
```
### Acesso à Dados
Para ter acesso aos métodos do CRUD do acesso à dados as classes devem herdar de **BaseDataAccess\<T>** e passar uma instância do contexto no construtor da classe base.
```csharp
public class ClienteDataAccess : BaseDataAccess<Cliente>
{
    public ClienteDataAccess() : base(new DataContext())
    {
    }
}
```
Todos os métodos podem sofrer sobrecarga para atender às necessidades.

### Lógicas de Negócio
Para ter acesso aos métodos do CRUD das lógicas de negócio as classes devem herdar de **BaseLogic\<T, TDAO>**. 
```csharp
    public class ClienteLogic : BaseLogic<Cliente, ClienteDataAccess>
    {
    }
```
Todos os métodos podem sofrer sobrecarga para atender às necessidades.
