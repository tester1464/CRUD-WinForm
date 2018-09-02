using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Domain;

namespace Broker
{
    public class Broker
    {
        SqlConnection connection;
        SqlConnectionStringBuilder connStringBuilder;
        
        void ConnectTo()
        {
            //Data Source=DESKTOP-EV3588L\LOCALDATABASE;Initial Catalog=DBv2;Integrated Security=True
            connStringBuilder = new SqlConnectionStringBuilder();
            connStringBuilder.DataSource = "DESKTOP-EV3588L\\LOCALDATABASE";
            connStringBuilder.InitialCatalog = "DBv2";
            connStringBuilder.IntegratedSecurity = true;

            connection = new SqlConnection(connStringBuilder.ToString());

        }

        public Broker()
        {
            ConnectTo();
        }

        public void Insert(Person person)
        {
            try
            {
                string cmd = "INSERT INTO dbo.People (FirstName, LastName) VALUES (@FirstName, @LastName)";
                SqlCommand sqlQuery = new SqlCommand(cmd, connection);
                sqlQuery.Parameters.AddWithValue("@FirstName", person.FirstName);
                sqlQuery.Parameters.AddWithValue("@LastName", person.LastName);

                connection.Open();
                sqlQuery.ExecuteNonQuery();
         
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }
    }
}
