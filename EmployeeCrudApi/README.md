Project Setup
1.	Open the Asp .net Core Web API Project
2.	Build the Project
3.	Run the Application
4.	Access Swagger UI (API Explorer)
Navigate to:
text
https://localhost:<port>/swagger
Replace <port> with the port number shown in the console.
💡 API Endpoints
Method	Route	Description	Response Type
GET	/api/employees	Fetch all employees	200 OK
GET	/api/employees/{id}	Fetch employee by ID	200 OK/404
POST	/api/employees	Add a new employee	201 Created
PUT	/api/employees/{id}	Update an employee by ID	204/400/404
DELETE	/api/employees/{id}	Delete employee by ID	204/404

	Sample JSON for POST/PUT
json
{
  "fullName": "Sagar Thombare",
  "department": "IT,
  "salary": 5000
}

	Testing API via Swagger
1.	Run the application with dotnet run
2.	Open Swagger UI
3.	You’ll get a full API UI with:
•	Endpoint list
•	Sample request/response
•	Try-it-out functionality
4.	Try creating, updating, and deleting employees directly from the browser.

	Input Validations
Basic input validation is implemented on POST and PUT operations to ensure:
•	FullName and Department must be non-empty strings.
•	Salary must be greater than 0.
If validation fails, a 400 Bad Request is returned.

	Error Handling & Status Codes
•	Returns 404 Not Found for missing resources
•	Returns 400 Bad Request for invalid inputs
•	Returns 201 Created after successful creation
•	Returns 204 No Content for successful updates/deletions

	Project Structure
EmployeeManagementAPI/
├── Controllers/
│   └── EmployeesController.cs     All endpoints for Employee CRUD
│
├── Models/
│   └── Employee.cs               Employee model
│
├── Services/
│   ├── IEmployeeService.cs       Interface abstraction
│   └── EmployeeService.cs        In-memory CRUD implementation
│
├── Program.cs                    Application entry and DI setup
└── README.md                     You're reading it!
•	The app uses in-memory storage, so data resets every time you restart.

