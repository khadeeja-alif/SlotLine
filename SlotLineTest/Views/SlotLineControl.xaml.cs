using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using SlotLineTest.Models;
using Xamarin.Forms;

namespace SlotLineTest.Views
{
    public partial class SlotLineControl : ContentView
    {
        public SlotLineControl()
        {
            InitializeComponent();
            slotList.ItemSelected += (sender, e) =>
            {
                slotList.SelectedItem = null;
            };
        }

        //public static BindableProperty ItemsSourceProperty =
            //BindableProperty.Create<SlotLineControl, ObservableCollection<Slot>>(y => y.ItemsSource,
                                                                                 //default(ObservableCollection<Slot>),BindingMode.OneWay,null);

        public static BindableProperty ItemsSourceProperty =
          BindableProperty.Create(
              nameof(ItemsSource),
              typeof(ObservableCollection<Slot>),
              typeof(SlotLineControl),
              default(ObservableCollection<Slot>),
              BindingMode.OneWay
          );

        public ObservableCollection<Slot> ItemsSource
        {
            get => (ObservableCollection<Slot>)GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }

        public static BindableProperty SlotSelectedProperty =
            BindableProperty.Create(
                nameof(SlotSelected),
                typeof(Slot),
                typeof(SlotLineControl),
                default(Slot),
                BindingMode.TwoWay
            );

        public Slot SlotSelected
        {
            get => (Slot)GetValue(SlotSelectedProperty);
            set => SetValue(SlotSelectedProperty, value);
        }
    }
}
