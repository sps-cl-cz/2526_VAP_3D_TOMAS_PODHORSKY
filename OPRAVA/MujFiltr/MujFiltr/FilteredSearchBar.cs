using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace MujFiltr;

public class FilteredSearchBar : SearchBar
{
    public static BindableProperty ItemsSourceProperty =
        BindableProperty.Create(
            nameof(ItemsSource),
            typeof(IEnumerable),
            typeof(FilteredSearchBar),
            propertyChanged: OnItemsSourceChanged);

    public IEnumerable ItemsSource
    {
        get => (IEnumerable)GetValue(ItemsSourceProperty);
        set => SetValue(ItemsSourceProperty, value);
    }

    public static BindableProperty FilterProperty =
        BindableProperty.Create(
            nameof(Filter),
            typeof(string),
            typeof(FilteredSearchBar),
            defaultValue: "");

    public string Filter
    {
        get => (string)GetValue(FilterProperty);
        set => SetValue(FilterProperty, value);
    }

    public static BindableProperty FilteredItemsProperty =
        BindableProperty.Create(
            nameof(FilteredItems),
            typeof(ObservableCollection<object>),
            typeof(FilteredSearchBar),
            defaultValue: null);

    public ObservableCollection<object> FilteredItems
    {
        get => (ObservableCollection<object>)GetValue(FilteredItemsProperty);
        set => SetValue(FilteredItemsProperty, value);
    }

    public static void OnItemsSourceChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is FilteredSearchBar searchBar)
        {
            if (oldValue is INotifyCollectionChanged oldCollection)
            {
                oldCollection.CollectionChanged -= searchBar.CollectionChanged;
            }
            if (newValue is INotifyCollectionChanged newCollection)
            {
                newCollection.CollectionChanged += searchBar.CollectionChanged;
            }
            searchBar.ApplyFilter();
        }
    }

    public FilteredSearchBar()
    {
        SetValue(FilteredItemsProperty, new ObservableCollection<object>());

        SearchButtonPressed += (sender, e) => ApplyFilter();
        TextChanged += (sender, e) => ApplyFilter();
    }

    private void CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        ApplyFilter();
    }

    void ApplyFilter()
    {
        FilteredItems.Clear();
        if (ItemsSource == null) return;

        foreach (var item in ItemsSource)
        {
            string itemString;

            if (!string.IsNullOrEmpty(Filter))
            {
                itemString = item?.GetType()
                    ?.GetProperty(Filter)
                    ?.GetValue(item)
                    ?.ToString()
                    ?? item?.ToString()
                    ?? "";
            }
            else
            {
                itemString = item?.ToString() ?? "";
            }

            if (itemString.ToLower().Contains(Text?.ToLower() ?? ""))
            {
                FilteredItems.Add(item);
            }
        }
    }
}