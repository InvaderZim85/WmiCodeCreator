//-------------------------------------------------------------------------
// Opens the specified code text in a specified file (path) in
// Notepad.
//-------------------------------------------------------------------------
private void OpenTextInNotepad(string path, string text)
{
    DirectoryInfo di = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\WMICodeCreator");
    try 
    {
        // Determines whether the directory exists.
        if (di.Exists) 
        {
            //Do nothing.
            ;
        }
        else
        {
            // Creates the directory.
            di.Create();
        }

        // Deletes the file if it exists.
        if (File.Exists(path)) 
        {
            File.Delete(path);
        }

        // Creates the file.
        using (FileStream fs = File.Create(path)) 
        {
            Byte[] info = new UTF8Encoding(true).GetBytes(text);
            // Add information to the file.
            fs.Write(info, 0, info.Length);
        }

        //Get the object on which the method is invoked.
        ManagementClass processClass = new ManagementClass("Win32_Process");

        //Get an in-parameter object for this method
        ManagementBaseObject inParams = processClass.GetMethodParameters("Create");

        //Fill in the in-parameter values.
        inParams["CommandLine"] = Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\notepad.exe \"" + path + "\"";
        
        //Execute the method.
        ManagementBaseObject outParams = processClass.InvokeMethod ("Create", inParams, null);
    }
    catch (System.IO.IOException error)
    {
        MessageBox.Show("Failed to create process. " + error.Message);
    }
    catch (System.Management.ManagementException mError)
    {
        MessageBox.Show("Failed to create process. " + mError.Message);
    }
}