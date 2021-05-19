using ProgramCore.ObjectForm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramCore.ObjectForm
{
    public class FriendTreeViewForm
    {
        public string Title { get; set; }
        public ObservableCollection<ProfileForm> List { get; set; }
    }
}
