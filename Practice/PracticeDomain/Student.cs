﻿namespace PracticeDomain;

public sealed class Student :
    IEquatable<Enum>,
    IEquatable<Student>,
    IEquatable<object>
{
    public enum Course
    {
        CSharp,
        GO,
        Yandex,
        DataSet,
        InfrastructureActivities
    }

    private readonly string _surname;
    private readonly string _name;
    private readonly string _patronymic;
    private readonly string _studyGroup;
    private readonly Course _course;
    
    /// <summary>
    /// Конструктор класса Student
    /// </summary>
    /// <param name="surname">Фамилия</param>
    /// <param name="name">Имя</param>
    /// <param name="patronymic">Отчество</param>
    /// <param name="studyGroup">Учебная группа</param>
    /// <param name="course">Выбранное направление</param>
    /// <exception cref="ArgumentNullException">Вместо строки передан null</exception>
    public Student(string? surname, string? name, string? patronymic, string? studyGroup, Course course)
    {
        _surname = surname ?? throw new ArgumentNullException(nameof(surname));
        _name = name ?? throw new ArgumentNullException(nameof(name));
        _patronymic = patronymic ?? throw new ArgumentNullException(nameof(patronymic));
        _studyGroup = studyGroup ?? throw new ArgumentNullException(nameof(studyGroup));
        _course = course;

        CourseNumberValue = _studyGroup[studyGroup.IndexOf('-') + 1];
    }

    public string SurnameValue => _surname;
    public string NameValue => _name;
    public string PatronymicValue => _patronymic;
    public string StudyGroupValue => _studyGroup;
    public Course ChosenCourseValue => _course;

    public char CourseNumberValue
    {
        get;
    }

    public override string ToString()
    {
        return $"[ Surname: {_surname}, Name: {_name}, Patronymic: {_patronymic}, StudyGroup: {_studyGroup}, ChosenCourse: {_course} ]";
    }

    public override int GetHashCode()
    {
        return (_surname.GetHashCode() * 2
               + _name.GetHashCode() * 3
               + _patronymic.GetHashCode() * 5
               + _studyGroup.GetHashCode() * 7
               + _course.GetHashCode() * 11) % 997;
    }

    public bool Equals(Student? @student)
    {
        if (@student is null)
        {
            return false;
        }

        return _surname.Equals(@student._surname)
               && _name.Equals(@student._name)
               && _patronymic.Equals(@student._patronymic)
               && _studyGroup.Equals(@student._studyGroup)
               && _course.Equals(@student._course);
    }

    public bool Equals(Enum @enum)
    {
        return _course.Equals(@enum);
    }
    
    public override bool Equals(object? obj)
    {
        if (obj is null)
        {
            return false;
        }

        if (obj is Student @student)
        {
            return Equals(@student);
        }
        if (obj is Course @course)
        {
            return _course.Equals(@course);
        }

        return false;
    }

    bool IEquatable<object>.Equals(object? obj)
    {
        if (obj is null)
        {
            return false;
        }

        if (obj is Student @student)
        {
            return Equals(@student);
        }
        if (obj is Course @course)
        {
            return _course.Equals(@course);
        }

        return false;
    }
}