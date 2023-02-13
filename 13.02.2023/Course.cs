using System;
using System.Collections.Generic;
using System.Text;

namespace _13._02._2023
{
    internal class Course: ICourse
    {

        public Group[] Groups=new Group[0];

        public void AddGroup(Group group)
        {
            Array.Resize(ref Groups, Groups.Length+1);
            Groups[Groups.Length-1] = group;
        }

        public Group GetGroupByNo(string no)
        {
            

            foreach (Group item in Groups)
            {
                if (item.No==no)
                {
                    return item;
                }
            }
            return null;
        }

        public Group[] GetGroupsByPointRange(byte minpoint,byte maxpoint)
        {
            Group[] wantedGroups= new Group[0];

           foreach (Group item in Groups)
            {
                if (item.AvgPoint>=minpoint&& item.AvgPoint<=maxpoint)
                {
                    Array.Resize(ref wantedGroups, wantedGroups.Length + 1);
                    wantedGroups[wantedGroups.Length-1] =item;
                     
                }
            }
           return wantedGroups;
        }


        public Group[] Search(string search)
        {
            Group[] wantedGroups= new Group[0];

            foreach (Group item in Groups)
            {
                if (item.No.Contains(search))
                {
                    Array.Resize(ref wantedGroups, wantedGroups.Length + 1);
                    wantedGroups[wantedGroups.Length - 1] = item;

                    
                }
            }
            return wantedGroups;
        }
    }
}
