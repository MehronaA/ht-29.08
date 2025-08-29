using System;
using System.Text.RegularExpressions;
using Dapper;
using Infrestucture.Interface;
using Npgsql;
using Domain.Entities;

namespace Infrestucture.Services;

public class GroupService : IGroupService
{
    public int CreateGroup(Groups group)
    {
        string connectionString = "Server=localhost;Database=dapperDB;Username=postgres;Password=m.613524";
        using var connection = new NpgsqlConnection(connectionString);
        connection.Open();
        var cmd = $"insert into groups(name,courseId) values('{group.Name}',{group.CourseId})";
        var result = connection.Execute(cmd);
        return result;
    }

    public int DeleteGroup(int id)
    {
        string connectionString = "Server=localhost;Database=dapperDB;Username=postgres;Password=m.613524";
        using var connection = new NpgsqlConnection(connectionString);
        connection.Open();
        var cmd = $"delete * from groups where id={id}";
        var result = connection.Execute(cmd);
        return result;
    }

    public List<Groups> GetGroups()
    {
        string connectionString = "Server=localhost;Database=dapperDB;Username=postgres;Password=m.613524";
        using var connection = new NpgsqlConnection(connectionString);
        connection.Open();
        var cmd = "select * from groups";
        List<Groups> groups = connection.Query<Groups>(cmd).ToList();
        return groups;
    }

    public int UpdateGroup(Groups group)
    {
        string connectionString = "Server=localhost;Database=dapperDB;Username=postgres;Password=m.613524";
        using var connection = new NpgsqlConnection(connectionString);
        connection.Open();
        var cmd = $"update courses set name='{group.Name}',courseID={group.CourseId}) where id ={group.Id}";
        var result = connection.Execute(cmd);
        return result;
    }
}
