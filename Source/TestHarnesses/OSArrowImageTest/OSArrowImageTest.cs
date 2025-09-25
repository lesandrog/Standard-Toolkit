using Krypton.Toolkit;

namespace OSArrowImageTest;

public partial class OSArrowImageTest : KryptonForm
{
    public OSArrowImageTest()
    {
        InitializeComponent();
        LoadOSArrowImages();
    }

    private void LoadOSArrowImages()
    {
        // Set OS-dependent arrow images on buttons
        btnUp.Values.Image = OSArrowImageHelper.GetOSArrowImageOrDefault(OSArrowDirection.Up, IconSize.Small);
        btnDown.Values.Image = OSArrowImageHelper.GetOSArrowImageOrDefault(OSArrowDirection.Down, IconSize.Small);
        btnLeft.Values.Image = OSArrowImageHelper.GetOSArrowImageOrDefault(OSArrowDirection.Left, IconSize.Small);
        btnRight.Values.Image = OSArrowImageHelper.GetOSArrowImageOrDefault(OSArrowDirection.Right, IconSize.Small);

        // Enable OS-dependent arrow on command link button (defaults to right arrow)
        cmdLinkTest.UACShieldIcon.DisplayOSArrow = true;
        cmdLinkTest.UACShieldIcon.ArrowDirection = OSArrowDirection.Right;

        // Display OS information
        var osInfo = $"Windows {Environment.OSVersion.Version.Major}.{Environment.OSVersion.Version.Minor}";
        if (OSUtilities.IsWindowsEleven) osInfo += " (Windows 11)";
        else if (OSUtilities.IsWindowsTen) osInfo += " (Windows 10)";
        else if (OSUtilities.IsWindowsEightPointOne) osInfo += " (Windows 8.1)";
        else if (OSUtilities.IsWindowsEight) osInfo += " (Windows 8)";
        else if (OSUtilities.IsWindowsSeven) osInfo += " (Windows 7)";

        lblOSInfo.Values.Text = $"OS Info: {osInfo}";
        lblAvailability.Values.Text = $"OS Arrow Images Available: {OSArrowImageHelper.AreOSArrowImagesAvailable()}";
    }
}