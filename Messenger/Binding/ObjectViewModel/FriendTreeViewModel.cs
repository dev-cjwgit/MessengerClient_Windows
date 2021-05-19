using GalaSoft.MvvmLight;
using ProgramCore.Entity;
using ProgramCore.ObjectModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Binding.ObjectViewModel
{
	public class Family
	{
		public Family()
		{
			this.List = new ObservableCollection<FamilyMember> ();
		}

		public string Title { get; set; }

		public ObservableCollection<FamilyMember> List { get; set; }
	}

	public class FamilyMember
	{
		public string NickName { get; set; }

		public string Introduce { get; set; }
	}
}
