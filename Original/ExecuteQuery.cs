//-------------------------------------------------------------------------
// Handles the event when the ExecuteQueryButton button is clicked.  This 
// compiles the code (in C# or VB .NET) and runs it. 
//-------------------------------------------------------------------------
private void ExecuteQueryButton_Click(object sender, System.EventArgs e)
{
    // Generates the file that contains the code.
    string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\WMICodeCreator\\MyWMIQuery_Script.vbs";

    if(this.VbNetMenuItem.Checked)
    {
        path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\WMICodeCreator\\MyWMIQuery_VB.vb";
    }
    else if(this.CSharpMenuItem.Checked)
    {
        path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\WMICodeCreator\\MyWMIQuery_CS.cs";
    }
    else if(this.VbsMenuItem.Checked)
    {
        path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\WMICodeCreator\\MyWMIQuery_Script.vbs";
    };

    
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
            Byte[] info = new UTF8Encoding(true).GetBytes(this.CodeText.Text);
            // Add information to the file.
            fs.Write(info, 0, info.Length);
        }
    
        //Gets the object on which the method is invoked.
        ManagementClass processClass = new ManagementClass("Win32_Process");

        //Gets an in-parameter object for this method.
        ManagementBaseObject inParams = processClass.GetMethodParameters("Create");

        if(this.VbsMenuItem.Checked)
        {
            //Fill in the in-parameter values.
            inParams["CommandLine"] = "cmd /k cscript.exe \"" + path + "\"";
        }
        else if(this.CSharpMenuItem.Checked)
        {
            if(File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\WMICodeCreator\\MyQuery_CS.exe"))
            {
                File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\WMICodeCreator\\MyQuery_CS.exe");
            }

            string frameworkVersion = NativeMethods.SystemDirectory();

            //Fill in the in-parameter values.
            inParams["CommandLine"] = "cmd /k cd " + frameworkVersion + " & csc.exe /target:exe /r:System.Management.dll /r:System.Data.dll /r:System.Drawing.dll /r:System.Drawing.Design.dll /r:System.Windows.Forms.dll /r:System.dll /out:\"" + Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\WMICodeCreator\\MyQuery_CS.exe\" \"" + path +
                "\" & \"" + Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\WMICodeCreator\\MyQuery_CS.exe\"";
        }
        else if(this.VbNetMenuItem.Checked)
        {
            if(File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\WMICodeCreator\\MyQuery_VB.exe"))
            {
                File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\WMICodeCreator\\MyQuery_VB.exe");
            }

            string frameworkVersion = NativeMethods.SystemDirectory();

            //Fill in the in-parameter values.
            inParams["CommandLine"] = "cmd /k cd " + frameworkVersion + " & vbc.exe /target:exe /r:System.Management.dll /r:System.Data.dll /r:System.Drawing.dll /r:System.Drawing.Design.dll /r:System.Windows.Forms.dll /r:System.dll /out:\"" + Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\WMICodeCreator\\MyQuery_VB.exe\" \"" + path +
                "\" & \"" + Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\WMICodeCreator\\MyQuery_VB.exe\"";
        }
        // Executes the process Create method and runs the code.
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