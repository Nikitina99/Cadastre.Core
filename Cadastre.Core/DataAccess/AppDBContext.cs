using Cadastre.Core.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastre.Core.DataAccess
{
    public class AppDBContext: DbContext
    {
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<User> Users { get; set; }

        /// <summary>
        /// Дополнительная настройка контекста.
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }

        /// <summary>
        /// Конструктор по-умолчанию
        /// </summary>
        public AppDBContext()
        { 

        }

        /// <summary>
        /// Конструктор для создани миграции.
        /// </summary>
        /// <param name="dbContextOptions"></param>
        public AppDBContext(DbContextOptions<AppDBContext> dbContextOptions): base(dbContextOptions)
        {

        }

        /// <summary>
        /// Выбирает и конфигурирует источник данных, используемых контекстом.
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}
