using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace fantasybestiariumdb
{
    internal class SzornyAdatbazis
    {
        readonly string connectionString = "server=localhost;database=fantasybestiariumdb;uid=root;pwd=;";

        public List<Szorny> Feltolt()
        {
            List<Szorny> szornyek = new();
            using (MySqlConnection connection = new(connectionString))
            {
                string query = "SELECT * FROM szornyek";
                using (MySqlCommand command = new(query, connection))
                {
                    connection.Open();
                    using(MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Szorny szorny = new(
                                reader.GetInt32("id"),
                                reader.GetString("nev"),
                                reader.GetInt32("veszelyessegiSzint"),
                                reader.GetString("elohely"),
                                reader.GetString("foGyengeseg"),
                                reader.GetString("leggyakoribbZsakmany"),
                                reader.GetBoolean("veszelyesE")
                            );
                            szornyek.Add(szorny);
                        }
                    }
                }
            }
            return szornyek;
        }
    }
}
