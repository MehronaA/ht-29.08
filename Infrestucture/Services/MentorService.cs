using System;
using Dapper;
using Domain.Entities;
using Infrestucture.Interface;
using Npgsql;
using Infrestucture.Data;
using System.Security.Cryptography.X509Certificates;

namespace Infrestucture.Services;

public class MentorService : IMentorService
{
    private readonly DataContext _context = new();
    public int CreateMentor(Mentor mentor)
    {
        using var connection = _context.GetConnection();
        connection.Open();
        var cmd = $"insert into mentors(fullname,email) values(@fullname,@email)";
        var result = connection.Execute(cmd, mentor);
        return result;
    }

    public int DeleteMentor(int id)
    {
        using var connection = _context.GetConnection();
        connection.Open();
        var cmd = $"delete * from mentors where id=@id";
        var result = connection.Execute(cmd, new { id });
        return result;
    }

    public int UpdateMentor(Mentor mentor)
    {
        using var connection = _context.GetConnection();
        connection.Open();
        var cmd = $"update courses set fullName=@fullname,email=@email where id =@id";
        var result = connection.Execute(cmd, mentor);
        return result;
    }

    public List<Mentor> GetMentors()
    {
        using var connection = _context.GetConnection();
        connection.Open();
        var cmd = "select * from mentors";
        List<Mentor> mentors = connection.Query<Mentor>(cmd).ToList();
        return mentors;
    }
    public List<Mentor> GetMentorsWithStudents()
    {
        using var connection = _context.GetConnection();
        connection.Open();
        var cmd = @"select m.* from mentors m 
                    join students as s on s.mentorId=m.id
                    group by m.*
                    having count(s.id)>0 ";
        List<Mentor> mentors = connection.Query<Mentor>(cmd).ToList();
        return mentors;
    }
    public List<Mentor> GetStudentsWithoutMentors()
    {
        using var connection = _context.GetConnection();
        connection.Open();
        var cmd = "select * from students where mentorId is null";
        List<Mentor> mentors = connection.Query<Mentor>(cmd).ToList();
        return mentors;
    }
    
    
    

}
