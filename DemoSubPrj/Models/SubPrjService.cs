using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace DemoSubPrj.Models
{
    public class SubPrjService
    {
        string connectionString;
        public SubPrjService()
        {
            connectionString = "Data Source=LAPTOP-FSPBQLNL\\SQLEXPRESS01;Initial Catalog=Employee_management_System;Integrated Security=True;Encrypt=false";

        }

        public List<SubPrjM> GetDataService()
        {
            string query = "SELECT * FROM EmployeeTb";
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);
                }
            }



        List<SubPrjM> subPrjList = new List<SubPrjM>();

            foreach (DataRow row in dataTable.Rows)
            {
                SubPrjM subPrj = new SubPrjM
                {

                    Emp_id = Convert.ToInt32(row["Emp_id"]),
                    Emp_name = row["Emp_name"].ToString(),
                    Emp_pno = row["Emp_pno"].ToString(),
                    Emp_salary  = Convert.ToInt32(row["Emp_salary"]),
                    Emp_gender = row["Emp_gender"].ToString(),
                    Emp_age = Convert.ToInt32(row["Emp_age"]),
                    Emp_department = row["Emp_department"].ToString(),
                    Emp_designation = row["Emp_designation"].ToString(),
                
                };

                // Add the populated SubPrjM object to the list
                subPrjList.Add(subPrj);
            }

            return subPrjList;
        }

        public void AddData(SubPrjM Data)
        {
            string query = "INSERT INTO EmployeeTb (Emp_name, Emp_age, Emp_salary, Emp_department, Emp_gender, Emp_pno, Emp_designation) " +
                           "VALUES (@Emp_name, @Emp_age, @Emp_salary, @Emp_department, @Emp_gender, @Emp_pno, @Emp_designation)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters to prevent SQL injection
                    command.Parameters.AddWithValue("@Emp_name", Data.Emp_name);
                    command.Parameters.AddWithValue("@Emp_age", Data.Emp_age);
                    command.Parameters.AddWithValue("@Emp_salary", Data.Emp_salary);
                    command.Parameters.AddWithValue("@Emp_department", Data.Emp_department);
                    command.Parameters.AddWithValue("@Emp_gender", Data.Emp_gender);
                    command.Parameters.AddWithValue("@Emp_pno", Data.Emp_pno);
                    command.Parameters.AddWithValue("@Emp_designation", Data.Emp_designation);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }


        public void UpdateData(SubPrjM Data)
        {
            string query = "UPDATE EmployeeTb SET Emp_name = @Emp_name, Emp_age = @Emp_age, Emp_salary = @Emp_salary, Emp_department = @Emp_department, Emp_gender = @Emp_gender, Emp_pno = @Emp_pno, Emp_designation = @Emp_designation WHERE Emp_id = @Emp_id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters to prevent SQL injection
                    command.Parameters.AddWithValue("@Emp_name", Data.Emp_name);
                    command.Parameters.AddWithValue("@Emp_age", Data.Emp_age);
                    command.Parameters.AddWithValue("@Emp_salary", Data.Emp_salary);
                    command.Parameters.AddWithValue("@Emp_department", Data.Emp_department);
                    command.Parameters.AddWithValue("@Emp_gender", Data.Emp_gender);
                    command.Parameters.AddWithValue("@Emp_pno", Data.Emp_pno);
                    command.Parameters.AddWithValue("@Emp_designation", Data.Emp_designation);
                    command.Parameters.AddWithValue("@Emp_id", Data.Emp_id);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            
        }


        public void DeleteData(SubPrjM Data)
        {
            string query = "Delete from EmployeeTb WHERE Emp_id = @Emp_id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Emp_id", Data.Emp_id);

                    connection.Open();
                    command.ExecuteNonQuery();
                }

            }
          
        }


    }
}
