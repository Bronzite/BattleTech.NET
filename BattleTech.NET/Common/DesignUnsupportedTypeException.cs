using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleTechNET.Common
{
	public class DesignUnsupportedTypeException:DesignException
	{
		public DesignUnsupportedTypeException(string sType):base($"Unsupported unit type: {sType}")
		{
			UnsupportedType = sType;

		}
		public string UnsupportedType { get; set; }

	}
}
