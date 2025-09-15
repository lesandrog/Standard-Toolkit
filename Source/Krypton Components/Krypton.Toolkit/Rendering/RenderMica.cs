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
/// Custom renderer for Mica material effects with enhanced subtle transparency support.
/// Provides smooth gradients and semi-transparent surfaces inspired by Windows 11 Fluent Design.
/// Features more subtle effects than Acrylic for better performance and visual harmony.
/// </summary>
public class RenderMica : RenderMicrosoft365
{
    #region Identity

    /// <summary>
    /// Initialize a new instance of the RenderMica class.
    /// </summary>
    public RenderMica()
    {
    }

    #endregion

    #region Override Methods

    /// <summary>
    /// Evaluate if transparent painting is needed for background palette.
    /// </summary>
    /// <param name="paletteBack">Background palette to test.</param>
    /// <param name="state">Element state associated with palette.</param>
    /// <returns>True if transparent painting required.</returns>
    public override bool EvalTransparentPaint(IPaletteBack paletteBack, PaletteState state)
    {
        // Always enable transparency for Mica effects (more subtle than Acrylic)
        return true;
    }


    #endregion

    #region Helper Methods

    /// <summary>
    /// Creates a Mica-style brush with enhanced subtle transparency effects.
    /// </summary>
    /// <param name="rect">Target rectangle.</param>
    /// <param name="color1">Primary color.</param>
    /// <param name="color2">Secondary color.</param>
    /// <param name="orientation">Gradient orientation.</param>
    /// <returns>Mica brush.</returns>
    private static Brush CreateMicaBrush(Rectangle rect, Color color1, Color color2, Orientation orientation)
    {
        // For Mica effect, use very subtle gradients (more subtle than Acrylic)
        if (color1.A < 255 || color2.A < 255)
        {
            // Create gradient with subtle transparency
            var gradientRect = orientation == Orientation.Vertical 
                ? new RectangleF(rect.X, rect.Y, rect.Width, rect.Height)
                : new RectangleF(rect.X, rect.Y, rect.Width, rect.Height);
                
            return new LinearGradientBrush(gradientRect, color1, color2, 
                orientation == Orientation.Vertical ? 90f : 0f);
        }
        else
        {
            // Solid color brush
            return new SolidBrush(color1);
        }
    }

    /// <summary>
    /// Draws a Mica-style border with subtle transparency.
    /// </summary>
    /// <param name="context">Rendering context.</param>
    /// <param name="rect">Target rectangle.</param>
    /// <param name="borderColor">Border color.</param>
    /// <param name="state">Element state.</param>
    private static void DrawMicaBorder(RenderContext context, Rectangle rect, Color borderColor, PaletteState state)
    {
        // Create very subtle border effect (more subtle than Acrylic)
        var borderPen = new Pen(Color.FromArgb(Math.Min((int)borderColor.A, 100), borderColor.R, borderColor.G, borderColor.B), 1f);
        
        try
        {
            // Draw border with Mica effect
            context.Graphics.DrawRectangle(borderPen, rect.X, rect.Y, rect.Width - 1, rect.Height - 1);
        }
        finally
        {
            borderPen.Dispose();
        }
    }

    /// <summary>
    /// Applies Mica blur effect to a region (placeholder for future Windows API integration).
    /// </summary>
    /// <param name="context">Rendering context.</param>
    /// <param name="rect">Target rectangle.</param>
    /// <param name="intensity">Blur intensity (0.0 to 1.0).</param>
    private static void ApplyMicaBlur(RenderContext context, Rectangle rect, float intensity)
    {
        // This is a placeholder for future Windows API integration
        // For now, we rely on the subtle transparency effects from the palette colors
        // Future enhancement could integrate with Windows 11 Mica APIs
        
        // Note: True Mica blur would require:
        // 1. Windows 11+ APIs (SetWindowCompositionAttribute with Mica)
        // 2. Layered window support
        // 3. Hardware acceleration
        // 4. Desktop wallpaper integration
    }

    #endregion
}
