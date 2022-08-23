using Messenger.ViewModel.config;
using Messenger.ViewModel.Interface;
using System;
using System.Reflection.Metadata;
using System.Windows.Controls;
using System.Windows.Input;

namespace Messenger.ViewModel
{
    public class LoginWindowViewModel : NotifyPropertyChanged, IWindowControl
    {
        public LoginWindowViewModel()
        {
            LoginButtonCommand = new Command(LoginButton, null);
        }

        #region Action

        public Action Close { get; set; }

        public Action Open { get; set; }

        #endregion

        #region ICommand
        public ICommand LoginButtonCommand { get; }
        #endregion

        #region Command Method
        private void LoginButton(object obj)
        {
            var passwordBox = obj as PasswordBox;
            Close?.Invoke();
        }

        #endregion

        #region VM Property


        private string? _emailTextBox;
        public string? EmailTextBox
        {
            get => _emailTextBox;

            set
            {
                _emailTextBox = value;
                OnPropertyChanged(nameof(EmailTextBox));
            }
        }
        #endregion
    }

}
