using System;
using System.Text.RegularExpressions;
using System.Data;
using System.Data.SqlClient;

namespace Dal
{


    public class Rmethods
    {
        static string constr = "data source=DESKTOP-45NCF2N;initial catalog=Restaurant;integrated security=True;";

        public void DisplayRestaurant()
        {
            DataTable dt = ExecuteData("select *from resto");
            if (dt.Rows.Count > 0)
            {

                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("====================");
                Console.WriteLine("RSYSTEM");
                Console.WriteLine("====================");

                foreach (DataRow row in dt.Rows)
                {
                    Console.WriteLine(row["rset_id"]+" "+row["name"].ToString() + "  " + row["Open_time"].ToString() + " " + row["close_time"].ToString() + " " + row["Phoneno"].ToString() + " " + row["Address"].ToString() + " " + row["Cuisine"].ToString() + " " + row["Status"].ToString());
                }
                Console.WriteLine("===============================" + Environment.NewLine);
            }
            else
            {
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("No Restaurant Found in database table");
                Console.WriteLine(Environment.NewLine);
            }
        }
        public DataTable ExecuteData(String query)
        {
            DataTable result = new DataTable();
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(constr))
                {
                    sqlcon.Open();
                    SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
                    SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
                    da.Fill(result);
                    sqlcon.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }
        public bool ExecuteCommand(string query)
        {
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(constr))
                {
                    sqlcon.Open();
                    SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
                    sqlcmd.ExecuteNonQuery();
                    sqlcon.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
                throw;
            }
            return true;
        }

        public void AddNewRestaurant()
        {
            int rset_id;
            string name = string.Empty;
            int Open_time;
            int close_time;
             long Phoneno;
            string Address = string.Empty;
            string Cuisine = string.Empty;
            string Status = string.Empty;


            Console.WriteLine("Insert new Restaurant");

            Console.WriteLine("Insert Restaurant Licence Id");
            rset_id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Name of Restaurant :");
            name = Console.ReadLine();
            while (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("You cannot have balnk name");
                Console.WriteLine("Please Enter Restaurant name again");
                name = Console.ReadLine();
            }


            Console.WriteLine("Enter Opening Time");
            Open_time = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Closing time");
            close_time =Convert.ToInt32(Console.ReadLine());

           

            while (true)
            {
                Console.Write("Enter contact Number of Restaurant: ");
                Phoneno =Convert.ToInt64(Console.ReadLine());
                bool status = isValidMobileNumber(Phoneno);              
                
                if (status == true)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Enter Valid Contact No...");
                    continue;
                }
            }
            



            Console.WriteLine("Enter Adress Of Restaurant");
            Address = Console.ReadLine();
            while (string.IsNullOrEmpty(Address))
            {
                Console.WriteLine("You cannot have balnk address");
                Console.WriteLine("Please Enter Restaurant adress name again");
                Address = Console.ReadLine();
            }

            Console.WriteLine("Enter Cuisine Type \n Italian, Chinese, Indian, Mexican");
            Cuisine = Console.ReadLine();
            while (string.IsNullOrEmpty(Cuisine))
            {
                Console.WriteLine("You cannot have to enter Cuisine");
                Console.WriteLine("Please Enter Cuisine adress name again");
                Cuisine = Console.ReadLine();
            }

            Console.WriteLine("Enter Status of Restauran (Active/Deactive)");
            Status = Console.ReadLine();
            while (string.IsNullOrEmpty(Status))
            {
                Console.WriteLine("You cannot Keep these feild Blank");
                Console.WriteLine("Enter Status of Restauran (Active/Deactive)");
                Status = Console.ReadLine();
            }

