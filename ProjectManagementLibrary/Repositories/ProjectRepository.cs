using ProjectManagementLibrary.Data;
using ProjectManagementLibrary.Models;
using Microsoft.EntityFrameworkCore;




namespace ProjectManagementLibrary.Repositories;


public class ProjectRepository : IProjectRepository
{
    private readonly AppDbContext _context;

    public ProjectRepository(AppDbContext context)
    {
        _context = context;
    }

    public void Add(Project project)
    {
        try
        {
            _context.Projects.Add(project);
            _context.SaveChanges();
        }
        catch (DbUpdateException ex)
        {
            Console.WriteLine("Database update failed: " + ex.InnerException?.Message);
            throw;
        }
    }

    public Project? GetById(int id) => _context.Projects.Find(id);

    public List<Project> GetAll() => _context.Projects.ToList();

    public void Update(Project project)
    {
        _context.Projects.Update(project);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var project = _context.Projects.Find(id);
        if (project != null)
        {
            _context.Projects.Remove(project);
            _context.SaveChanges();
        }
    }
}
