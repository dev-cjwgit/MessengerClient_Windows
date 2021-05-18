using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProgramCore.Entity
{
    public class MainWindowEntity
    {
        private UserControl _friend;
        private UserControl _chatting;
        private UserControl _more;

        public UserControl Friend
        {
            get
            {
                return _friend;
            }

            set
            {
                _friend = value;
            }
        }
        public UserControl Chatting
        {
            get
            {
                return _chatting;
            }

            set
            {
                _chatting = value;
            }
        }
        public UserControl More
        {
            get
            {
                return _more;
            }

            set
            {
                _more = value;
            }
        }

        private static MainWindowEntity instance;

        public static MainWindowEntity GetInstance()
        {
            if (instance == null)
                instance = new MainWindowEntity();
            return instance;
        }
    }
}
