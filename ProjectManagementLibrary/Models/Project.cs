

namespace ProjectManagementLibrary.Models
{
    public class Project
    {
        public int Id { get; set; }

        public string ProjectNumber { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }   

        public string Manager { get; set; } = string.Empty;

        public string Customer {  get; set; } = string.Empty;

        public string Service { get; set; } = string.Empty;

        public decimal TotalPrice { get; set; } = 0;
        public string Status { get; set; } = string.Empty;





    }
}
