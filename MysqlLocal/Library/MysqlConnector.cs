using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace MysqlLocal.Library
{
	public static class MysqlConnector
	{
		public static MySqlConnection GetConnection(string dbName)
		{
			MysqlLocalConfiguration.DbName = dbName;
			return new MySqlConnection(MysqlLocalConfiguration.MysqlDbConnectionString);
		}
	}
}
