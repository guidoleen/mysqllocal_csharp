using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using MysqlLocal.Library;

namespace MysqlLocal
{
	class Program
	{
		static void Main(string[] args)
		{
			// Json Config for the configuration in the assembly directory
			MysqlLocalConfiguration.PutFileInAssemblyDir("mysqlconfig.json");

			// Test datetime different values datatypes
			MysqlTestData.MysqlTestDateTime();
		}
}

	public class MysqlDAODriver
	{
		internal void InsertIntoDb(string dbName, string sql, Dictionary<string, object> values)
		{
			MysqlDAO mysqlDao = new MysqlDAO(dbName);
			mysqlDao.InsertInto(sql, values);
		}
	}

	public static class MysqlTestData
	{
		public static void MysqlTestDateTime()
		{
			DateTime dateTimeNow = DateTime.Now;
			DateTime dateNow = DateTime.Now.Date;
			DateTime dateParse = DateTime.Parse("2018-01-01");

			MysqlDAODriver driver = new MysqlDAODriver();

			driver.InsertIntoDb(
				"bpetesting",
				$@"INSERT INTO datetest (dtvalue, dvalue)
				VALUES (@dtvalue, @dvalue)",
				new Dictionary<string, object>()
				{
					{ "dtvalue", dateTimeNow },
					{ "dvalue", dateParse }
				}
			);
		}
	}
}
