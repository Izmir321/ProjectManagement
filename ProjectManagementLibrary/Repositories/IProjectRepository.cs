

using ProjectManagementLibrary.Models;

namespace ProjectManagementLibrary.Repositories;

public interface IProjectRepository
{
    void Add(Project project);
    Project? GetById(int id);
    List<Project> GetAll();
    void Update(Project project);
    void Delete(int id);
}
