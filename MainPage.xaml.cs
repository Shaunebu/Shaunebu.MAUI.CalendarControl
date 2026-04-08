namespace Shaunebu.MAUI.CalendarControl.Demo;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        SetupSpecialDates();
    }

    private void SetupSpecialDates()
    {
        // Holiday
        DemoCalendar.SpecialDates.Add(new CalendarSpecialDate
        {
            Date = new DateTime(DateTime.Today.Year, 12, 25),
            Background = Colors.Red,
            TextColor = Colors.White,
            IndicatorColor = Colors.Gold
        });

        // New Year
        DemoCalendar.SpecialDates.Add(new CalendarSpecialDate
        {
            Date = new DateTime(DateTime.Today.Year, 1, 1),
            IndicatorColor = Colors.Green
        });

        // Blackout a date
        DemoCalendar.BlackoutDates.Add(DateTime.Today.AddDays(3));
    }

    private void OnSelectionChanged(object? sender, DateSelectionChangedEventArgs e)
    {
        if (e.NewDate.HasValue)
            StatusLabel.Text = $"Selected: {e.NewDate.Value:D}";
        else if (e.AddedDates is { Count: > 0 })
            StatusLabel.Text = $"Added {e.AddedDates.Count} date(s) | Total: {DemoCalendar.SelectedDates.Count}";
        else if (e.RemovedDates is { Count: > 0 })
            StatusLabel.Text = $"Removed {e.RemovedDates.Count} date(s) | Total: {DemoCalendar.SelectedDates.Count}";
        else if (e.NewRange is { StartDate: not null, EndDate: not null })
            StatusLabel.Text = $"Range: {e.NewRange.StartDate.Value:d} - {e.NewRange.EndDate.Value:d}";
    }

    private void OnViewChanged(object? sender, CalendarViewChangedEventArgs e)
    {
        StatusLabel.Text = $"View: {e.OldView} -> {e.NewView}";
    }

    private void OnDisplayDateChanged(object? sender, DisplayDateChangedEventArgs e)
    {
        StatusLabel.Text = $"Navigated to {e.NewDate:MMMM yyyy}";
    }

    private void OnSelectionModeChanged(object? sender, EventArgs e)
    {
        if (SelectionModePicker.SelectedIndex < 0) return;
        DemoCalendar.SelectionMode = (CalendarSelectionMode)SelectionModePicker.SelectedIndex;
        StatusLabel.Text = $"Mode: {DemoCalendar.SelectionMode}";
    }

    private void OnGoToTodayClicked(object? sender, EventArgs e)
    {
        DemoCalendar.GoToToday();
    }

    private void OnResetClicked(object? sender, EventArgs e)
    {
        DemoCalendar.ResetSelection();
        StatusLabel.Text = "Selection cleared";
    }
}