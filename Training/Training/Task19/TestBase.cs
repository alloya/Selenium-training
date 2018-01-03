using NUnit.Framework;

namespace Training
{ 
	public class TestBase : Base
	{
		public Application app;

		[SetUp]
		public void start()
		{
			app = new Application(driver, wait);
		}

		[TearDown]
		public void stop()
		{
			app = null;
		}
	}
}

