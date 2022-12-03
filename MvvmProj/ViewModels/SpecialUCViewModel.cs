using MvvmProj.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MvvmProj.ViewModels
{
    public class SpecialUCViewModel:BaseViewModel
    {
		private string printerModel;

		public string PrinterModel
		{
			get { return printerModel; }
			set { printerModel = value; OnPropertyChanged(); }
		}


		public RelayCommand SelectUCCommand { get; set; }

		public SpecialUCViewModel()
		{
			SelectUCCommand = new RelayCommand((o) =>
			{
				MessageBox.Show(PrinterModel);
			});
		}
	}
}
