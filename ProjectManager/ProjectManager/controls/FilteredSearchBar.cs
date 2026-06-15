using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Controls
{
    public class FilteredSearchBar : SearchBar
    {
        public static BindableProperty ItemsSourceProperty = 
            BindableProperty.Create(
                nameof(ItemsSource), 
                typeof(IEnumerable), 
                typeof(FilteredSearchBar), propertyChanged: OnItemsSourceChanged);
        
        public IEnumerable ItemsSource 
        { 
            get => (IEnumerable)GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }

        public static BindableProperty FilterProperty = 
            BindableProperty.Create(
                nameof(Filter),
                typeof(string),
                typeof(FilteredSearchBar), defaultValue: "");

        public string Filter 
        { 
            get => (string)GetValue(FilterProperty);
            set => SetValue(FilterProperty, value);
        }

        public static BindableProperty FilteredItemsProperty = 
            BindableProperty.Create(
                nameof(FilteredItems),
                typeof(ObservableCollection<object>),
                typeof(FilteredSearchBar));

        public ObservableCollection<object> FilteredItems 
        { 
            get => (ObservableCollection<object>)GetValue(FilteredItemsProperty);
            set => SetValue(FilteredItemsProperty, value);
        }

        public static void OnItemsSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is FilteredSearchBar searchBar)
            {
            }
        }
    }
}
