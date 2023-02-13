using System;
using System.Collections.Generic;
using System.Text;

namespace _13._02._2023
{
    internal interface ICourse
    {
        void AddGroup(Group group);
        Group GetGroupByNo(string no);
        Group[] Search(string search);

    }
}
