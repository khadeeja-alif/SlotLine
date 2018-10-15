using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using SlotLineTest.Models;
using Xamarin.Forms;

namespace SlotLineTest.ViewModels
{
    public class BookingPageViewModel : ViewModelBase
    {
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
        public ObservableCollection<Slot> Slots { get; set; }
        public TimeSpan Duration { get; set; }
        public int SlotCount { get; set; }
        public int LastSlotIndex { get; set; }
        IPageDialogService _dialog;
        public BookingPageViewModel(INavigationService navigationService,IPageDialogService dialog)
            : base(navigationService)
        {
            _dialog = dialog;
            Slots = new ObservableCollection<Slot>();
            Start = new TimeSpan(0, 0, 0);
            End = new TimeSpan(24, 0, 0);
            CreateSlots(Start, End);

            Duration = new TimeSpan(1, 30, 0);
            SlotCount = (int)(Duration.Hours * 2 + (Duration.Minutes/30));
            Slots[4].SlotStatus = Models.SlotStatus.Unavailable.ToString();
            Slots[5].SlotStatus = Models.SlotStatus.Unavailable.ToString();
            Slots[15].SlotStatus = Models.SlotStatus.Unavailable.ToString();
            Slots[20].SlotStatus = Models.SlotStatus.Booking.ToString();
            RaisePropertyChanged("Slots");
            var lastSt = Slots.LastOrDefault();
            LastSlotIndex = Slots.IndexOf(lastSt);
        }

        public void CreateSlots(TimeSpan start,TimeSpan end)
        {
            var Diff = end - start;
            var count = (int)Diff.TotalHours * 2;
            TimeSpan ts = new TimeSpan(0, 30, 0);
            TimeSpan slotTime = start;
            for (int i = 0; i <= count; i++)
            {
                if (i > 0)
                {
                    slotTime = slotTime.Add(ts);
                }
                if (i == count)
                    Slots.Add(new Slot { SlotNo = i + 1, Time = slotTime, ShowBox = false, SlotStatus = Models.SlotStatus.Available.ToString() });
                else
                    Slots.Add(new Slot { SlotNo = i + 1, Time = slotTime, ShowBox = true, SlotStatus = Models.SlotStatus.Available.ToString() });
            }
        }

        public Slot lastSlot { get; set; }

        private Slot slotSelected { get; set; }
        public Slot SlotSelected
        {
            get { return slotSelected; }
            set
            {
                if (value != null)
                {
                    slotSelected = value;
                    if (lastSlot == null || lastSlot != slotSelected)
                    {
                        if (slotSelected.SlotStatus == Models.SlotStatus.Available.ToString() || slotSelected.SlotStatus == Models.SlotStatus.Selected.ToString())
                        {
                            ClearSlots();
                            SelectSlots();
                        }
                        lastSlot = value;
                    }
                    else if(lastSlot !=null && lastSlot == slotSelected)
                    {
                        if (slotSelected.SlotStatus == Models.SlotStatus.Selected.ToString())
                        {
                            ClearSlots();
                        }
                        else if (slotSelected.SlotStatus == Models.SlotStatus.Available.ToString())
                        {
                            SelectSlots();
                        }
                    }
                    RaisePropertyChanged("Slots");
                }
            }
        }

        public void ClearSlots()
        {
            foreach (var s in Slots)
            {
                if (s.SlotStatus == Models.SlotStatus.Selected.ToString())
                    s.SlotStatus = Models.SlotStatus.Available.ToString();
            }
            RaisePropertyChanged("Slots");
        }

        public void SelectSlots()
        {
            var flag = 0;
            var slot = Slots.Where(x => x.SlotNo == slotSelected.SlotNo).FirstOrDefault();
            var index = Slots.IndexOf(slot);
            var lastIndex = index + SlotCount;
            if (lastIndex <= LastSlotIndex)
            {
                for (int i = index; i < lastIndex; i++)
                {
                    if (Slots[i].SlotStatus != Models.SlotStatus.Available.ToString())
                        flag = 1;
                }
                if (flag == 0)
                {
                    for (int i = index; i < lastIndex; i++)
                    {
                        Slots[i].SlotStatus = Models.SlotStatus.Selected.ToString();
                    }
                }
                else
                {
                    _dialog.DisplayAlertAsync("Error", "No Continuos Slot available", "ok");
                }
            }
            else
            {
                _dialog.DisplayAlertAsync("Error", "No Continuos Slot available", "ok");
            }
        }

        //private bool isBusy;
        //public bool IsBusy
        //{
        //    get { return isBusy; }
        //    set { SetProperty(ref isBusy, value); }
        //}
    }
}
