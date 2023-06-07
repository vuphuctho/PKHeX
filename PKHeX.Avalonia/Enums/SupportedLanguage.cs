using System.ComponentModel.DataAnnotations;

namespace PKHeX.Avalonia.Enums;

public enum SupportedLanguage
{
    [Display(Name = "日本語", ShortName = "JPN")]
    Japanese = 0,
    [Display(Name = "English", ShortName = "ENG")]
    English = 1,
    [Display(Name = "Français", ShortName = "FRE")]
    French = 2,
    [Display(Name = "Italiano", ShortName = "ITA")]
    Italian = 3,
    [Display(Name = "Deutsch", ShortName = "GER")]
    German = 4,
    [Display(Name = "Español", ShortName = "ESP")]
    Spanish = 5,
    [Display(Name = "한국어", ShortName = "KOR")]
    Korean = 6,
    [Display(Name = "简体中文", ShortName = "CHS")]
    ChineseSimplified = 7,
    [Display(Name = "繁體中文", ShortName = "CHT")]
    ChineseTraditional = 8,
}
