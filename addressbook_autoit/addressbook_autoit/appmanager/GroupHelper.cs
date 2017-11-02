﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace addressbook_tests_autoit
{
    public class GroupHelper : HelperBase
    {
        public GroupHelper(ApplicationManager manager) : base(manager) { }

        public static string GROUPWINTITLE = "Group editor";

        public List<GroupData> GetGroupList()
        {
            List<GroupData> list = new List<GroupData>();
            OpenGroupsdDalogue();
            string count = aux.ControlTreeView(GROUPWINTITLE, "",
                "WindowsForms10.SysTreeView32.app.0.2c908d51", "GetItemCount", "#0", "");
            for (int i = 0; i < int.Parse(count); i++)
            {
                string item = aux.ControlTreeView(GROUPWINTITLE, "",
                  "WindowsForms10.SysTreeView32.app.0.2c908d51", "GetText", "#0|#" + i, "");
                list.Add(new GroupData()
                {
                    Name = item
                });
            }
            CloseGroupsdDalogue();
            return list;
        }

        public void Add(GroupData newGroup)
        {
            OpenGroupsdDalogue();
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d53");
            aux.Send(newGroup.Name);
            aux.Send("{ENTER}");
            CloseGroupsdDalogue();
        }

        private void CloseGroupsdDalogue()
        {
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d54");
        }

        private void OpenGroupsdDalogue()
        {
            aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d512");
            aux.WinWait(GROUPWINTITLE);
        }
    }
}