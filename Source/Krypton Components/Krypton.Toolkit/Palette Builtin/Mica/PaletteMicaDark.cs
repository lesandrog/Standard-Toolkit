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
/// Mica Dark palette variant inspired by Windows 11 Fluent Design System.
/// Features subtle translucency effects with better performance than Acrylic.
/// </summary>
public class PaletteMicaDark : PaletteMicaBase
{
    private static readonly ImageList _checkBoxList;
    private static readonly ImageList _galleryButtonList;
    private static readonly Image?[] _radioButtonArray;

    private static readonly PaletteMicrosoft365BlueDarkMode _forward365 = new PaletteMicrosoft365BlueDarkMode();

    static PaletteMicaDark()
    {
        _checkBoxList = new ImageList
        {
            ImageSize = new Size(13, 13),
            ColorDepth = ColorDepth.Depth32Bit
        };

        // Build glyph palette dynamically from the Mica Dark scheme
        var scheme = new PaletteMicaDark_BaseScheme();
        var darkPalette = MaterialSelectionGlyphFactory.FromScheme(scheme, isDarkSurface: true);

        var cbStrip = MaterialSelectionGlyphFactory.CreateCheckBoxStrip(darkPalette, _checkBoxList.ImageSize);
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

        _radioButtonArray = MaterialSelectionGlyphFactory.CreateRadioButtonArray(darkPalette, new Size(13, 13));

        // Override context menu glyphs to Mica
        _contextMenuChecked = MaterialSelectionGlyphFactory.CreateMenuCheckedGlyph(darkPalette, new Size(16, 16), true);
        _contextMenuIndeterminate = MaterialSelectionGlyphFactory.CreateMenuIndeterminateGlyph(darkPalette, new Size(16, 16), true);
        _contextMenuSubMenu = MaterialSelectionGlyphFactory.CreateMenuSubMenuArrow(darkPalette, new Size(16, 16));
    }

    public PaletteMicaDark()
        : base(new PaletteMicaDark_BaseScheme(), _checkBoxList, _galleryButtonList, _radioButtonArray)
    {
    }

    protected override bool IsDarkSurface() => true;

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
