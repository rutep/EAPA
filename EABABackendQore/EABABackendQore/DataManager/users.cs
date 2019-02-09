using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;

namespace EABABackendQore.DataManager
{
    public class users
    {
        //Global strengur fyrir connectionString
        public static string connString = "Server=127.0.0.1;Port=5432; User Id=postgres; Password=postgres; Database=EABA;";
        public static bool userNameExist(string username)
        {
            NpgsqlConnection connection = new NpgsqlConnection(connString);
            connection.Open();
            string req = "SELECT usersname from members;";
            NpgsqlCommand command = new NpgsqlCommand(req, connection);
            NpgsqlDataReader dataReader = command.ExecuteReader();
            object[] rows = new object[100000];
            for (int i = 0; dataReader.Read(); i++)
            {
                string a = dataReader[0].ToString();
                if (dataReader[0].ToString() == username)
                {
                    return true;
                }
            }
            return false;
        }
        public static void createUser(string username, string password, string firstName, string middleName, string lastName, string email, string other_email, string phone
                                        , string other_phone, string affiliation, string postcode, string region, string city, string country, string member_type,
                                        string repeat_password, string address, string other_address)
        {
            //Þarf að encrypta passwordið
            password = crypterinn.encryption.Encrypt(username);
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();

                // hofundur
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    String txt = "INSERT INTO members (usersName,password,firstName,middlename,lastname,email, other_email, phone, other_phone," +
                                "affiliation, postcode, region, city, country, member_type,address,other_address) " +
                                "VALUES (@u, @p,@n,@m,@last,@email,@oemail,@phone,@ophone,@afil, @code, @reg,@city,@country,@memb,@addr,@oaddr)";
                    cmd.CommandText = txt;
                    cmd.Parameters.AddWithValue("u", username);
                    cmd.Parameters.AddWithValue("p", password);
                    cmd.Parameters.AddWithValue("n", firstName);
                    cmd.Parameters.AddWithValue("m", middleName);
                    cmd.Parameters.AddWithValue("last", lastName);
                    cmd.Parameters.AddWithValue("email", email);
                    cmd.Parameters.AddWithValue("oemail", other_email);
                    cmd.Parameters.AddWithValue("phone", phone);
                    cmd.Parameters.AddWithValue("ophone", other_phone);
                    cmd.Parameters.AddWithValue("afil", affiliation);
                    cmd.Parameters.AddWithValue("code", postcode);
                    cmd.Parameters.AddWithValue("reg", region);
                    cmd.Parameters.AddWithValue("city", city);
                    cmd.Parameters.AddWithValue("country", country);
                    cmd.Parameters.AddWithValue("memb", member_type);
                    cmd.Parameters.AddWithValue("addr", address);
                    cmd.Parameters.AddWithValue("oaddr", other_address);
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static string userLogin(string username, string password)
        {
            NpgsqlConnection connection = new NpgsqlConnection(connString);
            connection.Open();
            string req = "SELECT usersName,password,firstName from members;";
            NpgsqlCommand command = new NpgsqlCommand(req, connection);
            NpgsqlDataReader dataReader = command.ExecuteReader();
            object[] rows = new object[100000];
            for (int i = 0; dataReader.Read(); i++)
            {
                string a = dataReader[0].ToString();
                if (username == dataReader[0].ToString())
                {
                    return dataReader[2].ToString();
                }
            }
            return "wrong credentials";
        }

    }
}
