using OnBase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace OnBase
{
    /// <summary>
    /// Cria uma instância da classe de logica de negocios conforme o tipo passado em T e acesso a dados conforme o tipo passado em TDAO
    /// </summary>
    /// <typeparam name="T">Tipo da ENTIDADE</typeparam>
    /// <typeparam name="TDAO">Tipo do ACESSO A DADOS (T seguido do sufixo DAO)</typeparam>
    public abstract class BaseLogic<T, TDAO> : IDisposable, IBaseLogic<T>
        where T : class, IBase
        where TDAO : class, IDisposable, IBaseDataAccess<T>, new()
    {
        TDAO dao;

        public BaseLogic()
        {
            dao = new TDAO();
        }

        /// <summary>
        /// Método responsável pela inserção.
        /// </summary>
        /// <param name="entity">Entidade</param>
        protected virtual void Insert(T entity)
        {
            try
            {
                dao.Insert(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Método responsável pela edição.
        /// </summary>
        /// <param name="entity">Entidade</param>
        protected virtual void Edit(T entity)
        {
            try
            {
                dao.Edit(entity);
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// Método responsável por salvar.
        /// </summary>
        /// <param name="entity">Entidade</param>
        public virtual void Save(T entity)
        {
            try
            {
                if (entity.Id == 0)
                    Insert(entity);
                else
                    Edit(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Método responsável por encontrar.
        /// </summary>
        /// <param name="id">Id da Entidade</param>
        /// <returns>Entidade</returns>
        public virtual T Get(int id)
        {
            try
            {
                return dao.Get(id);

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Método responsável por encontrar.
        /// </summary>
        /// <param name="filter">Filtro</param>
        /// <returns>Entidade</returns>
        public virtual T Get(Expression<Func<T, bool>> filter)
        {
            try
            {
                return dao.Get(filter);

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Método responsável por listar.
        /// </summary>
        /// <returns>Lista de entidades</returns>
        public virtual List<T> List()
        {
            try
            {
                return dao.List();

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Método responsável por listar.
        /// </summary>
        /// <param name="filter">Filtro</param>
        /// <returns>Lista de entidades</returns>
        public virtual List<T> List(Expression<Func<T, bool>> filter)
        {
            try
            {
                return dao.List(filter);

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Método responsável por remover.
        /// </summary>
        /// <param name="id">Id da Entidade</param>
        public virtual void Remove(int id)
        {
            try
            {
                dao.Remove(id);
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
