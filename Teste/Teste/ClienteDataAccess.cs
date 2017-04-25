using OnBase;

namespace Teste
{
    public class ClienteDataAccess : BaseDataAccess<Cliente>
    {
        public ClienteDataAccess() : base(new DataContext())
        {

        }
    }
}
