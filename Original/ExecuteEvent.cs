//-------------------------------------------------------------------------
// Handles the event when the ExecuteEventCodeButton button is clicked. This 
// compiles the code (in C# or VB .NET) and runs it. 
//-------------------------------------------------------------------------
private void ExecuteEventCodeButton_Click(object sender, System.EventArgs e)
{
    string code = this.CodeText_event.Text;

    if(this.GroupRemoteComputerMenu.Checked)
    {
        string delimStr = " ,\n";
        char [] delimiter = delimStr.ToCharArray();
        string [] split = this.TargetWindow.GetArrayOfComputers().Split(delimiter);
        
        string newStrComputer = "";
        string oldStrComputer = "";

        if(split.Length <= 25)
        {
            for(int i=0; i < split.Length; i++)
            {
                if(split[i].Trim().Length == 0 || split[i].Trim().Equals(" ") || split[i].Trim().Equals(",") || split[i].Trim().Equals("\n"))
                {
                    ;
                }
                else
                {

                    if(this.CSharpMenuItem.Checked)
                    {
                        newStrComputer = "string strComputer = \"" + split[i].Trim() + "\";";
                    }
                    else
                    {
                        newStrComputer = "strComputer = \"" + split[i].Trim() + "\"";
                    }
                    

                    string path = "";

                    if(this.VbNetMenuItem.Checked)
                    {
                        path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\WMICodeCreator\\MyWMIEvent_VB" + i + ".vb";
                    }
                    else if(this.CSharpMenuItem.Checked)
                    {
                        path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\WMICodeCreator\\MyWMIEvent_CS" + i + ".cs";
                    }
                    else if(this.VbsMenuItem.Checked)
                    {
                        path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\WMICodeCreator\\MyWMIEvent_Script" + i + ".vbs";
                    }

                    DirectoryInfo di = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\WMICodeCreator");
                    try 
                    {
                        // Determines whether the directory exists.
                        if (di.Exists) 
                        {
                            //Do nothing
                            ;
                        }
                        else
                        {
                            // Create the directory.
                            di.Create();
                        }

                        // Deletes the file if it exists.
                        if (File.Exists(path)) 
                        {
                            File.Delete(path);
                        }

                        if(i > 0)
                        {
                            this.CodeText_event.Text = this.CodeText_event.Text.Replace(oldStrComputer, newStrComputer);
                            oldStrComputer = newStrComputer;     
                        }
                        else
                        {
                            oldStrComputer = newStrComputer;
                        }

                        // Creates the file.
                        using (FileStream fs = File.Create(path)) 
                        {
                            Byte[] info = new UTF8Encoding(true).GetBytes(this.CodeText_event.Text);
                            // Add information to the file.
                            fs.Write(info, 0, info.Length);
                        }
        
                
                        //Get the object on which the method is invoked.
                        ManagementClass processClass = new ManagementClass("Win32_Process");

                        //Get an in-parameter object for this method.
                        ManagementBaseObject inParams = processClass.GetMethodParameters("Create");

                        if(this.VbsMenuItem.Checked)
                        {
                            //Fill in the in-parameter values.
                            inParams["CommandLine"] = "cmd /k cscript.exe \"" + path + "\"";
                        }
                        else if(this.CSharpMenuItem.Checked)
                        {
                            if(File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\WMICodeCreator\\MyWMIEvent" + i + "_CS.exe"))
                            {
                                File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\WMICodeCreator\\MyWMIEvent" + i + "_CS.exe");
                            }

                            string frameworkVersion = NativeMethods.SystemDirectory();

                            //Fills in the in-parameter values.
                            inParams["CommandLine"] = "cmd /k cd " + frameworkVersion + " & csc.exe /target:exe /r:System.Management.dll /r:System.Data.dll /r:System.Drawing.dll /r:System.Drawing.Design.dll /r:System.Windows.Forms.dll /r:System.dll /out:\"" + Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\WMICodeCreator\\MyWMIEvent" + i + "_CS.exe\" \"" + path +
                                "\" & \"" + Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\WMICodeCreator\\MyWMIEvent" + i + "_CS.exe\"";
                        }
                        else if(this.VbNetMenuItem.Checked)
                        {
                            if(File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\WMICodeCreator\\MyWMIEvent" + i + "_VB.exe"))
                            {
                                File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\WMICodeCreator\\MyWMIEvent" + i + "_VB.exe");
                            }

                            string frameworkVersion = NativeMethods.SystemDirectory();

                            //Fills in the in-parameter values.
                            inParams["CommandLine"] = "cmd /k cd " + frameworkVersion + " & vbc.exe /target:exe /r:System.Management.dll /r:System.Data.dll /r:System.Drawing.dll /r:System.Drawing.Design.dll /r:System.Windows.Forms.dll /r:System.dll /out:\"" + Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\WMICodeCreator\\MyWMIEvent" + i + "_VB.exe\" \"" + path +
                                "\" & \"" + Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\WMICodeCreator\\MyWMIEvent" + i + "_VB.exe\"";
                        }

                        // Executes the method.
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
            }
        }
        else
        {
            MessageBox.Show("Too many computers in the list. Only 25 computers in the list are allowed.");
            return;
        }
    }
    else
    {
        
        string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\WMICodeCreator\\MyWMIEvent_Script.vbs";

        if(this.VbNetMenuItem.Checked)
        {
            path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\WMICodeCreator\\MyWMIEvent_VB.vb";
        }
        else if(this.CSharpMenuItem.Checked)
        {
            path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\WMICodeCreator\\MyWMIEvent_CS.cs";
        }
        else if(this.VbsMenuItem.Checked)
        {
            path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\WMICodeCreator\\MyWMIEvent_Script.vbs";
        }

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
                    // Try to create the directory.
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
                Byte[] info = new UTF8Encoding(true).GetBytes(this.CodeText_event.Text);
                // Add information to the file.
                fs.Write(info, 0, info.Length);
            }
    
            // Get the object on which the method is invoked.
            ManagementClass processClass = new ManagementClass("Win32_Process");

            // Get an in-parameter object for this method.
            ManagementBaseObject inParams = processClass.GetMethodParameters("Create");

                if(this.VbsMenuItem.Checked)
                {
                    // Fill in the in-parameter values.
                    inParams["CommandLine"] = "cmd /k cscript.exe \"" + path + "\"";
                }
                else if(this.CSharpMenuItem.Checked)
                {
                    if(File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\WMICodeCreator\\MyWMIEvent_CS.exe"))
                    {
                        File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\WMICodeCreator\\MyWMIEvent_CS.exe");
                    }

                    string frameworkVersion = NativeMethods.SystemDirectory();

                    // Fill in the in-parameter values.
                    inParams["CommandLine"] = "cmd /k cd " + frameworkVersion + " & csc.exe /target:exe /r:System.Management.dll /r:System.Data.dll /r:System.Drawing.dll /r:System.Drawing.Design.dll /r:System.Windows.Forms.dll /r:System.dll /out:\"" + Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\WMICodeCreator\\MyWMIEvent_CS.exe\" \"" + path +
                        "\" & \"" + Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\WMICodeCreator\\MyWMIEvent_CS.exe\"";
                }
                else if(this.VbNetMenuItem.Checked)
                {
                    if(File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\WMICodeCreator\\MyWMIEvent_VB.exe"))
                    {
                        File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\WMICodeCreator\\MyWMIEvent_VB.exe");
                    }

                    string frameworkVersion = NativeMethods.SystemDirectory();

                    // Fill in the in-parameter values.
                    inParams["CommandLine"] = "cmd /k cd " + frameworkVersion + " & vbc.exe /target:exe /r:System.Management.dll /r:System.Data.dll /r:System.Drawing.dll /r:System.Drawing.Design.dll /r:System.Windows.Forms.dll /r:System.dll /out:\"" + Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\WMICodeCreator\\MyWMIEvent_VB.exe\" \"" + path +
                        "\" & \"" + Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\WMICodeCreator\\MyWMIEvent_VB.exe\"";
                }

            // Execute the method.
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

    this.CodeText_event.Text = code;
}