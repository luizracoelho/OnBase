using OnBase.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace OnBase
{
    /// <summary>
    /// Cria uma instância da classe de acesso a dados conforme o tipo passado em T
    /// </summary>
    /// <typeparam name="T">Tipo da ENTIDADE</typeparam>
    public class BaseDataAccess<T> : IDisposable, IBaseDataAccess<T> where T : class, IBase
    {
        DbContext _context;

        public BaseDataAccess(DbContext context)
        {
            _context = context;
        }

        public virtual List<T> Listar()
        {
            var dbSet = _context.Set<T>();
            return dbSet.ToList();
        }

        public virtual T Encontrar(int id)
        {
            var dbSet = _context.Set<T>();
            return dbSet.FirstOrDefault(x => x.Id == id);
        }

        public virtual void Inserir(T entidade)
        {
            var dbSet = _context.Set<T>();
            dbSet.Add(entidade);
            _context.SaveChanges();
        }

        public virtual void Editar(T entidade)
        {
            var dbSet = _context.Set<T>();
            dbSet.Attach(entidade);
            _context.Entry(entidade).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public virtual void Remover(int id)
        {
            var entidade = Encontrar(id);

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
