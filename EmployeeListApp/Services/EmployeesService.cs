using EmployeeListApp.Data;

namespace EmployeeListApp.Services
{
	public class EmployeesService
	{
		AppDbContext _context;
		public EmployeesService(AppDbContext context)
		{
			_context = context;
		}
		public async Task<List<Employee>> GetEmployeesAsync()
		{
			var result = _context.Employees;
			return await Task.FromResult(result.ToList());
		}
		public async Task<Employee> GetEmployeeByIdAsync(string id)
		{
			return await _context.Employees.FindAsync(id);
		}
		public async Task<Employee> InsertEmployeeAsync(Employee Employee)
		{
			_context.Employees.Add(Employee);
			await _context.SaveChangesAsync();
			return Employee;
		}
		public async Task<Employee> UpdateEmployeeAsync(string id, Employee s)
		{
			var Employee = await _context.Employees.FindAsync(id);
			if (Employee == null)
				return null;
			Employee.Id = s.Id;
			Employee.FullName = s.FullName;
			Employee.Department = s.Department;
			Employee.Salary = s.Salary;
			_context.Employees.Update(Employee);
			await _context.SaveChangesAsync();
			return Employee;
		}
		public async Task<Employee> DeleteEmployeeAsync(string id)
		{
			var Employee = await _context.Employees.FindAsync(id);
			if (Employee == null)
				return null;
			_context.Employees.Remove(Employee);
			await _context.SaveChangesAsync();
			return Employee;
		}
		private bool EmployeeExists(string id)
		{
			return _context.Employees.Any(e => e.Id == id);
		}
	}
}
