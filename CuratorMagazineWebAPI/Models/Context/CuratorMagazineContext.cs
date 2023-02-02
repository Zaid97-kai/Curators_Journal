using CuratorMagazineWebAPI.Models.Entities.Domains;
using CuratorMagazineWebAPI.Models.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;
using System.IO;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using DataProtectionKey = Microsoft.AspNetCore.DataProtection.EntityFrameworkCore.DataProtectionKey;

namespace CuratorMagazineWebAPI.Models.Context
{
    /// <summary>
    /// Class CuratorMagazineContext.
    /// Implements the <see cref="DbContext" />
    /// Implements the <see cref="CuratorMagazineWebAPI.Models.Context.ICuratorMagazineContext" />
    /// Implements the <see cref="Microsoft.AspNetCore.DataProtection.EntityFrameworkCore.IDataProtectionKeyContext" />
    /// </summary>
    /// <seealso cref="DbContext" />
    /// <seealso cref="CuratorMagazineWebAPI.Models.Context.ICuratorMagazineContext" />
    /// <seealso cref="Microsoft.AspNetCore.DataProtection.EntityFrameworkCore.IDataProtectionKeyContext" />
    public sealed class CuratorMagazineContext : DbContext, ICuratorMagazineContext, Microsoft.AspNetCore.DataProtection.EntityFrameworkCore.IDataProtectionKeyContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CuratorMagazineContext" /> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public CuratorMagazineContext(DbContextOptions<CuratorMagazineContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        /// <summary>
        /// Override this method to further configure the model that was discovered by convention from the entity types
        /// exposed in <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> properties on your derived context. The resulting model may be cached
        /// and re-used for subsequent instances of your derived context.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context. Databases (and other extensions) typically
        /// define extension methods on this object that allow you to configure aspects of the model that are specific
        /// to a given database.</param>
        /// <remarks><para>
        /// If a model is explicitly set on the options for this context (via <see cref="M:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.UseModel(Microsoft.EntityFrameworkCore.Metadata.IModel)" />)
        /// then this method will not be run.
        /// </para>
        /// <para>
        /// See <see href="https://aka.ms/efcore-docs-modeling">Modeling entity types and relationships</see> for more information.
        /// </para></remarks>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            #region Roles

            var administratorRole = new Role()
            {
                Id = 1,
                Name = "Administrator"
            };

            var deputyDirectorRole = new Role()
            {
                Id = 2,
                Name = "Deputy Director"
            };

            var curatorRole = new Role()
            {
                Id = 3,
                Name = "Curator"
            };

            #endregion

            #region Divisions

            var firstDivision = new Division()
            {
                Id = 1,
                Name = "УВР"
            };

            var secondDivision = new Division()
            {
                Id = 2,
                Name = "ИАНТЭ"
            };

            var thirdDivision = new Division()
            {
                Id = 3,
                Name = "ФМФ"
            };

            var fourthDivision = new Division()
            {
                Id = 4,
                Name = "ИАЭП"
            };

            var fifthDivision = new Division()
            {
                Id = 5,
                Name = "ИКТЗИ"
            };

            var sixthDivision = new Division()
            {
                Id = 6,
                Name = "КИТ"
            };

            var seventhDivision = new Division()
            {
                Id = 7,
                Name = "ТК"
            };

            #endregion

            #region Groups

            var firstGroup = new Group()
            {
                Id = 1,
                Name = "4101"
            };

            var secondGroup = new Group()
            {
                Id = 2,
                Name = "4102"
            };

            var thirdGroup = new Group()
            {
                Id = 3,
                Name = "4131"
            };

            var fourthGroup = new Group()
            {
                Id = 4,
                Name = "4132"
            };

            var fifthGroup = new Group()
            {
                Id = 5,
                Name = "3101"
            };

            var sixthGroup = new Group()
            {
                Id = 6,
                Name = "3101"
            };

            var seventhGroup = new Group()
            {
                Id = 7,
                Name = "2101"
            };

            #endregion

            #region Parents

            var firstParent = new Parent()
            {
                Id = 1,
                Name = "Иванов Иван Иванович",
                Phone = "3(67)992-09-22",
                WorkName = "Ассистент менеджера по продажам"
            };
            
            var secondParent = new Parent()
            {
                Id = 2,
                Name = "Иванова Инна Ивановна",
                Phone = "429(521)755-17-83",
                WorkName = "Преподаватель"
            };

