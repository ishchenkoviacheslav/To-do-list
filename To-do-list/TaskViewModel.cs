using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
namespace To_do_list
{
    public class TaskViewModel : INotifyPropertyChanged
    {
        private task currentTask;
        public TaskViewModel(task curTask)
        {
            currentTask = curTask;
        }
        public string Description
        {
            get { return currentTask.Description; }
            set
            {
                currentTask.Description = value;
                OnPropertyChanged("Description");
            }
        }

        public priority Priority
        {
            get { return currentTask.Priority; }
            set
            {
                currentTask.Priority = value;
                OnPropertyChanged("Priority");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        private RelayCommand priorityCommand;
        public RelayCommand PriorityCommand
        {
            get
            {
                return priorityCommand ??
                  (priorityCommand = new RelayCommand(obj =>
                  {
                      switch ((string)obj)
                      {
                          case  "0":
                              currentTask.Priority = priority.high;
                              break;
                          case "1":
                              currentTask.Priority = priority.middle;
                              break;
                          case "2":
                              currentTask.Priority = priority.low;
                              break;
                          default:
                              break;
                      }
                  }));
            }
        }
    }
}
