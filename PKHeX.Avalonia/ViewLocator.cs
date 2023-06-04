using System;
using Avalonia.Controls;
using HanumanInstitute.MvvmDialogs.Avalonia;
using PKHeX.Avalonia.ViewModels;

namespace PKHeX.Avalonia;

public class ViewLocator : ViewLocatorBase
{
    protected override string GetViewName(object viewModel) => viewModel.GetType().FullName!.Replace("ViewModel", "View");
}
