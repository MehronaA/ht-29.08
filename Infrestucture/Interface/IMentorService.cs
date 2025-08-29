using System;
using Domain.Entities;

namespace Infrestucture.Interface;

public interface IMentorService
{
    List<Mentor> GetMentors();
    int CreateMentor(Mentor mentor);
    int UpdateMentor(Mentor mentor);
    int DeleteMentor(int id);
    List<Mentor> GetMentorsWithStudents();
    List<Mentor> GetStudentsWithoutMentors();
}
