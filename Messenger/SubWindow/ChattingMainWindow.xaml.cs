using Messenger.Binding.ObjectViewModel;
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

namespace Messenger.SubWindow
{
    /// <summary>
    /// ChattingMainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ChattingMainWindow : UserControl
    {
        public ChattingMainWindow()
        {
            InitializeComponent();
            ChattingList.ItemsSource = ChattingListViewModel.GetInstance();

        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddChattingButton_Click(object sender, RoutedEventArgs e)
        {
            ChattingListViewModel.GetInstance().Add(new ChattingListViewModel()
            {
                Title = "채팅방1입니다",
                Body = "아니 그게 아니라... 이건데"
            });
        }
    }
}
