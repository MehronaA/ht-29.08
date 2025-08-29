using System;
using Dapper;
using Domain.Entities;
using Infrestucture.Interface;
using Npgsql;
using Infrestucture.Data;

namespace Infrestucture.Services;

public class CourseService : ICourseService
{
    private readonly DataContext _context = new();
    public int CreateCourse(Course course)
    {
        using var connection = _context.GetConnection();
        connection.Open();
        var cmd = $"insert into courses(name,duration) values(@name,@duration)";
        var result = connection.Execute(cmd, course);
        return result;
    }

    public int DeleteCourse(int id)
    {
        using var connection = _context.GetConnection();
        connection.Open();
        var cmd = $"delete * from course where id=@id";
        var result = connection.Execute(cmd, new { id });
        return result;
    }

    public List<Course> GetCourses()
    {
        using var connection = _context.GetConnection();
        connection.Open();
        var cmd = "select * from courses";
        List<Course> courses = connection.Query<Course>(cmd).ToList();
        return courses;
    }

    public int UpdateCourse(Course course)
    {
        using var connection = _context.GetConnection();
        connection.Open();
        var cmd = $"update courses set name=@name,duration=@duration where id =@id";
        var result = connection.Execute(cmd, course);
        return result;
    }
    public List<Course> GetCoursesWithoutGroups()
    {
        using var connection = _context.GetConnection();
        connection.Open();
        var cmd = @"select c.*
                    from courses c
                    left join groups g on g.courseId = c.id
                    group by c.* 
                    having count(g.id) = 0;";
        List<Course> courses = connection.Query<Course>(cmd).ToList();
        return courses;
    }
    
}
