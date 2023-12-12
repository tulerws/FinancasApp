using FinancasApp.Domain.Interfaces.Repositories;
using FinancasApp.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasApp.Infra.Data.Repositories
{
    /// <summary>
    /// Classe genérica para repositório de banco de dados
    /// </summary>
    public class BaseRepository<T> : IBaseRepository<T>
        where T : class
    {
        /// <summary>
        /// Inserir um registro em uma tabela do banco de dados
        /// </summary>
        public void Add(T entity)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Add(entity);
                dataContext.SaveChanges();
            }
        }

        /// <summary>
        /// Atualizar um registro em uma tabela do banco de dados
        /// </summary>
        public void Update(T entity)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Update(entity);
                dataContext.SaveChanges();
            }
        }

        /// <summary>
        /// Excluir um registro em uma tabela do banco de dados
        /// </summary>
        public void Delete(T entity)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Remove(entity);
                dataContext.SaveChanges();
            }
        }

        /// <summary>
        /// Consultar todos os registros de uma tabela do banco de dados
        /// </summary>
        public List<T> GetAll()
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<T>().ToList();
            }
        }

        /// <summary>
        /// Consultar 1 registro de uma tabela do banco de dados através do ID
        /// </summary>
        public T? GetById(Guid id)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext?.Set<T>().Find(id);
            }
        }
    }
}

