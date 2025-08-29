using System;
using Dapper;
using Domain.Entities;
using Infrestucture.Interface;
using Npgsql;

namespace Infrestucture.Services;

public class MentorService : IMentorService
{
    public int CreateMentor(Mentor mentor)
    {
        string connectionString = "Server=localhost;Database=dapperDB;Username=postgres;Password=m.613524";
        using var connection = new NpgsqlConnection(connectionString);
        connection.Open();
        var cmd = $"insert into mentors(fullname,email) values('{mentor.FullName}','{mentor.Email}')";
        var result = connection.Execute(cmd);
        return result;
    }

    public int DeleteMentor(int id)
    {
        string connectionString = "Server=localhost;Database=dapperDB;Username=postgres;Password=m.613524";
        using var connection = new NpgsqlConnection(connectionString);
        connection.Open();
        var cmd = $"delete * from mentors where id={id}";
        var result = connection.Execute(cmd);
        return result;
    }

    public int UpdateMentor(Mentor mentor)
    {
        string connectionString = "Server=localhost;Database=dapperDB;Username=postgres;Password=m.613524";
        using var connection = new NpgsqlConnection(connectionString);
        connection.Open();
        var cmd = $"update courses set fullName='{mentor.FullName}',email='{mentor.Email}'where id ={mentor.Id}";
        var result = connection.Execute(cmd);
        return result;
    }

    public  List<Mentor> GetMentors()
    {
        string connectionString = "Server=localhost;Database=dapperDB;Username=postgres;Password=m.613524";
        using var connection = new NpgsqlConnection(connectionString);
        connection.Open();
        var cmd = "select * from mentors";
        List<Mentor> mentors = connection.Query<Mentor>(cmd).ToList();
        return mentors;
    }

}
