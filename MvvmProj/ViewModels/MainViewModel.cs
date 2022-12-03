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

        public FakeRepo FakeRepo { get; set; }

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
            FakeRepo=new FakeRepo();

            if (FakeRepo.Printers.Count() == 0)
            {
                FakeRepo.Printers.AddRange(new List<Printer>{new Printer
                {
                    Id = 1,
                    Color = "Red",
                    Model = "C-200",
                    Vendor = "HP"
                },
                new Printer
                {
                    Id = 2,
                    Color = "Green",
                    Model = "Epsun",
                    Vendor = "HP"
                },
                new Printer
                {
                    Id = 3,
                    Color = "White",
                    Model = "RR-200",
                    Vendor = "Acer"
                },
                new Printer
                {
                    Id = 4,
                    Color = "Black",
                    Model = "S-600",
                    Vendor = "Samsung"
                }}
                );
                FakeRepo.SaveChanges();
            }


            AllPrinters = new ObservableCollection<Printer>(FakeRepo.Printers);

            EditCommand = new RelayCommand((o) =>
            {
                var vm = new EditViewModel();
                vm.SelectedPrinter = SelectedPrinter;

                EditWindow window = new EditWindow();
                window.DataContext = vm;

                window.ShowDialog();
                AllPrinters = new ObservableCollection<Printer>(FakeRepo.Printers);
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
