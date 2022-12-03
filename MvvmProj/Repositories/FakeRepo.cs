using MvvmProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmProj.Repositories
{
    public class FakeRepo
    {
        public static List<Printer> Printers { get; set; } = new List<Printer>
        {
            new Printer
                {
                     Id=1,
                      Color="Red",
                       Model="C-200",
                        Vendor="HP"
                },
                new Printer
                {
                     Id=2,
                      Color="Green",
                       Model="Epsun",
                        Vendor="HP"
                },
                new Printer
                {
                     Id=3,
                      Color="White",
                       Model="RR-200",
                        Vendor="Acer"
                },
                new Printer
                {
                     Id=4,
                      Color="Black",
                       Model="S-600",
                        Vendor="Samsung"
                },
        };
        public static List<Printer> GetPrinters()
        {
            return Printers;
        }
    }
}
