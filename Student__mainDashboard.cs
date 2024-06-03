using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static sprout__gradeBook.NewTask;
namespace sprout__gradeBook
{
    public partial class Student__mainDashboard : KryptonForm
    {
        private TaskHandler taskHandler= new TaskHandler();

        public Student__mainDashboard(string currentUser)
        {
            InitializeComponent();
            UpdateCurrentDateLabel();
            
            addTask_btn.Enabled = false;

            // Load tasks from the file
            LoadTasks();
        }

        //=== Placeholder ===\\
        private void newTask_input_Enter(object sender, EventArgs e)
        {
            UserInput_Manager.ResetInputField(newTask_input, "Add new task");
        }

        private void newTask_input_Leave(object sender, EventArgs e)
        {
            UserInput_Manager.RestoreDefaultText(newTask_input, "Add new task");
        }

        //=== Add Tasks ===\\
        private void addTask_btn_Click(object sender, EventArgs e)
        {
            string taskText = newTask_input.Text;

            if (string.IsNullOrWhiteSpace(taskText))
            {
                MessageBox.Show("Task cannot be empty. Please enter a task.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            AddTaskToUI(taskText);
            newTask_input.Clear();
            addTask_btn.Enabled = false;
            taskHandler.AddTask(taskText);
        }
        private void AddTaskToUI(string taskText)
        {
            NewTask taskControl = new NewTask
            {
                TaskText = taskText
            };

            taskControl.TaskDeleted += TaskControl_TaskDeleted;
            tasks_Panel.Controls.Add(taskControl);
        }
        private void newTask_input_TextChanged(object sender, EventArgs e)
        {
            // Enable the addTask_btn only if there is text in the input
            addTask_btn.Enabled = !string.IsNullOrWhiteSpace(newTask_input.Text);
        }


        //===Delete and Undo===\\
        private void TaskControl_TaskDeleted(object sender, TaskDeletedEventArgs e)
        {
            NewTask taskControl = sender as NewTask;
            tasks_Panel.Controls.Remove(taskControl);
            taskHandler.DeleteTask(e.TaskText);
            ShowSnackBar("Task deleted! Undo", UndoDeleteTask);
        }
        private void LoadTasks()
        {
            var tasks = taskHandler.GetAllTasks();
            foreach (var task in tasks)
            {
                AddTaskToUI(task);
            }
        }
        private void UndoDeleteTask(object sender, EventArgs e)
        {
            string restoredTask = taskHandler.UndoDelete();
            if (restoredTask != null)
            {
                AddTaskToUI(restoredTask);
            }
        }
        private void ShowSnackBar(string message, EventHandler undoHandler)
        {
            // Implementation of snackbar showing
            TaskUndo_SnackBar snackBar = new TaskUndo_SnackBar(message, undoHandler);
            snackBar.Show();
        }


        //===Update Date Label===\\
        private void UpdateCurrentDateLabel()
        {
            DateTime currentDate = DateTime.Now;
            string formattedDate = currentDate.ToString("MMMM dd, yyyy");
            currentDate_lbl.Text = formattedDate;
        }


    }
}
