using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using To_do_list;
using System.Collections.ObjectModel;
namespace tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCollection()
        {
            // Arrange
            ApplicationViewModel AppViewModel = new ApplicationViewModel();
            // Act
            ObservableCollection<task> AllTasks = AppViewModel.Tasks;
            //Assert
            Assert.IsNotNull(AllTasks);
        }
        [TestMethod]
        public void TestAddCommand()
        {
            // Arrange
            ApplicationViewModel AppViewModel = new ApplicationViewModel();
            //Act
            RelayCommand AddCommand = AppViewModel.AddTask;
            //Assert
            Assert.IsNotNull(AddCommand);
        }
        [TestMethod]
        public void TestDeleteCommand()
        {
            // Arrange
            ApplicationViewModel AppViewModel = new ApplicationViewModel();
            //Act
            RelayCommand DeleteCommand = AppViewModel.RemoveTask;
            //Assert
            Assert.IsNotNull(DeleteCommand);
        }

        [TestMethod]
        public void TestTask()
        {
            // Arrange
            task SomeTask = new task();
            //Act
            SomeTask.Description = "some description";
            SomeTask.Priority = priority.middle;
            //Assert
            Assert.IsNotNull(SomeTask);
        }
    }
}
