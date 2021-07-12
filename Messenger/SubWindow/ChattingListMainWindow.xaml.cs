using Messenger.Binding.ObjectViewModel;
using ProgramCore.ObjectForm;
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
        private int stack = 0;
        public List<ChattingViewModel> vmlist = new List<ChattingViewModel>();
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
                Title = "한기대 알고리즘 " + stack + "분반 오픈카톡방입니다. 환영해요",
                Body = "아니 그게 아니라... 이건rㅂㅈㄷㅅㅂㅈㄷㅅㅂㅈㄷㄱㅂㅈㄷㅅㅂㅈㄱㅂㅈㄷㄱㅂㅈㄷㅂㅈㄷㅅ데",
                Date="2021-04-25"
            });
            ChattingViewModel vm = new ChattingViewModel();
            vm.Title = "한기대 알고리즘 " + stack++ + "분반 오픈카톡방입니다. 환영해요";
            vm.List.Add(new ChatListForm()
            {
                NickName = "바보!!",
                Body = "반갑습니다 바보라구 해용!",
                NowTime = "오후 10:53"
            });
            vm.List.Add(new ChatListForm()
            {
                NickName = "운영자",
                Body = "안녕하십니까 꼭 필독사항(공지사항)을 읽어 주신 후 질문해주시길 바랍니다!!!",
                NowTime = "오후 10:54"
            });
            vm.List.Add(new ChatListForm()
            {
                NickName = "유저유저",
                Body = "질문이있습니다!! WPF에 대한 MVVM정석이 알고싶습니다. 저는 그냥 동작만하는 비둘기 대가리가 돌아가서 날라는 것과 비슷해서 질문드립니다!!",
                NowTime = "오후 10:55"
            });
            vm.List.Add(new ChatListForm()
            {
                NickName = "김루트",
                Body = "혹시 11시에 배그하실 분 계신가요?? 재미있게 배그할 사람 구해요~!!!!!",
                NowTime = "오후 10:55"
            });
            vm.List.Add(new ChatListForm()
            {
                NickName = "롤은 질병겜",
                Body = "자랭하실분 구합니다.. 즐겁게 하실분 구해요!!! 즐겜파티~!!",
                NowTime = "오후 11:05"
            });
            vm.List.Add(new ChatListForm()
            {
                NickName = "착짱죽짱",
                Body = "짱깨처럼 핵 안쓰는 배그 하실 착한분들 구합니다~ 즐겁고 화끈하게 무한 리부트로 하실분 구해요~!!! 무조건 여포모드 ON!!!",
                NowTime = "오후 11:05"
            });
            vm.List.Add(new ChatListForm()
            {
                NickName = "착짱죽짱",
                Body = "짱깨처럼 핵 안쓰는 배그 하실 착한분들 구합니다~ 즐겁고 화끈하게 무한 리부트로 하실분 구해요~!!! 무조건 여포모드 ON!!!",
                NowTime = "오후 11:05"
            });
            vm.List.Add(new ChatListForm()
            {
                NickName = "착짱죽짱",
                Body = "짱깨처럼 핵 안쓰는 배그 하실 착한분들 구합니다~ 즐겁고 화끈하게 무한 리부트로 하실분 구해요~!!! 무조건 여포모드 ON!!!",
                NowTime = "오후 11:05"
            });
            vm.List.Add(new ChatListForm()
            {
                NickName = "착짱죽짱",
                Body = "짱깨처럼 핵 안쓰는 배그 하실 착한분들 구합니다~ 즐겁고 화끈하게 무한 리부트로 하실분 구해요~!!! 무조건 여포모드 ON!!!",
                NowTime = "오후 11:05"
            });
            vm.List.Add(new ChatListForm()
            {
                NickName = "착짱죽짱",
                Body = "짱깨처럼 핵 안쓰는 배그 하실 착한분들 구합니다~ 즐겁고 화끈하게 무한 리부트로 하실분 구해요~!!! 무조건 여포모드 ON!!!",
                NowTime = "오후 11:05"
            });
            vm.List.Add(new ChatListForm()
            {
                NickName = "착짱죽짱",
                Body = "짱깨처럼 핵 안쓰는 배그 하실 착한분들 구합니다~ 즐겁고 화끈하게 무한 리부트로 하실분 구해요~!!! 무조건 여포모드 ON!!!",
                NowTime = "오후 11:05"
            });
            vm.List.Add(new ChatListForm()
            {
                NickName = "착짱죽짱",
                Body = "짱깨처럼 핵 안쓰는 배그 하실 착한분들 구합니다~ 즐겁고 화끈하게 무한 리부트로 하실분 구해요~!!! 무조건 여포모드 ON!!!",
                NowTime = "오후 11:05"
            });
            vm.List.Add(new ChatListForm()
            {
                NickName = "자1지훈",
                Body = "로리지훈 로리지훈 섹스 섹스 로리지훈 로리지훈 섹스 섹스",
                NowTime = "오후 11:05"
            });
            vmlist.Add(vm);
        }

        private void ChattingList_EnterChatting(object sender, RoutedEventArgs e)
        {
            dynamic meta_data = sender as dynamic;
            ChattingMainWindow form = new ChattingMainWindow(vmlist[0]);
            form.Show();
        }

        private void ChattingList_ExitChatting(object sender, RoutedEventArgs e)
        {

        }

        private void ChattingList_EnterChatting(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            dynamic meta_data = sender as dynamic;
            ChattingMainWindow form = new ChattingMainWindow(vmlist[meta_data.SelectedIndex]);
            form.Show();
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
