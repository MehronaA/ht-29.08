using System;

namespace Domain.Entities;

public class Student
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public int GroupId{ get; set; }
    public int MentorId{ get; set; }
}
