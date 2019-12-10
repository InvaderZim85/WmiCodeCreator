//-------------------------------------------------------------------------
// Handles the event when the namespace is changed on the query tab.
//
//-------------------------------------------------------------------------
private void NamespaceValue_SelectedIndexChanged(object sender, System.EventArgs e)
{
    this.ClassList.Items.Clear();
    this.ClassList.Text = "";
    this.PropertyList.Items.Clear();
    this.ValueList.Items.Clear();
    this.CodeText.Text = "";
    this.ClassStatus.Text = "";
    this.PropertyStatus.Text = "";
    this.ValueStatus.Text = "";
    this.QueryLinkLabel.Visible = false;

    // Populate the class list.
    System.Threading.ThreadPool.
        QueueUserWorkItem(
        new System.Threading.WaitCallback(
        this.AddClassesToList));
}