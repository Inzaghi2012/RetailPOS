using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using RetailPOS.ViewModel;

namespace RetailPOS.Utility
{
    public class AutoCompleteBoxEx : AutoCompleteBox
    {
        public static readonly DependencyProperty SelectionBoxItemProperty =
    DependencyProperty.Register(
    "SelectionBoxItem",
    typeof(object),
    typeof(AutoCompleteBox),
    new PropertyMetadata(OnSelectionBoxItemPropertyChanged));

        public object SelectionBoxItem
        {
            get
            {
                return GetValue(SelectionBoxItemProperty);
            }

            set
            {
                SetValue(SelectionBoxItemProperty, value);
            }
        }

        protected override void OnDropDownClosing(RoutedPropertyChangingEventArgs<bool> e)
        {
            base.OnDropDownClosing(e);
            SelectionBoxItem = SelectionAdapter.SelectedItem;
        }

        private static void OnSelectionBoxItemPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
        }
    }
}