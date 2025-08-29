using System;
using Domain.Entities;

namespace Infrestucture.Interface;

public interface IStudentService
{
    List<Student> GetStudents();
    int CreateStudent(Student student);
    int UpdateStudent(Student student);
    int DeleteStudent(int id);
}
