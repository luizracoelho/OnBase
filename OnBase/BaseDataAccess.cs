using OnBase.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace OnBase
{
    /// <summary>
    /// Cria uma instância da classe de acesso a dados conforme o tipo passado em T.
    /// </summary>
    /// <typeparam name="T">Tipo da ENTIDADE</typeparam>
    public abstract class BaseDataAccess<T> : IDisposable, IBaseDataAccess<T> where T : class, IBase
    {
        DbContext _context;

        public BaseDataAccess(DbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Método que lista as entidades no banco de dados.
        /// </summary>
        /// <returns>Lista</returns>
        public virtual List<T> List()
        {
            var dbSet = _context.Set<T>();
            return dbSet.ToList();
        }

        /// <summary>
        /// Método que lista as entidades no banco de dados.
        /// </summary>
        /// <param name="filter">Filtro</param>
        /// <returns>Lista</returns>
        public virtual List<T> List(Expression<Func<T, bool>> filter)
        {
            var dbSet = _context.Set<T>();
            return dbSet.Where(filter).ToList();
        }

        /// <summary>
        /// Método que retorna um registro do banco de dados.
        /// </summary>
        /// <param name="id">Id da Entidade</param>
        /// <returns>Entidade</returns>
        public virtual T Get(int id)
        {
            var dbSet = _context.Set<T>();
            return dbSet.Find(id);
        }

        /// <summary>
        /// Método que retorna um registro do banco de dados.
        /// </summary>
        /// <param name="filter">Filtro</param>
        /// <returns>Entidade</returns>
        public virtual T Get(Expression<Func<T, bool>> filter)
        {
            var dbSet = _context.Set<T>();
            return dbSet.FirstOrDefault(filter);
        }

        /// <summary>
        /// Método que insere um registro no banco de dados.
        /// </summary>
        /// <param name="entidade">Entidade</param>
        public virtual void Insert(T entidade)
        {
            var dbSet = _context.Set<T>();
            dbSet.Add(entidade);
            _context.SaveChanges();
        }

        /// <summary>
        /// Método que edita um registro no banco de dados.
        /// </summary>
        /// <param name="entidade">Entidade</param>
        public virtual void Edit(T entidade)
        {
            var dbSet = _context.Set<T>();
            dbSet.Attach(entidade);
            _context.Entry(entidade).State = EntityState.Modified;
            _context.SaveChanges();
        }

        /// <summary>
        /// Método que remove um registro no banco de dados.
        /// </summary>
        /// <param name="id">Id da Entidade</param>
        public virtual void Remove(int id)
        {
            var entidade = Get(id);

            var dbSet = _context.Set<T>();
            dbSet.Attach(entidade);
            dbSet.Remove(entidade);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        ~BaseDataAccess()
        {
            Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
