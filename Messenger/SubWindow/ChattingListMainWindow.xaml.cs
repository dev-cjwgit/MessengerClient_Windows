using Messenger.Binding.ObjectViewModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Messenger.SubWindow
{
    /// <summary>
    /// ChattingMainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ChattingListMainWindow : UserControl
    {
        public ChattingListMainWindow()
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
                Title = "한기대 알고리즘 2분반 오픈카톡방입니다. 환영해요",
                Body = "아니 그게 아니라... 이건rㅂㅈㄷㅅㅂㅈㄷㅅㅂㅈㄷㄱㅂㅈㄷㅅㅂㅈㄱㅂㅈㄷㄱㅂㅈㄷㅂㅈㄷㅅ데",
                Date="2021-04-25"
            });
        }

        private void ChattingList_EnterChatting(object sender, RoutedEventArgs e)
        {

        }

        private void ChattingList_ExitChatting(object sender, RoutedEventArgs e)
        {

        }

    }
    public class ValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((double)value) - 40;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("Cannot convert back");
        }
    }

    public class TitleTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((double)value) - 50;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("Cannot convert back");
        }
    }
}
