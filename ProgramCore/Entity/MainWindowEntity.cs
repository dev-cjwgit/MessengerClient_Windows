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
        public UserControl Friend { get; set; }
        public UserControl Chatting { get; set; }
        public UserControl More { get; set; }

        private static MainWindowEntity instance;

        public static MainWindowEntity GetInstance()
        {
            if (instance == null)
                instance = new MainWindowEntity();
            return instance;
        }
    }
}
