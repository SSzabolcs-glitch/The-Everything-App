using System;
using System.Data.SqlClient;
using System.IO;

public class DatabaseInitializer
{
    public void InitializeDatabase()
    {
        string connectionString = "Persist Security Info=False; Trusted_Connection=True; database=everything; server=(local)"; // cseréld ki a connection stringre
        string sqlFilePath = "C:\\Users\\Mayu\\projects\\el-proyecte-grande-sprint-1-csharp-EviBera\\Backend\\DatabaseInitializer\\database_init.sql"; // cseréld ki a file pathra

        try
        {
   
            string sqlCommands = File.ReadAllText(sqlFilePath);

    
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

          
                using (SqlCommand command = new SqlCommand(sqlCommands, connection))
                {
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }

            Console.WriteLine("Database initialization completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred during database initialization: " + ex.Message);
        }
    }
}
/*
 hogyan  használd:
DatabaseInitializer initializer = new DatabaseInitializer();

initializer.InitializeDatabase();


*/