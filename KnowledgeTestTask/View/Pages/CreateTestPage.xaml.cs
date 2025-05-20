using KnowledgeTestTask.ViewModel;
using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KnowledgeTestTask.View.Pages
{
    /// <summary>
    /// Interaction logic for CreateTestPage.xaml
    /// </summary>
    public partial class CreateTestPage : Page
    {
        private readonly CreateTestPageViewModel _viewModel;
        public CreateTestPage()
        {
            InitializeComponent();

            DataContext = _viewModel = new();
        }
    }
}
