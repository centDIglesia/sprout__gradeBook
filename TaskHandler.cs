using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace sprout__gradeBook
{
    internal class TaskHandler
    {
        private string filePath = "tasks.txt";
        private Stack<string> deletedTasks = new Stack<string>();

        public TaskHandler()
        {
            // Initialize the file if it doesn't exist
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }
        }

        public void AddTask(string task)
        {
            File.AppendAllText(filePath, task + Environment.NewLine);
        }
            
        public void DeleteTask(string task)
        {
            List<string> tasks = new List<string>(File.ReadAllLines(filePath));
            tasks.Remove(task);
            File.WriteAllLines(filePath, tasks.ToArray());
            deletedTasks.Push(task);
        }

        public string UndoDelete()
        {
            if (deletedTasks.Count > 0)
            {
                string lastDeletedTask = deletedTasks.Pop();
                AddTask(lastDeletedTask);
                return lastDeletedTask;
            }
            return null;
        }

        public List<string> GetAllTasks()
        {
            return new List<string>(File.ReadAllLines(filePath));
        }
    }
}
