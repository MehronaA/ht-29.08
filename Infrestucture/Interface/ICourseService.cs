using System;
using Domain.Entities;

namespace Infrestucture.Interface;

public interface ICourseService
{
    List<Course> GetCourses();
    int CreateCourse(Course course);
    int UpdateCourse(Course course);
    int DeleteCourse(int id);
    List<Course> GetCoursesWithoutGroups();
}
