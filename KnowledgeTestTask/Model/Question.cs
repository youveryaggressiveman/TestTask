using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeTestTask.Model
{
    public class Question: ICloneable
    {
        public int Number { get; set; }
        public string Meaning { get; set; }
        public ObservableCollection<string> Variables { get; set; } = new();
        public string RightAnswer { get; set; }
        public string LastAnswer { get; set; }
        public bool IsOk { get; set; }

        public object Clone()
        {
            return new Question
            {
                Number = this.Number,
                Meaning =this.Meaning,
                Variables = this.Variables,
                RightAnswer = this.RightAnswer,
            };
        }

    }
}
