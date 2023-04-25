using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo
{
    public class RepositoryInList : IRepository
    {
        private List<string> todos;

        public RepositoryInList()
        {
            this.todos = new List<string>();
        }

        public void Add(string description)
        {
            this.todos.Add(description);
        }

        public int Count() => this.todos.Count;
    }
}
