using MySql.Data.MySqlClient;
using Content_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Content_Management_System.Models.Classes
{
    public class RegisterLamp
    {

		public static void CreateLampData(Lamp lamp)
		{
			MySqlConnection databaseConnection = new MySqlConnection("Server = localhost; Database=cms;Uid=root;");

			string StoreDataString = "INSERT INTO `inventaris`(`model`, `watt`, `kleur`, `aantal`) VALUES (@val1,@val2,@val3,@val4);";
			MySqlCommand storeData = new MySqlCommand(StoreDataString, databaseConnection);
			storeData.Parameters.AddWithValue("@val1", lamp.Model);
			storeData.Parameters.AddWithValue("@val2", lamp.Watt);
			storeData.Parameters.AddWithValue("@val3", lamp.Kleur);
			storeData.Parameters.AddWithValue("@val4", lamp.Aantal);

			try
			{
				databaseConnection.Open();
				storeData.Prepare();
				var executeString = storeData.ExecuteReader();
				databaseConnection.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine("error: " + e.Message);
			}
		}
	}
}
