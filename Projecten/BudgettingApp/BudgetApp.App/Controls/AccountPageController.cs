using System.ComponentModel;
using BudgetApp.App.Localization;
using BudgetApp.App.Services;
using BudgetApp.Domain.Entities;
using CommunityToolkit.Mvvm.Input;

namespace BudgetApp.App.Controls;

// The page owns this controller. Only visible pages handle selection changes.
public sealed class AccountPageController
{
    private readonly ActiveAccountState _active;
    private readonly IAsyncRelayCommand _load;
    private readonly INotifyPropertyChanged _viewModel;
    private readonly Func<bool> _isBusy;
    private readonly Picker _picker;
    private readonly View _body;
    private readonly Label _error;
    private bool _visible;
    private bool _syncing;
    private bool _loading;

    public AccountPageController(ContentPage page, ActiveAccountState active,
        INotifyPropertyChanged viewModel, IAsyncRelayCommand load, Func<bool> isBusy)
    {
        _active = active;
        _viewModel = viewModel;
        _load = load;
        _isBusy = isBusy;
        _body = page.Content;
        _picker = new Picker { Title = L.Get("SelectAccountFirst"), MinimumHeightRequest = 48,
            ItemDisplayBinding = new Binding(nameof(Account.Name)) };
        _picker.SelectedIndexChanged += OnSelectionChanged;
        _error = new Label { IsVisible = false };
        var header = new VerticalStackLayout { Spacing = 4, Padding = new Thickness(20, 12),
            MaximumWidthRequest = 760, HorizontalOptions = LayoutOptions.Fill };
        header.Add(new Label { Text = L.Get("ActiveAccount"), FontAttributes = FontAttributes.Bold });
        header.Add(_picker);
        header.Add(_error);
        var layout = new Grid { RowDefinitions = { new RowDefinition(GridLength.Auto), new RowDefinition(GridLength.Star) } };
        page.Content = null;
        layout.Add(header);
        layout.Add(_body, 0, 1);
        page.Content = layout;
    }

    public async Task AppearAsync()
    {
        _visible = true;
        _active.Changed -= OnActiveChanged;
        _active.Changed += OnActiveChanged;
        _viewModel.PropertyChanged -= OnViewModelChanged;
        _viewModel.PropertyChanged += OnViewModelChanged;
        await ReloadAsync();
    }

    public void Disappear()
    {
        _visible = false;
        _active.Changed -= OnActiveChanged;
        _viewModel.PropertyChanged -= OnViewModelChanged;
    }

    private void OnViewModelChanged(object? sender, PropertyChangedEventArgs e)
        => _picker.IsEnabled = !_loading && !_isBusy();

    private void OnActiveChanged(object? sender, EventArgs e)
    {
        _syncing = true;
        try
        {
            _picker.ItemsSource = _active.Accounts.ToList();
            _picker.SelectedItem = _active.Current;
        }
        finally { _syncing = false; }
    }

    private async void OnSelectionChanged(object? sender, EventArgs e)
    {
        if (!_visible || _syncing || _loading || _isBusy() || _picker.SelectedItem is not Account account) return;
        if (account.Id == _active.Id) return;
        _active.Select(account);
        await ReloadAsync();
    }

    private async Task ReloadAsync()
    {
        if (_loading) return;
        _loading = true;
        _picker.IsEnabled = false;
        _body.IsVisible = false;
        _error.IsVisible = false;
        try
        {
            await _active.RefreshAsync();
            _syncing = true;
            try
            {
                _picker.ItemsSource = _active.Accounts.ToList();
                _picker.SelectedItem = _active.Current;
            }
            finally { _syncing = false; }
            if (_load.IsRunning && _load.ExecutionTask is { } pending) await pending;
            await _load.ExecuteAsync(null);
            _body.IsVisible = true;
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex);
            _error.Text = L.T("De actie is mislukt. Probeer opnieuw.");
            _error.IsVisible = true;
        }
        finally
        {
            _loading = false;
            _picker.IsEnabled = !_isBusy();
        }
    }
}
