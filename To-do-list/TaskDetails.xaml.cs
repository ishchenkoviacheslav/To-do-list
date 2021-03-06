﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace To_do_list
{
    /// <summary>
    /// Interaction logic for TaskDetails.xaml
    /// </summary>
    public partial class TaskDetails : Window
    {
        public TaskDetails(TaskViewModel task)
        {
            InitializeComponent();
            DataContext = task;
            switch (task.Priority)
            {
                case priority.high:
                    this.rbHigh.IsChecked = true;
                    break;
                case priority.middle:
                    this.rbMiddle.IsChecked = true;
                    break;
                case priority.low:
                    this.rbLow.IsChecked = true;
                    break;
                default:
                    break;
            }
        }
    }
}