            #endregion

            #region Users

            var firstUser = new User()
            {
                Id = 1,
                Name = "Administrator",
                Phone = "9(421)001-31-15",
                Address = "342340, Волгоградская область, город Москва, пл. Ленина, 80",
                //BirthDate = new DateTime(2001, 2, 1),
                //Division = firstDivision,
                DivisionId = firstDivision.Id,
                Email = "ripogroyippe-2863@yopmail.com",
                Password = "Administrator",
                RoleId = administratorRole.Id
            };
            
            var secondUser = new User()
            {
                Id = 2,
                Name = "Associate Director",
                Phone = "608(51)713-94-41",
                Address = "383478, Брянская область, город Люберцы, ул. Ломоносова, 72",
                //BirthDate = new DateTime(2002, 3, 1),
                //Division = sixthDivision,
                DivisionId = sixthDivision.Id,
                Email = "croummauroicegeu-1550@yopmail.com",
                Password = "Associate Director",
                RoleId = deputyDirectorRole.Id
            };
            
            var thirdUser = new User()
            {
                Id = 3,
                Name = "Рахимов Ранис Рамилевич",
                Phone = "9(421)001-31-15",
                Address = "342340, Волгоградская область, город Москва, пл. Ленина, 80",
                //BirthDate = new DateTime(2003, 11, 20),
                //Division = sixthDivision,
                DivisionId = sixthDivision.Id,
                Email = "treledoddoiseu-5434@yopmail.com",
                Password = "Рахимов Ранис Рамилевич",
                RoleId = curatorRole.Id,
                GroupId = fourthGroup.Id,
                FatherId = firstParent.Id,
                MotherId = secondParent.Id
            };

            #endregion

            modelBuilder.Entity<Role>().HasData(administratorRole, deputyDirectorRole, curatorRole);
            modelBuilder.Entity<Division>().HasData(firstDivision, secondDivision, thirdDivision, fourthDivision, fifthDivision, sixthDivision, seventhDivision);
            modelBuilder.Entity<Group>().HasData(firstGroup, secondGroup, thirdGroup, fourthGroup, fifthGroup, sixthGroup, seventhGroup);
            modelBuilder.Entity<Parent>().HasData(firstParent, secondParent);
            modelBuilder.Entity<User>().HasData(firstUser, secondUser, thirdUser);

            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// <para>
        /// Override this method to configure the database (and other options) to be used for this context.
        /// This method is called for each instance of the context that is created.
        /// The base implementation does nothing.
        /// </para>
        /// <para>
        /// In situations where an instance of <see cref="T:Microsoft.EntityFrameworkCore.DbContextOptions" /> may or may not have been passed
        /// to the constructor, you can use <see cref="P:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.IsConfigured" /> to determine if
        /// the options have already been set, and skip some or all of the logic in
        /// <see cref="M:Microsoft.EntityFrameworkCore.DbContext.OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder)" />.
        /// </para>
        /// </summary>
        /// <param name="optionsBuilder">A builder used to create or modify options for this context. Databases (and other extensions)
        /// typically define extension methods on this object that allow you to configure the context.</param>
        /// <remarks>See <see href="https://aka.ms/efcore-docs-dbcontext">DbContext lifetime, configuration, and initialization</see>
        /// for more information.</remarks>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlite("Data Source=helloapp456.db");

            optionsBuilder.UseLazyLoadingProxies();
        }

        #region Entities

        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        /// <value>The users.</value>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Gets or sets the divisions.
        /// </summary>
        /// <value>The divisions.</value>
        public DbSet<Division> Divisions { get; set; }

        /// <summary>
        /// Gets or sets the groups.
        /// </summary>
        /// <value>The groups.</value>
        public DbSet<Group> Groups { get; set; }

        /// <summary>
        /// Gets or sets the parents.
        /// </summary>
        /// <value>The parents.</value>
        public DbSet<Parent> Parents { get; set; }

        /// <summary>
        /// Gets or sets the roles.
        /// </summary>
        /// <value>The roles.</value>
        public DbSet<Role> Roles { get; set; }

        #endregion

        /// <summary>
        /// A collection of <see cref="T:Microsoft.AspNetCore.DataProtection.EntityFrameworkCore.DataProtectionKey" />
        /// </summary>
        /// <value>The data protection keys.</value>
        public DbSet<DataProtectionKey> DataProtectionKeys { get; set; }
    }
}
