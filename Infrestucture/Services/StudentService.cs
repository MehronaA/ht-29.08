using System;
using Dapper;
using Domain.Entities;
using Infrestucture.Interface;
using Npgsql;
using Infrestucture.Data;
using System.Data;

namespace Infrestucture.Services;

public class StudentService : IStudentService
{
    private readonly DataContext _context = new();
    public int CreateStudent(Student student)
    {
        using var connection = _context.GetConnection();
        connection.Open();
        var cmd = $"insert into students(fullname,grouoId,mentorId) values(@fullname,@groupId,@mentorId)";
        var result = connection.Execute(cmd);
        return result;
    }

    public int DeleteStudent(int id)
    {
        using var connection = _context.GetConnection();
        connection.Open();
        var cmd = $"delete * from students where id=@id";
        var result = connection.Execute(cmd, new { id });
        return result;
    }

    public List<Student> GetStudents()
    {
        using var connection = _context.GetConnection();
        connection.Open();
        var cmd = "select * from students";
        List<Student> students = connection.Query<Student>(cmd).ToList();
        return students;
    }

    public int UpdateStudent(Student student)
    {
        using var connection = _context.GetConnection();
        connection.Open();
        var cmd = $"update courses set fullname=@fullname,groupID=@groupId,mentorId=@mentorId where id =@id";
        var result = connection.Execute(cmd, student);
        return result;
    }
    public List<Student> GetStudentsByMentorName(string fullname)
    {
        using var connection = _context.GetConnection();
        connection.Open();
        var cmd = "select s.* from students s join mentors as m on m.id=s.mentorId where m.fullname=@fullname";
        List<Student> students = connection.Query<Student>(cmd, new { fullname }).ToList();
        return students;
    }
    public bool StudentExistsByEmail(string email)
    {
        using var connection = _context.GetConnection();
        connection.Open();
        var cmd = "select * from student where email = @email";
        var find = connection.QueryFirstOrDefault<Student>(cmd, new { email });
        if (find != null) return true;
        else return false;
    }
    public int UpdateStudentEmailAsync(int studentId, string email)
    {
        using var connection = _context.GetConnection();
        connection.Open();
        var cmd = "update students set email =@email where id=@studentid";
        var update = connection.Execute(cmd, new { Email = email, StudentId = studentId });
        return update;
    }
    public int DeleteStudentsByGroup(int groupId)
    { 
        using var connection = _context.GetConnection();
        connection.Open();
        var cmd = $"delete * from students where id=@groupId";
        var result = connection.Execute(cmd, new { groupId});
        return result;
    }
    
    




    
}
