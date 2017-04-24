using OnBase.Interfaces;
using System;
using System.Collections.Generic;

namespace OnBase
{
    /// <summary>
    /// Cria uma instância da classe de logica de negocios conforme o tipo passado em T e acesso a dados conforme o tipo passado em TDAO
    /// </summary>
    /// <typeparam name="T">Tipo da ENTIDADE</typeparam>
    /// <typeparam name="TDAO">Tipo do ACESSO A DADOS (T seguido do sufixo DAO)</typeparam>
    public class BaseLogic<T, TDAO> : IDisposable
        where T : class, IBase
        where TDAO : class, IDisposable, IBaseDataAccess<T>, new()
    {
        TDAO dao;

        public BaseLogic()
        {
            dao = new TDAO();
        }

        protected virtual void Inserir(T entidade)
        {
            try
            {
                dao.Inserir(entidade);
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected virtual void Editar(T entidade)
        {
            try
            {
                dao.Editar(entidade);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public virtual void Salvar(T entidade)
        {
            try
            {
                if (entidade.Id == 0)
                    Inserir(entidade);
                else
                    Editar(entidade);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual T Encontrar(int id)
        {
            try
            {
                return dao.Encontrar(id);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual List<T> Listar()
        {
            try
            {
                return dao.Listar();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual void Remover(int id)
        {
            try
            {
                dao.Remover(id);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void Dispose()
        {
            dao.Dispose();
            GC.SuppressFinalize(this);
        }

        ~BaseLogic()
        {
            Dispose();
        }
    }
}
