using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Messenger.Binding.ObjectViewModel
{
    public class ContentPageViewModel : NotifyPropertyChanged
    {
        private UserControl _page;
        public UserControl Page
        {
            get
            {
                return _page;
            }
            set
            {
                _page = value;
                OnPropertyChanged("Page");
            }
        }

        private static ContentPageViewModel instacne;

        public static ContentPageViewModel GetInstance()
        {
            if (instacne == null)
                instacne = new ContentPageViewModel();
            return instacne;
        }
    }
}
