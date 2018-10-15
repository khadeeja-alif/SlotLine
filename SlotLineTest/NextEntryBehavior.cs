using System;
using Xamarin.Forms;

namespace SlotLineTest
{
    public class NextEntryBehavior : Behavior<MaterialEntry>
    {
        public static readonly BindableProperty NextEntryProperty = BindableProperty.Create(nameof(NextEntry), typeof(MaterialEntry), typeof(MaterialEntry), defaultBindingMode: BindingMode.TwoWay);

        public MaterialEntry NextEntry
        {
            get => (MaterialEntry)GetValue(NextEntryProperty);
            set => SetValue(NextEntryProperty, value);
        }

        protected override void OnAttachedTo(MaterialEntry bindable)
        {
            bindable.materialEntry.Completed += OnEntryTextChanged;
            bindable.EntryUnfocused += Bindable_EntryUnfocused;
            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(MaterialEntry bindable)
        {
            bindable.materialEntry.Completed -= OnEntryTextChanged;
            bindable.EntryUnfocused -= Bindable_EntryUnfocused;
            base.OnDetachingFrom(bindable);
        }

        void Bindable_EntryUnfocused(object sender, FocusEventArgs e)
        {
            var entry = (MaterialEntry)sender;

            if (string.IsNullOrWhiteSpace(entry.Text))
            {
                entry.IsValid = false;
            }
            else
            {
                entry.IsValid = true;
            }
        }

        void OnEntryTextChanged(object sender, EventArgs e)
        {
            if (NextEntry != null)
            {
                NextEntry.materialEntry.Focus();
            }
        }
    }
}
