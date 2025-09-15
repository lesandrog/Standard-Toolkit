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
/// Base palette for Acrylic family variants. Uses Microsoft 365 color wiring while applying
/// the Acrylic renderer with semi-transparent surfaces and Windows 10 Fluent Design effects.
/// </summary>
public abstract class PaletteAcrylicBase : PaletteMicrosoft365Base
{
    #region Acrylic Tokens
    private static Color BlendOverlay(Color baseColor, Color overlayColor, float overlayWeight)
        => CommonHelper.MergeColors(baseColor, 1f - overlayWeight, overlayColor, overlayWeight);

    protected abstract bool IsDarkSurface();

    private Color TokenSurface => BaseColors != null ? BaseColors.PanelClient : SystemColors.Control;
    private Color TokenOnSurface => BaseColors != null ? BaseColors.TextLabelControl : SystemColors.ControlText;
    private Color TokenOutline => BaseColors != null ? BaseColors.ControlBorder : SystemColors.ControlDark;
    private Color TokenPrimary => BaseColors != null ? BaseColors.TextButtonNormal : SystemColors.HotTrack;

    private Color GetAcrylicSurfaceColor(PaletteState state)
    {
        var surface = TokenSurface;
        
        // Acrylic state overlays with transparency effects
        float overlay = state switch
        {
            PaletteState.Tracking => 0.08f,
            PaletteState.Pressed or PaletteState.CheckedPressed => 0.15f,
            PaletteState.CheckedNormal => 0.10f,
            PaletteState.CheckedTracking => 0.12f,
            _ => 0f
        };

        if (overlay <= 0f)
        {
            return surface;
        }

        var overlayColor = IsDarkSurface() ? Color.White : Color.Black;
        return BlendOverlay(surface, overlayColor, overlay);
    }

    private Color GetAcrylicBorderColor(PaletteState state)
    {
        var border = TokenOutline;
        
        // Subtle border transparency effects
        float overlay = state switch
        {
            PaletteState.Tracking => 0.12f,
            PaletteState.Pressed or PaletteState.CheckedPressed => 0.18f,
            PaletteState.CheckedNormal => 0.15f,
            PaletteState.CheckedTracking => 0.16f,
            _ => 0f
        };

        if (overlay <= 0f)
        {
            return border;
        }

        var overlayColor = IsDarkSurface() ? Color.White : Color.Black;
        return BlendOverlay(border, overlayColor, overlay);
    }
    #endregion

    #region Identity
    /// <summary>
    /// Initializes a new instance of the <see cref="PaletteAcrylicBase"/> class.
    /// </summary>
    protected PaletteAcrylicBase(
        [DisallowNull] KryptonColorSchemeBase scheme,
        [DisallowNull] ImageList checkBoxList,
        [DisallowNull] ImageList galleryButtonList,
        [DisallowNull] Image?[] radioButtonArray)
        : base(scheme, checkBoxList, galleryButtonList, radioButtonArray)
    {
    }
    #endregion

    #region Renderer
    /// <inheritdoc />
    public override IRenderer GetRenderer() => KryptonManager.RenderAcrylic;
    public override InheritBool UseThemeFormChromeBorderWidth => InheritBool.True;
    #endregion

