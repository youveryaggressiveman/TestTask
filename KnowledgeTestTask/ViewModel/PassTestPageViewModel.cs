using HandyControl.Controls;
using KnowledgeTestTask.Command;
using KnowledgeTestTask.Core;
using KnowledgeTestTask.Core.Singleton;
using KnowledgeTestTask.Model;
using KnowledgeTestTask.View.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KnowledgeTestTask.ViewModel
{
    public class PassTestPageViewModel : BaseViewModel
    {
        private ObservableCollection<Question> _actualListOfQuest;

        public ObservableCollection<Question> ActualListOfQuest
        {
            get => _actualListOfQuest;
            set
            {
                _actualListOfQuest = value;
                OnPropertyChanged(nameof(ActualListOfQuest));
            }
        }

        private Question _actualQuest;
        public Question ActualQuest
        {
            get => _actualQuest;
            set
            {
                _actualQuest = value;
                OnPropertyChanged(nameof(ActualQuest));
            }
        }

        private string _response;
        public string Response
        {
            get => _response;
            set
            {
                _response = value;
                OnPropertyChanged(nameof(Response));
            }
        }

        public ICommand End { get; }
        public ICommand Next { get; }
        public ICommand Back { get; }

        public PassTestPageViewModel()
        {
            ActualListOfQuest = new();

            TestSingleton.S_Question.OrderBy(quest => quest.Number)
                .ToList()
                .ForEach(quest => ActualListOfQuest.Add((Question)quest.Clone()));

            ActualQuest = ActualListOfQuest[0];

            End = new DelegateCommand(EndCommand);
            Next = new DelegateCommand(NextCommand);
            Back = new DelegateCommand(BackCommand);
        }

        private void CheckAnswer()
        {
            if (string.Equals(Response, ActualQuest.RightAnswer, StringComparison.CurrentCultureIgnoreCase))
            {
                ActualQuest.IsOk = true;
            }
            else
            {
                ActualQuest.IsOk = false;
            }

            ActualQuest.LastAnswer = Response;
        }

        private void BackCommand(object obj)
        {
            CheckAnswer();

            int currentIndex = ActualListOfQuest.IndexOf(ActualQuest);
            int newIndex = (currentIndex - 1 + ActualListOfQuest.Count) % ActualListOfQuest.Count;
            ActualQuest = ActualListOfQuest[newIndex];

            Response = string.Empty;

            if (!string.IsNullOrEmpty(ActualQuest.LastAnswer))
            {
                Response = ActualQuest.LastAnswer;
            }
        }

        private void NextCommand(object obj)
        {
            CheckAnswer();

            int currentIndex = ActualListOfQuest.IndexOf(ActualQuest);
            int newIndex = (currentIndex + 1) % ActualListOfQuest.Count;
            ActualQuest = ActualListOfQuest[newIndex];

            Response = string.Empty;

            if (!string.IsNullOrEmpty(ActualQuest.LastAnswer))
            {
                Response = ActualQuest.LastAnswer;
            }
        }

        private void EndCommand(object obj)
        {
            CheckAnswer();

            FrameManager.SetSource(new ResultPage(ActualListOfQuest));
        }
    }
}
