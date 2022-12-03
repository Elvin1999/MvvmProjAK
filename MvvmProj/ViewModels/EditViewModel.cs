using MvvmProj.Commands;
using MvvmProj.Models;
using MvvmProj.Repositories;
using MvvmProj.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmProj.ViewModels
{
    public class EditViewModel:BaseViewModel
    {
		private Printer selectedPrinter;

		public Printer SelectedPrinter
        {
			get { return selectedPrinter; }
			set { selectedPrinter = value; OnPropertyChanged(); }
		}

		public RelayCommand SaveCommand { get; set; }
		public RelayCommand AddCommand { get; set; }

		public Printer AddedPrinter { get; set; }

		public EditViewModel()
		{
			SaveCommand = new RelayCommand((o) =>
			{
				var window = o as EditWindow;
				window.Close();
			});

			AddCommand = new RelayCommand((o) =>
			{
				AddedPrinter = new Printer
				{
					Id = selectedPrinter.Id,
					Color = selectedPrinter.Color,
					Model = selectedPrinter.Model,
					Vendor = selectedPrinter.Vendor,
				};
                FakeRepo fakeRepo = new FakeRepo();
				fakeRepo.Printers.Add(AddedPrinter);
				fakeRepo.SaveChanges();

                var window = o as EditWindow;
                window.Close();
            });
		}
	}
}