    #region Back
    /// <inheritdoc />
    public override PaletteColorStyle GetBackColorStyle(PaletteBackStyle style, PaletteState state)
    {
        if (CommonHelper.IsOverrideState(state))
        {
            return PaletteColorStyle.Inherit;
        }

        switch (style)
        {
            case PaletteBackStyle.ButtonStandalone:
            case PaletteBackStyle.ButtonAlternate:
            case PaletteBackStyle.ButtonLowProfile:
            case PaletteBackStyle.ButtonBreadCrumb:
            case PaletteBackStyle.ButtonListItem:
            case PaletteBackStyle.ButtonCommand:
            case PaletteBackStyle.ButtonButtonSpec:
            case PaletteBackStyle.ButtonCluster:
            case PaletteBackStyle.ButtonForm:
            case PaletteBackStyle.ButtonFormClose:
            case PaletteBackStyle.ButtonCustom1:
            case PaletteBackStyle.ButtonCustom2:
            case PaletteBackStyle.ButtonCustom3:
                // Force solid fills for acrylic buttons with transparency
                return PaletteColorStyle.Solid;
            case PaletteBackStyle.ContextMenuOuter:
            case PaletteBackStyle.ContextMenuInner:
            case PaletteBackStyle.ContextMenuItemHighlight:
                return PaletteColorStyle.Solid;
            case PaletteBackStyle.ControlClient:
            case PaletteBackStyle.ControlAlternate:
            case PaletteBackStyle.ControlCustom1:
            case PaletteBackStyle.ControlCustom2:
            case PaletteBackStyle.ControlCustom3:
            case PaletteBackStyle.HeaderPrimary:
            case PaletteBackStyle.HeaderSecondary:
            case PaletteBackStyle.HeaderDockActive:
            case PaletteBackStyle.HeaderDockInactive:
            case PaletteBackStyle.HeaderForm:
            case PaletteBackStyle.HeaderCalendar:
            case PaletteBackStyle.HeaderCustom1:
            case PaletteBackStyle.HeaderCustom2:
            case PaletteBackStyle.HeaderCustom3:
            case PaletteBackStyle.FormMain:
            case PaletteBackStyle.InputControlStandalone:
            case PaletteBackStyle.InputControlRibbon:
            case PaletteBackStyle.InputControlCustom1:
            case PaletteBackStyle.InputControlCustom2:
            case PaletteBackStyle.InputControlCustom3:
                return PaletteColorStyle.Solid;
            default:
                return base.GetBackColorStyle(style, state);
        }
    }

    /// <inheritdoc />
    public override PaletteGraphicsHint GetBackGraphicsHint(PaletteBackStyle style, PaletteState state)
    {
        if (CommonHelper.IsOverrideState(state))
        {
            return PaletteGraphicsHint.Inherit;
        }

        // Enable anti-aliasing for acrylic effects
        switch (style)
        {
            case PaletteBackStyle.ContextMenuOuter:
            case PaletteBackStyle.ContextMenuInner:
            case PaletteBackStyle.ContextMenuItemHighlight:
                return PaletteGraphicsHint.AntiAlias;
            case PaletteBackStyle.ControlClient:
            case PaletteBackStyle.ControlAlternate:
            case PaletteBackStyle.ControlCustom1:
            case PaletteBackStyle.ControlCustom2:
            case PaletteBackStyle.ControlCustom3:
            case PaletteBackStyle.HeaderPrimary:
            case PaletteBackStyle.HeaderSecondary:
            case PaletteBackStyle.HeaderDockActive:
            case PaletteBackStyle.HeaderDockInactive:
            case PaletteBackStyle.HeaderForm:
            case PaletteBackStyle.HeaderCalendar:
            case PaletteBackStyle.HeaderCustom1:
            case PaletteBackStyle.HeaderCustom2:
            case PaletteBackStyle.HeaderCustom3:
            case PaletteBackStyle.FormMain:
            case PaletteBackStyle.InputControlStandalone:
            case PaletteBackStyle.InputControlRibbon:
            case PaletteBackStyle.InputControlCustom1:
            case PaletteBackStyle.InputControlCustom2:
            case PaletteBackStyle.InputControlCustom3:
                return PaletteGraphicsHint.AntiAlias;
            default:
                return base.GetBackGraphicsHint(style, state);
        }
    }

