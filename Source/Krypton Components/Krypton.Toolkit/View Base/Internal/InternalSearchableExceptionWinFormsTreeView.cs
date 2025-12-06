#region BSD License
/*
 *
 *  New BSD 3-Clause License (https://github.com/Krypton-Suite/Standard-Toolkit/blob/master/LICENSE)
 *  Modifications by Peter Wagner(aka Wagnerp), Simon Coghlan(aka Smurf-IV), Giduac, et al. 2025 - 2026. All rights reserved.
 *
 */
#endregion

namespace Krypton.Toolkit;

internal partial class InternalSearchableExceptionWinFormsTreeView : UserControl
{
    #region Instance Fields

    private bool _showSearchFeatures;

    private readonly List<TreeNode> _originalNodes = new List<TreeNode>();

    private readonly List<string> _searchResults = new List<string>();

    #endregion

    #region Public

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool ShowSearchFeatures
    {
        get => _showSearchFeatures;
        set
        {
            _showSearchFeatures = value;

            Invalidate();
        }
    }

    public Exception? SelectedException => etvExceptionOutline.SelectedException;

    public TreeView Tree => etvExceptionOutline;

    public KryptonTextBox SearchBox => iksbSearch;

    #endregion

    #region Events

    public event TreeViewEventHandler? NodeSelected
    {
        add => etvExceptionOutline.AfterSelect += value;
        remove => etvExceptionOutline.AfterSelect -= value;
    }

    #endregion

    #region Identity

    public InternalSearchableExceptionWinFormsTreeView()
    {
        InitializeComponent();

        kwlblResults.Text = KryptonManager.Strings.ExceptionDialogStrings.TypeToSearch;

        etvExceptionOutline.DrawMode = TreeViewDrawMode.OwnerDrawText;
        etvExceptionOutline.DrawNode += EtvExceptionOutline_DrawNode;
    }

    #endregion

    #region Implementation

    public void Populate(Exception exception)
    {
        etvExceptionOutline.Populate(exception);
        _originalNodes.Clear();
        _searchResults.Clear();

        foreach (TreeNode node in etvExceptionOutline.Nodes)
        {
            _originalNodes.Add((TreeNode)node.Clone());
            
            // Populate search results with all node text
            foreach (TreeNode flattenedNode in FlattenTree(node))
            {
                if (!string.IsNullOrWhiteSpace(flattenedNode.Text) && !_searchResults.Contains(flattenedNode.Text))
                {
                    _searchResults.Add(flattenedNode.Text);
                }
            }
        }

        // Setup search suggestions
        iksbSearch.SetSearchSuggestions(_searchResults);
    }

    private void Search(string searchQueryText)
    {
        string searchText = searchQueryText.Trim().ToLowerInvariant();

        etvExceptionOutline.BeginUpdate();
        etvExceptionOutline.Nodes.Clear();

        int matchCount = 0;

        if (string.IsNullOrWhiteSpace(searchText))
        {
            // Reset: restore all original nodes
            foreach (TreeNode original in _originalNodes)
            {
                etvExceptionOutline.Nodes.Add((TreeNode)original.Clone());
            }

            // Reset label and styling
            kwlblResults.Text = KryptonManager.Strings.ExceptionDialogStrings.TypeToSearch;
            kwlblResults.StateCommon.TextColor = Color.Gray;

            etvExceptionOutline.EndUpdate();

            // Select first node if available
            if (etvExceptionOutline.Nodes.Count > 0)
            {
                etvExceptionOutline.SelectedNode = etvExceptionOutline.Nodes[0];
            }

            return;
        }

        // If searching
        foreach (TreeNode original in _originalNodes)
        {
            TreeNode? filtered = FilterAndCloneNode(original, searchText, ref matchCount);
            if (filtered != null)
            {
                etvExceptionOutline.Nodes.Add(filtered);
            }
        }

        etvExceptionOutline.EndUpdate();

        // Update label
        if (string.IsNullOrWhiteSpace(searchText))
        {
            kwlblResults.Text = KryptonManager.Strings.ExceptionDialogStrings.TypeToSearch;
        }
        else if (matchCount == 0)
        {
            kwlblResults.Text = KryptonManager.Strings.ExceptionDialogStrings.NoMatchesFound;
        }
        else
        {
            kwlblResults.Text = $@"{matchCount} {KryptonManager.Strings.ExceptionDialogStrings.Result}{(matchCount == 1 ? "" : $"{KryptonManager.Strings.ExceptionDialogStrings.ResultsAppendage}")} {KryptonManager.Strings.ExceptionDialogStrings.ResultsFoundAppendage}";
        }

        kwlblResults.StateCommon.TextColor = SystemColors.ControlText;

        // Auto-select match or fallback
        var firstMatch = etvExceptionOutline.Nodes
            .Cast<TreeNode>()
            .SelectMany(FlattenTree)
            .FirstOrDefault(n => n.BackColor == Color.LightYellow);

        etvExceptionOutline.SelectedNode = firstMatch ??
                                           (etvExceptionOutline.Nodes.Count > 0 ? etvExceptionOutline.Nodes[0] : null);

        kwlblResults.StateCommon.TextColor = string.IsNullOrWhiteSpace(searchQueryText) ? Color.Gray : Color.Empty;
    }

