using Microsoft.Data.SqlClient;
using Dapper;
using CRUDop;

{
    // Connection string: replace with your actual server, database, and credentials
    string connectionString = "Server=YOUR_SERVER_NAME;Database=SchoolDB;User Id=YOUR_USERNAME;Password=YOUR_PASSWORD;";

    using (SqlConnection conn = new SqlConnection(connectionString))
    {
        conn.Open();

        // =========================
        // CREATE (Insert new record)
        // =========================
        string insertQuery = "INSERT INTO Students (Name, Age, Email) VALUES (@Name, @Age, @Email)";
        conn.Execute(insertQuery, new { Name = "John Doe", Age = 20, Email = "john@example.com" });

        // =========================
        // READ (Select records)
        // =========================
        string selectQuery = "SELECT * FROM Students";
        IEnumerable<Student> students = conn.Query<Student>(selectQuery);
        Console.WriteLine("\nStudents in database:");
        foreach (var s in students)
        {
            Console.WriteLine($"{s.StudentID}: {s.Name}, {s.Age}, {s.Email}");
        }

        // =========================
        // UPDATE (Modify existing record)
        // =========================
        string updateQuery = "UPDATE Students SET Age = @Age WHERE Name = @Name";
        conn.Execute(updateQuery, new { Age = 21, Name = "John Doe" });

        // =========================
        // DELETE (Remove record)
        // =========================
        string deleteQuery = "DELETE FROM Students WHERE Name = @Name";
        conn.Execute(deleteQuery, new { Name = "John Doe" });

        conn.Close();
    }
}
