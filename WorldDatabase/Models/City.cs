using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using WorldDatabase;

namespace WorldDatabase.Models
{
    public class City
    {
        private int _Id;
        private string _Name;
        private string _CountryCode;
        private int _Population;
        private static List<City> _instances = new List<City> { };

        public City(int id, string name, int population)
        {
            _Id = id;
            _Name = name;
            _Population = population;
        }
        public string GetName()
        {
            return _Name;
        }
        public string GetCountry()
        {
            return _CountryCode;
        }
        public int GetPop()
        {
            return _Population;
        }

        public static List<City> GetAll()
        {
            List<City> allCities = new List<City> { };
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM city;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                int cityId = rdr.GetInt32(0);
                string cityName = rdr.GetString(1);
                int cityPop = rdr.GetInt32(4);
                City newCity = new City(cityId, cityName, cityPop);
                allCities.Add(newCity);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allCities;
        }
    }


}
