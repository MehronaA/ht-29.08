using System;
using Dapper;
using Domain.Entities;
using Infrestucture.Interface;
using Npgsql;

namespace Infrestucture.Services;

public class StudentService : IStudentService
{
    public int CreateStudent(Student student)
    {
        string connectionString = "Server=localhost;Database=dapperDB;Username=postgres;Password=m.613524";
        using var connection = new NpgsqlConnection(connectionString);
        connection.Open();
        var cmd = $"insert into students(fullname,grouoId,mentorId) values('{student.FullName}',{student.GroupId},{student.MentorId})";
        var result = connection.Execute(cmd);
        return result;
    }

    public int DeleteStudent(int id)
    {
        string connectionString = "Server=localhost;Database=dapperDB;Username=postgres;Password=m.613524";
        using var connection = new NpgsqlConnection(connectionString);
        connection.Open();
        var cmd = $"delete * from students where id={id}";
        var result = connection.Execute(cmd);
        return result;
    }

    public List<Student> GetStudents()
    {
        string connectionString = "Server=localhost;Database=dapperDB;Username=postgres;Password=m.613524";
        using var connection = new NpgsqlConnection(connectionString);
        connection.Open();
        var cmd = "select * from students";
        List<Student> students = connection.Query<Student>(cmd).ToList();
        return students;
    }

    public int UpdateStudent(Student student)
    {
        string connectionString = "Server=localhost;Database=dapperDB;Username=postgres;Password=m.613524";
        using var connection = new NpgsqlConnection(connectionString);
        connection.Open();
        var cmd = $"update courses set fullname={student.FullName}',groupID={student.GroupId},mentorId={student.MentorId} where id ={student.Id}";
        var result = connection.Execute(cmd);
        return result;
    }
}
