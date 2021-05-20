using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Binding.ObjectViewModel
{

    public class ChattingListViewModel
    {
        public string Title
        {
            get; set;
        }

        public int People
        {
            get; set;
        }

        public string Body
        {
            get; set;
        }

        public string Date
        {
            get; set;
        }
        private static ObservableCollection<ChattingListViewModel> instance;
        public static ObservableCollection<ChattingListViewModel> GetInstance()
        {
            if (instance == null)
                instance = new ObservableCollection<ChattingListViewModel>();
            return instance;
        }
    }
}
