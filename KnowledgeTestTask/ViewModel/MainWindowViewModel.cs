using HandyControl.Controls;
using KnowledgeTestTask.Command;
using KnowledgeTestTask.Core;
using KnowledgeTestTask.Core.Singleton;
using KnowledgeTestTask.View.Pages;
using System;
using System.Collections.Generic;
using System.Configuration.Internal;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KnowledgeTestTask.ViewModel
{
    public class MainWindowViewModel: BaseViewModel
    {
        public ICommand Create { get; }
        public ICommand Start { get; }

        public MainWindowViewModel()
        {
            Create = new DelegateCommand(CreateCommand);
            Start = new DelegateCommand(StartCommand);
        }

        private void StartCommand(object obj)
        {
            if(TestSingleton.S_Question.Count != 0)
            {
                FrameManager.SetSource(new PassTestPage());
            }
            else
            {
                MessageBox.Info("Нету данных о тесте!");
            }
        }

        private void CreateCommand(object obj)
        {
            FrameManager.SetSource(new CreateTestPage());
        }
    }
}
