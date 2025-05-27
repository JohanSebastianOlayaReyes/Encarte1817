using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

using Entity.Model;
using Entity.Model.Base;

using System.Data;
using Dapper;

using System.Linq.Expressions;


namespace Entity.Context
{
    public class ApplicationDbContext : DbContext
    {

        protected readonly IConfiguration _configuration;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        //Dbset SETS
        public DbSet<User> Users { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<RolUser> RolUsers { get; set; }
        public DbSet<Deparment> Deparments { get; set; }
        public DbSet<Neighborhood> Neighborhoods { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Employed> Employeds { get; set; }
        public DbSet<FormModule> FormModules { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<RolFormPermission> RolFormPermissions { get; set; }
        public DbSet<Permission> Permissions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de la relación muchos-a-muchos
            modelBuilder.Entity<RolUser>()
                .HasKey(ru => new { ru.UserId, ru.RolId }); // Clave compuesta

            modelBuilder.Entity<RolUser>()
                .HasOne(ru => ru.User)
                .WithMany(u => u.RolUsers)
                .HasForeignKey(ru => ru.UserId);

            modelBuilder.Entity<RolUser>()
                .HasOne(ru => ru.Rol)
                .WithMany(r => r.RolUsers)
                .HasForeignKey(ru => ru.RolId);

            //relacion uno City  a muchos  Deparments
            modelBuilder.Entity<City>()
                .HasMany(c => c.Deparments)
                .WithOne(d => d.City)
                .HasForeignKey(d => d.CityId);

            //relacion de uno city a muchos Neighborhoods
            modelBuilder.Entity< City>()
                .HasMany(N => N.Neighborhoods)
                .WithOne(c => c.City)
                .HasForeignKey(n => n.CityId);

            //relacion de una country a muchos city 
            modelBuilder.Entity<Country>()
                .HasMany(co => co.Cities)
                .WithOne(c => c.Country)
                .HasForeignKey(c => c.CountryId);

            //relacion de uno a muchos employed a client
            modelBuilder.Entity<Employed>()
                .HasMany(e => e.Clients)
                .WithOne(c => c.Employed)
                .HasForeignKey(c => c.EmployedId);

            //relacion de muchos a muchos entre form y module 
            modelBuilder.Entity<FormModule>()
                .HasKey(fm => new { fm.FormId, fm.ModuleId });

            modelBuilder.Entity<FormModule>()
                .HasOne(fm => fm.Form)
                .WithMany(f => f.FormModules)
                .HasForeignKey(fm => fm.FormId);

            modelBuilder.Entity<FormModule>()
                .HasOne(fm => fm.Module)
                .WithMany(m => m.FormModules)
                .HasForeignKey(fm => fm.ModuleId);

            //relaciones de RolFormPermission
            modelBuilder.Entity<RolFormPermission>()
               .HasKey(rfp => new { rfp.RoleId, rfp.FormId, rfp.PermissionId });

            modelBuilder.Entity<RolFormPermission>()
                .HasOne(rfp => rfp.Role)
                .WithMany(r => r.RolFormPermissions)
                .HasForeignKey(rfp => rfp.RoleId);

            modelBuilder.Entity<RolFormPermission>()
                .HasOne(rfp => rfp.Form)
                .WithMany(f => f.RolFormPermissions)
                .HasForeignKey(rfp => rfp.FormId);

            modelBuilder.Entity<RolFormPermission>()
                .HasOne(rfp => rfp.Permission)
                .WithMany(p => p.RolFormPermissions)
                .HasForeignKey(rfp => rfp.PermissionId);

            modelBuilder.Entity<Provider>()
                .HasOne(E => E.Employed)
                .WithMany(p => p.Providers)
                .HasForeignKey(E => E.EmployedId);


            // Configuración para todas las entidades que heredan de BaseEntity
            foreach (var entityType in modelBuilder.Model.GetEntityTypes()
                .Where(t => t.ClrType.IsSubclassOf(typeof(BaseEntity))))
            {
                // Configurar CreatedAt para que no sea nullable
                modelBuilder.Entity(entityType.ClrType)
                    .Property("CreatedAt")
                    .IsRequired();
                    
                // Configurar UpdatedAt y DeleteAt como nullable
                modelBuilder.Entity(entityType.ClrType)
                    .Property("UpdatedAt")
                    .IsRequired(false);
                    
                modelBuilder.Entity(entityType.ClrType)
                    .Property("DeleteAt")
                    .IsRequired(false);
                    
                // Configurar Status con un valor predeterminado de true
                modelBuilder.Entity(entityType.ClrType)
                    .Property("Status")
                    .HasDefaultValue(true); 
            }
        }

        
        /// <summary>
        /// Configura opciones adicionales del contexto, como el registro de datos sensibles.
        /// </summary>
        /// <param name="optionsBuilder">Constructor de opciones de configuración del contexto.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            // Otras configuraciones adicionales pueden ir aquí
        }

        /// <summary>
        /// Configura convenciones de tipos de datos, estableciendo la precisión por defecto de los valores decimales.
        /// </summary>
        /// <param name="configurationBuilder">Constructor de configuración de modelos.</param>
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<decimal>().HavePrecision(18, 2);
        }

