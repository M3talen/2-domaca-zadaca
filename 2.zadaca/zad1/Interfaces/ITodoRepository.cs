using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
	public interface ITodoRepository
	{
		/// <summary >
		/// Gets  TodoItem  for a given id
		/// </summary >
		/// <returns >TodoItem  if found , null  otherwise </returns >
		ToDoItem  Get(Guid  todoId);
		/// <summary >
		/// Adds  new  TodoItem  object  in  database.
		/// If  object  with  the  same id  already  exists ,
		/// method  should  throw  DuplicateTodoItemException  with  the  message"duplicate  id: {id}".
		/// </summary >
		void  Add(ToDoItem todoItem);
		/// <summary >
		/// Tries to  remove a TodoItem  with  given id from  the  database.
		/// </summary >
		/// <returns >True if success , false  otherwise </returns >
		bool  Remove(Guid  todoId);
		/// <summary >
		/// Updates  given  TodoItem  in  database.
		/// If  TodoItem  does  not exist , method  will  add  one.
		/// </summary >
		void  Update(ToDoItem todoItem);
		/// <summary >
		/// Tries to mark a TodoItem  as  completed  in  database.
		/// </summary >
		/// <returns >True if success , false  otherwise </returns >
		bool  MarkAsCompleted(Guid  todoId);
		/// <summary >
		/// Gets  all  TodoItem  objects  in database , sorted  by date  created(descending)
		/// </summary >
		List <ToDoItem > GetAll ();
		/// <summary >
		/// Gets  all  incomplete  TodoItem  objects  in  database
		/// </summary >
		List <ToDoItem > GetActive ();
		/// <summary >
		/// Gets  all  completed  TodoItem  objects  in  database
		/// </summary >
		List <ToDoItem > GetCompleted ();
		/// <summary >
		/// Gets  all  TodoItem  objects  in  database  that  apply to the  filter
		/// </summary >
		List <ToDoItem > GetFiltered(Func <ToDoItem , bool > filterFunction);
	}
}
