using System.Collections.Generic;

namespace OnBase.Interfaces
{
    public interface IBaseDataAccess<T>
    {
        List<T> Listar();

        T Encontrar(int id);

        void Inserir(T entidade);

        void Editar(T entidade);

        void Remover(int id);
    }
}
