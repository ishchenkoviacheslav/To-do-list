using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
namespace To_do_list
{
    class ApplicationViewModel: INotifyPropertyChanged
    {
        public ObservableCollection<task> Tasks { get; set; }
        private task selectedTask;
        public task CurrentTask
        {
            get
            {
                return selectedTask;
            }
            set
            {
                selectedTask = value;
                OnPropertyChanged("CurrentTask");
            }
        }
        public ApplicationViewModel()
        {
            Tasks = new ObservableCollection<task>()
            {
                new task {Description = "meet with friends", Priority = priority.middle },
                new task {Description = "drink tea", Priority = priority.middle },
                new task {Description = "call to Grandfather", Priority = priority.high },
                new task {Description = "answer email", Priority = priority.low }
            };
            //sorting by priority and rewrite.
            Tasks = new ObservableCollection<task>(Tasks.OrderBy(
                tsk =>  (int)tsk.Priority).ToList());

        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        private RelayCommand detailsCommand;
        public RelayCommand DetailsCommand
        {
            get
            {
                return detailsCommand ??
                  (detailsCommand = new RelayCommand(obj =>
                  {
                      task task = obj as task;
                      TaskViewModel taskViewModel = new TaskViewModel(task);
                      if ( taskViewModel != null)
                      {
                          TaskDetails taskDtls = new TaskDetails(taskViewModel);
                          taskDtls.ShowDialog();
                      }
                      
                  }));
            }
        }
        private RelayCommand addTask;
        public RelayCommand AddTask
        {
            get
            {
                return addTask ??
                  (addTask = new RelayCommand(obj =>
                  {
                      task newTask = new task() { Description = "some task", Priority = priority.low };
                      Tasks.Insert(0, newTask);
                      //sorting by priority and rewrite.
                      //      Tasks = new ObservableCollection<task>(Tasks.OrderBy(
                      //tsk => (int)tsk.Priority).ToList());
                      selectedTask = newTask;
                  }));
            }
        }

        private RelayCommand removeTask;
        public RelayCommand RemoveTask
        {
            get
            {
                return removeTask??
                  (removeTask = new RelayCommand(obj =>
                  {
                      task removingTask = obj as task;
                      if (removingTask != null)
                      {
                          Tasks.Remove(removingTask);
                      }
                  },
                      (obj=>Tasks.Count > 0)
                  ));
            }
        }
    }
}