    /// <inheritdoc />
    public override Color GetBackColor1(PaletteBackStyle style, PaletteState state)
    {
        switch (style)
        {
            // Buttons: use acrylic surface color with state-specific transparency
            case PaletteBackStyle.ButtonStandalone:
            case PaletteBackStyle.ButtonAlternate:
            case PaletteBackStyle.ButtonLowProfile:
            case PaletteBackStyle.ButtonBreadCrumb:
            case PaletteBackStyle.ButtonListItem:
            case PaletteBackStyle.ButtonCommand:
            case PaletteBackStyle.ButtonButtonSpec:
            case PaletteBackStyle.ButtonCluster:
            case PaletteBackStyle.ButtonForm:
            case PaletteBackStyle.ButtonFormClose:
            case PaletteBackStyle.ButtonCustom1:
            case PaletteBackStyle.ButtonCustom2:
            case PaletteBackStyle.ButtonCustom3:
                return GetAcrylicSurfaceColor(state);
            case PaletteBackStyle.HeaderForm:
            case PaletteBackStyle.HeaderPrimary:
                // Acrylic header background
                return GetAcrylicSurfaceColor(state);
            case PaletteBackStyle.ControlClient:
                return GetAcrylicSurfaceColor(state);
            case PaletteBackStyle.GridDataCellList:
            case PaletteBackStyle.GridDataCellSheet:
            case PaletteBackStyle.GridDataCellCustom1:
            case PaletteBackStyle.GridDataCellCustom2:
            case PaletteBackStyle.GridDataCellCustom3:
                return GetAcrylicSurfaceColor(state);
            case PaletteBackStyle.ContextMenuOuter:
            case PaletteBackStyle.ContextMenuInner:
                return GetAcrylicSurfaceColor(state);
            case PaletteBackStyle.ContextMenuItemHighlight:
                return GetAcrylicSurfaceColor(state);
            default:
                return base.GetBackColor1(style, state);
        }
    }

    /// <inheritdoc />
    public override Color GetBackColor2(PaletteBackStyle style, PaletteState state)
    {
        switch (style)
        {
            case PaletteBackStyle.ButtonStandalone:
            case PaletteBackStyle.ButtonAlternate:
            case PaletteBackStyle.ButtonLowProfile:
            case PaletteBackStyle.ButtonBreadCrumb:
            case PaletteBackStyle.ButtonListItem:
            case PaletteBackStyle.ButtonCommand:
            case PaletteBackStyle.ButtonButtonSpec:
            case PaletteBackStyle.ButtonCluster:
            case PaletteBackStyle.ButtonForm:
            case PaletteBackStyle.ButtonFormClose:
            case PaletteBackStyle.ButtonCustom1:
            case PaletteBackStyle.ButtonCustom2:
            case PaletteBackStyle.ButtonCustom3:
                return GetAcrylicSurfaceColor(state);
            case PaletteBackStyle.HeaderForm:
            case PaletteBackStyle.HeaderPrimary:
                return GetAcrylicSurfaceColor(state);
            case PaletteBackStyle.ControlClient:
                return GetAcrylicSurfaceColor(state);
            case PaletteBackStyle.GridDataCellList:
            case PaletteBackStyle.GridDataCellSheet:
            case PaletteBackStyle.GridDataCellCustom1:
            case PaletteBackStyle.GridDataCellCustom2:
            case PaletteBackStyle.GridDataCellCustom3:
                return GetAcrylicSurfaceColor(state);
            case PaletteBackStyle.ContextMenuOuter:
            case PaletteBackStyle.ContextMenuInner:
                return GetAcrylicSurfaceColor(state);
            case PaletteBackStyle.ContextMenuItemHighlight:
                return GetAcrylicSurfaceColor(state);
            default:
                return base.GetBackColor2(style, state);
        }
    }
    #endregion

    #region Border
    /// <inheritdoc />
    public override InheritBool GetBorderDraw(PaletteBorderStyle style, PaletteState state)
    {
        // Enable subtle borders for acrylic effects
        if (style == PaletteBorderStyle.ControlClient || style == PaletteBorderStyle.ControlAlternate)
        {
            return InheritBool.True;
        }

        if (CommonHelper.IsOverrideState(state))
        {
            if (state == PaletteState.FocusOverride && IsAnyInputBorderStyle(style))
            {
                return InheritBool.True;
            }
            return InheritBool.Inherit;
        }

        if (IsAnyButtonBorderStyle(style))
        {
            var interactiveMask = PaletteState.Tracking | PaletteState.Pressed | PaletteState.Checked;
            bool isInteractive = (state & interactiveMask) != 0;
            return isInteractive ? InheritBool.True : InheritBool.False;
        }

        return base.GetBorderDraw(style, state);
    }

