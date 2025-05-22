using KnowledgeTestTask.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeTestTask.ViewModel
{
    public class ResultPageViewModel: BaseViewModel
    {
        private int _okCount;
        public int OkCount
        {
            get => _okCount;
            set
            {
                _okCount = value;
                OnPropertyChanged(nameof(OkCount));
            }
        }

        private int _count;
        public int Count
        {
            get => _count;
            set
            {
                _count = value;
                OnPropertyChanged(nameof(Count));
            }
        }

        private string _result;
        public string Result
        {
            get => _result;
            set
            {
                _result = value;
                OnPropertyChanged(nameof(Result));
            }
        }

        public ResultPageViewModel(ObservableCollection<Question> questions)
        {
            Calculate(questions);
        }

        private void Calculate(ObservableCollection<Question> questions)
        {
            Count = questions.Count;
            OkCount = questions.Where(quest => quest.IsOk == true).Count();

            var percent = Math.Round(((double)OkCount / (double)Count) * 100, 1);

            Result = percent switch
            {
                <= 50 => "неудовлетворительно",
                > 50 and <= 65 => "удовлетворительно",
                > 65 and <= 80 => "хорошо",
                > 80 => "отлично",
                _ => "неизвестно"
            };
        }
    }
}
