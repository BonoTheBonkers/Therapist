using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EFlatColor
{
    Red,
    Orange,
    Yellow,
    Sand,
    NavyBlue,
    Black,
    Magenta,
    Teal,
    SkyBlue,
    Green,
    Mint,
    White,
    Gray,
    ForestGreen,
    Purple,
    Brown,
    Plum,
    Watermelon,
    Lime,
    Pink,
    Maroon,
    Coffee,
    PowderBlue,
    Blue,
    Max
}

    public enum EThemePart
{
    None,
    Background,
    ButtonFull,
    ButtonShadowed,
    SettingsBackground,
    AmbientLight,
    AmbientDark,
    FontFullColor,
    FontShadowedColor,
    Max
}

public enum EFlatFont
{
    SmallText,
    MediumText,
    LargeText,
    SmallTitleText,
    TitleText,
    LargeTitleText,
    SmallValue,
    MediumValue,
    LargeValue,
    ProductTitle,
    Max
}

public enum EDifficulty
{
    VeryEasy,
    Easy,
    Medium,
    Hard,
    VeryHard,
    Max
}

public enum EAttribute
{
    Sizes,
    SomethingMore,
    Colors,
    Amounts,
    Movements,
    Mixed,
    Shapes,
    Development,
    Max
}

public enum EContraindications
{
    ColorBlindess,
    Deafness,
    Max
}

public enum EGameScreen
{
    Intro,
    MainMenu,
    AttributeMenu,
    Settings,
    Statistics,
    UserSelection,
    Board,
    Levels,
    CreatePlayer,
    Max
}

public enum ELanguage
{
    English,
    Spanish,
    SimplifiedChinese,
    Japanese,
    Korean,
    French,
    German,
    Italian,
    Portuguese,
    Arabic,
    Russian,
    Hindi,
    Swedish,
    Polish,
    Max
}

public enum EExampleConfig
{
    None,
    SameSequence,
    SameAttribute,
    SameLogic,
    Max
}

public enum EUserType
{
    Guardian,
    Therapist,
    Max
}

public enum ETokenPlaceType
{
    None,
    ExampleSequence,
    CurrentSequence,
    CurrentTokens,
    Max
}

public enum ESettingsSliderType
{
    None,
    Sounds,
    Music,
    VideoQuality,
    Max
}