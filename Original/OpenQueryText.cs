//-------------------------------------------------------------------------
// Handles the event when the OpenQueryText button is clicked. This opens
// the code (in the CodeText text box) in Notepad. 
//-------------------------------------------------------------------------
private void OpenQueryText_Click(object sender, System.EventArgs e)
{
    string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\WMICodeCreator\\MyWMIQuery.vbs";

    if(this.VbNetMenuItem.Checked)
    {
        path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\WMICodeCreator\\MyWMIQuery.vb";
    }
    else if(this.CSharpMenuItem.Checked)
    {
        path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\WMICodeCreator\\MyWMIQuery.cs";
    }
    else if(this.VbsMenuItem.Checked)
    {
        path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\WMICodeCreator\\MyWMIQuery.vbs";
    };


    OpenTextInNotepad(path, this.CodeText.Text);
}