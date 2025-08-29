using System;
using Dapper;
using Domain.Entities;
using Infrestucture.Interface;
using Npgsql;

namespace Infrestucture.Services;

public class CourseService : ICourseService
{
    public int CreateCourse(Course course)
    {
        string connectionString = "Server=localhost;Database=dapperDB;Username=postgres;Password=m.613524";
        using var connection = new NpgsqlConnection(connectionString);
        connection.Open();
        var cmd = $"insert into courses(name,duration) values('{course.Name}',{course.Duration})";
        var result = connection.Execute(cmd);
        return result;
    }

    public int DeleteCourse(int id)
    {
        string connectionString = "Server=localhost;Database=dapperDB;Username=postgres;Password=m.613524";
        using var connection = new NpgsqlConnection(connectionString);
        connection.Open();
        var cmd = $"delete * from course where id={id}";
        var result = connection.Execute(cmd);
        return result;
    }

    public List<Course> GetCourses()
    {
        string connectionString = "Server=localhost;Database=dapperDB;Username=postgres;Password=m.613524";
        using var connection = new NpgsqlConnection(connectionString);
        connection.Open();
        var cmd = "select * from courses";
        List<Course> courses = connection.Query<Course>(cmd).ToList();
        return courses;
    }

    public int UpdateCourse(Course course)
    {
        string connectionString = "Server=localhost;Database=dapperDB;Username=postgres;Password=m.613524";
        using var connection = new NpgsqlConnection(connectionString);
        connection.Open();
        var cmd = $"update courses set name='{course.Name}',duration={course.Duration}) where id ={course.Id}";
        var result = connection.Execute(cmd);
        return result;
    }
}
