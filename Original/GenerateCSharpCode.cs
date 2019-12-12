//-------------------------------------------------------------------------
// Generates the C# code in the query tab's generated code area.
// 
//-------------------------------------------------------------------------
private void GenerateCSharpQueryCode()
{
    try
    {
        string code = "";

        code =  
            "using System;" + Environment.NewLine +
            "using System.Management;" + Environment.NewLine +
            "using System.Windows.Forms;" + Environment.NewLine +
            Environment.NewLine +
            "namespace WMISample" + Environment.NewLine +
            "{" + Environment.NewLine +
            "    public class MyWMIQuery" + Environment.NewLine +
            "    {" + Environment.NewLine +
            "        public static void Main()" + Environment.NewLine +
            "        {" + Environment.NewLine +
            "            try" + Environment.NewLine +
            "            {" + Environment.NewLine +
            "                ManagementObjectSearcher searcher = " + Environment.NewLine +
            "                    new ManagementObjectSearcher(\"" + this.NamespaceValue.Text.Replace("\\", "\\\\") + "\", " + Environment.NewLine +
            "                    \"SELECT * FROM " + this.ClassList.Text;

        if(this.ValueList.SelectedItems.Count >= 1)
        {
            string updatedValue = ValueList.SelectedItems[0].ToString().Replace("\\", "\\\\").Trim();
            code = code + " WHERE " + updatedValue;
        }
    
        code = code + "\"); " + Environment.NewLine + Environment.NewLine +
            "                foreach (ManagementObject queryObj in searcher.Get())" + Environment.NewLine +
            "                {" + Environment.NewLine +
            "                    Console.WriteLine(\"-----------------------------------\");" + Environment.NewLine +
            "                    Console.WriteLine(\"" + this.ClassList.Text + " instance\");" + Environment.NewLine +
            "                    Console.WriteLine(\"-----------------------------------\");" + Environment.NewLine;

        ManagementClass m = new ManagementClass(this.NamespaceValue.Text, this.ClassList.Text, null);
    
        for( int i=0; i < PropertyList.SelectedItems.Count; i++)
        {
            if(m.Properties[PropertyList.SelectedItems[i].ToString()].IsArray)
            {
                // Determines the type of the array.
                string type = "";
                switch (m.Properties[PropertyList.SelectedItems[i].ToString()].Type.ToString())
                {
                    case "Char16":
                        type = "Char";
                        break;
                    case "Real64":
                        type = "Double";
                        break;
                    case "Real32":
                        type = "Single";
                        break;
                    case "SInt16":
                        type = "Int16";
                        break;
                    case "SInt32":
                        type = "Int32";
                        break;
                    case "SInt64":
                        type = "Int64";
                        break;
                    case "SInt8":
                        type = "SByte";
                        break;
                    case "UInt8":
                        type = "Byte";
                        break;
                    default:
                        type = m.Properties[PropertyList.SelectedItems[i].ToString()].Type.ToString();
                        break;
                }

                code = code + Environment.NewLine + 
                    "                    if(queryObj[\"" + PropertyList.SelectedItems[i].ToString() + "\"] == null)" + Environment.NewLine +
                    "                        Console.WriteLine(\"" + PropertyList.SelectedItems[i].ToString() + ": {0}\", queryObj[\"" + PropertyList.SelectedItems[i].ToString() + "\"]);" + Environment.NewLine +
                    "                    else" + System.Environment.NewLine +
                    "                    {" + System.Environment.NewLine +
                    "                        " + type + "[] arr" + PropertyList.SelectedItems[i].ToString() + " = (" + type + "[])(queryObj[\"" + PropertyList.SelectedItems[i].ToString() + "\"]);" + Environment.NewLine +
                    "                        foreach (" + type + " arrValue in arr" + PropertyList.SelectedItems[i].ToString() + ")" + System.Environment.NewLine +
                    "                        {" + System.Environment.NewLine +
                    "                            Console.WriteLine(\"" + PropertyList.SelectedItems[i].ToString() + ": {0}\", arrValue);" + Environment.NewLine +
                    "                        }" + System.Environment.NewLine +
                    "                    }" +
                    Environment.NewLine;
            }
            else
            {
                code = code + 
                    "                    Console.WriteLine(\"" + 
                    // Property from selection.
                    this.PropertyList.SelectedItems[i].ToString() +
                    ": {0}\", queryObj[\"" +
                    this.PropertyList.SelectedItems[i].ToString() + "\"]);" +
                    Environment.NewLine;
            }
        }

        code = code + 
            "                }" + Environment.NewLine +
            "            }" + Environment.NewLine +
            "            catch (ManagementException e)" + Environment.NewLine +
            "            {" + Environment.NewLine +
            "                MessageBox.Show(\"An error occurred while querying for WMI data: \" + e.Message);" + Environment.NewLine +
            "            }" + Environment.NewLine +
            "        }" + Environment.NewLine +
            "    }" + Environment.NewLine +
            "}";
        this.CodeText.Text = code;
    }
    catch (ManagementException mErr)
    {
        if(mErr.Message.Equals("Not found "))
            MessageBox.Show("Error creating code: WMI class not found.");
        else
            MessageBox.Show("Error creating code: " + mErr.Message.ToString());
    }
    
}