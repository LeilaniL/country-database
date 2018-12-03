using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using WorldDatabase;

namespace WorldDatabase.Models
{
    public class Country
    {
        private string _Code;
        private string _Name;
        private string _Region;
        private int _Population;
        private static List<Country> _instances = new List<Country> { };

        public Country(string code, string name, string region, int population)
        {
            _Code = code;
            _Name = name;
            _Region = region;
            _Population = population;

        }
        public string GetName()
        {
            return _Name;
        }
        public string GetRegion()
        {
            return _Region;
        }
        public int GetPop()
        {
            return _Population;
        }

        public static List<Country> GetAll()
        {
            List<Country> allCountries = new List<Country> { };
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM country;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                string code = rdr.GetString(0);
                string countryName = rdr.GetString(1);
                string countryRegion = rdr.GetString(3);
                int countryPop = rdr.GetInt32(6);
                Country newCountry = new Country(code, countryName, countryRegion, countryPop);
                allCountries.Add(newCountry);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allCountries;
        }
        public static List<Country> SearchCountry(string searchName)
        {
            List<Country> allCountries = new List<Country> { };
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM country WHERE name LIKE '" + searchName + @"%';";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                string code = rdr.GetString(0);
                string countryName = rdr.GetString(1);
                string countryRegion = rdr.GetString(3);
                int countryPop = rdr.GetInt32(6);
                Country newCountry = new Country(code, countryName, countryRegion, countryPop);
                allCountries.Add(newCountry);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allCountries;
        }
    }
}
