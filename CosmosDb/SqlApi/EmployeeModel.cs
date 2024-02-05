using Azure;

namespace CosmosDb.SqlApi
{
    public class EmployeeModel
    {
        public string id { get; set; }
        public string EmployeeId { get; set; }
        public string Designation { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public decimal Experience { get; set; }
        public float Salary { get; set; }
    }
}