    /// <inheritdoc />
    public override PaletteGraphicsHint GetBorderGraphicsHint(PaletteBorderStyle style, PaletteState state)
    {
        // Enable anti-aliasing for acrylic borders
        return PaletteGraphicsHint.AntiAlias;
    }

    private static bool IsAnyButtonBorderStyle(PaletteBorderStyle style)
    {
        switch (style)
        {
            case PaletteBorderStyle.ButtonStandalone:
            case PaletteBorderStyle.ButtonGallery:
            case PaletteBorderStyle.ButtonAlternate:
            case PaletteBorderStyle.ButtonLowProfile:
            case PaletteBorderStyle.ButtonBreadCrumb:
            case PaletteBorderStyle.ButtonListItem:
            case PaletteBorderStyle.ButtonCommand:
            case PaletteBorderStyle.ButtonButtonSpec:
            case PaletteBorderStyle.ButtonCluster:
            case PaletteBorderStyle.ButtonForm:
            case PaletteBorderStyle.ButtonFormClose:
            case PaletteBorderStyle.ButtonCustom1:
            case PaletteBorderStyle.ButtonCustom2:
            case PaletteBorderStyle.ButtonCustom3:
            case PaletteBorderStyle.ButtonNavigatorStack:
            case PaletteBorderStyle.ButtonNavigatorOverflow:
            case PaletteBorderStyle.ButtonNavigatorMini:
            case PaletteBorderStyle.ButtonCalendarDay:
            case PaletteBorderStyle.ButtonInputControl:
                return true;
            default:
                return false;
        }
    }

    private static bool IsAnyInputBorderStyle(PaletteBorderStyle style)
    {
        switch (style)
        {
            case PaletteBorderStyle.InputControlStandalone:
            case PaletteBorderStyle.InputControlRibbon:
            case PaletteBorderStyle.InputControlCustom1:
            case PaletteBorderStyle.InputControlCustom2:
            case PaletteBorderStyle.InputControlCustom3:
                return true;
            default:
                return false;
        }
    }

    /// <inheritdoc />
    public override PaletteDrawBorders GetBorderDrawBorders(PaletteBorderStyle style, PaletteState state)
    {
        if (IsAnyInputBorderStyle(style))
        {
            if (state == PaletteState.FocusOverride)
            {
                return PaletteDrawBorders.Bottom;
            }
            return PaletteDrawBorders.Bottom;
        }

        if (IsAnyButtonBorderStyle(style))
        {
            var interactiveMask = PaletteState.Tracking | PaletteState.Pressed | PaletteState.Checked;
            bool isInteractive = (state & interactiveMask) != 0;
            if (CommonHelper.IsOverrideState(state) && state != PaletteState.FocusOverride)
            {
                isInteractive = false;
            }
            return isInteractive ? PaletteDrawBorders.All : PaletteDrawBorders.None;
        }

        return base.GetBorderDrawBorders(style, state);
    }

    /// <inheritdoc />
    public override int GetBorderWidth(PaletteBorderStyle style, PaletteState state)
    {
        if (CommonHelper.IsOverrideState(state))
        {
            if (state == PaletteState.FocusOverride && IsAnyInputBorderStyle(style))
            {
                return 2;
            }
            if (IsAnyButtonBorderStyle(style))
            {
                return 0;
            }
            return -1;
        }

        if (IsAnyButtonBorderStyle(style))
        {
            var interactiveMask = PaletteState.Tracking | PaletteState.Pressed | PaletteState.Checked;
            bool isInteractive = (state & interactiveMask) != 0;
            return isInteractive ? 1 : 0;
        }

        if (style == PaletteBorderStyle.FormMain || style == PaletteBorderStyle.HeaderForm)
        {
            return 1;
        }

        if (IsAnyInputBorderStyle(style))
        {
            return state is PaletteState.Disabled or PaletteState.Normal ? 1 : 2;
        }

        return base.GetBorderWidth(style, state);
    }

