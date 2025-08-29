using System;
using System.Text.RegularExpressions;
using Dapper;
using Infrestucture.Interface;
using Npgsql;
using Domain.Entities;
using Infrestucture.Data;
using Domain.DTO;

namespace Infrestucture.Services;

public class GroupService : IGroupService
{
    private readonly DataContext _context = new();
    public int CreateGroup(Groups group)
    {
        using var connection = _context.GetConnection();
        connection.Open();
        var cmd = $"insert into groups(name,courseId) values(@name,@courseID)";
        var result = connection.Execute(cmd, group);
        return result;
    }

    public int DeleteGroup(int id)
    {
        using var connection = _context.GetConnection();
        connection.Open();
        var cmd = $"delete * from groups where id=@id";
        var result = connection.Execute(cmd, new { id });
        return result;
    }

    public List<Groups> GetGroups()
    {
        using var connection = _context.GetConnection();
        connection.Open();
        var cmd = "select * from groups";
        List<Groups> groups = connection.Query<Groups>(cmd).ToList();
        return groups;
    }

    public int UpdateGroup(Groups group)
    {
        using var connection = _context.GetConnection();
        connection.Open();
        var cmd = $"update courses set name=@name,courseID=@courseId) where id =@id";
        var result = connection.Execute(cmd, group);
        return result;
    }
    List<Groups> GetGroupsByCourseId(int courseId)
    {
        using var connection = _context.GetConnection();
        connection.Open();
        var cmd = "select * from groups where courseId=@courseID ";
        List<Groups> groups = connection.Query<Groups>(cmd, new { courseId }).ToList();
        return groups;
    }
    public List<GroupWithStudentCountDto> GetStudentCountByGroup()
    {
        using var connection = _context.GetConnection();
        connection.Open();
        var cmd = "select courseID, count(id) from students group by courseId";
        List<GroupWithStudentCountDto> groupsCount = connection.Query<GroupWithStudentCountDto>(cmd).ToList();
        return groupsCount;
    }
    
    
}
