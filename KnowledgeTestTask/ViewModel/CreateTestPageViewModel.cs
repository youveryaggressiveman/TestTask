using HandyControl.Controls;
using KnowledgeTestTask.Command;
using KnowledgeTestTask.Core.Singleton;
using KnowledgeTestTask.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KnowledgeTestTask.ViewModel
{
    public class CreateTestPageViewModel : BaseViewModel
    {
        private string _variable;

        public string Variable
        {
            get => _variable;
            set
            {
                _variable = value;
                OnPropertyChanged(nameof(Variable));
            }
        }

        private Question _question;
        public Question Question
        {
            get => _question;
            set
            {
                _question = value;

                Question.Number = TestSingleton.S_Question.Count + 1;

                OnPropertyChanged(nameof(Question));
            }
        }

        public ICommand AddQuest { get; }
        public ICommand AddVariable { get; }

        public CreateTestPageViewModel()
        {
            TestSingleton.S_Question = new();

            Variable = string.Empty;
            Question = new();

            AddVariable = new DelegateCommand(AddVariableCommand);
            AddQuest = new DelegateCommand(AddQuestCommand);
        }

        private void AddQuestCommand(object obj)
        {
            if (string.IsNullOrEmpty(Question.Meaning) || string.IsNullOrEmpty(Question.RightAnswer) || Question.Variables.Count == 0)
            {
                MessageBox.Warning("Заполните все поля.");

                return;
            }
            else if (!Question.Variables.Contains(Question.RightAnswer))
            {
                MessageBox.Warning("Такого варианта ответа не содержится.");

                return;
            }
            else
            {
                TestSingleton.S_Question.Add(Question);

                Variable = string.Empty;
                Question = new();
            }
        }

        private void AddVariableCommand(object obj)
        {
            if (string.IsNullOrEmpty(Variable))
            {
                MessageBox.Warning("Текст не может быть пустым.");

                return;
            }
            else if (Question.Variables.Contains(Variable))
            {
                MessageBox.Warning("Данный вариант ответа уже присутствует!");

                return;

            }
            else
            {
                Question.Variables.Add(Variable);
            }
        }
    }
}
