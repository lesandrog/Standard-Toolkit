#region BSD License
/*
 *
 *  New BSD 3-Clause License (https://github.com/Krypton-Suite/Standard-Toolkit/blob/master/LICENSE)
 *  Modifications by Peter Wagner(aka Wagnerp) & Simon Coghlan(aka Smurf-IV), et al. 2017 - 2025. All rights reserved.
 *
 */
#endregion

// ReSharper disable InconsistentNaming
namespace Krypton.Toolkit;

public class CommandLinkImageValues : Storage, IContentValues
{
    #region Instance Fields
    private bool _displayUACShield;
    private bool _displayOSArrow;
    private Color _transparencyKey;
    private Image? _image;
    private IconSize _uacShieldIconSize;
    private OSArrowDirection _arrowDirection;
    #endregion

    #region Identity
    /// <summary>Initializes a new instance of the <see cref="CommandLinkImageValues" /> class.</summary>
    /// <param name="needPaint">The need paint.</param>
    public CommandLinkImageValues(NeedPaintHandler needPaint)
    {
        NeedPaint = needPaint;
        _uacShieldIconSize = IconSize.Small;
        _arrowDirection = OSArrowDirection.Right; // Default to right arrow for command links
        _displayOSArrow = true; // Enable OS arrow by default for command links
    }
    #endregion

    #region Public

    [DefaultValue(false)]
    [Description("Display the UAC Shield image.")]
    public bool DisplayUACShield
    {
        get => _displayUACShield;

        set
        {
            if (_displayUACShield != value)
            {
                _displayUACShield = value;
                ShowUACShieldImage(_uacShieldIconSize);
            }
        }
    }
    private bool ShouldSerializeDisplayUACShield() => _displayUACShield;
    private void ResetDisplayUACShield() => DisplayUACShield = false;

    [DefaultValue(true)]
    [Description("Display the OS-dependent arrow image.")]
    public bool DisplayOSArrow
    {
        get => _displayOSArrow;

        set
        {
            if (_displayOSArrow != value)
            {
                _displayOSArrow = value;
                ShowOSArrowImage(_arrowDirection, _uacShieldIconSize);
            }
        }
    }
    private bool ShouldSerializeDisplayOSArrow() => !_displayOSArrow;
    private void ResetDisplayOSArrow() => DisplayOSArrow = true;

    /// <summary>Gets and sets the heading image transparent color.</summary>
    [Category("Visuals")]
    [Description("Image transparent color.")]
    [RefreshProperties(RefreshProperties.All)]
    [KryptonDefaultColor]
    public Color ImageTransparentColor
    {
        get => _transparencyKey;

        set
        {
            if (_transparencyKey != value)
            {
                _transparencyKey = value;
                PerformNeedPaint(true);
            }
        }
    }
    private bool ShouldSerializeImageTransparentColor() => _transparencyKey != GlobalStaticValues.EMPTY_COLOR;
    private void ResetImageTransparentColor() => ImageTransparentColor = GlobalStaticValues.EMPTY_COLOR;

    /// <summary>The UAC image.</summary>
    [Category("Visuals")]
    [Description("The image.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Image? Image
    {
        get => _image;
    }

    [DefaultValue(IconSize.Small)]
    [Description("UAC Shield icon size")]
    public IconSize UACShieldIconSize
    {
        get => _uacShieldIconSize;

        set
        {
            _uacShieldIconSize = value;
            if (_displayUACShield)
            {
                ShowUACShieldImage(value);
            }
            else if (_displayOSArrow)
            {
                ShowOSArrowImage(_arrowDirection, value);
            }
            else
            {
                // If neither is enabled, clear the image
                _image = null;
                PerformNeedPaint(true);
            }
        }
    }
    private bool ShouldSerializeUACShieldIconSize() => _uacShieldIconSize != IconSize.Small;
    private void ResetUACShieldIconSize() => UACShieldIconSize = IconSize.Small;

    [DefaultValue(typeof(OSArrowDirection), "Right")]
    [Description("Direction of the OS-dependent arrow image.")]
    public OSArrowDirection ArrowDirection
    {
        get => _arrowDirection;

        set
        {
            if (_arrowDirection != value)
            {
                _arrowDirection = value;
                if (_displayOSArrow)
                {
                    ShowOSArrowImage(_arrowDirection, _uacShieldIconSize);
                }
            }
        }
    }
    private bool ShouldSerializeArrowDirection() => _arrowDirection != OSArrowDirection.Right;
    private void ResetArrowDirection() => ArrowDirection = OSArrowDirection.Right;

    #endregion


    #region IsDefault

    /// <inheritdoc />
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override bool IsDefault => (!ShouldSerializeDisplayUACShield()
        && !ShouldSerializeDisplayOSArrow()
        && Image == null
        && !ShouldSerializeImageTransparentColor()
        && !ShouldSerializeUACShieldIconSize()
        && !ShouldSerializeArrowDirection());
    #endregion

    #region Implementation

    /// <inheritdoc />
    public Image? GetImage(PaletteState state) 
    {
        // If OS arrow is enabled and we don't have an image yet, generate it
        if (_displayOSArrow && !_displayUACShield && _image == null)
        {
            ShowOSArrowImage(_arrowDirection, _uacShieldIconSize);
        }
        
        return Image;
    }

    /// <inheritdoc />
    public Color GetImageTransparentColor(PaletteState state) => ImageTransparentColor;

    /// <inheritdoc />
    public string GetShortText() => GlobalStaticValues.DEFAULT_EMPTY_STRING;

    /// <inheritdoc />
    public string GetLongText() => GlobalStaticValues.DEFAULT_EMPTY_STRING;

    /// <summary>Shows the uac shield.</summary>
    /// <param name="shieldIconSize">Size of the shield icon.</param>
    private void ShowUACShieldImage(IconSize shieldIconSize)
    {
        if (_displayUACShield)
        {
            int size = shieldIconSize switch
            {
                IconSize.ExtraSmall => 16,
                IconSize.Small      => 32,
                IconSize.Medium     => 64,
                IconSize.Large      => 128,
                IconSize.ExtraLarge => 256,
                _                   => 32
            };

            _image = GraphicsExtensions.ScaleImage(SystemIcons.Shield.ToBitmap(), new Size(size, size));
        }
        else if (_displayOSArrow)
        {
            // If UAC shield is disabled but OS arrow is enabled, show the arrow
            ShowOSArrowImage(_arrowDirection, shieldIconSize);
        }
        else
        {
            _image = null;
        }

        // Force a repaint
        PerformNeedPaint(true);
    }

    /// <summary>Shows the OS-dependent arrow image.</summary>
    /// <param name="arrowDirection">Direction of the arrow.</param>
    /// <param name="iconSize">Size of the arrow icon.</param>
    private void ShowOSArrowImage(OSArrowDirection arrowDirection, IconSize iconSize)
    {
        if (_displayOSArrow && !_displayUACShield)
        {
            // Use our OSArrowImageHelper to get the appropriate arrow image
            _image = OSArrowImageHelper.GetOSArrowImageOrDefault(arrowDirection, iconSize);
        }
        else if (_displayUACShield)
        {
            // If UAC shield is enabled, it takes precedence
            ShowUACShieldImage(iconSize);
            return;
        }
        else
        {
            _image = null;
        }

        // Force a repaint
        PerformNeedPaint(true);
    }
    #endregion
}