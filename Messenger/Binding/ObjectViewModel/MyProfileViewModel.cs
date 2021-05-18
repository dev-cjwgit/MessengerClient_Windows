using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Binding.ObjectViewModel
{
    public class MyProfileViewModel : NotifyPropertyChanged
    {
        private string _nickname;
        private string _introduce;

        public string NickName
        {
            get
            {
                return _nickname;
            }

            set
            {
                _nickname = value;
                OnPropertyChanged("NickName");
            }
        }
        public string Introduce
        {
            get
            {
                return _introduce;
            }

            set
            {
                _introduce = value;
                OnPropertyChanged("Introduce");
            }
        }

        private static MyProfileViewModel instance;

        public static MyProfileViewModel GetInstance()
        {
            if (instance == null)
                instance = new MyProfileViewModel();
            return instance;
        }
    }
}