        /// <summary>
        /// Guarda los cambios en la base de datos, asegurando la auditoría antes de persistir los datos.
        /// </summary>
        /// <returns>Número de filas afectadas.</returns>
        public override int SaveChanges()
        {
            EnsureAudit();
            return base.SaveChanges();
        }

        /// <summary>
        /// Guarda los cambios en la base de datos de manera asíncrona, asegurando la auditoría antes de la persistencia.
        /// </summary>
        /// <param name="acceptAllChangesOnSuccess">Indica si se deben aceptar todos los cambios en caso de éxito.</param>
        /// <param name="cancellationToken">Token de cancelación para abortar la operación.</param>
        /// <returns>Número de filas afectadas de forma asíncrona.</returns>
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            EnsureAudit();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        /// <summary>
        /// Ejecuta una consulta SQL utilizando Dapper y devuelve una colección de resultados de tipo genérico.
        /// </summary>
        /// <typeparam name="T">Tipo de los datos de retorno.</typeparam>
        /// <param name="text">Consulta SQL a ejecutar.</param>
        /// <param name="parameters">Parámetros opcionales de la consulta.</param>
        /// <param name="timeout">Tiempo de espera opcional para la consulta.</param>
        /// <param name="type">Tipo opcional de comando SQL.</param>
        /// <returns>Una colección de objetos del tipo especificado.</returns>
        public async Task<IEnumerable<T>> QueryAsync<T>(string text, object? parameters = null, int? timeout = null, CommandType? type = null)
        {
           using var command = new DapperEFCoreCommand(this, text, parameters ?? new { }, timeout, type, CancellationToken.None);
           var connection = this.Database.GetDbConnection();
           return await connection.QueryAsync<T>(command.Definition);
        }

        /// <summary>
        /// Ejecuta una consulta SQL utilizando Dapper y devuelve un solo resultado o el valor predeterminado si no hay resultados.
        /// </summary>
        /// <typeparam name="T">Tipo de los datos de retorno.</typeparam>
        /// <param name="text">Consulta SQL a ejecutar.</param>
        /// <param name="parameters">Parámetros opcionales de la consulta.</param>
        /// <param name="timeout">Tiempo de espera opcional para la consulta.</param>
        /// <param name="type">Tipo opcional de comando SQL.</param>
        /// <returns>Un objeto del tipo especificado o su valor predeterminado.</returns>
        public async Task<T?> QueryFirstOrDefaultAsync<T>(string text, object? parameters = null, int? timeout = null, CommandType? type = null)
        {
           using var command = new DapperEFCoreCommand(this, text, parameters ?? new { }, timeout, type, CancellationToken.None);
           var connection = this.Database.GetDbConnection();
           return await connection.QueryFirstOrDefaultAsync<T>(command.Definition);
        }        
        
        /// <summary>
        /// Obtiene un IQueryable para usar en consultas LINQ que incluye filtro de status activo.
        /// </summary>
        /// <typeparam name="T">Tipo de entidad para la consulta.</typeparam>
        /// <returns>IQueryable filtrado para estrategias LINQ.</returns>
        public IQueryable<T> GetActiveSet<T>() where T : class
        {
            var query = Set<T>().AsQueryable();
            
            // Filtramos por Status aplicando expresiones genéricas si la entidad tiene la propiedad Status
            var parameter = Expression.Parameter(typeof(T), "e");
            
            if (typeof(T).GetProperty("Status") != null)
            {
                try {
                    // Construimos una expresión lambda para filtrar por Status = true
                    var property = Expression.Property(parameter, "Status");
                    var value = Expression.Constant(true);
                    var equal = Expression.Equal(property, value);
                    var lambda = Expression.Lambda<Func<T, bool>>(equal, parameter);
                    
                    // Aplicamos el filtro
                    query = query.Where(lambda);
                }
                catch {
                    // Si hay algún error, devolvemos el query sin filtrar
                }
            }
            
            return query;
        }
        /// <summary>
        /// Método auxiliar para obtener el valor de una propiedad de un objeto mediante reflexión.
        /// </summary>
        /// <param name="obj">Objeto del que se obtendrá el valor.</param>
        /// <param name="propertyName">Nombre de la propiedad.</param>
        /// <returns>Valor de la propiedad.</returns>
        private static bool GetPropertyValue(object obj, string propertyName)
        {
            var property = obj.GetType().GetProperty(propertyName);
            if (property == null)
            {
                return false;
            }
            return property.GetValue(obj, null) is bool value ? value : false;
        }
        
