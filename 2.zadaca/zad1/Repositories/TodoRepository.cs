using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Runtime.Serialization;


namespace Repositories
{
	/// <summary >
	/// Class  that  encapsulates  all  the  logic  for  accessing  TodoTtems.
	/// </summary >
	public class TodoRepository : ITodoRepository
	{
		/// <summary >
		/// Repository  does  not  fetch  todoItems  from  the  actual  database ,
		/// it uses in  memory  storage  for  this  excersise.
		/// </summary >
		private readonly List<ToDoItem> _inMemoryTodoDatabase;
		public TodoRepository(List<ToDoItem> initialDbState = null)
		{
			if (initialDbState != null)
			{
				_inMemoryTodoDatabase = initialDbState;
			}
			else
			{
				_inMemoryTodoDatabase = new List<ToDoItem>();
			}
		}
		public void Add(ToDoItem todoItem)
		{
            if (todoItem == null) throw new ArgumentNullException();
            if (Get(todoItem.Id) == todoItem) throw new DuplicateTodoItemException();
            _inMemoryTodoDatabase.Add(todoItem);
		}

		public ToDoItem Get(Guid todoId)
		{
		    var temp = _inMemoryTodoDatabase
		        .Where(x => x.Id == todoId)
                .Select(x=>x);
		    return temp.FirstOrDefault();
		}

		public List<ToDoItem> GetActive()
		{
		    var temp = _inMemoryTodoDatabase
		        .Where(x => !x.IsCompleted)
		        .ToList();
			return temp;
		}

		public List<ToDoItem> GetAll()
		{
		    var temp = _inMemoryTodoDatabase
		        .OrderByDescending(x => x.DateCreated)
                .ToList();
            return temp;
		}

		public List<ToDoItem> GetCompleted()
		{
            var temp = _inMemoryTodoDatabase
                .Where(x => x.IsCompleted)
                .ToList();
            return temp;
        }

		public List<ToDoItem> GetFiltered(Func<ToDoItem, bool> filterFunction)
		{
            var temp = _inMemoryTodoDatabase
                .Where(filterFunction)
                .ToList();
            return temp;
        }

		public bool MarkAsCompleted(Guid todoId)
		{
		    var item = Get(todoId);
		    if (item == null) return false;
            item.MarkAsCompleted();
		    return item.IsCompleted;
		}

		public bool Remove(Guid todoId)
		{
		    return _inMemoryTodoDatabase.Remove(Get(todoId));
		}

		public void Update(ToDoItem todoItem)
		{
		    if (Get(todoItem.Id) == null) Add(todoItem);

		}
	}

 }

