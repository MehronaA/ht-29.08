using System;
using Domain.Entities;

namespace Infrestucture.Interface;

public interface IStudentService
{
    List<Student> GetStudents();
    int CreateStudent(Student student);
    int UpdateStudent(Student student);
    int DeleteStudent(int id);
    List<Student> GetStudentsByMentorName(string mentorName);
    bool StudentExistsByEmail(string email);
    int UpdateStudentEmailAsync(int studentId, string newEmail);
    int DeleteStudentsByGroup(int groupId);
}
