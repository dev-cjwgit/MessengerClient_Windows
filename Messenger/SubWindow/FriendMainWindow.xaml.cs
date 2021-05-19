using Messenger.Binding.ObjectViewModel;
using ProgramCore.Entity;
using ProgramCore.ObjectForm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private void InitBinding()
        {
            ProfileNickNameText.DataContext = MyProfileViewModel.GetInstance();
            ProfileIntroduceText.DataContext = MyProfileViewModel.GetInstance();
            FriendTreeView.ItemsSource = FriendTreeViewModel.GetInstance();
        }

        public FriendMainWindow()
        {
            InitializeComponent();
            InitBinding();

            TreeModel model = new TreeModel();
            model.InsertGroup("즐겨찾기");
            model.InsertGroup("생일");
            model.InsertGroup("친구");

            Random rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                model.InsertFriend(rand.Next(0, 3), new ProfileForm()
                {
                    NickName = "유미" + rand.Next(1, 100),
                    Introduce = "자기소개 " + rand.Next(1, 1000) + " 번쨰"
                });
            }
            model.Fetch();
        }

    private void AddFriendButton_Click(object sender, RoutedEventArgs e)
    {

    }

    private void SearchButton_Click(object sender, RoutedEventArgs e)
    {

    }

    private void FriendTreeView_DoubleClick(object sender, MouseButtonEventArgs e)
    {
        dynamic meta_data = sender as dynamic;

        Console.WriteLine();
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
