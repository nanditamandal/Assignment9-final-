using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using  System.Data.SqlClient;
using System.Threading.Tasks;
using Customerdetail.Model;

namespace Customerdetail.Repository
{
    public class CustomerRepository
    {
        public bool Exitcode(CustomerModel customerModel)
        {
         
            string connectionString = @"Server=NANDITA;DataBase=Customerdetail;Integrated Security=true";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            string CommandString = @"SELECT * FROM Customers WHERE Code='"+customerModel.Code+"' ";

            SqlCommand sqlCommand = new SqlCommand(CommandString, sqlConnection);
            sqlConnection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            
            if (dataTable.Rows.Count > 0)
            {
                return  true;
            
            }
            sqlConnection.Close();
            return false;
        }
        public bool Exitcontact(CustomerModel customerModel)
        {

            string connectionString = @"Server=NANDITA;DataBase=Customerdetail;Integrated Security=true";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            string CommandString = @"SELECT * FROM Customers WHERE Contact='" + customerModel.Contact + "'";

            SqlCommand sqlCommand = new SqlCommand(CommandString, sqlConnection);
            sqlConnection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {
                return true;

            }
            sqlConnection.Close();
            return false;
        }

        public bool Addcustomer(CustomerModel customerModel)
        {
            bool isadd = false;
            try
            {

                string connection = @"Server=NANDITA;DataBase=Customerdetail;Integrated Security=True";
                SqlConnection sqlconnection = new SqlConnection(connection);
                string insert = @"INSERT INTO Customers(Code,Name, Address , Contact, DistrictName)VALUES('" + customerModel.Code + "','" + customerModel.Name + "', '" + customerModel.Address + "','" + customerModel.Contact+ "','" + customerModel.DistrictName + "')";
                SqlCommand command = new SqlCommand(insert, sqlconnection);

                sqlconnection.Open();
                int isExecuted = command.ExecuteNonQuery();
                if (isExecuted > 0)
                {
                    isadd = true;

                }

                sqlconnection.Close();

            }
            catch (Exception e)
            {
                //MessageBox.Show("please insert name address and contact..");
            }
            return isadd;
        }
      /*  public List<DistrictModel> DistrictComboBox()
        {
           

            string connectionString = @"Server=NANDITA;DataBase=Customerdetail;Integrated Security=true";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            string CommandString = @"SELECT DistrictName FROM District ";

            SqlCommand sqlCommand = new SqlCommand(CommandString, sqlConnection);

            sqlConnection.Open();
          
            List<DistrictModel> districts = new List<DistrictModel>();
      


            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            //districts.Add(d);
            while (sqlDataReader.Read())
            {
                
                DistrictModel district = new DistrictModel();
                
                district.DistrictName =Convert.ToString( sqlDataReader["DistrictName"]);
     
                districts.Add(district);
            }
          
            sqlConnection.Close();
            return districts;

            // return dataTable;

        }
        */
        public List<CustomerModel> ShowCustomer()
        {

            string connectionString = @"Server=NANDITA; Database=Customerdetail; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);


            string commandString = @"SELECT * FROM Customers";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);


            sqlConnection.Open();
            List<CustomerModel> customers = new List<CustomerModel>();

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                CustomerModel customer = new CustomerModel();
                customer.Id = Convert.ToInt32(sqlDataReader["Id"]);
                customer.Code = Convert.ToString(sqlDataReader["Code"]);
                customer.Name = Convert.ToString(sqlDataReader["Name"]);
                customer.Address = Convert.ToString(sqlDataReader["Address"]);
                customer.Contact = Convert.ToString(sqlDataReader["Contact"]);
                customer.DistrictName = Convert.ToString(sqlDataReader["DistrictName"]);

                customers.Add(customer);
            }

            sqlConnection.Close();
            return customers;
        }

          
      
        public List<CustomerModel> Search(CustomerModel customerModel)
        {


            string connectionString = @"Server=NANDITA;DataBase=Customerdetail;Integrated Security=true";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            string CommandString = @"SELECT * FROM Customers WHERE Code='" + customerModel.Code+ "'";

            SqlCommand sqlCommand = new SqlCommand(CommandString, sqlConnection);
            sqlConnection.Open();

            List<CustomerModel> customers = new List<CustomerModel>();

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                CustomerModel customer = new CustomerModel();
                customer.Id = Convert.ToInt32(sqlDataReader["Id"]);
                customer.Code = Convert.ToString(sqlDataReader["Code"]);
                customer.Name = Convert.ToString(sqlDataReader["Name"]);
                customer.Address = Convert.ToString(sqlDataReader["Address"]);
                customer.Contact = Convert.ToString(sqlDataReader["Contact"]);
                customer.DistrictName = Convert.ToString(sqlDataReader["DistrictName"]);

                customers.Add(customer);
            }

            sqlConnection.Close();

            return customers;


        }

        public bool Modificustomer(CustomerModel customerModel)
        {
            bool isupdate = false;
            try
            {
                string connection = @"Server=NANDITA;DataBase=Customerdetail;Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connection);

                string modifi = @"UPDATE Customers SET Name='" + customerModel.Name + "', Address='" + customerModel.Address + "',Contact='" + customerModel.Contact + "',DistrictName='" + customerModel.DistrictName + "' WHERE Id='" + customerModel.Id+ "'";
                SqlCommand command = new SqlCommand(modifi, sqlConnection);

                sqlConnection.Open();

                int isExecuted = command.ExecuteNonQuery();
                if (isExecuted > 0)
                {
                    return isupdate = true;
                }

                sqlConnection.Close();
            }
            catch (Exception e)
            {
                //MessageBox.Show("no customer recod in database");
            }
            return isupdate;

        }

        public DataTable DistrictComboBox()
        {
            string connectionString = @"Server=NANDITA;DataBase=Customerdetail;Integrated Security=true";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            string CommandString = @"SELECT DistrictName FROM District ";

            SqlCommand sqlCommand = new SqlCommand(CommandString, sqlConnection);

            sqlConnection.Open();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            DataRow row = dataTable.NewRow();
            row[0] = 0;
            row[0] = "--select--";
            dataTable.Rows.InsertAt(row, 0);


            sqlConnection.Close();
            return dataTable;

            // return dataTable;

        }






    }
}
