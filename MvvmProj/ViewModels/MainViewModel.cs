using MvvmProj.Commands;
using MvvmProj.Models;
using MvvmProj.Repositories;
using MvvmProj.Views;
using MvvmProj.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MvvmProj.ViewModels
{
    public class MainViewModel:BaseViewModel
    {
        private ObservableCollection<Printer> allPrinters;

        public ObservableCollection<Printer> AllPrinters
        {
            get { return allPrinters; }
            set { allPrinters = value;  OnPropertyChanged(); }
        }

        private Printer selectedItem;

        public Printer SelectedPrinter
        {
            get { return selectedItem; }
            set { selectedItem = value; OnPropertyChanged(); }
        }

        public RelayCommand EditCommand { get; set; }
        public RelayCommand AddUserControlsCommand { get; set; }

        public MainViewModel()
        {
            AllPrinters= new ObservableCollection<Printer>(FakeRepo.GetPrinters());

            EditCommand = new RelayCommand((o) =>
            {
                var vm = new EditViewModel();
                vm.SelectedPrinter = SelectedPrinter;

                EditWindow window = new EditWindow();
                window.DataContext = vm;

                window.ShowDialog();
                AllPrinters = new ObservableCollection<Printer>(FakeRepo.GetPrinters());
            });


            AddUserControlsCommand = new RelayCommand((o) =>
            {
                var panel = o as WrapPanel;
                foreach (var p in FakeRepo.Printers)
                {
                    var vm = new SpecialUCViewModel();
                    vm.PrinterModel = p.Model;
                    var uc = new SpecialUC();
                    uc.DataContext = vm;

                    panel.Children.Add(uc);

                }
            });
        }
    }
}
