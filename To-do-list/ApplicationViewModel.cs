using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace To_do_list
{
    class ApplicationViewModel: INotifyPropertyChanged
    {
        public List<task> Tasks { get; set; }
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
            Tasks = new List<task>()
            {
                new task {Description = "meet with friends", Priority = priority.middle },
                new task {Description = "drink tea", Priority = priority.middle },
                new task {Description = "call to Grandfather", Priority = priority.high },
                new task {Description = "answer email", Priority = priority.low }
            };
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

    }
}
