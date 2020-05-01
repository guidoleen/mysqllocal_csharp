using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace MysqlLocal.Library
{
	public class MysqlDAO
	{
		private string _dbName;
		public MysqlDAO(string dbName)
		{
			this._dbName = dbName;
		}
		public string InsertInto(string sql, Dictionary<string, object> values)
		{
			string message = "";
			try
			{
				using (MySqlCommand command = new MySqlCommand())
				{
					command.Connection = MysqlConnector.GetConnection(this._dbName);
					command.Connection.Open();
					command.CommandText = sql;

					this.AddParametersToCommand(command, values);

						command.ExecuteNonQuery();

					command.Connection.Close();
					message = "Succesfull insert into Db";
				}
			}
			catch(Exception ee)
			{
				return $"Error: {ee.ToString()}";
			}
			finally
			{
			}
			return message;
		}

		private void AddParametersToCommand(MySqlCommand command, Dictionary<string, object> values)
		{
			foreach (var item in values)
			{
				command.Parameters.AddWithValue($@"@{item.Key}", item.Value);
			}
		}
	}
}
