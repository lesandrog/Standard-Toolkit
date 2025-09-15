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
/// Custom renderer for acrylic material effects with enhanced transparency support.
/// Provides smooth gradients and semi-transparent surfaces inspired by Windows 10 Fluent Design.
/// </summary>
public class RenderAcrylic : RenderMicrosoft365
{
    #region Identity

    /// <summary>
    /// Initialize a new instance of the RenderAcrylic class.
    /// </summary>
    public RenderAcrylic()
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
        // Always enable transparency for acrylic effects
        return true;
    }


    #endregion

    #region Helper Methods

    /// <summary>
    /// Creates an acrylic-style brush with enhanced transparency effects.
    /// </summary>
    /// <param name="rect">Target rectangle.</param>
    /// <param name="color1">Primary color.</param>
    /// <param name="color2">Secondary color.</param>
    /// <param name="orientation">Gradient orientation.</param>
    /// <returns>Acrylic brush.</returns>
    private static Brush CreateAcrylicBrush(Rectangle rect, Color color1, Color color2, Orientation orientation)
    {
        // For acrylic effect, use subtle gradients
        if (color1.A < 255 || color2.A < 255)
        {
            // Create gradient with transparency
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
    /// Draws an acrylic-style border with subtle transparency.
    /// </summary>
    /// <param name="context">Rendering context.</param>
    /// <param name="rect">Target rectangle.</param>
    /// <param name="borderColor">Border color.</param>
    /// <param name="state">Element state.</param>
    private static void DrawAcrylicBorder(RenderContext context, Rectangle rect, Color borderColor, PaletteState state)
    {
        // Create subtle border effect
        var borderPen = new Pen(Color.FromArgb(Math.Min((int)borderColor.A, 120), borderColor.R, borderColor.G, borderColor.B), 1f);
        
        try
        {
            // Draw border with acrylic effect
            context.Graphics.DrawRectangle(borderPen, rect.X, rect.Y, rect.Width - 1, rect.Height - 1);
        }
        finally
        {
            borderPen.Dispose();
        }
    }

    /// <summary>
    /// Applies acrylic blur effect to a region (placeholder for future Windows API integration).
    /// </summary>
    /// <param name="context">Rendering context.</param>
    /// <param name="rect">Target rectangle.</param>
    /// <param name="intensity">Blur intensity (0.0 to 1.0).</param>
    private static void ApplyAcrylicBlur(RenderContext context, Rectangle rect, float intensity)
    {
        // This is a placeholder for future Windows API integration
        // For now, we rely on the transparency effects from the palette colors
        // Future enhancement could integrate with DirectComposition or similar APIs
        
        // Note: True acrylic blur would require:
        // 1. Windows 10+ APIs (DirectComposition, SetWindowCompositionAttribute)
        // 2. Layered window support
        // 3. Hardware acceleration
    }

    #endregion
}
