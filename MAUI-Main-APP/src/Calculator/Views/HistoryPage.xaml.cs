using Calculator.Data;
using Calculator.Models;
using System.Collections.ObjectModel;

namespace Calculator.Views;

public partial class HistoryPage : ContentPage
{
    HistoryDatabase database;
    public ObservableCollection<HistoryItem> Items { get; set; } = new();
    public HistoryPage(HistoryDatabase historyDatabase)
    {
        InitializeComponent();
        database = historyDatabase;
        BindingContext = this;
        refreshData();
    }

    public async void refreshData()
    {
        List<HistoryItem> Items = await database.GetItemsAsync();
        historyList.ItemsSource = Items;
    }

    async void OnDeleteClicked(object sender, EventArgs e)
    {
        await database.DeleteAllItems();
        refreshData();
    }
}