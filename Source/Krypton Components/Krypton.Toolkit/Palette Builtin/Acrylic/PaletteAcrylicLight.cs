#region BSD License
/*
 *
 *  New BSD 3-Clause License (https://github.com/Krypton-Suite/Standard-Toolkit/blob/master/LICENSE)
 *  Modifications by Peter Wagner (aka Wagnerp), Simon Coghlan (aka Smurf-IV), tobitege et al. 2025 - 2025. All rights reserved.
 *
 */
#endregion

namespace Krypton.Toolkit;

/// <summary>
/// Acrylic Light palette variant inspired by Windows 10 Fluent Design System.
/// Features semi-transparent light surfaces with subtle blur effects and modern color schemes.
/// </summary>
public class PaletteAcrylicLight : PaletteAcrylicBase
{
    private static readonly ImageList _checkBoxList;
    private static readonly ImageList _galleryButtonList;
    private static readonly Image?[] _radioButtonArray;

    private static readonly PaletteMicrosoft365BlueLightMode _forward365 = new PaletteMicrosoft365BlueLightMode();

    static PaletteAcrylicLight()
    {
        _checkBoxList = new ImageList
        {
            ImageSize = new Size(13, 13),
            ColorDepth = ColorDepth.Depth32Bit
        };

        // Build glyph palette dynamically from the Acrylic Light scheme
        var scheme = new PaletteAcrylicLight_BaseScheme();
        var lightPalette = MaterialSelectionGlyphFactory.FromScheme(scheme, isDarkSurface: false);

        var cbStrip = MaterialSelectionGlyphFactory.CreateCheckBoxStrip(lightPalette, _checkBoxList.ImageSize);
        for (int i = 0; i < cbStrip.Length; i++)
        {
            _checkBoxList.Images.Add(cbStrip[i]);
        }

        _galleryButtonList = new ImageList
        {
            ImageSize = new Size(13, 7),
            ColorDepth = ColorDepth.Depth24Bit,
            TransparentColor = GlobalStaticValues.TRANSPARENCY_KEY_COLOR
        };
        _galleryButtonList.Images.AddStrip(GalleryImageResources.Gallery2010);

        _radioButtonArray = MaterialSelectionGlyphFactory.CreateRadioButtonArray(lightPalette, new Size(13, 13));

        // Override context menu glyphs to Acrylic
        _contextMenuChecked = MaterialSelectionGlyphFactory.CreateMenuCheckedGlyph(lightPalette, new Size(16, 16), true);
        _contextMenuIndeterminate = MaterialSelectionGlyphFactory.CreateMenuIndeterminateGlyph(lightPalette, new Size(16, 16), true);
        _contextMenuSubMenu = MaterialSelectionGlyphFactory.CreateMenuSubMenuArrow(lightPalette, new Size(16, 16));
    }

    public PaletteAcrylicLight()
        : base(new PaletteAcrylicLight_BaseScheme(), _checkBoxList, _galleryButtonList, _radioButtonArray)
    {
    }

    protected override bool IsDarkSurface() => false;

    private static Image? _contextMenuChecked;
    private static Image? _contextMenuIndeterminate;
    private static Image? _contextMenuSubMenu;

    public override Image? GetContextMenuCheckedImage() => _contextMenuChecked;
    public override Image? GetContextMenuIndeterminateImage() => _contextMenuIndeterminate;
    public override Image? GetContextMenuSubMenuImage() => _contextMenuSubMenu;
    public override Image? GetButtonSpecImage(PaletteButtonSpecStyle style, PaletteState state) => _forward365.GetButtonSpecImage(style, state);
    public override Color GetRibbonFileAppTabBottomColor(PaletteState state) => _forward365.GetRibbonFileAppTabBottomColor(state);
    public override Color GetRibbonFileAppTabTopColor(PaletteState state) => _forward365.GetRibbonFileAppTabTopColor(state);
    public override Color GetRibbonFileAppTabTextColor(PaletteState state) => _forward365.GetRibbonFileAppTabTextColor(state);
    public override Color GetRibbonTabRowGradientColor1(PaletteState state) => _forward365.GetRibbonTabRowGradientColor1(state);
    public override Color GetRibbonTabRowBackgroundGradientRaftingDark(PaletteState state) => _forward365.GetRibbonTabRowBackgroundGradientRaftingDark(state);
    public override Color GetRibbonTabRowBackgroundGradientRaftingLight(PaletteState state) => _forward365.GetRibbonTabRowBackgroundGradientRaftingLight(state);
    public override Color GetRibbonTabRowBackgroundSolidColor(PaletteState state) => _forward365.GetRibbonTabRowBackgroundSolidColor(state);
    public override float GetRibbonTabRowGradientRaftingAngle(PaletteState state) => _forward365.GetRibbonTabRowGradientRaftingAngle(state);
}
