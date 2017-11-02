using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_autoit
{
    [TestFixture]
    class GroupRemovalTests : TestBase
    {
        [Test]
        public void TestGroupRemoval()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            if (oldGroups.Count() < 2)
            { // единственную существующую группу не удалить, нужно создать группу для удаления
                app.Groups.Add(new GroupData()
                {
                    Name = "groupToRemoval"
                });
                oldGroups = app.Groups.GetGroupList();
            }

            GroupData toBeRemoved = oldGroups[oldGroups.Count-1];//удаляем последнюю в списке

            app.Groups.Remove(toBeRemoved);
            oldGroups.RemoveAt(oldGroups.Count - 1);

            List<GroupData> newGroups = app.Groups.GetGroupList();

            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupList().Count);

            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