            ExecuteCommand(string.Format("Insert into resto(rset_id,name,Open_time,close_time,Phoneno,Address,Cuisine,Status) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')",rset_id,name, Open_time, close_time, Phoneno, Address, Cuisine, Status));
        }

        public void EditRestaurant()
        {
            int rset_id;
            string name = string.Empty;
            int Open_time;
            int close_time;
            long Phoneno;
            string Address = string.Empty;
            string Cuisine = string.Empty;
            string Status = string.Empty;

            Console.WriteLine("Edit Existing Employee:");

            Console.WriteLine("Insert Restaurant Licence Id");
            rset_id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Name of Restaurant :");
            name = Console.ReadLine();
            while (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("You cannot have balnk name");
                Console.WriteLine("Please Enter Restaurant name again");
                name = Console.ReadLine();
            }


            Console.WriteLine("Enter Opening Time");
            Open_time =Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Closing time");
            close_time =Convert.ToInt32(Console.ReadLine());

            
            while (true)
            {
                Console.Write("Enter contact of Restaurant: ");
                Phoneno = Convert.ToInt64(Console.ReadLine());
                bool status = isValidMobileNumber(Phoneno);

                if (status == true)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Eneter Valid Contact No...");
                    continue;
                }
            }


            Console.WriteLine("Enter Adress Of Restaurant");
            Address = Console.ReadLine();
            while (string.IsNullOrEmpty(Address))
            {
                Console.WriteLine("You cannot have balnk address");
                Console.WriteLine("Please Enter Restaurant adress name again");
                Address = Console.ReadLine();
            }


            Console.WriteLine("Enter Cuisine Type \n Italian, Chinese, Indian, Mexican");
            Cuisine = Console.ReadLine();
            while (string.IsNullOrEmpty(Address))
            {
                Console.WriteLine("You cannot have balnk address");
                Console.WriteLine("Enter Cuisine Type \n Italian, Chinese, Indian, Mexican");
                Cuisine = Console.ReadLine();
            }


            Console.WriteLine("Enter Status of Restauran (Active/Deactive)");
            Status = Console.ReadLine();
            while (string.IsNullOrEmpty(Status))
            {
                Console.WriteLine("You cannot Keep these feild Blank");
                Console.WriteLine("Enter Status of Restauran (Active/Deactive)");
                Status = Console.ReadLine();
            }


            ExecuteCommand(string.Format("Update resto set name ='{0}',Open_time='{1}',close_time='{2}',Address='{3}',Cuisine='{4}',Status='{5}',Phoneno='{6}'where rset_id='{7}'", name, Open_time, close_time, Address, Cuisine, Status, Phoneno,rset_id));

        }

        public void DeleteRestaurant()
        {
            int rset_id;
            Console.WriteLine("Delete Existing Restaurant");

            Console.WriteLine("Enter Restaurant Licence id");
            rset_id =Convert.ToInt32(Console.ReadLine());

            ExecuteCommand(string.Format("Delete from resto where rset_id='{0}'", rset_id));
            Console.WriteLine("====================");
            Console.WriteLine("Restaurant details deleted from database:" + Environment.NewLine);
        }



        public void ShowActive()
        {
            DataTable dt = ExecuteData("select *from resto where Status='Active'");

            if (dt.Rows.Count > 0)
            {

                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("====================");
                Console.WriteLine("ACTIVE RESTAURANT");
                Console.WriteLine("====================");

                foreach (DataRow row in dt.Rows)
                {
                    Console.WriteLine(row["name"].ToString() + " " + row["Open_time"].ToString() + " " + row["close_time"].ToString() + " " + row["Phoneno"].ToString() + " " + row["Address"].ToString() + " " + row["Cuisine"].ToString() + " " + row["Status"].ToString());
                }
                Console.WriteLine("===============================" + Environment.NewLine);
            }
            else
            {
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("No Restaurant Found in database table");
                Console.WriteLine(Environment.NewLine);
            }

        }
        public static bool isValidMobileNumber(long inputMobileNumber)
        {
            string strRegex = @"(^[0-9]{10}$)|(^\+[0-9]{2}\s+[0-9] {2}[0-9]{8}$)|(^[0-9]{3}-[0-9]{4}-[0-9]{4}$)";


            Regex re = new Regex(strRegex);


            if (re.IsMatch(Convert.ToString(inputMobileNumber)))
            {
                return (true);
            }

            else
            {
                return (false);
            }

        }


        public void SearchRestaurant()
        {
            string name = string.Empty;
            Console.WriteLine("Enter Name of restaurant to serach");
            name = Console.ReadLine();
            Console.WriteLine("Searching....");
            while(string.IsNullOrEmpty(name))
            {
                Console.WriteLine("You cannot Keep these feild Blank");
                Console.WriteLine("Enter Name of restaurant to serach");
                name = Console.ReadLine();
                Console.WriteLine("Searching....");
            }
            DataTable dt = ExecuteData("select * from resto where name='"+name+"' ");
             if (dt.Rows.Count > 0)
            {

                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("====================");
                Console.WriteLine("Search Results");
                Console.WriteLine("====================");

                foreach (DataRow row in dt.Rows)
                {
                    Console.WriteLine(row["name"].ToString() + " " + row["Open_time"].ToString() + " " + row["close_time"].ToString() + " " + row["Phoneno"].ToString() + " " + row["Address"].ToString() + " " + row["Cuisine"].ToString() + " " + row["Status"].ToString());
                }
                Console.WriteLine("===============================" + Environment.NewLine);
            }
            else
            {
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("No Restaurant Found in database table");
                Console.WriteLine(Environment.NewLine);
            }

        }

    }
}
