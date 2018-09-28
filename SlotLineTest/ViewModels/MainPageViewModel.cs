using DataSlotLine;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SlotLineTest.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public List<Class1> MyData { get; set; }
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";
        }
    }
}
