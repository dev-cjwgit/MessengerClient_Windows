using Messenger.Binding.ObjectViewModel;
using ProgramCore.Entity;
using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// FriendMainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class FriendMainWindow : UserControl
    {

        public FriendMainWindow()
        {
            InitializeComponent();
            ProfileNickNameText.DataContext = MyProfileViewModel.GetInstance();
            ProfileIntroduceText.DataContext = MyProfileViewModel.GetInstance();

            MyProfileViewModel.GetInstance().NickName = FriendWindowEntity.GetInstance().NickName;
            MyProfileViewModel.GetInstance().Introduce = FriendWindowEntity.GetInstance().Introduce;
        }

        private void AddFriendButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
    public class LineConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((double)value) - 20;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("Cannot convert back");
        }
    }
}
