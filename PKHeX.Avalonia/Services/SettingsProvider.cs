using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Avalonia.Controls;
using PKHeX.Avalonia.Enums;
using PKHeX.Avalonia.Models;
using PKHeX.Avalonia.Utils;

namespace PKHeX.Avalonia.BusinessLogics;

/// <summary>
/// Handle load, save, validating input settings
/// </summary>
public class SettingsProvider : ISettingsProvider
{
    private readonly ISerializationService _serializationService;
    private readonly string _settingFilePath;
    public SettingsProvider(ISerializationService serializationService)
    {
        _serializationService = serializationService;
        Load();
    }

    // TODO: how to make this reactive
    public AppSettings Value { get; set; }

    /// <summary>
    /// Event triggered on loading completed
    /// </summary>
    public event EventHandler? OnLoaded;

    /// <summary>
    /// Event triggered during saving setting file
    /// </summary>
    public event EventHandler? OnSaving;

    /// <summary>
    /// Event triggered on saving completed
    /// </summary>
    public event EventHandler? OnSaved;

    /// <summary>
    /// Load settings from file if present, or create a new object with default values
    /// </summary>
    /// <returns></returns>
    public AppSettings Load()
    {
        List<string> errors = new();
        AppSettings? result = null;
        try
        {
            result = _serializationService.DeserializeFromFile<AppSettings>(_settingFilePath);
        }
        catch (InvalidOperationException e)
        {
            errors.Add(e.Message);
        }
        catch (FileNotFoundException) { }

        var validationErrors = result?.Validate();
        if (validationErrors != null)
            errors.AddRange(validationErrors.Select(e => e.ErrorMessage ?? string.Empty));

        if (errors.Any())
        {
            var msg = "Failed to load configuration file " + _settingFilePath + Environment.NewLine + string.Join(Environment.NewLine, errors);
            throw new InvalidOperationException(msg);
        }

        Value = result ?? GetDefault();
        OnLoaded?.Invoke(this, EventArgs.Empty);
        return Value;
    }

    /// <summary>
    /// Save current setting values to predefined file path
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NullReferenceException">File not exist</exception>
    public bool Save()
    {
        OnSaving?.Invoke(this, EventArgs.Empty);
        if (Value == null) throw new NullReferenceException();

        OnSaved?.Invoke(this, EventArgs.Empty);
        return true;
    }

    /// <summary>
    /// Returns the default setting values of the app
    /// </summary>
    /// <returns>Default settings</returns>
    public AppSettings GetDefault() => new()
    {
        Language = SupportedLanguage.English,
    };
}
