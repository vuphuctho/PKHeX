using System;
using System.Collections.Generic;

namespace PKHeX.Avalonia.Services;

/// <summary>
/// Provides information about the application, environment and operating system.
/// Mainly to collect information for debugging
/// </summary>
public interface IEnvironmentService
{
    /// <summary>
    /// Returns a string array containing the command-line arguments for the current process.
    /// </summary>
    IEnumerable<string> CommandLineArguments { get; }
    /// <summary>
    /// Returns the version of executing assembly.
    /// </summary>
    Version AppVersion { get; }
    /// <summary>
    /// Returns the friendly name of this application.
    /// </summary>
    string AppFriendlyName { get; }
    /// <summary>
    /// Returns the path of the system special folder CommonApplicationData.
    /// </summary>
    string ApplicationDataPath { get; }
    /// <summary>
    /// Returns the directory from which the application is run.
    /// </summary>
    string AppDirectory { get; }
    /// <summary>
    /// Returns the root of the drive where the operating system is installed.
    /// </summary>
    string SystemRootDirectory { get; }
    /// <summary>
    /// Returns the path where x86 Program Files are installed.
    /// </summary>
    string ProgramFilesX86 { get; }
    /// <summary>
    /// Returns the character used to separate directory levels in the file system.
    /// </summary>
    char DirectorySeparatorChar { get; }
    /// <summary>
    /// Provides a platform-specific alternate character used to separate directory levels in a path string that reflects a hierarchical file system organization.
    /// </summary>
    char AltDirectorySeparatorChar { get; }
    /// <summary>
    /// Returns the current date and time on this computer expressed as local time.
    /// </summary>
    DateTime Now { get; }
    /// <summary>
    /// Returns the current date and time on this computer expressed as UTC.
    /// </summary>
    DateTime UtcNow { get; }
    /// <summary>Indicates whether the current application is running on Linux.</summary>
    bool IsLinux { get; }
    /// <summary>Indicates whether the current application is running on Windows.</summary>
    bool IsWindows { get; }
    /// <summary>Indicates whether the current application is running on MacOS.</summary>
    // ReSharper disable once InconsistentNaming
    bool IsMacOS { get; }
    /// <summary>
    /// Gets or sets the <see cref="T:System.Globalization.CultureInfo" /> object that represents the culture used by the current thread and task-based asynchronous operations.
    /// </summary>
    IFormatProvider CurrentCulture { get; }
    /// <summary>
    /// Returns the operating system and CPU architecture in the same format as RuntimeIdentifier set while building. ex: win-x64, linux-arm64.
    /// </summary>
    /// <returns>The operating system and architecture as a string.</returns>
    string GetRuntimeIdentifier();
}
