#region BSD License
/*
 *
 *  New BSD 3-Clause License (https://github.com/Krypton-Suite/Standard-Toolkit/blob/master/LICENSE)
 *  Modifications by Peter Wagner(aka Wagnerp) & Simon Coghlan(aka Smurf-IV), et al. 2024 - 2025. All rights reserved.
 *
 */
#endregion

namespace Krypton.Toolkit;

/// <summary>
/// Helper class for extracting OS-specific arrow images from imageres.dll with fallback to local resources.
/// Provides OS-dependent default arrow images based on Windows version.
/// </summary>
public static class OSArrowImageHelper
{
    #region Public Methods

    /// <summary>
    /// Gets the OS-specific arrow image for the specified direction and size.
    /// </summary>
    /// <param name="direction">The arrow direction (Up, Down, Left, Right).</param>
    /// <param name="size">The desired size of the arrow image.</param>
    /// <param name="selectionStrategy">The strategy for selecting fallback icons.</param>
    /// <returns>The arrow image as a Bitmap, or null if extraction fails.</returns>
    public static Bitmap? GetOSArrowImage(OSArrowDirection direction, IconSize size, IconSelectionStrategy selectionStrategy = IconSelectionStrategy.OSBased)
    {
        // Try to extract from imageres.dll first based on OS version
        var osImage = ExtractOSArrowFromImageres(direction, size, selectionStrategy);
        if (osImage != null)
        {
            return osImage;
        }

        // Fall back to embedded resources
        return GetFallbackArrowImage(direction, size);
    }

    /// <summary>
    /// Gets the OS-specific arrow image, guaranteed to return a valid image.
    /// </summary>
    /// <param name="direction">The arrow direction.</param>
    /// <param name="size">The desired size of the arrow image.</param>
    /// <param name="selectionStrategy">The strategy for selecting fallback icons.</param>
    /// <returns>The arrow image as a Bitmap (never null).</returns>
    public static Bitmap GetOSArrowImageOrDefault(OSArrowDirection direction, IconSize size, IconSelectionStrategy selectionStrategy = IconSelectionStrategy.OSBased)
    {
        var image = GetOSArrowImage(direction, size, selectionStrategy);
        return image ?? GetFallbackArrowImage(direction, size) ?? CreateDefaultArrowImage(direction, size);
    }

