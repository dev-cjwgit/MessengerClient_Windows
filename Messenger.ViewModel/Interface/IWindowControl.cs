using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.ViewModel.Interface
{
    public interface IWindowControl
    {
        Action Close { get; set; }
        Action Open { get; set; }
    }
}
