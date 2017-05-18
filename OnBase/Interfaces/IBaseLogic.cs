using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace OnBase.Interfaces
{
    public interface IBaseLogic<T> where T : class
    {
        /// <summary>
        /// Método responsável por salvar.
        /// </summary>
        /// <param name="entity">Entidade</param>
        void Save(T entity);

        /// <summary>
        /// Método responsável por encontrar.
        /// </summary>
        /// <param name="id">Id da Entidade</param>
        /// <returns>Entidade</returns>
        T Get(int id);

        /// <summary>
        /// Método responsável por encontrar.
        /// </summary>
        /// <param name="filter">Filtro</param>
        /// <returns>Entidade</returns>
        T Get(Expression<Func<T, bool>> filter);

        /// <summary>
        /// Método responsável por listar.
        /// </summary>
        /// <returns>Lista de entidades</returns>
        List<T> List();

        /// <summary>
        /// Método responsável por listar.
        /// </summary>
        /// <param name="filter">Filtro</param>
        /// <returns>Lista de entidades</returns>
        List<T> List(Expression<Func<T, bool>> filter);

        /// <summary>
        /// Método responsável por remover.
        /// </summary>
        /// <param name="id">Id da Entidade</param>
        void Remove(int id);
    }
}
