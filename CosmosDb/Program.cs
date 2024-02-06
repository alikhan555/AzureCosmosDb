using CosmosDb.SqlApi;

string connectionString = "";

SqlApiHandler<EmployeeModel> sqlApiHandler = new SqlApiHandler<EmployeeModel>(connectionString);

// CosmosDB SQL API

//await sqlApiHandler.CreateDatabaseIfNotExistsAsync("HR");

//await sqlApiHandler.CreateContainerIfNotExistsAsync("HR", "Employees", "/Designation");

//EmployeeModel employeeModel = new EmployeeModel() { id = "901", EmployeeId = "1001", Designation = "Software Engineer I", Age = 40, Experience = 2, Name = "Muhammad Ali", Salary = 50000 };
//await sqlApiHandler.CreateItemAsync("HR", "Employees", employeeModel, employeeModel.Designation);

//List<EmployeeModel> employees = new() 
//{
//    new EmployeeModel() { id = "902", EmployeeId = "1002", Designation = "Software Engineer I", Age = 40, Experience = 2, Name = "Muhammad Ali 2", Salary = 50000 },
//    new EmployeeModel() { id = "903", EmployeeId = "1003", Designation = "Software Engineer II", Age = 30, Experience = 2, Name = "Asif Jabbar", Salary = 32000 },
//    new EmployeeModel() { id = "904", EmployeeId = "1004", Designation = "Software Engineer II", Age = 20, Experience = 2, Name = "Abdul Mujeeb", Salary = 70000 },
//    new EmployeeModel() { id = "905", EmployeeId = "1005", Designation = "Software Engineer IV", Age = 10, Experience = 2, Name = "Abdul Waris", Salary = 1000000 }
//};
//await sqlApiHandler.CreateBulkItemAsync("HR", "Employees", employees, "Designation");

//await sqlApiHandler.DeleteItemAsync("HR", "Employees", "901", "Software Engineer I");

//List<EmployeeModel> employees = await sqlApiHandler.QueryItems("HR", "Employees", "SELECT * FROM e ");
//employees.ForEach(x => Console.WriteLine($"id: {x.id}, EmployeeId: {x.EmployeeId}, Name: {x.Name}"));

//EmployeeModel employee = await sqlApiHandler.ReadItemAsync("HR", "Employees", "902", "Software Engineer I");
//Console.WriteLine($"id: {employee.id}, EmployeeId: {employee.EmployeeId}, Name: {employee.Name}");
//employee.Name = "Muhammad Ali UPDATED";
//await sqlApiHandler.UpdateItemAsync("HR", "Employees", employee.id, employee.Designation, employee);

//dynamic[] parameters = new dynamic[1] {
//    new  { id = "906", EmployeeId = "1006", Designation = "Software Engineer V", Age = 5, Experience = 2, Name = "Abdul Waris 1.0", Salary = 10000 }
//};
//object response = await sqlApiHandler.ExecuteStoredProcedureAsync("HR", "Employees", parameters[0].Designation, "AddItem", parameters );
//Console.WriteLine(response.ToString());

Console.WriteLine("Run Successfully");