using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using WpfApp_MVVM.Models;

namespace WpfApp_MVVM.ViewModels
{
    //public class AddTaskCommand : ICommand
    //{
    //    private readonly MainViewModel mainViewModel;
    //    public event EventHandler? CanExecuteChanged;

    //    public AddTaskCommand(MainViewModel mainViewModel)
    //    {
    //        this.mainViewModel = mainViewModel;
    //    }

    //    public bool CanExecute(object? parameter) => true;


    //    public void Execute(object? parameter)
    //    {
    //        mainViewModel.AddTask();
    //        MessageBox.Show("Add");
    //    }
    //}

    //public class RemoveTaskCommand : ICommand
    //{
    //    private readonly MainViewModel mainViewModel;
    //    public event EventHandler? CanExecuteChanged;

    //    public RemoveTaskCommand(MainViewModel mainViewModel)
    //    {
    //        this.mainViewModel = mainViewModel;
    //    }

    //    public bool CanExecute(object? parameter) => true;


    //    public void Execute(object? parameter)
    //    {
    //        mainViewModel.RemoveTask();
    //        MessageBox.Show("Remove");
    //    }
    //}

    public class CommandBase : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Action<object> action;

        public CommandBase(Action<object> action)
        {
            this.action = action;
        }

        public bool CanExecute(object parameter) => true;
       

        public void Execute(object parameter)
        {
           action?.Invoke(parameter);
        }
    }

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
            //AddTaskCommand = new CommandBase(x=> AddTask());
            //RemoveTaskCommand = new CommandBase(x=> RemoveTask());
            //AddTaskCommand = new CommandBase(AddTask);
            //RemoveTaskCommand = new CommandBase(RemoveTask);
        }
        public string TaskName { get => taskName; set => OnChanged(out taskName, value); }
        public string TaskDescription { get => taskDescription; set => OnChanged(out taskDescription, value); }
        public bool TaskDone { get => taskDone; set => OnChanged(out taskDone, value); }
        public DateTime TaskDeadline { get => taskDeadline; set => OnChanged(out taskDeadline, value); }
        public ObservableCollection<MyTask> MyTasks { get => myTasks; set => OnChanged(out myTasks, value); }
        public MyTask SelectedTask { get => myTask; set => OnChanged(out myTask, value); }


        //public void AddTask()
        //{
        //    MyTask task = new MyTask()
        //    {
        //        Description = TaskDescription,
        //        Name = TaskName,
        //        Deadline = TaskDeadline,
        //        IsDone = TaskDone
        //    };
        //    MyTasks.Add(task);
        //    Clear();
        //}
        //public void RemoveTask()
        //{
        //    if (SelectedTask != null)
        //    {
        //        MyTasks.Remove(SelectedTask);
        //    }
        //}
        //public void AddTask(object obj)
        //{
        //    MyTask task = new MyTask()
        //    {
        //        Description = TaskDescription,
        //        Name = TaskName,
        //        Deadline = TaskDeadline,
        //        IsDone = TaskDone
        //    };
        //    MyTasks.Add(task);
        //    Clear();
        //}
        //public void RemoveTask(object obj)
        //{
        //    if (SelectedTask != null)
        //    {
        //        MyTasks.Remove(SelectedTask);
        //    }
        //}
        public void Clear()
        {
            TaskDescription = string.Empty;
            TaskName = string.Empty;
            TaskDone = false;
            TaskDeadline = DateTime.Now;
        }

        public ICommand addTaskCommand;
        public ICommand AddTaskCommand => addTaskCommand ??= new CommandBase(x =>
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
        });

        public ICommand removeTaskCommand;
        public ICommand RemoveTaskCommand => removeTaskCommand ??= new CommandBase(x =>
        {
            if (SelectedTask != null)
            {
                MyTasks.Remove(SelectedTask);
            }
        });
       
        //public ICommand addTaskCommand;
        //public ICommand AddTaskCommand 
        //{ 
        //    get
        //    {
        //      return addTaskCommand ??= new CommandBase(x => AddTask());
        //    }
        //}
        //public ICommand removeTaskCommand;
        //public ICommand RemoveTaskCommand
        //{
        //    get
        //    {
        //        return removeTaskCommand ??= new CommandBase(x => RemoveTask());
        //    }
        //}
        //public ICommand addTaskCommand;
        //public ICommand AddTaskCommand 
        //{ 
        //    get
        //    {
        //      return addTaskCommand ?? (addTaskCommand = new CommandBase(x => AddTask()));
        //    }
        //}
        //public ICommand removeTaskCommand;
        //public ICommand RemoveTaskCommand
        //{
        //    get
        //    {
        //        return removeTaskCommand ?? (removeTaskCommand = new CommandBase(x => RemoveTask()));
        //    }
        //}
        //public ICommand addTaskCommand;
        //public ICommand AddTaskCommand 
        //{ 
        //    get
        //    {
        //      return addTaskCommand ?? new CommandBase(x => AddTask());
        //    }
        //}
        //public ICommand removeTaskCommand;
        //public ICommand RemoveTaskCommand
        //{
        //    get
        //    {
        //        return removeTaskCommand ?? new CommandBase(x => RemoveTask());
        //    }
        //}
        //public ICommand addTaskCommand;
        //public ICommand AddTaskCommand 
        //{ 
        //    get
        //    {
        //        if (addTaskCommand == null)
        //        {
        //            addTaskCommand = new CommandBase(x => AddTask());
        //        }
        //        return addTaskCommand;
        //    }
        //}
        //public ICommand removeTaskCommand;
        //public ICommand RemoveTaskCommand
        //{
        //    get
        //    {
        //        if (removeTaskCommand == null)
        //        {
        //            removeTaskCommand = new CommandBase(x => RemoveTask());
        //        }
        //        return removeTaskCommand;
        //    }
        //}
    }
}
