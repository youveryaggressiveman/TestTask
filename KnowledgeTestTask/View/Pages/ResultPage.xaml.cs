using KnowledgeTestTask.Model;
using KnowledgeTestTask.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KnowledgeTestTask.View.Pages
{
    /// <summary>
    /// Interaction logic for ResultPage.xaml
    /// </summary>
    public partial class ResultPage : Page
    {
        private readonly ResultPageViewModel _viewModel;

        public ResultPage(ObservableCollection<Question> questions)
        {
            InitializeComponent();

            DataContext = _viewModel = new(questions);
        }
    }
}
