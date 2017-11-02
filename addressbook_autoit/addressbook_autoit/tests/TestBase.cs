using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_tests_autoit
{
    public class TestBase
    {
        public ApplicationManager app;

        [SetUp]//[TestFixtureSetUp]//error CS0246: The type or namespace name could not 'TestFixtureSetUpAttribute' could not be found (are you missing a using directive or an assemly reference?)
        public void initApplication()
        {
            app = new ApplicationManager();
        }

        [TearDown]// [TestFixtureTearDown]//
        public void stopApplication()
        {
            app.Stop();
        }
    }
}