        /// <summary>
        /// Ejecuta una consulta con paginación utilizando LINQ.
        /// </summary>
        /// <typeparam name="T">Tipo de los datos de retorno.</typeparam>
        /// <param name="query">Consulta IQueryable base.</param>
        /// <param name="page">Número de página (comienza en 1).</param>
        /// <param name="pageSize">Tamaño de la página.</param>
        /// <returns>Colección paginada de elementos.</returns>
        public IQueryable<T> GetPaged<T>(IQueryable<T> query, int page, int pageSize) where T : class
        {
            if (page <= 0) page = 1;
            if (pageSize <= 0) pageSize = 10;
            
            return query.Skip((page - 1) * pageSize).Take(pageSize);
        }
         
        /// <summary>
        /// Ejecuta una consulta LINQ y devuelve los resultados como una colección asíncrona.
        /// </summary>
        /// <typeparam name="T">Tipo de los datos de retorno.</typeparam>
        /// <param name="query">Consulta IQueryable a ejecutar.</param>
        /// <returns>Colección asíncrona de resultados.</returns>
        public async Task<List<T>> ToListAsyncSafe<T>(IQueryable<T> query)
        {
            if (query == null)
                return new List<T>();
                
            return await EntityFrameworkQueryableExtensions.ToListAsync(query);
        }

        /// <summary>
        /// Método interno para garantizar la auditoría de los cambios en las entidades.
        /// </summary>
        private void EnsureAudit()
        {
            ChangeTracker.DetectChanges();
            
            var entries = ChangeTracker.Entries()
                .Where(e => e.Entity is BaseEntity);

            var currentDateTime = DateTime.UtcNow;

            foreach (var entry in entries)
            {
                if (entry.Entity is BaseEntity entity)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            entity.CreatedAt = currentDateTime;
                            entity.Status = true;
                            break;
                        case EntityState.Modified:
                            entity.UpdatedAt = currentDateTime;
                            break;
                        case EntityState.Deleted:
                            // Convertimos el borrado en un borrado lógico
                            entry.State = EntityState.Modified;
                            entity.DeleteAt = currentDateTime;
                            entity.Status = false;
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Estructura para ejecutar comandos SQL con Dapper en Entity Framework Core.
        /// </summary>
        public readonly struct DapperEFCoreCommand : IDisposable
        {
        /// <summary>
            /// Constructor del comando Dapper.
            /// </summary>
            /// <param name="context">Contexto de la base de datos.</param>
            /// <param name="text">Consulta SQL.</param>
            /// <param name="parameters">Parámetros opcionales.</param>
            /// <param name="timeout">Tiempo de espera opcional.</param>
            /// <param name="type">Tipo de comando SQL opcional.</param>
            /// <param name="ct">Token de cancelación.</param>
            public DapperEFCoreCommand(DbContext context, string text, object parameters, int? timeout, CommandType? type, CancellationToken ct)
            {
                var transaction = context.Database.CurrentTransaction?.GetDbTransaction();
                var commandType = type ?? CommandType.Text;
                var commandTimeout = timeout ?? context.Database.GetCommandTimeout() ?? 30;

                Definition = new CommandDefinition(
                    text,
                    parameters,
                    transaction,
                    commandTimeout,
                    commandType,
                    cancellationToken: ct
                );
            }

        //    /// <summary>
        //    /// Define los parámetros del comando SQL.
        //    /// </summary>
           public CommandDefinition Definition { get; }

        //    /// <summary>
        //    /// Método para liberar los recursos.
        //    /// </summary>
           public void Dispose()
           {
           }
        }
    }
}
