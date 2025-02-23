using ProjectManagementLibrary.Models;
using ProjectManagementLibrary.Repositories;

namespace ProjectManagementLibrary.Services
{
    public class ProjectService
    {
        private readonly IProjectRepository _repository;

        public ProjectService(IProjectRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));             // Denna kod är ifrån Chat-gpt. 
        }

    


    public void CreateProject(string name, DateTime startDate, DateTime endDate, string manager, string customer, string service, decimal totalPrice)
        {
            var project = new Project

            {
                ProjectNumber = $"P-{new Random().Next(100,999)}",
                
                Name = name,

                StartDate = startDate,

                EndDate = endDate, 

                Manager = manager,

                Customer = customer,

                Service = service,

                TotalPrice = totalPrice,
                
                Status = "Inte Påbörjat. "

            };




        _repository.Add(project);
            
               
            
        }
        public void UpdateProject()  //Lite kod ifrån chatgpt för göra metoden lite smidigare
        {
            Console.WriteLine("Ange en projektnummer som du vill redigera. ");
            String ProjectNumber = Console.ReadLine() ?? ""; 

            var project = _repository.GetAll().FirstOrDefault(p => p.ProjectNumber == ProjectNumber);

            if (project == null)
            {
                Console.WriteLine("Projektet du angav kunde inte hittas. ");
                return;
            }

            Console.WriteLine($"Redugerar projekt just nu. {project.Name}");


            Console.Write($"Nytt namn ({project.Name}): ");
            string newName = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(newName)) project.Name = newName;



            Console.Write($"Nytt startdatum ({project.StartDate:yyyy-MM-dd}): ");
            string newStartDate = Console.ReadLine();
            if (DateTime.TryParse(newStartDate, out DateTime startDate)) project.StartDate = startDate;


            Console.Write($"Nytt slutdatum ({project.EndDate:yyyy-MM-dd}): ");
            string newEndDate = Console.ReadLine();
            if (DateTime.TryParse(newEndDate, out DateTime endDate)) project.EndDate = endDate;


            Console.Write($"Ny projektansvarig ({project.Manager}): ");
            string newManager = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newManager)) project.Manager = newManager;


            Console.Write($"Ny kund ({project.Customer}): ");
            string newCustomer = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newCustomer)) project.Customer = newCustomer;


            Console.Write($"Ny tjänst ({project.Service}): ");
            string newService = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newService)) project.Service = newService;


            Console.Write($"Nytt totalpris ({project.TotalPrice}): ");
            string newTotalPrice = Console.ReadLine();
            if (decimal.TryParse(newTotalPrice, out decimal totalPrice)) project.TotalPrice = totalPrice;


            Console.Write($"Ny status ({project.Status}) (Ej påbörjat, Pågående, Avslutat): ");
            string newStatus = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newStatus)) project.Status = newStatus;


            _repository.Update(project);
            Console.WriteLine("Projektet har uppdaterats!");

        }

        public void ListProject()
        {
            var projects = _repository.GetAll();

            if (projects.Count == 0)
            {
                Console.WriteLine("Inga projekt hittades.");
                return;
            }

            Console.WriteLine("Listan över alla projekt. ");
            foreach (var project in projects)
            {
                Console.WriteLine($"{project.ProjectNumber}: {project.Name} ({project.StartDate:yyyy-MM-dd} - {project.EndDate:yyyy-MM-dd}) [{project.Status}]");
            }
        }
    }

  
   
}
