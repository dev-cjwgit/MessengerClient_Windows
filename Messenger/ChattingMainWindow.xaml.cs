using Messenger.Binding.ObjectViewModel;
using Messenger.SubWindow;
using ProgramCore.ObjectForm;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Messenger
{
    /// <summary>
    /// ChattingMainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ChattingMainWindow : Window
    {
        private ChattingViewModel vm = new ChattingViewModel();
        private WindowState PrevWindowState = WindowState.Normal;
        public ChattingMainWindow()
        {
            InitializeComponent();
        }
        public ChattingMainWindow(string title)
        {
            InitializeComponent();
            TitleTextBox.DataContext = vm;
            ChattingListSubWindow.ChatMsgList.ItemsSource = vm.List;
            vm.Title = title;
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
        }

        #region Window Events
        private void WindowsCloseButton_Click(object sender, RoutedEventArgs e)
        {

            Close();
        }

        private void WindowsMinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            PrevWindowState = WindowState;
            var anim = new DoubleAnimation(0, (Duration)TimeSpan.FromSeconds(0.3));
            anim.Completed += (s, _) =>
            {
                this.WindowState = WindowState.Minimized;
                //TrayInit();

            };

            this.BeginAnimation(UIElement.OpacityProperty, anim);
        }

        private void WindowsMaximizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState temp = (this.WindowState == WindowState.Normal ? WindowState.Maximized : WindowState.Normal);
            DoubleAnimation anim1 = new DoubleAnimation(1, 0, (Duration)TimeSpan.FromSeconds(0.33));
            DoubleAnimation anim2 = new DoubleAnimation(0, 1, (Duration)TimeSpan.FromSeconds(0.33));

            anim1.Completed += (s, _) =>
            {
                this.WindowState = temp;
                this.BeginAnimation(OpacityProperty, anim2);
            };

            this.BeginAnimation(OpacityProperty, anim1);
        }
        #endregion

        private void WindowsMaximizeButton_Click(object sender, MouseButtonEventArgs e)
        {

        }

        private void WindowsTitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            this.Opacity = Slider1.Value / 100;
        }
    }
}
