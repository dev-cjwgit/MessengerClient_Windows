using ProgramCore.ObjectForm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Binding.ObjectViewModel
{
    public class ChattingViewModel : NotifyPropertyChanged
    {
        private string _title;
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                OnPropertyChanged("Title");
            }
        }

        public ObservableCollection<ChatListForm> List { get; set; }

        public ChattingViewModel()
        {
            this.Title = "노멀 화면입니다.";
            List = new ObservableCollection<ChatListForm>();
        }
        public ChattingViewModel(string Title)
        {
            this.Title = Title;
            List = new ObservableCollection<ChatListForm>();
        }
    }
}
