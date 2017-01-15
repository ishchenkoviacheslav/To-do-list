using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To_do_list
{
    class ApplicationViewModel
    {
        public List<task> Tasks { get; set; }

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

        private RelayCommand detailsCommand;
        public RelayCommand DetailsCommand
        {
            get
            {
                return detailsCommand ??
                  (detailsCommand = new RelayCommand(obj =>
                  {
                      TaskDetails taskDtls = new TaskDetails(TaskViewModel task);
                      taskDtls.ShowDialog();
                  }));
            }
        }

    }
}