    private IEnumerable<TreeNode> FlattenTree(TreeNode root)
    {
        yield return root;

        foreach (TreeNode child in root.Nodes)
        {
            foreach (var descendant in FlattenTree(child))
            {
                yield return descendant;
            }
        }
    }

    private TreeNode? FilterAndCloneNode(TreeNode node, string searchQuery, ref int matchCount)
    {
        bool isMatch = node.Text.ToLowerInvariant().Contains(searchQuery);
        TreeNode clone = (TreeNode)node.Clone();
        clone.Nodes.Clear();

        foreach (TreeNode child in node.Nodes)
        {
            TreeNode? filteredChild = FilterAndCloneNode(child, searchQuery, ref matchCount);
            if (filteredChild != null)
            {
                clone.Nodes.Add(filteredChild);
            }
        }

        if (isMatch || clone.Nodes.Count > 0)
        {
            if (isMatch)
            {
                matchCount++;
                clone.BackColor = Color.LightYellow;
                clone.ForeColor = Color.Black;
                clone.NodeFont = new Font(etvExceptionOutline.Font, FontStyle.Bold);
            }
            else
            {
                clone.BackColor = Color.White;
                clone.ForeColor = etvExceptionOutline.ForeColor;
                clone.NodeFont = etvExceptionOutline.Font;
            }

            return clone;
        }

        return null;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        if (ShowSearchFeatures)
        {
            SearchBox.Visible = true;
            kwlblResults.Visible = true;
        }
        else
        {
            SearchBox.Visible = false;
            kwlblResults.Visible = false;
        }
    }

    private void iksbSearch_Search(object sender, SearchEventArgs e) => Search(e.SearchText);

    private void EtvExceptionOutline_DrawNode(object? sender, DrawTreeNodeEventArgs e)
    {
        if (e.Node == null)
        {
            return;
        }

        Color backColor = e.Node.BackColor;
        Color foreColor = e.Node.ForeColor;
        Font? nodeFont = e.Node.NodeFont;

        if (backColor == Color.Empty)
        {
            backColor = etvExceptionOutline.BackColor;
        }

        if (foreColor == Color.Empty)
        {
            foreColor = etvExceptionOutline.ForeColor;
        }

        if (nodeFont == null)
        {
            nodeFont = etvExceptionOutline.Font;
        }

        TextFormatFlags flags = TextFormatFlags.GlyphOverhangPadding | TextFormatFlags.VerticalCenter | TextFormatFlags.Left;

        if (e.State.HasFlag(TreeNodeStates.Selected))
        {
            backColor = SystemColors.Highlight;
            foreColor = SystemColors.HighlightText;
        }
        else if (e.State.HasFlag(TreeNodeStates.Hot))
        {
            backColor = SystemColors.HotTrack;
            foreColor = SystemColors.HighlightText;
        }

        Rectangle bounds = e.Bounds;
        e.Graphics.FillRectangle(new SolidBrush(backColor), bounds);
        TextRenderer.DrawText(e.Graphics, e.Node.Text, nodeFont, bounds, foreColor, flags);

        e.DrawDefault = false;
    }

    #endregion
}