    /// <summary>
    /// Determines if OS-specific arrow images are available for the current OS version.
    /// </summary>
    /// <returns>True if OS-specific images are available, false otherwise.</returns>
    public static bool AreOSArrowImagesAvailable()
    {
        // Test with a simple down arrow to see if imageres.dll is accessible
        try
        {
            var testImage = ExtractOSArrowFromImageres(OSArrowDirection.Down, IconSize.Small, IconSelectionStrategy.OSBased);
            testImage?.Dispose();
            return testImage != null;
        }
        catch
        {
            return false;
        }
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Extracts an OS-specific arrow from imageres.dll based on Windows version and direction.
    /// </summary>
    /// <param name="direction">The arrow direction.</param>
    /// <param name="size">The desired size.</param>
    /// <param name="selectionStrategy">The selection strategy.</param>
    /// <returns>The arrow image as a Bitmap, or null if extraction fails.</returns>
    private static Bitmap? ExtractOSArrowFromImageres(OSArrowDirection direction, IconSize size, IconSelectionStrategy selectionStrategy)
    {
        try
        {
            var iconId = GetArrowIconIdForOS(direction, selectionStrategy);
            if (iconId == null)
            {
                return null;
            }

            var icon = GraphicsExtensions.ExtractIconFromImageres((int)iconId, size, selectionStrategy);
            return icon?.ToBitmap();
        }
        catch
        {
            return null;
        }
    }

    /// <summary>
    /// Gets the appropriate arrow icon ID from imageres.dll based on OS version and direction.
    /// </summary>
    /// <param name="direction">The arrow direction.</param>
    /// <param name="selectionStrategy">The selection strategy.</param>
    /// <returns>The icon ID, or null if no appropriate icon is found.</returns>
    private static ImageresIconID? GetArrowIconIdForOS(OSArrowDirection direction, IconSelectionStrategy selectionStrategy)
    {
        // Use OS-based selection to determine the best icon style
        if (selectionStrategy == IconSelectionStrategy.OSBased)
        {
            // For Windows 10 and later, use modern navigation icons
            if (OSUtilities.IsWindowsTen || OSUtilities.IsWindowsEleven)
            {
                return direction switch
                {
                    OSArrowDirection.Up => ImageresIconID.NavigationUp,
                    OSArrowDirection.Down => ImageresIconID.NavigationDown,
                    OSArrowDirection.Left => ImageresIconID.NavigationLeft,
                    OSArrowDirection.Right => ImageresIconID.NavigationRight,
                    _ => null
                };
            }

            // For Windows 8.x, use different navigation style
            if (OSUtilities.IsWindowsEight || OSUtilities.IsWindowsEightPointOne)
            {
                return direction switch
                {
                    OSArrowDirection.Up => ImageresIconID.NavigationPageUp,
                    OSArrowDirection.Down => ImageresIconID.NavigationPageDown,
                    OSArrowDirection.Left => ImageresIconID.NavigationPrevious,
                    OSArrowDirection.Right => ImageresIconID.NavigationNext,
                    _ => null
                };
            }

            // For Windows 7 and earlier, use classic navigation icons
            if (OSUtilities.IsWindowsSeven)
            {
                return direction switch
                {
                    OSArrowDirection.Up => ImageresIconID.NavigationTop,
                    OSArrowDirection.Down => ImageresIconID.NavigationBottom,
                    OSArrowDirection.Left => ImageresIconID.NavigationBack,
                    OSArrowDirection.Right => ImageresIconID.NavigationForward,
                    _ => null
                };
            }
        }

        // Default fallback for any OS
        return direction switch
        {
            OSArrowDirection.Up => ImageresIconID.NavigationUp,
            OSArrowDirection.Down => ImageresIconID.NavigationDown,
            OSArrowDirection.Left => ImageresIconID.NavigationLeft,
            OSArrowDirection.Right => ImageresIconID.NavigationRight,
            _ => null
        };
    }

    /// <summary>
    /// Gets a fallback arrow image from embedded resources.
    /// </summary>
    /// <param name="direction">The arrow direction.</param>
    /// <param name="size">The desired size.</param>
    /// <returns>The fallback arrow image, or null if not available.</returns>
    private static Bitmap? GetFallbackArrowImage(OSArrowDirection direction, IconSize size)
    {
        try
        {
            // Use existing embedded arrow resources as fallback
            return direction switch
            {
                OSArrowDirection.Up => GenericWhiteImageResources.WhiteArrowUpButton?.Clone() as Bitmap,
                OSArrowDirection.Down => GenericWhiteImageResources.WhiteArrowDownButton?.Clone() as Bitmap,
                OSArrowDirection.Left => GenericWhiteImageResources.WhiteArrowLeftButton?.Clone() as Bitmap,
                OSArrowDirection.Right => GenericWhiteImageResources.WhiteArrowRightButton?.Clone() as Bitmap,
                _ => null
            };
        }
        catch
        {
            return null;
        }
    }

    /// <summary>
    /// Creates a default arrow image when no other sources are available.
    /// </summary>
    /// <param name="direction">The arrow direction.</param>
    /// <param name="size">The desired size.</param>
    /// <returns>A programmatically generated arrow image.</returns>
    private static Bitmap CreateDefaultArrowImage(OSArrowDirection direction, IconSize size)
    {
        var pixelSize = (int)size;
        var bitmap = new Bitmap(pixelSize, pixelSize, PixelFormat.Format32bppArgb);
        
        using (var g = Graphics.FromImage(bitmap))
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(Color.Transparent);

            var arrowColor = Color.Black; // Default arrow color
            using var brush = new SolidBrush(arrowColor);

            // Calculate arrow points based on direction
            var points = GetArrowPoints(direction, pixelSize);
            g.FillPolygon(brush, points);
        }

        return bitmap;
    }

    /// <summary>
    /// Gets the arrow points for drawing based on direction and size.
    /// </summary>
    /// <param name="direction">The arrow direction.</param>
    /// <param name="size">The size of the arrow area.</param>
    /// <returns>Array of points defining the arrow shape.</returns>
    private static Point[] GetArrowPoints(OSArrowDirection direction, int size)
    {
        var center = size / 2;
        var quarter = size / 4;
        var threeQuarter = size * 3 / 4;

        return direction switch
        {
            OSArrowDirection.Up => new[]
            {
                new Point(center, quarter),
                new Point(quarter, threeQuarter),
                new Point(threeQuarter, threeQuarter)
            },
            OSArrowDirection.Down => new[]
            {
                new Point(quarter, quarter),
                new Point(threeQuarter, quarter),
                new Point(center, threeQuarter)
            },
            OSArrowDirection.Left => new[]
            {
                new Point(quarter, center),
                new Point(threeQuarter, quarter),
                new Point(threeQuarter, threeQuarter)
            },
            OSArrowDirection.Right => new[]
            {
                new Point(quarter, quarter),
                new Point(quarter, threeQuarter),
                new Point(threeQuarter, center)
            },
            _ => new[] { new Point(0, 0), new Point(size, 0), new Point(size / 2, size) }
        };
    }

    #endregion
}

/// <summary>
/// Defines the direction of an arrow image.
/// </summary>
public enum OSArrowDirection
{
    /// <summary>Arrow pointing up</summary>
    Up,
    /// <summary>Arrow pointing down</summary>
    Down,
    /// <summary>Arrow pointing left</summary>
    Left,
    /// <summary>Arrow pointing right</summary>
    Right
}
