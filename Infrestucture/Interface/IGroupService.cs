using System;
using System.Text.RegularExpressions;
using Domain.Entities;
using Domain.DTO;

namespace Infrestucture.Interface;

public interface IGroupService
{
    List<Groups> GetGroups();
    int CreateGroup(Groups group);
    int UpdateGroup(Groups group);
    int DeleteGroup(int id);
    List<Groups> GetGroupsByCourseId(int courseId);
    List<GroupWithStudentCountDto> GetStudentCountByGroup();
    List<Course> GetCoursesWithoutGroups();
    
}
