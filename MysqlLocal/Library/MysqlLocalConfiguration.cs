using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace MysqlLocal.Library
{
	internal static class MysqlLocalConfiguration
	{
		internal static string DbName { get; set; }
		internal static IConfigurationRoot Config { get; } = new ConfigurationBuilder()
				.SetBasePath(AppContext.BaseDirectory)
				.AddJsonFile("Settings/mysqlconfig.json")
				.Build();

		internal static string MysqlDbConnectionString { get; } = Config["connectionString"]; // {DbName}

		/// <summary>
		/// Puts a config json file in the assembly envirnment
		/// </summary>
		/// <param name="fileName"></param>
		internal static void PutFileInAssemblyDir(string fileName)
		{
			var jsonConfigDirName = @"Settings/";
			var baseDir = System.AppContext.BaseDirectory.ToString() + jsonConfigDirName;
			var configJson = File.ReadAllText($@"{baseDir.Split(@"\bin")[0]}/{jsonConfigDirName}{fileName}");

			if (!Directory.Exists(baseDir))
				Directory.CreateDirectory(baseDir);

			var destConfigJsonDir = $@"{baseDir}{fileName}";

			if (!File.Exists(destConfigJsonDir))
				File.Create(destConfigJsonDir);

			File.WriteAllText(destConfigJsonDir, configJson);
		}
	}
}
