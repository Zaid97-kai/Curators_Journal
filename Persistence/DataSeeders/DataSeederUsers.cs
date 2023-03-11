using Microsoft.EntityFrameworkCore;
using Shared.Entities.Domains;

namespace Persistence.DataSeeders;

/// <summary>
/// Class DataSeederUsers.
/// </summary>
public static class DataSeederUsers
{
    /// <summary>
    /// Seeds the data.
    /// </summary>
    /// <param name="modelBuilder">The model builder.</param>
    /// <returns>ModelBuilder.</returns>
    public static ModelBuilder SeedData(ModelBuilder modelBuilder)
    {
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

        var studentRole = new Role()
        {
            Id = 4,
            Name = "Student"
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

        #region GroupEvents

        var firstGroupEvent = new GroupEvent()
        {
            Id = 1,
            GroupId = 2,
            EventId = 1
        };

        var secondGroupEvent = new GroupEvent()
        {
            Id = 2,
            GroupId = 2,
            EventId = 2
        };

        var thirdGroupEvent = new GroupEvent()
        {
            Id = 3,
            GroupId = 2,
            EventId = 2
        };

        var fourthGroupEvent = new GroupEvent()
        {
            Id = 4,
            GroupId = 2,
            EventId = 2
        };

        var fifthGroupEvent = new GroupEvent()
        {
            Id = 5,
            GroupId = 2,
            EventId = 2
        };
        #endregion

        #region Events

        var firstEvent = new Event()
        {
            Id = 1,
            Name = "Студвесна"
        };

        var secondEvent = new Event()
        {
            Id = 2,
            Name = "Первый код"
        };

        var thirdEvent = new Event()
        {
            Id = 3,
            Name = "Мистер КИТ"
        };

        var fourthEvent = new Event()
        {
            Id = 4,
            Name = "Мисс КИТ"
        };

        var fifthEvent = new Event()
        {
            Id = 5,
            Name = "Квартирник"
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

        var fourthUser = new User()
        {
            Id = 4,
            Name = "Мингалиев Заид Зульфатович",
            Phone = "9(421)001-31-15",
            Address = "342340, Волгоградская область, город Москва, пл. Ленина, 80",
            //BirthDate = new DateTime(2003, 11, 20),
            //Division = sixthDivision,
            DivisionId = sixthDivision.Id,
            Email = "treledoddoiseu-5434@yopmail.com",
            Password = "Рахимов Ранис Рамилевич",
            RoleId = studentRole.Id,
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
        modelBuilder.Entity<Event>().HasData(firstEvent, secondEvent, thirdEvent, fourthEvent, fifthEvent);
        modelBuilder.Entity<GroupEvent>().HasData(firstGroupEvent, secondGroupEvent, thirdGroupEvent, fourthGroupEvent, fifthGroupEvent);

        return modelBuilder;
    }
}