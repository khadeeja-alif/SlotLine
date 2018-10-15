using System;
using Prism.Mvvm;
using Xamarin.Forms;

namespace SlotLineTest.Models
{
    public class Slot : BindableBase
    {
        public TimeSpan Time { get; set; }
        public int SlotNo { get; set; }
        public bool ShowBox { get; set; }
        private string slotTime { get; set; }
        public string SlotTime
        {
            get
            {
                var date = DateTime.Now.Date;
                date = date.Add(Time);
                var time = date.ToString("hh:mm tt");
                return time;
            }
        }

        public bool NotHalfTime
        {
            get
            {
                if (SlotTime.Contains("30"))
                    return false;
                else
                    return true;
            }
        }

        public string slotStatus;

        public string SlotStatus
        {
            get { return slotStatus; }
            set
            {
                SetProperty(ref slotStatus, value);
                if (SlotStatus == Models.SlotStatus.Unavailable.ToString())
                    SlotColor =  Color.FromHex("#ACACAC");
                else if (SlotStatus == Models.SlotStatus.Blocked.ToString())
                    SlotColor = Color.FromHex("#ACACAC");
                else if (SlotStatus == Models.SlotStatus.Booked.ToString())
                    SlotColor = Color.FromHex("#ACACAC");
                else if (SlotStatus == Models.SlotStatus.Booking.ToString())
                    SlotColor = Color.FromHex("#FFD38D");
                else if (SlotStatus == Models.SlotStatus.Selected.ToString())
                    SlotColor = Color.FromHex("#32BEA6");
                else
                    SlotColor = Color.White;

                RaisePropertyChanged("SlotStatus");
                RaisePropertyChanged("SlotColor");
            }
        }


        public Color SlotColor { get; set; }
    }

    public enum SlotStatus
    {
        Booking,
        Booked,
        Blocked,
        Unavailable,
        Available,
        Selected
    }
}

