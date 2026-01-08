using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tridy
{
    class MyTask
    {
        private static int _count = 0;
        public string Title;
        public bool Completed;
        public int Id;

        public MyTask(string title, bool completed)
        {
            Title = title;
            Completed = completed;
            Id = _count++;
        }
        public override string ToString()
        {
            return "Title: " + Title + "Completed: " + Completed + "Id: " + Id;
        }

    }
}
