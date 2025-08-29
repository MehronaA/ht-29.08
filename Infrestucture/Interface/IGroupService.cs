using System;
using System.Text.RegularExpressions;
using Domain.Entities;

namespace Infrestucture.Interface;

public interface IGroupService
{
    List<Group> GetGroups();
    int CreateGroup(Groups group);
    int UpdateGroup(Groups group);
    int DeleteGroup(int id);
}