    /// <inheritdoc />
    public override float GetBorderRounding(PaletteBorderStyle style, PaletteState state)
    {
        if (CommonHelper.IsOverrideState(state))
        {
            return GlobalStaticValues.DEFAULT_PRIMARY_CORNER_ROUNDING_VALUE;
        }

        if (style == PaletteBorderStyle.FormMain || style == PaletteBorderStyle.HeaderForm)
        {
            return 0f;
        }

        if (IsAnyButtonBorderStyle(style) || IsAnyInputBorderStyle(style))
        {
            return 0f;
        }

        return base.GetBorderRounding(style, state);
    }

    /// <inheritdoc />
    public override Color GetBorderColor1(PaletteBorderStyle style, PaletteState state)
    {
        if (style == PaletteBorderStyle.FormMain || style == PaletteBorderStyle.HeaderForm)
        {
            return base.GetBorderColor1(style, state);
        }

        if (IsAnyButtonBorderStyle(style) || IsAnyInputBorderStyle(style))
        {
            return GetAcrylicBorderColor(state);
        }

        return base.GetBorderColor1(style, state);
    }

    /// <inheritdoc />
    public override Color GetBorderColor2(PaletteBorderStyle style, PaletteState state)
    {
        if (style == PaletteBorderStyle.FormMain || style == PaletteBorderStyle.HeaderForm)
        {
            return base.GetBorderColor2(style, state);
        }

        if (IsAnyButtonBorderStyle(style) || IsAnyInputBorderStyle(style))
        {
            return GetAcrylicBorderColor(state);
        }

        return base.GetBorderColor2(style, state);
    }
    #endregion

    #region Content
    /// <inheritdoc />
    public override Color GetContentShortTextColor1(PaletteContentStyle style, PaletteState state)
    {
        switch (style)
        {
            case PaletteContentStyle.ButtonListItem:
            case PaletteContentStyle.HeaderForm:
            case PaletteContentStyle.GridHeaderColumnList:
            case PaletteContentStyle.GridHeaderColumnSheet:
            case PaletteContentStyle.GridHeaderColumnCustom1:
            case PaletteContentStyle.GridHeaderColumnCustom2:
            case PaletteContentStyle.GridHeaderColumnCustom3:
            case PaletteContentStyle.GridHeaderRowList:
            case PaletteContentStyle.GridHeaderRowSheet:
            case PaletteContentStyle.GridHeaderRowCustom1:
            case PaletteContentStyle.GridHeaderRowCustom2:
            case PaletteContentStyle.GridHeaderRowCustom3:
            case PaletteContentStyle.ContextMenuItemTextStandard:
            case PaletteContentStyle.ContextMenuItemTextAlternate:
            case PaletteContentStyle.ContextMenuItemShortcutText:
                return BaseColors?.HeaderText ?? base.GetContentShortTextColor1(style, state);

            case PaletteContentStyle.GridDataCellList:
            case PaletteContentStyle.GridDataCellSheet:
            case PaletteContentStyle.GridDataCellCustom1:
            case PaletteContentStyle.GridDataCellCustom2:
            case PaletteContentStyle.GridDataCellCustom3:
                return BaseColors?.TextLabelControl ?? base.GetContentShortTextColor1(style, state);
        }

        return base.GetContentShortTextColor1(style, state);
    }

    /// <inheritdoc />
    public override Color GetContentShortTextColor2(PaletteContentStyle style, PaletteState state)
    {
        switch (style)
        {
            case PaletteContentStyle.GridHeaderColumnList:
            case PaletteContentStyle.GridHeaderColumnSheet:
            case PaletteContentStyle.GridHeaderColumnCustom1:
            case PaletteContentStyle.GridHeaderColumnCustom2:
            case PaletteContentStyle.GridHeaderColumnCustom3:
            case PaletteContentStyle.GridHeaderRowList:
            case PaletteContentStyle.GridHeaderRowSheet:
            case PaletteContentStyle.GridHeaderRowCustom1:
            case PaletteContentStyle.GridHeaderRowCustom2:
            case PaletteContentStyle.GridHeaderRowCustom3:
            case PaletteContentStyle.ContextMenuItemTextStandard:
            case PaletteContentStyle.ContextMenuItemTextAlternate:
            case PaletteContentStyle.ContextMenuItemShortcutText:
                return BaseColors?.HeaderText ?? base.GetContentShortTextColor2(style, state);

            case PaletteContentStyle.GridDataCellList:
            case PaletteContentStyle.GridDataCellSheet:
            case PaletteContentStyle.GridDataCellCustom1:
            case PaletteContentStyle.GridDataCellCustom2:
            case PaletteContentStyle.GridDataCellCustom3:
                return BaseColors?.TextLabelControl ?? base.GetContentShortTextColor2(style, state);
        }

        return base.GetContentShortTextColor2(style, state);
    }

