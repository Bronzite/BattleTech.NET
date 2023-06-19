using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleTechNET.Common
{
	public class DesignException:Exception
	{
		public DesignException(string message):base(message)
		{
		}
	}
}
