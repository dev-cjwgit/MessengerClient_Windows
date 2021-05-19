using GalaSoft.MvvmLight;
using ProgramCore.Entity;
using ProgramCore.ObjectForm;
using ProgramCore.ObjectForm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Binding.ObjectViewModel
{
    public class TreeModel
    {
        private ObservableCollection<FriendTreeViewForm> list = new ObservableCollection<FriendTreeViewForm>();

        public void InsertFriend(int idx, ProfileForm people)
        {
            list[idx].List.Add(new ProfileForm()
            {
                NickName = people.NickName,
                Introduce = people.Introduce
            });
        }
        public void InsertGroup(string title)
        {
            list.Add(new FriendTreeViewForm()
            {
                Title = title,
                List = new ObservableCollection<ProfileForm>()
            });
        }

        public void Fetch()
        {
            FriendTreeViewModel.SetSource(list);
        }
    }

    public class FriendTreeViewModel
    {
        private static ObservableCollection<FriendTreeViewForm> instance;

        public static ObservableCollection<FriendTreeViewForm> GetInstance()
        {
            if (instance == null)
                instance = new ObservableCollection<FriendTreeViewForm>();
            return instance;
        }

        public static void SetSource(ObservableCollection<FriendTreeViewForm> src)
        {
            instance.Clear();
            foreach (var i in src)
            {
                instance.Add(new FriendTreeViewForm()
                {
                    Title = i.Title,
                    List = i.List
                });
            }
        }

    }
}
