using Messenger.Socket;
using PacketComponent;
using ProgramCore.Entity;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Messenger
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class LoginWindow : Window
    {

        public LoginWindow()
        {
            InitializeComponent();
            new ServerService("220.88.163.147", 5000);
            ServerService.sendLoginFrm = RecvData;
        }

        private void WindowsTitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void WindowsCloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            SendPacket s = new SendPacket();
            if (emailTextBox.Text.ToString().Contains("@"))
            {
                s.writeShort(256);
            }
            else
            {
                s.writeShort(255);
            }
            s.writeString(emailTextBox.Text.ToString());
            s.writeString(PWTextBox.Password.ToString());
            ServerService.send(s.getPacket());


        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var anim = new DoubleAnimation(0, 1, (Duration)TimeSpan.FromSeconds(0.5));
            this.BeginAnimation(UIElement.OpacityProperty, anim);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Closing -= Window_Closing;
            e.Cancel = true;
            var anim = new DoubleAnimation(0, (Duration)TimeSpan.FromSeconds(0.5));
            anim.Completed += (s, _) => Environment.Exit(0);
            this.BeginAnimation(UIElement.OpacityProperty, anim);
        }

        public void RecvData(int opcode, ReadPacket r)
        {
            int status = r.readShort();
            switch (status)
            {
                case -1:
                    {
                        MessageBox.Show("서버 연결이 실패하였습니다.");
                        break;
                    }
                case 1:
                    {
                        MessageBox.Show("존재하지 않는 전화번호입니다.");
                        break;
                    }
                case 2:
                    {
                        MessageBox.Show("비밀번호가 틀렸습니다.");
                        break;
                    }

                case 5:
                    {
                        int uid = r.readInt();
                        string nickname = r.readString();
                        string introduce = r.readString();

                        FriendWindowEntity.GetInstance().Uid = uid;
                        FriendWindowEntity.GetInstance().NickName = nickname;
                        FriendWindowEntity.GetInstance().Introduce = introduce;
                        Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate
                        {
                            MainWindow main = new MainWindow();
                            this.Hide();
                            main.Show();
                        }));
                        break;
                    }
            }
        }
    }
}
