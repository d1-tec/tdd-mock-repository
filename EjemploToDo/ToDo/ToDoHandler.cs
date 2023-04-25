using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo
{

    // ToDoHandler todoHandler = new TodoHandler(new RepositoryInList())
    // ToDoHandler todoHandler = new TodoHandler(new RepositoryInArray())

    public class ToDoHandler
    {
        // La lista es privada, es implementacion
        // Y esto me permite si quisiera cambiar la implementacion
        // sin que esto impacte a nadie
        // private List<string> todos;
        private IRepository repository;

        // Esto esta encapsulado dado que es una property
        // Pero igual la implementacion esta expuesta, yo estoy
        // mostrando en que estructura guardo mis elementos
        // Si yo maniana cambio los Items por un array, todos los que conocen
        // a la Items como una lista de strings tienen que cambiar conmigo
        // Todos los que conocen a ITems como una lista de strings estan acoplados
        // a esta implementacion
        //public List<string> Items { get; set; }

        public ToDoHandler(IRepository repository)
        {
            this.repository = repository;
        }

        public void CreateToDo(string description)
        {
            if (string.IsNullOrEmpty(description))
                throw new InvalidToDoException();

            this.repository.Add(description);
        }

        public int AmountOfItems() 
        {
            return this.repository.Count();
        }
    }
}
