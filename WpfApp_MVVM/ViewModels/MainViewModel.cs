using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using WpfApp_MVVM.Models;

namespace WpfApp_MVVM.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private string taskName;
        private string taskDescription;
        private bool taskDone;
        private MyTask myTask;
        private DateTime taskDeadline = DateTime.Now;
        private ObservableCollection<MyTask> myTasks;
        public MainViewModel()
        {
            MyTasks = new ObservableCollection<MyTask>();
        }
        public string TaskName { get => taskName; set => OnChanged(out taskName, value); }
        public string TaskDescription { get => taskDescription; set => OnChanged(out taskDescription, value); }
        public bool TaskDone { get => taskDone; set => OnChanged(out taskDone, value); }
        public DateTime TaskDeadline { get => taskDeadline; set => OnChanged(out taskDeadline, value); }
        public ObservableCollection<MyTask> MyTasks { get => myTasks; set => OnChanged(out myTasks, value); }
        public MyTask SelectedTask { get => myTask; set => OnChanged(out myTask, value); }

        public void AddTask()
        {
            MyTask task = new MyTask()
            {
                Description = TaskDescription,
                Name = TaskName,
                Deadline = TaskDeadline,
                IsDone = TaskDone
            };
            MyTasks.Add(task);
            Clear();
        }
        public void RemoveTask()
        {
            if (SelectedTask != null)
            {
                MyTasks.Remove(SelectedTask);
            }
        }
        public void Clear()
        {
            TaskDescription = string.Empty;
            TaskName = string.Empty;
            TaskDone = false;
            TaskDeadline = DateTime.Now;
        }

    }
}
