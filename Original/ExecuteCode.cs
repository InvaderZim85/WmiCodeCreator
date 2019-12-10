//-------------------------------------------------------------------------
// Handles the event when the ExecuteMethodButton button is clicked. This 
// compiles the code (in C# or VB .NET) and runs it. 
//-------------------------------------------------------------------------
private void ExecuteMethodButton_Click(object sender, System.EventArgs e)
{
    string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\WMICodeCreator\\MyWMIMethod_Script.vbs";

    if(this.VbNetMenuItem.Checked)
    {
        path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\WMICodeCreator\\MyWMIMethod_VB.vb";
    }
    else if(this.CSharpMenuItem.Checked)
    {
        path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\WMICodeCreator\\MyWMIMethod_CS.cs";
    }
    else if(this.VbsMenuItem.Checked)
    {
        path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\WMICodeCreator\\MyWMIMethod_Script.vbs";
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
            Byte[] info = new UTF8Encoding(true).GetBytes(this.CodeText_m.Text);
            // Add information to the file.
            fs.Write(info, 0, info.Length);
        }

        //Gets the object on which the method isinvoked.
        ManagementClass processClass = new ManagementClass("Win32_Process");

        //Get an in-parameter object for this method.
        ManagementBaseObject inParams = processClass.GetMethodParameters("Create");

        if(this.VbsMenuItem.Checked)
        {
            //Fills in the in-parameter values.
            inParams["CommandLine"] = "cmd /k cscript.exe \"" + path + "\"";
        }
        else if(this.CSharpMenuItem.Checked)
        {
            if(File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\WMICodeCreator\\MyWMIMethod_CS.exe"))
            {
                File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\WMICodeCreator\\MyWMIMethod_CS.exe");
            }

            string frameworkVersion = NativeMethods.SystemDirectory();

            //Fills in the in-parameter values.
            inParams["CommandLine"] = "cmd /k cd " + frameworkVersion + " & csc.exe /target:exe /r:System.Management.dll /r:System.Data.dll /r:System.Drawing.dll /r:System.Drawing.Design.dll /r:System.Windows.Forms.dll /r:System.dll /out:\"" + Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\WMICodeCreator\\MyWMIMethod_CS.exe\" \"" + path +
                "\" & \"" + Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\WMICodeCreator\\MyWMIMethod_CS.exe\"";
        }
        else if(this.VbNetMenuItem.Checked)
        {
            if(File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\WMICodeCreator\\MyWMIMethod_VB.exe"))
            {
                File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\WMICodeCreator\\MyWMIMethod_VB.exe");
            }

            string frameworkVersion = NativeMethods.SystemDirectory();

            //Fills in the in-parameter values.
            inParams["CommandLine"] = "cmd /k cd " + frameworkVersion + " & vbc.exe /target:exe /r:System.Management.dll /r:System.Data.dll /r:System.Drawing.dll /r:System.Drawing.Design.dll /r:System.Windows.Forms.dll /r:System.dll /out:\"" + Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\WMICodeCreator\\MyWMIMethod_VB.exe\" \"" + path +
                "\" & \"" + Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\WMICodeCreator\\MyWMIMethod_VB.exe\"";
        }

        //Executes the method.
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