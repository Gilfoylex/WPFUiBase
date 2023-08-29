using System.Windows;

namespace UIBase.Controls;

/// <summary>
/// Represents a method that handles general events.
/// </summary>
/// <typeparam name="TSender"></typeparam>
/// <typeparam name="TArgs"></typeparam>
/// <param name="sender"></param>
/// <param name="args"></param>
public delegate void TypedEventHandler<in TSender, in TArgs>(TSender sender, TArgs args)
    where TSender : DependencyObject
    where TArgs : RoutedEventArgs;