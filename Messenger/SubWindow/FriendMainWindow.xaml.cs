using Messenger.Binding.ObjectViewModel;
using ProgramCore.Entity;
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
        }

        public FriendMainWindow()
        {
            InitializeComponent();
            InitBinding();

            MyProfileViewModel.GetInstance().NickName = FriendWindowEntity.GetInstance().NickName;
            MyProfileViewModel.GetInstance().Introduce = FriendWindowEntity.GetInstance().Introduce;

            List<Family> families = new List<Family>();

            Family family1 = new Family() { Title = "즐겨찾기" };
            family1.List.Add(new FamilyMember() { NickName = "김진혁", Introduce = "반갑습니다" });
            families.Add(family1);

            Family family2 = new Family() { Title = "생일" };
            family2.List.Add(new FamilyMember() { NickName = "정윤모", Introduce = "생일이당~" });
            families.Add(family2);

            Family family3 = new Family() { Title = "친구" };
            family3.List.Add(new FamilyMember() { NickName = "김진혁", Introduce = "반갑습니다" });
            family3.List.Add(new FamilyMember() { NickName = "정윤모", Introduce = "생일이당~" });
            family3.List.Add(new FamilyMember() { NickName = "홍길동", Introduce = "나는 의적!" });
            families.Add(family3);
            FriendTreeView.ItemsSource = families;

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
