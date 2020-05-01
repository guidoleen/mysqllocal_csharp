using System;
using System.Collections.Generic;
using System.Text;

namespace MysqlLocal.Library
{
	public class DateTimeUtil
	{
		public DateTime GetParsedDateTime(string date)
		{
			return DateTime.Parse(date);
		}

		public DateTime GetOnlyDateFromDateTime(DateTime date)
		{
			return date.Date;
		}
	}
}
