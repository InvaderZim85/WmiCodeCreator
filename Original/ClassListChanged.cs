//-------------------------------------------------------------------------
// Handles the event when the class is changed on the query tab.
//
//-------------------------------------------------------------------------
private void ClassList_SelectedIndexChanged(object sender, System.EventArgs e)
{
    // Clears out all the other information forms.
    this.PropertyList.Items.Clear();
    this.ValueList.Items.Clear();
    this.PropertyStatus.Text = "";
    this.ValueStatus.Text = "";
    this.CodeText.Text = "";

    // Display the link to the class documentation.
    // Note: This link changes if MSDN changes the URL for the WMI SDK documentation.
    if(this.QueryLinkLabel.Links.Count > 0)
    {
        this.QueryLinkLabel.Links[0].LinkData = "www.msdn.microsoft.com/library/default.asp?url=/library/en-us/wmisdk/wmi/" + this.ClassList.Text + ".asp";
    }
    else
    {
        this.QueryLinkLabel.Links.Add(0, this.MethodLinkLabel.Text.Length, "www.msdn.microsoft.com/library/default.asp?url=/library/en-us/wmisdk/wmi/" + this.ClassList.Text + ".asp");
    }

    // All the Win32 classes are documented and have links to the documentation.
    if(this.ClassList.Text.StartsWith("Win32"))
    {
        this.QueryLinkLabel.Visible = true;
    }
    else
    {
        this.QueryLinkLabel.Visible = false;
    }

    System.Threading.ThreadPool.
        QueueUserWorkItem(
        new System.Threading.WaitCallback(
        this.AddPropertiesToList));
}