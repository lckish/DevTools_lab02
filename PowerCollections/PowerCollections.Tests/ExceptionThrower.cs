using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Wintellect.PowerCollections.Tests
{
	[TestClass]
	public class ExceptionThrower
	{
		[TestMethod]
		public void ThrowException()
		{
			throw new ArgumentNullException();
		}
	}
}