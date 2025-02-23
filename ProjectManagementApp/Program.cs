using Microsoft.Extensions.DependencyInjection;
using ProjectManagementLibrary.Data;
using ProjectManagementLibrary.Repositories;
using ProjectManagementLibrary.Services;
using Microsoft.EntityFrameworkCore;

var serviceProvider = new ServiceCollection()

.AddDbContext<AppDbContext>(options =>
        options.UseSqlite("Data Source=projects.db"))  
    .AddScoped<IProjectRepository, ProjectRepository>()    //Den här koden är ifrån Chat-gpt. Den konfigurerar SQLite som databas & DI för repository.
    .AddScoped<ProjectService>() 
    .BuildServiceProvider();


var projectService = serviceProvider.GetRequiredService<ProjectService>();

Console.WriteLine("Välkommen till projekthandledning!");
Console.WriteLine("1. Lägg till ett nytt projekt. ");
Console.WriteLine("2. Visa alla sparade projekt. ");
Console.WriteLine("3. Upptadera ett projekt. ");
Console.WriteLine("4. Avsluta programmet. ");

var choice = Console.ReadLine();

switch (choice)
{
    case "1":
        Console.Write("Projektets namn: ");
        string name = Console.ReadLine() ?? "";

        Console.Write("Startdatum (YYYY-MM-DD): ");
        DateTime startDate = DateTime.Parse(Console.ReadLine() ?? "2000-01-01");

        Console.Write("Slutdatum (YYYY-MM-DD): ");
        DateTime endDate = DateTime.Parse(Console.ReadLine() ?? "2000-01-01");

        Console.Write("Projektansvarig: ");
        string manager = Console.ReadLine() ?? "";

        Console.Write("Kund: ");
        string customer = Console.ReadLine() ?? "";

        Console.Write("Tjänst: ");
        string service = Console.ReadLine() ?? "";

        Console.Write("Totalpris: ");
        decimal totalPrice = decimal.Parse(Console.ReadLine() ?? "0");

        projectService.CreateProject(name, startDate, endDate, manager, customer, service, totalPrice);
        Console.WriteLine("Projekt skapat!");
        break;

    case "2":
        projectService.ListProject();
        break;

    case "3":
        projectService.UpdateProject();
        break;

    case "4":
        Console.WriteLine("Avslutar programmet.");
        return;

    default:
        Console.WriteLine("Ogiltigt val. Försök igen.");
        break;
}


