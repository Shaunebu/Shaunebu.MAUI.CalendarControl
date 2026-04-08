# Shaunebu.MAUI.CalendarControl 📅

[![Platform](https://img.shields.io/badge/Platform-.NET%209%20%7C%20.NET%2010-blue?logo=dotnet)](https://dotnet.microsoft.com/)
[![MAUI](https://img.shields.io/badge/.NET%20MAUI-Mobile%20%7C%20Desktop-512BD4?logo=dotnet)](https://learn.microsoft.com/dotnet/maui/)
[![License](https://img.shields.io/badge/License-MIT-lightgrey?logo=opensourceinitiative)](LICENSE)
[![Status](https://img.shields.io/badge/Status-Enterprise%20Ready-brightgreen)]()

[![NuGet Version](https://img.shields.io/nuget/v/Shaunebu.MAUI.CalendarControl?color=blue&label=NuGet)](https://www.nuget.org/packages/Shaunebu.MAUI.CalendarControl)

[![Android](https://img.shields.io/badge/Android-Supported-green?logo=android)]()
[![iOS](https://img.shields.io/badge/iOS-Supported-black?logo=apple)]()
[![macOS](https://img.shields.io/badge/macOS-Mac%20Catalyst-purple?logo=apple)]()
[![Windows](https://img.shields.io/badge/Windows-WinUI%203-0078D4?logo=windows)]()

[![Support](https://img.shields.io/badge/support-buy%20me%20a%20coffee-FFDD00)](https://buymeacoffee.com/jcz65te)

## Overview ✨

`Shaunebu.MAUI.CalendarControl` is a professional-grade, fully customizable calendar control for .NET MAUI with:

- **4 view modes** — Month, Year, Decade, and Century with drill-up/drill-down navigation
- **4 selection modes** — None, Single, Multiple, and Range
- **50+ bindable properties** — Full theming, styling, and behavioral customization
- **Full MVVM support** — Commands for navigation, selection, view changes, and display date changes
- **Special dates** — Custom backgrounds, text colors, indicator dots, and blackout dates
- **Swipe navigation** — Left/right swipe gestures for month/year/decade/century navigation
- **Culture-aware** — Localized month names, day names, and week numbering
- **Accessibility** — `AutomationProperties` on all day cells with descriptive labels
- **Cross-platform** — Android, iOS, macOS (Mac Catalyst), and Windows

## Feature Highlights 🆚

| Feature | Description |
|---|---|
| **Month View** | 6-row × 7-column day grid with optional week numbers and leading/trailing dates |
| **Year View** | 3×4 grid of abbreviated month names with selection highlighting |
| **Decade View** | 3×4 grid of 12 years (1 leading + 10 in-decade + 1 trailing) |
| **Century View** | 3×4 grid of decade ranges with drill-down navigation |
| **Single Selection** | Tap to select a single date; auto-navigates to tapped month |
| **Multiple Selection** | Toggle dates on/off; `ObservableCollection<DateTime>` backed |
| **Range Selection** | Two-tap range selection with visual range band |
| **Blackout Dates** | Dates rendered with strikethrough and disabled interaction |
| **Special Dates** | Per-date custom background, text color, indicator dot, and blackout flag |
| **Min/Max Date** | Constrains navigation and disables out-of-range dates |
| **Culture Support** | Fully localized via `CultureInfo` — month names, day names, week numbers |
| **Header Date Format** | Customizable header format string (e.g., `"MMM yyyy"`) |
| **Day Name Format** | Full (`Monday`), Abbreviated (`Mon`), or Shortest (`Mo`) |
| **Swipe Navigation** | Left/right swipe gestures on the body grid |
| **Today Button** | Optional "Today" button for quick navigation to the current date |
| **View Navigation** | Drill-up (header tap) and drill-down (cell tap) between view levels |
| **MVVM Commands** | `ForwardCommand`, `BackwardCommand`, `GoToTodayCommand`, `ResetSelectionCommand` |
| **Events + Commands** | `SelectionChanged`, `ViewChanged`, `DisplayDateChanged` with both events and bindable commands |
| **Accessibility** | `AutomationProperties.Name` and `HelpText` on every day cell |

## Installation 📦

```
dotnet add package Shaunebu.MAUI.CalendarControl
```

Or via `PackageReference`:

```xml
<ItemGroup>
  <PackageReference Include="Shaunebu.MAUI.CalendarControl" Version="1.0.6" />
</ItemGroup>
```

## Quick Start 🚀

### 1. Configure in `MauiProgram.cs`

```csharp
using Shaunebu.MAUI.CalendarControl;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        builder
            .UseMauiApp<App>()
            .UseShaunebuCalendar();

        return builder.Build();
    }
}
```

### 2. Add to XAML

```xml
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:cal="clr-namespace:Shaunebu.MAUI.CalendarControl;assembly=Shaunebu.MAUI.CalendarControl"
             x:Class="MyApp.MainPage">

    <cal:CalendarView
        SelectionMode="Single"
        ShowWeekNumbers="True"
        ShowTodayButton="True"
        FirstDayOfWeek="Monday"
        SelectionChanged="OnSelectionChanged" />

</ContentPage>
```

### 3. Handle Selection in Code-Behind

```csharp
private void OnSelectionChanged(object sender, DateSelectionChangedEventArgs e)
{
    if (e.NewDate.HasValue)
    {
        DisplayAlert("Selected", e.NewDate.Value.ToShortDateString(), "OK");
    }
}
```

## XAML Configuration Examples 🎨

### Basic Calendar with Theming

```xml
<cal:CalendarView
    SelectionMode="Single"
    ShowWeekNumbers="True"
    ShowTodayButton="True"
    ShowNavigationArrows="True"
    FirstDayOfWeek="Monday"
    DayNameFormat="Abbreviated"
    HeaderBackground="#1976D2"
    HeaderTextColor="White"
    HeaderFontSize="20"
    DayTextColor="#333333"
    DayFontSize="14"
    TodayTextColor="#1976D2"
    TodayBorderColor="#1976D2"
    TodayBackground="Transparent"
    SelectionBackground="#1976D2"
    SelectionTextColor="White"
    WeekendTextColor="#999999"
    DayNamesTextColor="#888888"
    NavigationArrowColor="White"
    CellCornerRadius="20" />
```

### Multiple Selection Mode

```xml
<cal:CalendarView
    x:Name="MultiCalendar"
    SelectionMode="Multiple"
    ShowLeadingAndTrailingDates="True" />
```

```csharp
// Access selected dates
var dates = MultiCalendar.SelectedDates; // ObservableCollection<DateTime>
```

### Range Selection Mode

```xml
<cal:CalendarView
    x:Name="RangeCalendar"
    SelectionMode="Range"
    RangeSelectionBackground="#331976D2" />
```

```csharp
// Access selected range
var range = RangeCalendar.SelectedDateRange; // CalendarDateRange
if (range?.StartDate != null && range?.EndDate != null)
{
    // Use range.Contains(someDate) to check membership
}
```

### Min/Max Date Constraints

```xml
<cal:CalendarView
    MinDate="{Binding MinimumDate}"
    MaxDate="{Binding MaximumDate}" />
```

### Localized Calendar

```xml
<cal:CalendarView
    Culture="{Binding SelectedCulture}"
    HeaderDateFormat="MMMM yyyy"
    DayNameFormat="Shortest" />
```

## MVVM Integration 🏗

### Binding to Commands

```xml
<cal:CalendarView
    SelectionMode="Single"
    SelectedDate="{Binding SelectedDate, Mode=TwoWay}"
    DisplayDate="{Binding DisplayDate, Mode=TwoWay}"
    SelectionChangedCommand="{Binding DateSelectedCommand}"
    DisplayDateChangedCommand="{Binding MonthNavigatedCommand}"
    ViewChangedCommand="{Binding ViewDrilledCommand}"
    ForwardCommand="{Binding GoForwardCommand}"
    BackwardCommand="{Binding GoBackwardCommand}"
    GoToTodayCommand="{Binding NavigateToTodayCommand}"
    ResetSelectionCommand="{Binding ClearSelectionCommand}" />
```

### ViewModel Example

```csharp
public partial class CalendarViewModel : ObservableObject
{
    [ObservableProperty]
    private DateTime? selectedDate = DateTime.Today;

    [ObservableProperty]
    private DateTime displayDate = new(DateTime.Today.Year, DateTime.Today.Month, 1);

    [RelayCommand]
    private void DateSelected(DateSelectionChangedEventArgs e)
    {
        if (e.NewDate.HasValue)
        {
            // Handle date selection
            Debug.WriteLine($"Selected: {e.NewDate.Value:d}");
        }
    }

    [RelayCommand]
    private void MonthNavigated(DisplayDateChangedEventArgs e)
    {
        Debug.WriteLine($"Navigated from {e.OldDate:MMMM yyyy} to {e.NewDate:MMMM yyyy}");
    }
}
```

## Special Dates & Blackout Dates 📌

### Configure Special Dates

```csharp
var calendar = new CalendarView();

// Add special dates with custom styling
calendar.SpecialDates.Add(new CalendarSpecialDate
{
    Date = new DateTime(2025, 12, 25),
    Background = Colors.Red,
    TextColor = Colors.White,
    IndicatorColor = Colors.Gold
});

// Add a blackout date via special dates
calendar.SpecialDates.Add(new CalendarSpecialDate
{
    Date = new DateTime(2025, 1, 1),
    IsBlackout = true
});

// Add blackout dates directly
calendar.BlackoutDates.Add(new DateTime(2025, 7, 4));
calendar.BlackoutDates.Add(new DateTime(2025, 11, 27));
```

### Special Date Properties

| Property | Type | Description |
|---|---|---|
| `Date` | `DateTime` | The date to customize |
| `Background` | `Color?` | Custom background color for the cell |
| `TextColor` | `Color?` | Custom text color for the day number |
| `IndicatorColor` | `Color?` | Color of a small dot indicator beneath the day number |
| `IsBlackout` | `bool` | If `true`, the date is disabled with strikethrough styling |

## Public Methods 🔧

| Method | Description |
|---|---|
| `Forward()` | Navigate to the next month / year / decade / century |
| `Backward()` | Navigate to the previous month / year / decade / century |
| `GoToToday()` | Navigate to today's date and switch to Month view |
| `GoToDate(DateTime date)` | Navigate to show the specified date in Month view |
| `ResetSelection()` | Clear all selections across all modes |

## Bindable Properties Reference 📚

### Selection Properties

| Property | Type | Default | Description |
|---|---|---|---|
| `SelectedDate` | `DateTime?` | `DateTime.Today` | Selected date in Single mode |
| `SelectedDates` | `ObservableCollection<DateTime>` | Empty | Selected dates in Multiple mode |
| `SelectedDateRange` | `CalendarDateRange?` | `null` | Selected range in Range mode |
| `SelectionMode` | `CalendarSelectionMode` | `Single` | None, Single, Multiple, or Range |

### Display & Navigation Properties

| Property | Type | Default | Description |
|---|---|---|---|
| `DisplayDate` | `DateTime` | First of current month | Controls which month/year is displayed |
| `View` | `CalendarViewMode` | `Month` | Current view mode |
| `MinView` | `CalendarViewMode` | `Month` | Minimum drill-down level |
| `MaxView` | `CalendarViewMode` | `Century` | Maximum drill-up level |
| `MinDate` | `DateTime?` | `null` | Earliest navigable/selectable date |
| `MaxDate` | `DateTime?` | `null` | Latest navigable/selectable date |
| `FirstDayOfWeek` | `DayOfWeek` | Culture default | First day of the week |
| `AllowViewNavigation` | `bool` | `true` | Enable header tap drill-up and cell drill-down |

### Visibility Properties

| Property | Type | Default | Description |
|---|---|---|---|
| `ShowLeadingAndTrailingDates` | `bool` | `true` | Show dates from adjacent months |
| `ShowWeekNumbers` | `bool` | `false` | Show ISO week numbers column |
| `ShowTodayButton` | `bool` | `false` | Show "Today" button below calendar |
| `ShowNavigationArrows` | `bool` | `true` | Show forward/backward arrow buttons |

### Formatting Properties

| Property | Type | Default | Description |
|---|---|---|---|
| `Culture` | `CultureInfo` | `CurrentCulture` | Culture for localized formatting |
| `HeaderDateFormat` | `string?` | `null` (= `"MMMM yyyy"`) | Custom header date format string |
| `DayNameFormat` | `CalendarDayNameFormat` | `Abbreviated` | Day name display format |

### Styling Properties

| Property | Type | Default | Description |
|---|---|---|---|
| `HeaderBackground` | `Color` | `Transparent` | Header row background |
| `HeaderTextColor` | `Color` | `#333333` | Header label text color |
| `HeaderFontSize` | `double` | `18.0` | Header label font size |
| `DayTextColor` | `Color` | `#333333` | Default day number text color |
| `DayFontSize` | `double` | `14.0` | Day number font size |
| `TodayBackground` | `Color` | `Transparent` | Today cell background |
| `TodayTextColor` | `Color` | `#1976D2` | Today cell text color |
| `TodayBorderColor` | `Color` | `#1976D2` | Today cell border ring color |
| `SelectionBackground` | `Color` | `#1976D2` | Selected cell background |
| `SelectionTextColor` | `Color` | `White` | Selected cell text color |
| `RangeSelectionBackground` | `Color` | `#331976D2` | Range band background |
| `WeekendTextColor` | `Color` | `#999999` | Weekend day text color |
| `TrailingLeadingTextColor` | `Color` | `#CCCCCC` | Adjacent month day text color |
| `DisabledTextColor` | `Color` | `#DDDDDD` | Disabled/out-of-range text color |
| `DayNamesTextColor` | `Color` | `#888888` | Day-of-week header text color |
| `DayNamesFontSize` | `double` | `12.0` | Day-of-week header font size |
| `WeekNumberTextColor` | `Color` | `#AAAAAA` | Week number text color |
| `WeekNumberBackground` | `Color` | `Transparent` | Week number column background |
| `NavigationArrowColor` | `Color` | `#333333` | Navigation arrow button color |
| `CellCornerRadius` | `double` | `20` | Corner radius for selected/today cells |

### Command Properties (MVVM)

| Property | Type | Description |
|---|---|---|
| `SelectionChangedCommand` | `ICommand` | Invoked when selection changes |
| `SelectionChangedCommandParameter` | `object` | Parameter for `SelectionChangedCommand` |
| `ViewChangedCommand` | `ICommand` | Invoked when view mode changes |
| `ViewChangedCommandParameter` | `object` | Parameter for `ViewChangedCommand` |
| `DisplayDateChangedCommand` | `ICommand` | Invoked when display date changes |
| `DisplayDateChangedCommandParameter` | `object` | Parameter for `DisplayDateChangedCommand` |
| `ForwardCommand` | `ICommand` | Navigate forward command |
| `BackwardCommand` | `ICommand` | Navigate backward command |
| `GoToTodayCommand` | `ICommand` | Go to today command |
| `ResetSelectionCommand` | `ICommand` | Reset selection command |

## Events 📡

| Event | EventArgs | Description |
|---|---|---|
| `SelectionChanged` | `DateSelectionChangedEventArgs` | Raised when user changes selection |
| `ViewChanged` | `CalendarViewChangedEventArgs` | Raised when the view mode changes |
| `DisplayDateChanged` | `DisplayDateChangedEventArgs` | Raised when navigating to a different month/year |

### DateSelectionChangedEventArgs

| Property | Type | Description |
|---|---|---|
| `NewDate` | `DateTime?` | Newly selected date (Single mode) |
| `OldDate` | `DateTime?` | Previously selected date (Single mode) |
| `AddedDates` | `IReadOnlyList<DateTime>?` | Dates added (Multiple mode) |
| `RemovedDates` | `IReadOnlyList<DateTime>?` | Dates removed (Multiple mode) |
| `NewRange` | `CalendarDateRange?` | New range (Range mode) |
| `OldRange` | `CalendarDateRange?` | Previous range (Range mode) |

## Architecture Overview 🏗

```
┌────────────────────────────────────────────────────────────────────┐
│              Shaunebu.MAUI.CalendarControl                         │
├────────────────────────────────────────────────────────────────────┤
│ Controls/                                                          │
│   CalendarView.cs          Main ContentView control (~1500 lines)  │
│     ├─ Bindable Properties   50+ configurable properties           │
│     ├─ Rendering Engine      Month / Year / Decade / Century views │
│     ├─ Selection Handling    Single / Multiple / Range / None      │
│     ├─ Navigation            Forward / Backward / DrillUp / Down   │
│     ├─ MVVM Commands         8 bindable ICommand properties        │
│     └─ Accessibility         AutomationProperties on all cells     │
├────────────────────────────────────────────────────────────────────┤
│ Enums/                                                             │
│   CalendarViewMode.cs       Month | Year | Decade | Century        │
│   CalendarSelectionMode.cs  None | Single | Multiple | Range       │
│   CalendarDayNameFormat.cs  Full | Abbreviated | Shortest          │
├────────────────────────────────────────────────────────────────────┤
│ Models/                                                            │
│   CalendarDateRange.cs      Start/End date range with Contains()   │
│   CalendarSpecialDate.cs    Per-date visual customization model    │
├────────────────────────────────────────────────────────────────────┤
│ Events/                                                            │
│   DateSelectionChangedEventArgs.cs    Multi-mode selection args    │
│   CalendarViewChangedEventArgs.cs     View mode change args        │
│   DisplayDateChangedEventArgs.cs      Display date change args     │
├────────────────────────────────────────────────────────────────────┤
│ Extensions/                                                        │
│   AppBuilderExtensions.cs   UseShaunebuCalendar() registration     │
├────────────────────────────────────────────────────────────────────┤
│ Platforms/                                                         │
│   Android/   iOS/   MacCatalyst/   Windows/                        │
└────────────────────────────────────────────────────────────────────┘
```

## Advanced Usage Scenarios 🔥

### Booking / Scheduling Calendar

```csharp
var calendar = new CalendarView
{
    SelectionMode = CalendarSelectionMode.Range,
    MinDate = DateTime.Today,
    MaxDate = DateTime.Today.AddMonths(6),
    ShowTodayButton = true
};

// Block out unavailable dates
foreach (var bookedDate in existingBookings)
    calendar.BlackoutDates.Add(bookedDate);

// Highlight available premium slots
foreach (var slot in premiumSlots)
{
    calendar.SpecialDates.Add(new CalendarSpecialDate
    {
        Date = slot,
        IndicatorColor = Colors.Gold,
        Background = Color.FromArgb("#FFF8E1")
    });
}
```

### Multi-Tenant Event Calendar

```csharp
// Mark event dates with color-coded indicators
calendar.SpecialDates.Add(new CalendarSpecialDate
{
    Date = meetingDate,
    IndicatorColor = Colors.Blue
});

calendar.SpecialDates.Add(new CalendarSpecialDate
{
    Date = deadlineDate,
    IndicatorColor = Colors.Red,
    TextColor = Colors.Red
});

calendar.SpecialDates.Add(new CalendarSpecialDate
{
    Date = holidayDate,
    IsBlackout = true
});
```

### Culture-Aware International Calendar

```csharp
var calendar = new CalendarView
{
    Culture = new CultureInfo("ar-SA"),        // Arabic (Saudi Arabia)
    FirstDayOfWeek = DayOfWeek.Saturday,
    DayNameFormat = CalendarDayNameFormat.Shortest,
    HeaderDateFormat = "MMMM yyyy"
};
```

### Programmatic Navigation

```csharp
// Navigate to a specific date
calendar.GoToDate(new DateTime(2025, 12, 25));

// Navigate forward/backward
calendar.Forward();
calendar.Backward();

// Jump to today
calendar.GoToToday();

// Clear all selections
calendar.ResetSelection();
```

## Supported Platforms 📱

| Platform | Minimum Version | Target Frameworks |
|---|---|---|
| **Android** | API 21 (Lollipop) | `net9.0-android`, `net10.0-android` |
| **iOS** | 15.0 | `net9.0-ios`, `net10.0-ios` |
| **macOS** | Mac Catalyst 15.0 | `net9.0-maccatalyst`, `net10.0-maccatalyst` |
| **Windows** | 10.0.17763.0 | `net9.0-windows10.0.19041.0`, `net10.0-windows10.0.19041.0` |

## Troubleshooting 🔧

### Calendar Not Rendering

- Ensure `UseShaunebuCalendar()` is called in `MauiProgram.cs`
- Verify the XAML namespace: `xmlns:cal="clr-namespace:Shaunebu.MAUI.CalendarControl;assembly=Shaunebu.MAUI.CalendarControl"`

### Selection Not Working

- Check that `SelectionMode` is not set to `None`
- Verify the date is not in `BlackoutDates` or `SpecialDates` with `IsBlackout = true`
- Ensure the date is within `MinDate` / `MaxDate` bounds

### Navigation Arrows Disabled

- The arrows automatically disable when `MinDate` / `MaxDate` boundaries are reached
- Verify `ShowNavigationArrows` is `true`

### View Drill-Up/Down Not Working

- Set `AllowViewNavigation="True"` (default)
- The header label must be tapped to drill up
- View navigation respects `MinView` and `MaxView` bounds

### Week Numbers Not Showing

- Set `ShowWeekNumbers="True"`
- Week numbers use the `Culture` property's calendar week rule

## License 📄

This project is licensed under the MIT License.