    /// <inheritdoc />
    public override Color GetContentLongTextColor1(PaletteContentStyle style, PaletteState state)
    {
        switch (style)
        {
            case PaletteContentStyle.GridHeaderColumnList:
            case PaletteContentStyle.GridHeaderColumnSheet:
            case PaletteContentStyle.GridHeaderColumnCustom1:
            case PaletteContentStyle.GridHeaderColumnCustom2:
            case PaletteContentStyle.GridHeaderColumnCustom3:
            case PaletteContentStyle.GridHeaderRowList:
            case PaletteContentStyle.GridHeaderRowSheet:
            case PaletteContentStyle.GridHeaderRowCustom1:
            case PaletteContentStyle.GridHeaderRowCustom2:
            case PaletteContentStyle.GridHeaderRowCustom3:
            case PaletteContentStyle.ContextMenuItemTextStandard:
            case PaletteContentStyle.ContextMenuItemTextAlternate:
            case PaletteContentStyle.ContextMenuItemShortcutText:
                return BaseColors?.HeaderText ?? base.GetContentLongTextColor1(style, state);

            case PaletteContentStyle.GridDataCellList:
            case PaletteContentStyle.GridDataCellSheet:
            case PaletteContentStyle.GridDataCellCustom1:
            case PaletteContentStyle.GridDataCellCustom2:
            case PaletteContentStyle.GridDataCellCustom3:
                if (state is PaletteState.CheckedNormal or PaletteState.CheckedTracking or PaletteState.CheckedPressed)
                {
                    return BaseColors?.HeaderText ?? base.GetContentLongTextColor1(style, state);
                }
                break;
        }

        return base.GetContentLongTextColor1(style, state);
    }

    /// <inheritdoc />
    public override Color GetContentLongTextColor2(PaletteContentStyle style, PaletteState state)
    {
        switch (style)
        {
            case PaletteContentStyle.GridHeaderColumnList:
            case PaletteContentStyle.GridHeaderColumnSheet:
            case PaletteContentStyle.GridHeaderColumnCustom1:
            case PaletteContentStyle.GridHeaderColumnCustom2:
            case PaletteContentStyle.GridHeaderColumnCustom3:
            case PaletteContentStyle.GridHeaderRowList:
            case PaletteContentStyle.GridHeaderRowSheet:
            case PaletteContentStyle.GridHeaderRowCustom1:
            case PaletteContentStyle.GridHeaderRowCustom2:
            case PaletteContentStyle.GridHeaderRowCustom3:
            case PaletteContentStyle.ContextMenuItemTextStandard:
            case PaletteContentStyle.ContextMenuItemTextAlternate:
            case PaletteContentStyle.ContextMenuItemShortcutText:
                return BaseColors?.HeaderText ?? base.GetContentLongTextColor2(style, state);

            case PaletteContentStyle.GridDataCellList:
            case PaletteContentStyle.GridDataCellSheet:
            case PaletteContentStyle.GridDataCellCustom1:
            case PaletteContentStyle.GridDataCellCustom2:
            case PaletteContentStyle.GridDataCellCustom3:
                if (state is PaletteState.CheckedNormal or PaletteState.CheckedTracking or PaletteState.CheckedPressed)
                {
                    return BaseColors?.HeaderText ?? base.GetContentLongTextColor2(style, state);
                }
                break;
        }

        return base.GetContentLongTextColor2(style, state);
    }
    #endregion
}
