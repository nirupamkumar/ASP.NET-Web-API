namespace dotNetCoreWebAPI.Models.Entities
{
    public class Employee
    {
        public int GuId { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public string? Phone {  get; set; }
        public decimal Salary { get; set; }
    }
}
