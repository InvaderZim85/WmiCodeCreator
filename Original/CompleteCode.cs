 
/*********************************************************************
*  This code is not supported under any Microsoft standard support program or service.
*  This code is provided AS IS without warranty of any kind. Microsoft further
*  disclaims all implied warranties including, without limitation, any implied warranties
*  of merchantability or of fitness for a particular purpose. The entire risk arising out
*  of the use or performance of this code and documentation remains with you.
*  In no event shall Microsoft, its authors, or anyone else involved in the creation,
*  production, or delivery of the code be liable for any damages whatsoever (including,
*  without limitation, damages for loss of business profits, business interruption,
*  loss of business information, or other pecuniary loss) arising out of the use of or
*  inability to use the code or documentation, even if Microsoft has been
*  advised of the possibility of such damages.
*
*  File:          WMICodeCreator.cs
*
*  Created:       May 2005
*  Version:       1.0
*
*  Description:   The WMI Code Creator is a WMI learning tool
*                 that creates WMI code examples in VBScript,
*                 C#, or VB .NET.  The examples either query for data
*                 from WMI classes, execute a method from a WMI class,
*                 or receive event notifications from WMI (or a WMI 
*                 event provider).
*
* Dependencies:   There are two (that I'm aware of):
*                 1. You must run the WMI Code Creator on a WMI-enabled
*                    computer. Any Windows operating system that has
*                    the number 2000 or higher in its name, or XP,
*                    is a safe bet.
*                 2. You must have version 1.1 or higher of the .NET Framework
*                    installed on your computer.
*
********************************************************************/

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Management;
using System.Data;
using System.IO;
using System.Text;
using System.Threading;
using System.Runtime.InteropServices;

[assembly: ComVisible(false)]
namespace WMICodeCreatorTools 
{
	//-----------------------------------------------------------------------------
    // This WMICodeCreator class generates a windows form application that
	// creates code to perform tasks in WMI based
	// on user input.
	//-----------------------------------------------------------------------------
    [ComVisible(false)]
    public class WMICodeCreator : 
        System.Windows.Forms.Form 
    {
        private System.Windows.Forms.Label NamespaceLabel1;
        private InParameterWindow[] InParameterArray;
        private EventQueryCondition[] EventConditionArray;
        private System.Windows.Forms.ListBox PropertyList;
        private System.Windows.Forms.Label ClassStatus;
        private System.Windows.Forms.Label PropertyStatus;
        private System.Windows.Forms.Label QueryClassesLabel;
        private System.Windows.Forms.Label ResultsLabel4;
        private System.Windows.Forms.TextBox CodeText;
        private System.Windows.Forms.ListBox ValueList;
        private System.Windows.Forms.Button ValueButton;
        private System.Windows.Forms.Label ResultsLabel5;
        private System.Windows.Forms.Label ValueStatus;
        private System.Windows.Forms.TabControl MainTabControl;
        private System.Windows.Forms.Label NamespaceLabel3;
        private System.Windows.Forms.Label ClassStatus_m;
        private System.Windows.Forms.Label MethodClassLabel;
        private System.Windows.Forms.TextBox CodeText_m;
        private System.Windows.Forms.Label MethodStatus;
        private System.Windows.Forms.Label ClassLabel2;
        private System.Windows.Forms.Label ResultsLabel2;
        private System.Windows.Forms.Label ResultsLabel3;
        private System.Windows.Forms.Label BrowseClassResults;
        private System.Windows.Forms.ListBox BrowseMethodList;
        private System.Windows.Forms.Button BrowseMethodButton;
        private System.Windows.Forms.Label BrowseMethodStatus;
        private System.Windows.Forms.ListBox BrowsePropertyList;
        private System.Windows.Forms.Button BrowsePropertyButton;
        private System.Windows.Forms.Label BrowsePropertyStatus;
        private System.Windows.Forms.ComboBox NamespaceValue_m;
        private System.Windows.Forms.ComboBox NamespaceValue;
        private System.Windows.Forms.ComboBox ClassList;
        private System.Windows.Forms.Label NamespaceLabel2;
        private System.Windows.Forms.Label EventClassListLabel;
        private System.Windows.Forms.ComboBox ClassList_event;
        private System.Windows.Forms.ComboBox NamespaceList_event;
        private System.Windows.Forms.Label ClassStatus_event;
        private System.Windows.Forms.TextBox SecondsBox;
        private System.Windows.Forms.Label PropertyValueLabel;
        private System.Windows.Forms.ComboBox ClassList_m;
        private System.Windows.Forms.ListBox InParameterBox;
        private System.Windows.Forms.ComboBox MethodList;
        private System.Windows.Forms.Label MethodsLabel;
        private System.Windows.Forms.Label InParameterLabel;
        private System.Windows.Forms.Label EventQueryConditionsLabel;
        private System.Windows.Forms.LinkLabel MethodLinkLabel;
        private System.Windows.Forms.LinkLabel QueryLinkLabel;
        private System.Windows.Forms.LinkLabel EventLinkLabel;
        private System.Windows.Forms.TextBox CodeText_event;
        private System.Windows.Forms.ComboBox BrowseNamespaceList;
        private System.Windows.Forms.ComboBox BrowseClassList;
        private System.Windows.Forms.Label NamespaceLabel4;
        private System.Windows.Forms.Label ResultsLabel1;
        private System.Windows.Forms.ListBox BrowseQualifierList;
        private System.Windows.Forms.Button BrowseQualifierButton;
        private System.Windows.Forms.Label BrowseQualiferStatus;
        private System.Windows.Forms.Button OpenQueryText;
        private System.Windows.Forms.Button OpenMethodText;
        private System.Windows.Forms.Button OpenEventText;
        private System.Windows.Forms.Button ExecuteQueryButton;
        private System.Windows.Forms.Button ExecuteMethodButton;
        private System.Windows.Forms.Label PropertyListLabel;
        private System.Windows.Forms.Label ScopeLabel;
        private System.Windows.Forms.MainMenu MainMenu;						
        private System.ComponentModel.Container 
            components = null;
        private System.Windows.Forms.ListBox KeyValueBox;
        private System.Windows.Forms.Label KeyValueLabel;
        private System.Windows.Forms.TextBox PropertyInformation;
        private System.Windows.Forms.TextBox MethodInformation;
        private System.Windows.Forms.TextBox BrowseClassDescription;
        private System.Windows.Forms.Label ClassDescriptionLabel;
        private System.Windows.Forms.Label PropertyDescriptionLabel;
        private System.Windows.Forms.Label MethodDescriptionLabel;
        private System.Windows.Forms.ComboBox TargetClassList_event;
        private System.Windows.Forms.ListBox PropertyList_event;
        private System.Windows.Forms.Label PollLabelEnd;
        private System.Windows.Forms.MenuItem CSharpMenuItem;
        private System.Windows.Forms.MenuItem VbNetMenuItem;
        private System.Windows.Forms.MenuItem VbsMenuItem;
        private System.Windows.Forms.CheckBox Asynchronous;
        private System.Windows.Forms.MenuItem LocalComputerMenu;
        private System.Windows.Forms.MenuItem RemoteComputerMenu;
        private System.Windows.Forms.MenuItem GroupRemoteComputerMenu;
        private System.Windows.Forms.Label GenerateCodeLabel2;
        private System.Windows.Forms.GroupBox CodeGroupBox;
        private System.Windows.Forms.GroupBox MethodCodeGroupBox;
        private System.Windows.Forms.Label GeneratedCodeLabel3;
        private System.Windows.Forms.GroupBox EventCodeGroupBox;
        private System.Windows.Forms.Label GenerateCodeLabel1;
        private System.Windows.Forms.Label BrowseNamespaceResults;
        private TargetComputerWindow TargetWindow;
        private System.Windows.Forms.Button ExecuteEventCodeButton;
        private System.Windows.Forms.Label InParamLabel;
        private System.Windows.Forms.MenuItem ExitMenuItem;
        private System.Windows.Forms.MenuItem FileMenuItem;
        private System.Windows.Forms.MenuItem CodeLangMenuItem;
        private System.Windows.Forms.MenuItem TargetComputerMenuItem;
        private System.Windows.Forms.MenuItem HelpMenuItem;
        private System.Windows.Forms.MenuItem QueryHelpMenuItem;
        private System.Windows.Forms.MenuItem MethodHelpMenuItem;
        private System.Windows.Forms.MenuItem EventHelpMenuItem;
        private System.Windows.Forms.MenuItem BrowseHelpMenuItem;
        private System.Windows.Forms.TabPage QueryTab;
        private System.Windows.Forms.TabPage MethodTab;
        private System.Windows.Forms.TabPage EventTab;
        private System.Windows.Forms.TabPage BrowseTab;
        
        private int NamespaceCount;
        private System.String[] SupportedEventQueries; 
        private const int MAXINPARAMS = 20;
        private const int MAXQUERYCONDITIONS = 10;
        private const int MAXEVENTQUERIES = 60;
        private System.Windows.Forms.Label PollLabel;
        private int QueryCounter;

        //-------------------------------------------------------------------------
        // Default constructor for the WMICodeCreator form.
        //
        //-------------------------------------------------------------------------
        public WMICodeCreator() 
        {  
            NamespaceCount = 0;
            QueryCounter = 0;

            // Holds the event queries that are supported by event providers.
            SupportedEventQueries = new string[MAXEVENTQUERIES];
            SupportedEventQueries.Initialize();

            // Generates the start-up screen.
            SplashScreenForm.ShowSplashScreen();
		
            InitializeComponent();

            // Creates the window for the target computer information.
            this.TargetWindow = new TargetComputerWindow(this);
            this.TargetWindow.Visible = false;

            // Creates the array of windows for method in-parameters.
            this.InParameterArray = new InParameterWindow[MAXINPARAMS];
            InParameterArray.Initialize();

            // Creates the array of windows for event conditions.
            this.EventConditionArray = new EventQueryCondition[MAXQUERYCONDITIONS];
            EventConditionArray.Initialize();

            // Populates the class lists on the form.
            System.Threading.ThreadPool.
                QueueUserWorkItem(
                new System.Threading.WaitCallback(
                this.InitialAddClassesToList));

            // Populates the namespace list on the form.
            System.Threading.ThreadPool.
                QueueUserWorkItem(
                new System.Threading.WaitCallback(
                this.AddNamespacesToList));
            
        }

        //-------------------------------------------------------------------------
        // Disposes of the WMICodeCreator and its components.
        //
        //-------------------------------------------------------------------------
        protected override void Dispose( bool disposing ) 
        {
            if( disposing ) 
            {
                if (components != null) 
                {
                    components.Dispose();
                }
            }
            base.Dispose( disposing );
        }

        //-------------------------------------------------------------------------
        // Initialization code for the WMICodeCreator form. This method is 
        // called in the constructor.
        //-------------------------------------------------------------------------
        private void InitializeComponent()
        {
            this.NamespaceLabel1 = new System.Windows.Forms.Label();
            this.PropertyList = new System.Windows.Forms.ListBox();
            this.ClassStatus = new System.Windows.Forms.Label();
            this.PropertyStatus = new System.Windows.Forms.Label();
            this.QueryClassesLabel = new System.Windows.Forms.Label();
            this.ResultsLabel4 = new System.Windows.Forms.Label();
            this.CodeText = new System.Windows.Forms.TextBox();
            this.ValueList = new System.Windows.Forms.ListBox();
            this.ValueButton = new System.Windows.Forms.Button();
            this.ResultsLabel5 = new System.Windows.Forms.Label();
            this.ValueStatus = new System.Windows.Forms.Label();
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.QueryTab = new System.Windows.Forms.TabPage();
            this.CodeGroupBox = new System.Windows.Forms.GroupBox();
            this.GenerateCodeLabel2 = new System.Windows.Forms.Label();
            this.ScopeLabel = new System.Windows.Forms.Label();
            this.PropertyListLabel = new System.Windows.Forms.Label();
            this.ExecuteQueryButton = new System.Windows.Forms.Button();
            this.OpenQueryText = new System.Windows.Forms.Button();
            this.QueryLinkLabel = new System.Windows.Forms.LinkLabel();
            this.ClassList = new System.Windows.Forms.ComboBox();
            this.NamespaceValue = new System.Windows.Forms.ComboBox();
            this.MethodTab = new System.Windows.Forms.TabPage();
            this.InParamLabel = new System.Windows.Forms.Label();
            this.MethodCodeGroupBox = new System.Windows.Forms.GroupBox();
            this.GeneratedCodeLabel3 = new System.Windows.Forms.Label();
            this.CodeText_m = new System.Windows.Forms.TextBox();
            this.KeyValueLabel = new System.Windows.Forms.Label();
            this.KeyValueBox = new System.Windows.Forms.ListBox();
            this.ExecuteMethodButton = new System.Windows.Forms.Button();
            this.OpenMethodText = new System.Windows.Forms.Button();
            this.MethodLinkLabel = new System.Windows.Forms.LinkLabel();
            this.InParameterLabel = new System.Windows.Forms.Label();
            this.MethodsLabel = new System.Windows.Forms.Label();
            this.MethodList = new System.Windows.Forms.ComboBox();
            this.InParameterBox = new System.Windows.Forms.ListBox();
            this.ClassList_m = new System.Windows.Forms.ComboBox();
            this.NamespaceValue_m = new System.Windows.Forms.ComboBox();
            this.NamespaceLabel3 = new System.Windows.Forms.Label();
            this.ClassStatus_m = new System.Windows.Forms.Label();
            this.MethodClassLabel = new System.Windows.Forms.Label();
            this.MethodStatus = new System.Windows.Forms.Label();
            this.EventTab = new System.Windows.Forms.TabPage();
            this.SecondsBox = new System.Windows.Forms.TextBox();
            this.PollLabel = new System.Windows.Forms.Label();
            this.EventCodeGroupBox = new System.Windows.Forms.GroupBox();
            this.GenerateCodeLabel1 = new System.Windows.Forms.Label();
            this.CodeText_event = new System.Windows.Forms.TextBox();
            this.Asynchronous = new System.Windows.Forms.CheckBox();
            this.TargetClassList_event = new System.Windows.Forms.ComboBox();
            this.PropertyList_event = new System.Windows.Forms.ListBox();
            this.ExecuteEventCodeButton = new System.Windows.Forms.Button();
            this.OpenEventText = new System.Windows.Forms.Button();
            this.EventLinkLabel = new System.Windows.Forms.LinkLabel();
            this.EventQueryConditionsLabel = new System.Windows.Forms.Label();
            this.PropertyValueLabel = new System.Windows.Forms.Label();
            this.ClassList_event = new System.Windows.Forms.ComboBox();
            this.NamespaceList_event = new System.Windows.Forms.ComboBox();
            this.NamespaceLabel2 = new System.Windows.Forms.Label();
            this.ClassStatus_event = new System.Windows.Forms.Label();
            this.EventClassListLabel = new System.Windows.Forms.Label();
            this.PollLabelEnd = new System.Windows.Forms.Label();
            this.BrowseTab = new System.Windows.Forms.TabPage();
            this.BrowseNamespaceResults = new System.Windows.Forms.Label();
            this.MethodDescriptionLabel = new System.Windows.Forms.Label();
            this.PropertyDescriptionLabel = new System.Windows.Forms.Label();
            this.ClassDescriptionLabel = new System.Windows.Forms.Label();
            this.BrowseClassDescription = new System.Windows.Forms.TextBox();
            this.MethodInformation = new System.Windows.Forms.TextBox();
            this.PropertyInformation = new System.Windows.Forms.TextBox();
            this.ResultsLabel1 = new System.Windows.Forms.Label();
            this.BrowseQualifierList = new System.Windows.Forms.ListBox();
            this.BrowseQualifierButton = new System.Windows.Forms.Button();
            this.BrowseQualiferStatus = new System.Windows.Forms.Label();
            this.NamespaceLabel4 = new System.Windows.Forms.Label();
            this.BrowseClassList = new System.Windows.Forms.ComboBox();
            this.BrowseNamespaceList = new System.Windows.Forms.ComboBox();
            this.BrowseClassResults = new System.Windows.Forms.Label();
            this.ResultsLabel3 = new System.Windows.Forms.Label();
            this.BrowseMethodList = new System.Windows.Forms.ListBox();
            this.BrowseMethodButton = new System.Windows.Forms.Button();
            this.BrowseMethodStatus = new System.Windows.Forms.Label();
            this.ClassLabel2 = new System.Windows.Forms.Label();
            this.ResultsLabel2 = new System.Windows.Forms.Label();
            this.BrowsePropertyList = new System.Windows.Forms.ListBox();
            this.BrowsePropertyButton = new System.Windows.Forms.Button();
            this.BrowsePropertyStatus = new System.Windows.Forms.Label();
            this.MainMenu = new System.Windows.Forms.MainMenu();
            this.FileMenuItem = new System.Windows.Forms.MenuItem();
            this.ExitMenuItem = new System.Windows.Forms.MenuItem();
            this.CodeLangMenuItem = new System.Windows.Forms.MenuItem();
            this.CSharpMenuItem = new System.Windows.Forms.MenuItem();
            this.VbNetMenuItem = new System.Windows.Forms.MenuItem();
            this.VbsMenuItem = new System.Windows.Forms.MenuItem();
            this.TargetComputerMenuItem = new System.Windows.Forms.MenuItem();
            this.LocalComputerMenu = new System.Windows.Forms.MenuItem();
            this.RemoteComputerMenu = new System.Windows.Forms.MenuItem();
            this.GroupRemoteComputerMenu = new System.Windows.Forms.MenuItem();
            this.HelpMenuItem = new System.Windows.Forms.MenuItem();
            this.QueryHelpMenuItem = new System.Windows.Forms.MenuItem();
            this.MethodHelpMenuItem = new System.Windows.Forms.MenuItem();
            this.EventHelpMenuItem = new System.Windows.Forms.MenuItem();
            this.BrowseHelpMenuItem = new System.Windows.Forms.MenuItem();
            this.MainTabControl.SuspendLayout();
            this.QueryTab.SuspendLayout();
            this.CodeGroupBox.SuspendLayout();
            this.MethodTab.SuspendLayout();
            this.MethodCodeGroupBox.SuspendLayout();
            this.EventTab.SuspendLayout();
            this.EventCodeGroupBox.SuspendLayout();
            this.BrowseTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // NamespaceLabel1
            // 
            this.NamespaceLabel1.Location = new System.Drawing.Point(8, 8);
            this.NamespaceLabel1.Name = "NamespaceLabel1";
            this.NamespaceLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.NamespaceLabel1.Size = new System.Drawing.Size(68, 16);
            this.NamespaceLabel1.TabIndex = 1;
            this.NamespaceLabel1.Text = "Namespace:";
            // 
            // PropertyList
            // 
            this.PropertyList.HorizontalScrollbar = true;
            this.PropertyList.Location = new System.Drawing.Point(16, 128);
            this.PropertyList.Name = "PropertyList";
            this.PropertyList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.PropertyList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.PropertyList.Size = new System.Drawing.Size(280, 108);
            this.PropertyList.Sorted = true;
            this.PropertyList.TabIndex = 4;
            this.PropertyList.SelectedIndexChanged += new System.EventHandler(this.PropertyList_SelectedIndexChanged);
            // 
            // ClassStatus
            // 
            this.ClassStatus.Location = new System.Drawing.Point(104, 32);
            this.ClassStatus.Name = "ClassStatus";
            this.ClassStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ClassStatus.Size = new System.Drawing.Size(336, 16);
            this.ClassStatus.TabIndex = 13;
            // 
            // PropertyStatus
            // 
            this.PropertyStatus.Location = new System.Drawing.Point(56, 96);
            this.PropertyStatus.Name = "PropertyStatus";
            this.PropertyStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.PropertyStatus.Size = new System.Drawing.Size(384, 16);
            this.PropertyStatus.TabIndex = 13;
            // 
            // QueryClassesLabel
            // 
            this.QueryClassesLabel.Location = new System.Drawing.Point(8, 48);
            this.QueryClassesLabel.Name = "QueryClassesLabel";
            this.QueryClassesLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.QueryClassesLabel.Size = new System.Drawing.Size(96, 32);
            this.QueryClassesLabel.TabIndex = 15;
            this.QueryClassesLabel.Text = "Classes (dynamic or static):";
            // 
            // ResultsLabel4
            // 
            this.ResultsLabel4.Location = new System.Drawing.Point(8, 96);
            this.ResultsLabel4.Name = "ResultsLabel4";
            this.ResultsLabel4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ResultsLabel4.Size = new System.Drawing.Size(48, 14);
            this.ResultsLabel4.TabIndex = 16;
            this.ResultsLabel4.Text = "Results:";
            // 
            // CodeText
            // 
            this.CodeText.AcceptsReturn = true;
            this.CodeText.AcceptsTab = true;
            this.CodeText.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.CodeText.AllowDrop = true;
            this.CodeText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                | System.Windows.Forms.AnchorStyles.Left) 
                | System.Windows.Forms.AnchorStyles.Right)));
            this.CodeText.AutoSize = false;
            this.CodeText.Location = new System.Drawing.Point(8, 32);
            this.CodeText.Multiline = true;
            this.CodeText.Name = "CodeText";
            this.CodeText.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CodeText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.CodeText.Size = new System.Drawing.Size(384, 448);
            this.CodeText.TabIndex = 17;
            this.CodeText.TabStop = false;
            this.CodeText.Text = "";
            this.CodeText.WordWrap = false;
            // 
            // ValueList
            // 
            this.ValueList.HorizontalScrollbar = true;
            this.ValueList.Location = new System.Drawing.Point(16, 304);
            this.ValueList.Name = "ValueList";
            this.ValueList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ValueList.Size = new System.Drawing.Size(416, 108);
            this.ValueList.TabIndex = 6;
            this.ValueList.SelectedIndexChanged += new System.EventHandler(this.ValueList_SelectedIndexChanged);
            // 
            // ValueButton
            // 
            this.ValueButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ValueButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ValueButton.Location = new System.Drawing.Point(16, 256);
            this.ValueButton.Name = "ValueButton";
            this.ValueButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ValueButton.Size = new System.Drawing.Size(192, 24);
            this.ValueButton.TabIndex = 5;
            this.ValueButton.Text = "Search for Property Values";
            this.ValueButton.Click += new System.EventHandler(this.ValueButton_Click);
            // 
            // ResultsLabel5
            // 
            this.ResultsLabel5.Location = new System.Drawing.Point(232, 256);
            this.ResultsLabel5.Name = "ResultsLabel5";
            this.ResultsLabel5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ResultsLabel5.Size = new System.Drawing.Size(48, 16);
            this.ResultsLabel5.TabIndex = 32;
            this.ResultsLabel5.Text = "Results:";
            // 
            // ValueStatus
            // 
            this.ValueStatus.Location = new System.Drawing.Point(280, 256);
            this.ValueStatus.Name = "ValueStatus";
            this.ValueStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ValueStatus.Size = new System.Drawing.Size(168, 48);
            this.ValueStatus.TabIndex = 31;
            // 
            // MainTabControl
            // 
            this.MainTabControl.Controls.Add(this.QueryTab);
            this.MainTabControl.Controls.Add(this.MethodTab);
            this.MainTabControl.Controls.Add(this.EventTab);
            this.MainTabControl.Controls.Add(this.BrowseTab);
            this.MainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTabControl.Location = new System.Drawing.Point(0, 0);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(848, 497);
            this.MainTabControl.TabIndex = 33;
            this.MainTabControl.SelectedIndexChanged += new System.EventHandler(this.MainTabControl_SelectedIndexChanged);
            // 
            // QueryTab
            // 
            this.QueryTab.Controls.Add(this.CodeGroupBox);
            this.QueryTab.Controls.Add(this.ScopeLabel);
            this.QueryTab.Controls.Add(this.PropertyListLabel);
            this.QueryTab.Controls.Add(this.ExecuteQueryButton);
            this.QueryTab.Controls.Add(this.OpenQueryText);
            this.QueryTab.Controls.Add(this.QueryLinkLabel);
            this.QueryTab.Controls.Add(this.ClassList);
            this.QueryTab.Controls.Add(this.NamespaceValue);
            this.QueryTab.Controls.Add(this.NamespaceLabel1);
            this.QueryTab.Controls.Add(this.ClassStatus);
            this.QueryTab.Controls.Add(this.QueryClassesLabel);
            this.QueryTab.Controls.Add(this.ResultsLabel4);
            this.QueryTab.Controls.Add(this.ResultsLabel5);
            this.QueryTab.Controls.Add(this.ValueStatus);
            this.QueryTab.Controls.Add(this.ValueList);
            this.QueryTab.Controls.Add(this.PropertyList);
            this.QueryTab.Controls.Add(this.ValueButton);
            this.QueryTab.Controls.Add(this.PropertyStatus);
            this.QueryTab.Location = new System.Drawing.Point(4, 22);
            this.QueryTab.Name = "QueryTab";
            this.QueryTab.Size = new System.Drawing.Size(840, 471);
            this.QueryTab.TabIndex = 0;
            this.QueryTab.Text = "Query for data from a WMI class";
            // 
            // CodeGroupBox
            // 
            this.CodeGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                | System.Windows.Forms.AnchorStyles.Left) 
                | System.Windows.Forms.AnchorStyles.Right)));
            this.CodeGroupBox.Controls.Add(this.CodeText);
            this.CodeGroupBox.Controls.Add(this.GenerateCodeLabel2);
            this.CodeGroupBox.Location = new System.Drawing.Point(448, -8);
            this.CodeGroupBox.Name = "CodeGroupBox";
            this.CodeGroupBox.Size = new System.Drawing.Size(400, 488);
            this.CodeGroupBox.TabIndex = 61;
            this.CodeGroupBox.TabStop = false;
            // 
            // GenerateCodeLabel2
            // 
            this.GenerateCodeLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.GenerateCodeLabel2.Location = new System.Drawing.Point(8, 16);
            this.GenerateCodeLabel2.Name = "GenerateCodeLabel2";
            this.GenerateCodeLabel2.Size = new System.Drawing.Size(128, 16);
            this.GenerateCodeLabel2.TabIndex = 60;
            this.GenerateCodeLabel2.Text = "Generated Code:";
            // 
            // ScopeLabel
            // 
            this.ScopeLabel.Location = new System.Drawing.Point(16, 288);
            this.ScopeLabel.Name = "ScopeLabel";
            this.ScopeLabel.Size = new System.Drawing.Size(256, 16);
            this.ScopeLabel.TabIndex = 59;
            this.ScopeLabel.Text = "Select one value to narrow the scope of the query.";
            // 
            // PropertyListLabel
            // 
            this.PropertyListLabel.Location = new System.Drawing.Point(16, 112);
            this.PropertyListLabel.Name = "PropertyListLabel";
            this.PropertyListLabel.Size = new System.Drawing.Size(224, 16);
            this.PropertyListLabel.TabIndex = 58;
            this.PropertyListLabel.Text = "Select the properties you want values for.";
            // 
            // ExecuteQueryButton
            // 
            this.ExecuteQueryButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ExecuteQueryButton.Location = new System.Drawing.Point(280, 424);
            this.ExecuteQueryButton.Name = "ExecuteQueryButton";
            this.ExecuteQueryButton.Size = new System.Drawing.Size(152, 32);
            this.ExecuteQueryButton.TabIndex = 14;
            this.ExecuteQueryButton.Text = "Execute Code";
            this.ExecuteQueryButton.Click += new System.EventHandler(this.ExecuteQueryButton_Click);
            // 
            // OpenQueryText
            // 
            this.OpenQueryText.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.OpenQueryText.Location = new System.Drawing.Point(120, 424);
            this.OpenQueryText.Name = "OpenQueryText";
            this.OpenQueryText.Size = new System.Drawing.Size(152, 32);
            this.OpenQueryText.TabIndex = 13;
            this.OpenQueryText.Text = "Open code in Notepad";
            this.OpenQueryText.Click += new System.EventHandler(this.OpenQueryText_Click);
            // 
            // QueryLinkLabel
            // 
            this.QueryLinkLabel.Location = new System.Drawing.Point(96, 72);
            this.QueryLinkLabel.Name = "QueryLinkLabel";
            this.QueryLinkLabel.Size = new System.Drawing.Size(336, 16);
            this.QueryLinkLabel.TabIndex = 55;
            this.QueryLinkLabel.TabStop = true;
            this.QueryLinkLabel.Text = "Get documentation for this class from the online MSDN Library.";
            this.QueryLinkLabel.Visible = false;
            this.QueryLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.QueryLinkLabel_LinkClicked);
            // 
            // ClassList
            // 
            this.ClassList.Location = new System.Drawing.Point(104, 48);
            this.ClassList.MaxDropDownItems = 35;
            this.ClassList.Name = "ClassList";
            this.ClassList.Size = new System.Drawing.Size(336, 21);
            this.ClassList.Sorted = true;
            this.ClassList.TabIndex = 2;
            this.ClassList.SelectedIndexChanged += new System.EventHandler(this.ClassList_SelectedIndexChanged);
            // 
            // NamespaceValue
            // 
            this.NamespaceValue.Location = new System.Drawing.Point(104, 8);
            this.NamespaceValue.MaxDropDownItems = 25;
            this.NamespaceValue.Name = "NamespaceValue";
            this.NamespaceValue.Size = new System.Drawing.Size(336, 21);
            this.NamespaceValue.Sorted = true;
            this.NamespaceValue.TabIndex = 1;
            this.NamespaceValue.Text = "root\\CIMV2";
            this.NamespaceValue.SelectedIndexChanged += new System.EventHandler(this.NamespaceValue_SelectedIndexChanged);
            // 
            // MethodTab
            // 
            this.MethodTab.Controls.Add(this.InParamLabel);
            this.MethodTab.Controls.Add(this.MethodCodeGroupBox);
            this.MethodTab.Controls.Add(this.KeyValueLabel);
            this.MethodTab.Controls.Add(this.KeyValueBox);
            this.MethodTab.Controls.Add(this.ExecuteMethodButton);
            this.MethodTab.Controls.Add(this.OpenMethodText);
            this.MethodTab.Controls.Add(this.MethodLinkLabel);
            this.MethodTab.Controls.Add(this.InParameterLabel);
            this.MethodTab.Controls.Add(this.MethodsLabel);
            this.MethodTab.Controls.Add(this.MethodList);
            this.MethodTab.Controls.Add(this.InParameterBox);
            this.MethodTab.Controls.Add(this.ClassList_m);
            this.MethodTab.Controls.Add(this.NamespaceValue_m);
            this.MethodTab.Controls.Add(this.NamespaceLabel3);
            this.MethodTab.Controls.Add(this.ClassStatus_m);
            this.MethodTab.Controls.Add(this.MethodClassLabel);
            this.MethodTab.Controls.Add(this.MethodStatus);
            this.MethodTab.Location = new System.Drawing.Point(4, 22);
            this.MethodTab.Name = "MethodTab";
            this.MethodTab.Size = new System.Drawing.Size(840, 471);
            this.MethodTab.TabIndex = 1;
            this.MethodTab.Text = "Execute a method";
            // 
            // InParamLabel
            // 
            this.InParamLabel.Location = new System.Drawing.Point(144, 160);
            this.InParamLabel.Name = "InParamLabel";
            this.InParamLabel.Size = new System.Drawing.Size(128, 16);
            this.InParamLabel.TabIndex = 63;
            this.InParamLabel.Text = "Method [in] parameters:";
            // 
            // MethodCodeGroupBox
            // 
            this.MethodCodeGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                | System.Windows.Forms.AnchorStyles.Left) 
                | System.Windows.Forms.AnchorStyles.Right)));
            this.MethodCodeGroupBox.Controls.Add(this.GeneratedCodeLabel3);
            this.MethodCodeGroupBox.Controls.Add(this.CodeText_m);
            this.MethodCodeGroupBox.Location = new System.Drawing.Point(448, -9);
            this.MethodCodeGroupBox.Name = "MethodCodeGroupBox";
            this.MethodCodeGroupBox.Size = new System.Drawing.Size(408, 489);
            this.MethodCodeGroupBox.TabIndex = 62;
            this.MethodCodeGroupBox.TabStop = false;
            // 
            // GeneratedCodeLabel3
            // 
            this.GeneratedCodeLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.GeneratedCodeLabel3.Location = new System.Drawing.Point(8, 16);
            this.GeneratedCodeLabel3.Name = "GeneratedCodeLabel3";
            this.GeneratedCodeLabel3.Size = new System.Drawing.Size(128, 16);
            this.GeneratedCodeLabel3.TabIndex = 60;
            this.GeneratedCodeLabel3.Text = "Generated Code:";
            // 
            // CodeText_m
            // 
            this.CodeText_m.AcceptsReturn = true;
            this.CodeText_m.AcceptsTab = true;
            this.CodeText_m.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.CodeText_m.AllowDrop = true;
            this.CodeText_m.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                | System.Windows.Forms.AnchorStyles.Left) 
                | System.Windows.Forms.AnchorStyles.Right)));
            this.CodeText_m.AutoSize = false;
            this.CodeText_m.Location = new System.Drawing.Point(8, 32);
            this.CodeText_m.Multiline = true;
            this.CodeText_m.Name = "CodeText_m";
            this.CodeText_m.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CodeText_m.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.CodeText_m.Size = new System.Drawing.Size(384, 448);
            this.CodeText_m.TabIndex = 44;
            this.CodeText_m.TabStop = false;
            this.CodeText_m.Text = "";
            this.CodeText_m.WordWrap = false;
            // 
            // KeyValueLabel
            // 
            this.KeyValueLabel.Location = new System.Drawing.Point(8, 296);
            this.KeyValueLabel.Name = "KeyValueLabel";
            this.KeyValueLabel.Size = new System.Drawing.Size(136, 80);
            this.KeyValueLabel.TabIndex = 60;
            this.KeyValueLabel.Text = "Select the instance to execute the query on. The values in the list are the value" +
                "s of the key property for this class on the local computer.";
            this.KeyValueLabel.Visible = false;
            // 
            // KeyValueBox
            // 
            this.KeyValueBox.BackColor = System.Drawing.SystemColors.Window;
            this.KeyValueBox.HorizontalScrollbar = true;
            this.KeyValueBox.Location = new System.Drawing.Point(144, 288);
            this.KeyValueBox.Name = "KeyValueBox";
            this.KeyValueBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.KeyValueBox.Size = new System.Drawing.Size(296, 121);
            this.KeyValueBox.Sorted = true;
            this.KeyValueBox.TabIndex = 5;
            this.KeyValueBox.Visible = false;
            this.KeyValueBox.SelectedIndexChanged += new System.EventHandler(this.KeyValueBox_SelectedIndexChanged);
            // 
            // ExecuteMethodButton
            // 
            this.ExecuteMethodButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ExecuteMethodButton.Location = new System.Drawing.Point(304, 424);
            this.ExecuteMethodButton.Name = "ExecuteMethodButton";
            this.ExecuteMethodButton.Size = new System.Drawing.Size(136, 32);
            this.ExecuteMethodButton.TabIndex = 13;
            this.ExecuteMethodButton.Text = "Execute Code";
            this.ExecuteMethodButton.Click += new System.EventHandler(this.ExecuteMethodButton_Click);
            // 
            // OpenMethodText
            // 
            this.OpenMethodText.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.OpenMethodText.Location = new System.Drawing.Point(160, 424);
            this.OpenMethodText.Name = "OpenMethodText";
            this.OpenMethodText.Size = new System.Drawing.Size(136, 32);
            this.OpenMethodText.TabIndex = 12;
            this.OpenMethodText.Text = "Open code in Notepad";
            this.OpenMethodText.Click += new System.EventHandler(this.OpenMethodText_Click);
            // 
            // MethodLinkLabel
            // 
            this.MethodLinkLabel.Location = new System.Drawing.Point(88, 104);
            this.MethodLinkLabel.Name = "MethodLinkLabel";
            this.MethodLinkLabel.Size = new System.Drawing.Size(336, 16);
            this.MethodLinkLabel.TabIndex = 54;
            this.MethodLinkLabel.TabStop = true;
            this.MethodLinkLabel.Text = "Get documentation for this class from the online MSDN Library.";
            this.MethodLinkLabel.Visible = false;
            this.MethodLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.MethodLinkLabel_LinkClicked);
            // 
            // InParameterLabel
            // 
            this.InParameterLabel.Location = new System.Drawing.Point(8, 184);
            this.InParameterLabel.Name = "InParameterLabel";
            this.InParameterLabel.Size = new System.Drawing.Size(136, 56);
            this.InParameterLabel.TabIndex = 53;
            this.InParameterLabel.Text = "Select the method [in] parameters you want to assign a value to (some may be opti" +
                "onal).";
            // 
            // MethodsLabel
            // 
            this.MethodsLabel.Location = new System.Drawing.Point(16, 128);
            this.MethodsLabel.Name = "MethodsLabel";
            this.MethodsLabel.Size = new System.Drawing.Size(56, 23);
            this.MethodsLabel.TabIndex = 52;
            this.MethodsLabel.Text = "Methods:";
            // 
            // MethodList
            // 
            this.MethodList.Location = new System.Drawing.Point(88, 128);
            this.MethodList.Name = "MethodList";
            this.MethodList.Size = new System.Drawing.Size(352, 21);
            this.MethodList.Sorted = true;
            this.MethodList.TabIndex = 3;
            this.MethodList.SelectedIndexChanged += new System.EventHandler(this.MethodList_SelectedIndexChanged);
            // 
            // InParameterBox
            // 
            this.InParameterBox.BackColor = System.Drawing.SystemColors.Window;
            this.InParameterBox.HorizontalScrollbar = true;
            this.InParameterBox.Location = new System.Drawing.Point(144, 176);
            this.InParameterBox.Name = "InParameterBox";
            this.InParameterBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.InParameterBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.InParameterBox.Size = new System.Drawing.Size(296, 95);
            this.InParameterBox.Sorted = true;
            this.InParameterBox.TabIndex = 4;
            this.InParameterBox.SelectedIndexChanged += new System.EventHandler(this.InParameterBox_SelectedIndexChanged);
            // 
            // ClassList_m
            // 
            this.ClassList_m.Location = new System.Drawing.Point(88, 64);
            this.ClassList_m.MaxDropDownItems = 25;
            this.ClassList_m.Name = "ClassList_m";
            this.ClassList_m.Size = new System.Drawing.Size(352, 21);
            this.ClassList_m.Sorted = true;
            this.ClassList_m.TabIndex = 2;
            this.ClassList_m.SelectedIndexChanged += new System.EventHandler(this.ClassList_m_SelectedIndexChanged);
            // 
            // NamespaceValue_m
            // 
            this.NamespaceValue_m.Location = new System.Drawing.Point(88, 16);
            this.NamespaceValue_m.MaxDropDownItems = 25;
            this.NamespaceValue_m.Name = "NamespaceValue_m";
            this.NamespaceValue_m.Size = new System.Drawing.Size(352, 21);
            this.NamespaceValue_m.Sorted = true;
            this.NamespaceValue_m.TabIndex = 1;
            this.NamespaceValue_m.Text = "root\\CIMV2";
            this.NamespaceValue_m.SelectedIndexChanged += new System.EventHandler(this.NamespaceValue_m_SelectedIndexChanged);
            // 
            // NamespaceLabel3
            // 
            this.NamespaceLabel3.Location = new System.Drawing.Point(16, 16);
            this.NamespaceLabel3.Name = "NamespaceLabel3";
            this.NamespaceLabel3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.NamespaceLabel3.Size = new System.Drawing.Size(68, 16);
            this.NamespaceLabel3.TabIndex = 34;
            this.NamespaceLabel3.Text = "Namespace:";
            // 
            // ClassStatus_m
            // 
            this.ClassStatus_m.Location = new System.Drawing.Point(88, 40);
            this.ClassStatus_m.Name = "ClassStatus_m";
            this.ClassStatus_m.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ClassStatus_m.Size = new System.Drawing.Size(360, 24);
            this.ClassStatus_m.TabIndex = 41;
            // 
            // MethodClassLabel
            // 
            this.MethodClassLabel.Location = new System.Drawing.Point(16, 64);
            this.MethodClassLabel.Name = "MethodClassLabel";
            this.MethodClassLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.MethodClassLabel.Size = new System.Drawing.Size(72, 32);
            this.MethodClassLabel.TabIndex = 42;
            this.MethodClassLabel.Text = "Classes with methods:";
            // 
            // MethodStatus
            // 
            this.MethodStatus.Location = new System.Drawing.Point(88, 88);
            this.MethodStatus.Name = "MethodStatus";
            this.MethodStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.MethodStatus.Size = new System.Drawing.Size(352, 24);
            this.MethodStatus.TabIndex = 40;
            // 
            // EventTab
            // 
            this.EventTab.Controls.Add(this.SecondsBox);
            this.EventTab.Controls.Add(this.PollLabel);
            this.EventTab.Controls.Add(this.EventCodeGroupBox);
            this.EventTab.Controls.Add(this.Asynchronous);
            this.EventTab.Controls.Add(this.TargetClassList_event);
            this.EventTab.Controls.Add(this.PropertyList_event);
            this.EventTab.Controls.Add(this.ExecuteEventCodeButton);
            this.EventTab.Controls.Add(this.OpenEventText);
            this.EventTab.Controls.Add(this.EventLinkLabel);
            this.EventTab.Controls.Add(this.EventQueryConditionsLabel);
            this.EventTab.Controls.Add(this.PropertyValueLabel);
            this.EventTab.Controls.Add(this.ClassList_event);
            this.EventTab.Controls.Add(this.NamespaceList_event);
            this.EventTab.Controls.Add(this.NamespaceLabel2);
            this.EventTab.Controls.Add(this.ClassStatus_event);
            this.EventTab.Controls.Add(this.EventClassListLabel);
            this.EventTab.Controls.Add(this.PollLabelEnd);
            this.EventTab.Location = new System.Drawing.Point(4, 22);
            this.EventTab.Name = "EventTab";
            this.EventTab.Size = new System.Drawing.Size(840, 471);
            this.EventTab.TabIndex = 2;
            this.EventTab.Text = "Receive an event";
            // 
            // SecondsBox
            // 
            this.SecondsBox.Location = new System.Drawing.Point(232, 304);
            this.SecondsBox.MaxLength = 5;
            this.SecondsBox.Name = "SecondsBox";
            this.SecondsBox.Size = new System.Drawing.Size(40, 20);
            this.SecondsBox.TabIndex = 5;
            this.SecondsBox.Text = "10";
            this.SecondsBox.TextChanged += new System.EventHandler(this.SecondsBox_TextChanged);
            // 
            // PollLabel
            // 
            this.PollLabel.Location = new System.Drawing.Point(16, 304);
            this.PollLabel.Name = "PollLabel";
            this.PollLabel.Size = new System.Drawing.Size(216, 23);
            this.PollLabel.TabIndex = 63;
            this.PollLabel.Text = "Designate WMI to poll for the event every";
            this.PollLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EventCodeGroupBox
            // 
            this.EventCodeGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                | System.Windows.Forms.AnchorStyles.Left) 
                | System.Windows.Forms.AnchorStyles.Right)));
            this.EventCodeGroupBox.Controls.Add(this.GenerateCodeLabel1);
            this.EventCodeGroupBox.Controls.Add(this.CodeText_event);
            this.EventCodeGroupBox.Location = new System.Drawing.Point(448, -9);
            this.EventCodeGroupBox.Name = "EventCodeGroupBox";
            this.EventCodeGroupBox.Size = new System.Drawing.Size(408, 489);
            this.EventCodeGroupBox.TabIndex = 62;
            this.EventCodeGroupBox.TabStop = false;
            // 
            // GenerateCodeLabel1
            // 
            this.GenerateCodeLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.GenerateCodeLabel1.Location = new System.Drawing.Point(8, 16);
            this.GenerateCodeLabel1.Name = "GenerateCodeLabel1";
            this.GenerateCodeLabel1.Size = new System.Drawing.Size(128, 16);
            this.GenerateCodeLabel1.TabIndex = 60;
            this.GenerateCodeLabel1.Text = "Generated Code:";
            // 
            // CodeText_event
            // 
            this.CodeText_event.AcceptsReturn = true;
            this.CodeText_event.AcceptsTab = true;
            this.CodeText_event.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.CodeText_event.AllowDrop = true;
            this.CodeText_event.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                | System.Windows.Forms.AnchorStyles.Left) 
                | System.Windows.Forms.AnchorStyles.Right)));
            this.CodeText_event.AutoSize = false;
            this.CodeText_event.Location = new System.Drawing.Point(8, 32);
            this.CodeText_event.Multiline = true;
            this.CodeText_event.Name = "CodeText_event";
            this.CodeText_event.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CodeText_event.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.CodeText_event.Size = new System.Drawing.Size(384, 448);
            this.CodeText_event.TabIndex = 41;
            this.CodeText_event.TabStop = false;
            this.CodeText_event.Text = "";
            this.CodeText_event.WordWrap = false;
            // 
            // Asynchronous
            // 
            this.Asynchronous.Location = new System.Drawing.Point(24, 344);
            this.Asynchronous.Name = "Asynchronous";
            this.Asynchronous.Size = new System.Drawing.Size(264, 24);
            this.Asynchronous.TabIndex = 60;
            this.Asynchronous.Text = "Get the event without waiting (asynchronously).";
            this.Asynchronous.CheckedChanged += new System.EventHandler(this.Asynchronous_CheckedChanged);
            // 
            // TargetClassList_event
            // 
            this.TargetClassList_event.Location = new System.Drawing.Point(120, 104);
            this.TargetClassList_event.MaxDropDownItems = 35;
            this.TargetClassList_event.Name = "TargetClassList_event";
            this.TargetClassList_event.Size = new System.Drawing.Size(312, 21);
            this.TargetClassList_event.Sorted = true;
            this.TargetClassList_event.TabIndex = 3;
            this.TargetClassList_event.Visible = false;
            this.TargetClassList_event.SelectedIndexChanged += new System.EventHandler(this.TargetClassList_event_SelectedIndexChanged);
            // 
            // PropertyList_event
            // 
            this.PropertyList_event.HorizontalScrollbar = true;
            this.PropertyList_event.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.PropertyList_event.Location = new System.Drawing.Point(16, 152);
            this.PropertyList_event.Name = "PropertyList_event";
            this.PropertyList_event.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.PropertyList_event.Size = new System.Drawing.Size(416, 134);
            this.PropertyList_event.Sorted = true;
            this.PropertyList_event.TabIndex = 4;
            this.PropertyList_event.SelectedIndexChanged += new System.EventHandler(this.PropertyList_event_SelectedIndexChanged);
            // 
            // ExecuteEventCodeButton
            // 
            this.ExecuteEventCodeButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ExecuteEventCodeButton.Location = new System.Drawing.Point(288, 424);
            this.ExecuteEventCodeButton.Name = "ExecuteEventCodeButton";
            this.ExecuteEventCodeButton.Size = new System.Drawing.Size(144, 32);
            this.ExecuteEventCodeButton.TabIndex = 15;
            this.ExecuteEventCodeButton.Text = "Execute Code";
            this.ExecuteEventCodeButton.Click += new System.EventHandler(this.ExecuteEventCodeButton_Click);
            // 
            // OpenEventText
            // 
            this.OpenEventText.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.OpenEventText.Location = new System.Drawing.Point(136, 424);
            this.OpenEventText.Name = "OpenEventText";
            this.OpenEventText.Size = new System.Drawing.Size(144, 32);
            this.OpenEventText.TabIndex = 14;
            this.OpenEventText.Text = "Open code in Notepad";
            this.OpenEventText.Click += new System.EventHandler(this.OpenEventText_Click);
            // 
            // EventLinkLabel
            // 
            this.EventLinkLabel.Location = new System.Drawing.Point(88, 80);
            this.EventLinkLabel.Name = "EventLinkLabel";
            this.EventLinkLabel.Size = new System.Drawing.Size(336, 16);
            this.EventLinkLabel.TabIndex = 58;
            this.EventLinkLabel.TabStop = true;
            this.EventLinkLabel.Text = "Get documentation for this class from the online MSDN Library.";
            this.EventLinkLabel.Visible = false;
            this.EventLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.EventLinkLabel_LinkClicked);
            // 
            // EventQueryConditionsLabel
            // 
            this.EventQueryConditionsLabel.Location = new System.Drawing.Point(16, 136);
            this.EventQueryConditionsLabel.Name = "EventQueryConditionsLabel";
            this.EventQueryConditionsLabel.Size = new System.Drawing.Size(128, 16);
            this.EventQueryConditionsLabel.TabIndex = 57;
            this.EventQueryConditionsLabel.Text = "Event Query Conditions:";
            // 
            // PropertyValueLabel
            // 
            this.PropertyValueLabel.Location = new System.Drawing.Point(16, 104);
            this.PropertyValueLabel.Name = "PropertyValueLabel";
            this.PropertyValueLabel.Size = new System.Drawing.Size(104, 16);
            this.PropertyValueLabel.TabIndex = 52;
            this.PropertyValueLabel.Visible = false;
            // 
            // ClassList_event
            // 
            this.ClassList_event.Location = new System.Drawing.Point(84, 56);
            this.ClassList_event.MaxDropDownItems = 35;
            this.ClassList_event.Name = "ClassList_event";
            this.ClassList_event.Size = new System.Drawing.Size(352, 21);
            this.ClassList_event.Sorted = true;
            this.ClassList_event.TabIndex = 2;
            this.ClassList_event.SelectedIndexChanged += new System.EventHandler(this.ClassList_event_SelectedIndexChanged);
            // 
            // NamespaceList_event
            // 
            this.NamespaceList_event.Location = new System.Drawing.Point(84, 16);
            this.NamespaceList_event.MaxDropDownItems = 25;
            this.NamespaceList_event.Name = "NamespaceList_event";
            this.NamespaceList_event.Size = new System.Drawing.Size(352, 21);
            this.NamespaceList_event.Sorted = true;
            this.NamespaceList_event.TabIndex = 1;
            this.NamespaceList_event.Text = "root\\CIMV2";
            this.NamespaceList_event.SelectedIndexChanged += new System.EventHandler(this.NamespaceList_event_SelectedIndexChanged);
            // 
            // NamespaceLabel2
            // 
            this.NamespaceLabel2.Location = new System.Drawing.Point(12, 16);
            this.NamespaceLabel2.Name = "NamespaceLabel2";
            this.NamespaceLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.NamespaceLabel2.Size = new System.Drawing.Size(68, 16);
            this.NamespaceLabel2.TabIndex = 37;
            this.NamespaceLabel2.Text = "Namespace:";
            // 
            // ClassStatus_event
            // 
            this.ClassStatus_event.Location = new System.Drawing.Point(84, 40);
            this.ClassStatus_event.Name = "ClassStatus_event";
            this.ClassStatus_event.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ClassStatus_event.Size = new System.Drawing.Size(352, 24);
            this.ClassStatus_event.TabIndex = 39;
            // 
            // EventClassListLabel
            // 
            this.EventClassListLabel.Location = new System.Drawing.Point(12, 56);
            this.EventClassListLabel.Name = "EventClassListLabel";
            this.EventClassListLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.EventClassListLabel.Size = new System.Drawing.Size(68, 16);
            this.EventClassListLabel.TabIndex = 40;
            this.EventClassListLabel.Text = "Event Class:";
            // 
            // PollLabelEnd
            // 
            this.PollLabelEnd.Location = new System.Drawing.Point(280, 312);
            this.PollLabelEnd.Name = "PollLabelEnd";
            this.PollLabelEnd.Size = new System.Drawing.Size(56, 16);
            this.PollLabelEnd.TabIndex = 51;
            this.PollLabelEnd.Text = "seconds.";
            // 
            // BrowseTab
            // 
            this.BrowseTab.Controls.Add(this.BrowseNamespaceResults);
            this.BrowseTab.Controls.Add(this.MethodDescriptionLabel);
            this.BrowseTab.Controls.Add(this.PropertyDescriptionLabel);
            this.BrowseTab.Controls.Add(this.ClassDescriptionLabel);
            this.BrowseTab.Controls.Add(this.BrowseClassDescription);
            this.BrowseTab.Controls.Add(this.MethodInformation);
            this.BrowseTab.Controls.Add(this.PropertyInformation);
            this.BrowseTab.Controls.Add(this.ResultsLabel1);
            this.BrowseTab.Controls.Add(this.BrowseQualifierList);
            this.BrowseTab.Controls.Add(this.BrowseQualifierButton);
            this.BrowseTab.Controls.Add(this.BrowseQualiferStatus);
            this.BrowseTab.Controls.Add(this.NamespaceLabel4);
            this.BrowseTab.Controls.Add(this.BrowseClassList);
            this.BrowseTab.Controls.Add(this.BrowseNamespaceList);
            this.BrowseTab.Controls.Add(this.BrowseClassResults);
            this.BrowseTab.Controls.Add(this.ResultsLabel3);
            this.BrowseTab.Controls.Add(this.BrowseMethodList);
            this.BrowseTab.Controls.Add(this.BrowseMethodButton);
            this.BrowseTab.Controls.Add(this.BrowseMethodStatus);
            this.BrowseTab.Controls.Add(this.ClassLabel2);
            this.BrowseTab.Controls.Add(this.ResultsLabel2);
            this.BrowseTab.Controls.Add(this.BrowsePropertyList);
            this.BrowseTab.Controls.Add(this.BrowsePropertyButton);
            this.BrowseTab.Controls.Add(this.BrowsePropertyStatus);
            this.BrowseTab.Location = new System.Drawing.Point(4, 22);
            this.BrowseTab.Name = "BrowseTab";
            this.BrowseTab.Size = new System.Drawing.Size(840, 471);
            this.BrowseTab.TabIndex = 3;
            this.BrowseTab.Text = "Browse the namespaces on this computer";
            // 
            // BrowseNamespaceResults
            // 
            this.BrowseNamespaceResults.Location = new System.Drawing.Point(88, 16);
            this.BrowseNamespaceResults.Name = "BrowseNamespaceResults";
            this.BrowseNamespaceResults.Size = new System.Drawing.Size(392, 16);
            this.BrowseNamespaceResults.TabIndex = 71;
            // 
            // MethodDescriptionLabel
            // 
            this.MethodDescriptionLabel.Location = new System.Drawing.Point(504, 248);
            this.MethodDescriptionLabel.Name = "MethodDescriptionLabel";
            this.MethodDescriptionLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.MethodDescriptionLabel.Size = new System.Drawing.Size(112, 14);
            this.MethodDescriptionLabel.TabIndex = 70;
            this.MethodDescriptionLabel.Text = "Method Description:";
            // 
            // PropertyDescriptionLabel
            // 
            this.PropertyDescriptionLabel.Location = new System.Drawing.Point(504, 128);
            this.PropertyDescriptionLabel.Name = "PropertyDescriptionLabel";
            this.PropertyDescriptionLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.PropertyDescriptionLabel.Size = new System.Drawing.Size(120, 14);
            this.PropertyDescriptionLabel.TabIndex = 69;
            this.PropertyDescriptionLabel.Text = "Property Description:";
            // 
            // ClassDescriptionLabel
            // 
            this.ClassDescriptionLabel.Location = new System.Drawing.Point(504, 24);
            this.ClassDescriptionLabel.Name = "ClassDescriptionLabel";
            this.ClassDescriptionLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ClassDescriptionLabel.Size = new System.Drawing.Size(96, 14);
            this.ClassDescriptionLabel.TabIndex = 68;
            this.ClassDescriptionLabel.Text = "Class Description:";
            // 
            // BrowseClassDescription
            // 
            this.BrowseClassDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
                | System.Windows.Forms.AnchorStyles.Right)));
            this.BrowseClassDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BrowseClassDescription.Location = new System.Drawing.Point(504, 40);
            this.BrowseClassDescription.Multiline = true;
            this.BrowseClassDescription.Name = "BrowseClassDescription";
            this.BrowseClassDescription.ReadOnly = true;
            this.BrowseClassDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.BrowseClassDescription.Size = new System.Drawing.Size(320, 80);
            this.BrowseClassDescription.TabIndex = 67;
            this.BrowseClassDescription.Text = "";
            // 
            // MethodInformation
            // 
            this.MethodInformation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
                | System.Windows.Forms.AnchorStyles.Right)));
            this.MethodInformation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MethodInformation.Location = new System.Drawing.Point(504, 264);
            this.MethodInformation.Multiline = true;
            this.MethodInformation.Name = "MethodInformation";
            this.MethodInformation.ReadOnly = true;
            this.MethodInformation.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.MethodInformation.Size = new System.Drawing.Size(320, 88);
            this.MethodInformation.TabIndex = 66;
            this.MethodInformation.Text = "";
            // 
            // PropertyInformation
            // 
            this.PropertyInformation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
                | System.Windows.Forms.AnchorStyles.Right)));
            this.PropertyInformation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PropertyInformation.Location = new System.Drawing.Point(504, 144);
            this.PropertyInformation.Multiline = true;
            this.PropertyInformation.Name = "PropertyInformation";
            this.PropertyInformation.ReadOnly = true;
            this.PropertyInformation.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.PropertyInformation.Size = new System.Drawing.Size(320, 88);
            this.PropertyInformation.TabIndex = 65;
            this.PropertyInformation.Text = "";
            // 
            // ResultsLabel1
            // 
            this.ResultsLabel1.Location = new System.Drawing.Point(24, 400);
            this.ResultsLabel1.Name = "ResultsLabel1";
            this.ResultsLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ResultsLabel1.Size = new System.Drawing.Size(48, 16);
            this.ResultsLabel1.TabIndex = 63;
            this.ResultsLabel1.Text = "Results:";
            // 
            // BrowseQualifierList
            // 
            this.BrowseQualifierList.Location = new System.Drawing.Point(232, 360);
            this.BrowseQualifierList.Name = "BrowseQualifierList";
            this.BrowseQualifierList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BrowseQualifierList.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.BrowseQualifierList.Size = new System.Drawing.Size(248, 95);
            this.BrowseQualifierList.Sorted = true;
            this.BrowseQualifierList.TabIndex = 64;
            // 
            // BrowseQualifierButton
            // 
            this.BrowseQualifierButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.BrowseQualifierButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.BrowseQualifierButton.Location = new System.Drawing.Point(24, 360);
            this.BrowseQualifierButton.Name = "BrowseQualifierButton";
            this.BrowseQualifierButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BrowseQualifierButton.Size = new System.Drawing.Size(192, 24);
            this.BrowseQualifierButton.TabIndex = 61;
            this.BrowseQualifierButton.Text = "List all the qualifiers for the class";
            this.BrowseQualifierButton.Click += new System.EventHandler(this.BrowseQualifierButton_Click);
            // 
            // BrowseQualiferStatus
            // 
            this.BrowseQualiferStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BrowseQualiferStatus.Location = new System.Drawing.Point(72, 392);
            this.BrowseQualiferStatus.Name = "BrowseQualiferStatus";
            this.BrowseQualiferStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BrowseQualiferStatus.Size = new System.Drawing.Size(144, 40);
            this.BrowseQualiferStatus.TabIndex = 62;
            // 
            // NamespaceLabel4
            // 
            this.NamespaceLabel4.Location = new System.Drawing.Point(16, 40);
            this.NamespaceLabel4.Name = "NamespaceLabel4";
            this.NamespaceLabel4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.NamespaceLabel4.Size = new System.Drawing.Size(68, 16);
            this.NamespaceLabel4.TabIndex = 60;
            this.NamespaceLabel4.Text = "Namespace:";
            // 
            // BrowseClassList
            // 
            this.BrowseClassList.Location = new System.Drawing.Point(88, 88);
            this.BrowseClassList.MaxDropDownItems = 25;
            this.BrowseClassList.Name = "BrowseClassList";
            this.BrowseClassList.Size = new System.Drawing.Size(400, 21);
            this.BrowseClassList.Sorted = true;
            this.BrowseClassList.TabIndex = 59;
            this.BrowseClassList.SelectedIndexChanged += new System.EventHandler(this.BrowseClassList_SelectedIndexChanged);
            // 
            // BrowseNamespaceList
            // 
            this.BrowseNamespaceList.ItemHeight = 13;
            this.BrowseNamespaceList.Location = new System.Drawing.Point(88, 40);
            this.BrowseNamespaceList.MaxDropDownItems = 25;
            this.BrowseNamespaceList.Name = "BrowseNamespaceList";
            this.BrowseNamespaceList.Size = new System.Drawing.Size(400, 21);
            this.BrowseNamespaceList.Sorted = true;
            this.BrowseNamespaceList.TabIndex = 58;
            this.BrowseNamespaceList.Text = "Select a namespace";
            this.BrowseNamespaceList.SelectedIndexChanged += new System.EventHandler(this.BrowseNamespaceList_SelectedIndexChanged);
            // 
            // BrowseClassResults
            // 
            this.BrowseClassResults.Location = new System.Drawing.Point(96, 64);
            this.BrowseClassResults.Name = "BrowseClassResults";
            this.BrowseClassResults.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BrowseClassResults.Size = new System.Drawing.Size(384, 24);
            this.BrowseClassResults.TabIndex = 57;
            // 
            // ResultsLabel3
            // 
            this.ResultsLabel3.Location = new System.Drawing.Point(24, 288);
            this.ResultsLabel3.Name = "ResultsLabel3";
            this.ResultsLabel3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ResultsLabel3.Size = new System.Drawing.Size(48, 14);
            this.ResultsLabel3.TabIndex = 53;
            this.ResultsLabel3.Text = "Results:";
            // 
            // BrowseMethodList
            // 
            this.BrowseMethodList.Location = new System.Drawing.Point(232, 248);
            this.BrowseMethodList.Name = "BrowseMethodList";
            this.BrowseMethodList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BrowseMethodList.Size = new System.Drawing.Size(248, 95);
            this.BrowseMethodList.Sorted = true;
            this.BrowseMethodList.TabIndex = 54;
            this.BrowseMethodList.SelectedIndexChanged += new System.EventHandler(this.BrowseMethodList_SelectedIndexChanged);
            // 
            // BrowseMethodButton
            // 
            this.BrowseMethodButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.BrowseMethodButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.BrowseMethodButton.Location = new System.Drawing.Point(24, 248);
            this.BrowseMethodButton.Name = "BrowseMethodButton";
            this.BrowseMethodButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BrowseMethodButton.Size = new System.Drawing.Size(192, 24);
            this.BrowseMethodButton.TabIndex = 50;
            this.BrowseMethodButton.Text = "List all the methods in the class";
            this.BrowseMethodButton.Click += new System.EventHandler(this.BrowseMethodButton_Click);
            // 
            // BrowseMethodStatus
            // 
            this.BrowseMethodStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BrowseMethodStatus.Location = new System.Drawing.Point(72, 280);
            this.BrowseMethodStatus.Name = "BrowseMethodStatus";
            this.BrowseMethodStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BrowseMethodStatus.Size = new System.Drawing.Size(144, 40);
            this.BrowseMethodStatus.TabIndex = 51;
            // 
            // ClassLabel2
            // 
            this.ClassLabel2.Location = new System.Drawing.Point(16, 88);
            this.ClassLabel2.Name = "ClassLabel2";
            this.ClassLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ClassLabel2.Size = new System.Drawing.Size(40, 16);
            this.ClassLabel2.TabIndex = 42;
            this.ClassLabel2.Text = "Class:";
            // 
            // ResultsLabel2
            // 
            this.ResultsLabel2.Location = new System.Drawing.Point(24, 176);
            this.ResultsLabel2.Name = "ResultsLabel2";
            this.ResultsLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ResultsLabel2.Size = new System.Drawing.Size(48, 14);
            this.ResultsLabel2.TabIndex = 43;
            this.ResultsLabel2.Text = "Results:";
            // 
            // BrowsePropertyList
            // 
            this.BrowsePropertyList.Location = new System.Drawing.Point(232, 136);
            this.BrowsePropertyList.Name = "BrowsePropertyList";
            this.BrowsePropertyList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BrowsePropertyList.Size = new System.Drawing.Size(248, 95);
            this.BrowsePropertyList.Sorted = true;
            this.BrowsePropertyList.TabIndex = 44;
            this.BrowsePropertyList.SelectedIndexChanged += new System.EventHandler(this.BrowsePropertyList_SelectedIndexChanged);
            // 
            // BrowsePropertyButton
            // 
            this.BrowsePropertyButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.BrowsePropertyButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.BrowsePropertyButton.Location = new System.Drawing.Point(24, 136);
            this.BrowsePropertyButton.Name = "BrowsePropertyButton";
            this.BrowsePropertyButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BrowsePropertyButton.Size = new System.Drawing.Size(192, 24);
            this.BrowsePropertyButton.TabIndex = 38;
            this.BrowsePropertyButton.Text = "List all the properties in the class";
            this.BrowsePropertyButton.Click += new System.EventHandler(this.BrowsePropertyButton_Click);
            // 
            // BrowsePropertyStatus
            // 
            this.BrowsePropertyStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BrowsePropertyStatus.Location = new System.Drawing.Point(72, 168);
            this.BrowsePropertyStatus.Name = "BrowsePropertyStatus";
            this.BrowsePropertyStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BrowsePropertyStatus.Size = new System.Drawing.Size(144, 40);
            this.BrowsePropertyStatus.TabIndex = 40;
            // 
            // MainMenu
            // 
            this.MainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                     this.FileMenuItem,
                                                                                     this.CodeLangMenuItem,
                                                                                     this.TargetComputerMenuItem,
                                                                                     this.HelpMenuItem});
            // 
            // FileMenuItem
            // 
            this.FileMenuItem.Index = 0;
            this.FileMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                         this.ExitMenuItem});
            this.FileMenuItem.Text = "File";
            // 
            // ExitMenuItem
            // 
            this.ExitMenuItem.Index = 0;
            this.ExitMenuItem.Text = "Exit";
            this.ExitMenuItem.Click += new System.EventHandler(this.ExitMenuItem_Click);
            // 
            // CodeLangMenuItem
            // 
            this.CodeLangMenuItem.Index = 1;
            this.CodeLangMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                             this.CSharpMenuItem,
                                                                                             this.VbNetMenuItem,
                                                                                             this.VbsMenuItem});
            this.CodeLangMenuItem.Text = "Code Language";
            // 
            // CSharpMenuItem
            // 
            this.CSharpMenuItem.Index = 0;
            this.CSharpMenuItem.Text = "C#";
            this.CSharpMenuItem.Click += new System.EventHandler(this.CSharpMenuItem_Click);
            // 
            // VbNetMenuItem
            // 
            this.VbNetMenuItem.Index = 1;
            this.VbNetMenuItem.Text = "Visual Basic .NET";
            this.VbNetMenuItem.Click += new System.EventHandler(this.VbNetMenuItem_Click);
            // 
            // VbsMenuItem
            // 
            this.VbsMenuItem.Checked = true;
            this.VbsMenuItem.Index = 2;
            this.VbsMenuItem.Text = "Visual Basic Script";
            this.VbsMenuItem.Click += new System.EventHandler(this.VbsMenuItem_Click);
            // 
            // TargetComputerMenuItem
            // 
            this.TargetComputerMenuItem.Index = 2;
            this.TargetComputerMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                                   this.LocalComputerMenu,
                                                                                                   this.RemoteComputerMenu,
                                                                                                   this.GroupRemoteComputerMenu});
            this.TargetComputerMenuItem.Text = "Target Computer";
            // 
            // LocalComputerMenu
            // 
            this.LocalComputerMenu.Checked = true;
            this.LocalComputerMenu.Index = 0;
            this.LocalComputerMenu.Text = "Local Computer";
            this.LocalComputerMenu.Click += new System.EventHandler(this.LocalComputerMenu_Click);
            // 
            // RemoteComputerMenu
            // 
            this.RemoteComputerMenu.Index = 1;
            this.RemoteComputerMenu.Text = "Remote Computer";
            this.RemoteComputerMenu.Click += new System.EventHandler(this.RemoteComputerMenu_Click);
            // 
            // GroupRemoteComputerMenu
            // 
            this.GroupRemoteComputerMenu.Index = 2;
            this.GroupRemoteComputerMenu.Text = "Group of Remote Computers";
            this.GroupRemoteComputerMenu.Click += new System.EventHandler(this.GroupRemoteComputerMenu_Click);
            // 
            // HelpMenuItem
            // 
            this.HelpMenuItem.Index = 3;
            this.HelpMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                         this.QueryHelpMenuItem,
                                                                                         this.MethodHelpMenuItem,
                                                                                         this.EventHelpMenuItem,
                                                                                         this.BrowseHelpMenuItem});
            this.HelpMenuItem.Text = "Help";
            // 
            // QueryHelpMenuItem
            // 
            this.QueryHelpMenuItem.Index = 0;
            this.QueryHelpMenuItem.Text = "Querying for WMI data";
            this.QueryHelpMenuItem.Click += new System.EventHandler(this.QueryHelpMenuItem_Click);
            // 
            // MethodHelpMenuItem
            // 
            this.MethodHelpMenuItem.Index = 1;
            this.MethodHelpMenuItem.Text = "Executing a method in WMI";
            this.MethodHelpMenuItem.Click += new System.EventHandler(this.MethodHelpMenuItem_Click);
            // 
            // EventHelpMenuItem
            // 
            this.EventHelpMenuItem.Index = 2;
            this.EventHelpMenuItem.Text = "Receiving an event";
            this.EventHelpMenuItem.Click += new System.EventHandler(this.EventHelpMenuItem_Click);
            // 
            // BrowseHelpMenuItem
            // 
            this.BrowseHelpMenuItem.Index = 3;
            this.BrowseHelpMenuItem.Text = "Browsing WMI namespaces";
            this.BrowseHelpMenuItem.Click += new System.EventHandler(this.BrowseHelpMenuItem_Click);
            // 
            // WMICodeCreator
            // 
            this.AllowDrop = true;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(848, 497);
            this.Controls.Add(this.MainTabControl);
            this.Menu = this.MainMenu;
            this.Name = "WMICodeCreator";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WMI Code Creator";
            this.Load += new System.EventHandler(this.WMICodeBuddy_Load);
            this.MainTabControl.ResumeLayout(false);
            this.QueryTab.ResumeLayout(false);
            this.CodeGroupBox.ResumeLayout(false);
            this.MethodTab.ResumeLayout(false);
            this.MethodCodeGroupBox.ResumeLayout(false);
            this.EventTab.ResumeLayout(false);
            this.EventCodeGroupBox.ResumeLayout(false);
            this.BrowseTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        //-------------------------------------------------------------------------
        // The main entry point for the application. Creates a new WMICodeCreator form.
        //
        //-------------------------------------------------------------------------
        [STAThread]
        static void Main() 
        {
            Application.EnableVisualStyles();
            Application.Run(new WMICodeCreator());
        }


        //-------------------------------------------------------------------------
        // When the form is created, this method adds all the WMI classes to
        // the lists of classes on each tab in the WMICodeCreator form. This method
        // should only be called in the WMICodeCreator constructor.
        //-------------------------------------------------------------------------
        private void InitialAddClassesToList(object o) 
        {
            // Start the progress bar on the splash screen.
            SplashScreenForm.SetProgressMax(330);   

            // Variables for counting the class on each tab
            // and for status.
            int queryClassCount = 0;
            this.ClassStatus.Text = "Searching...";
            int classCount_m = 0;
            this.ClassStatus_m.Text = "Searching...";
            int classCount_event = 0;
            this.ClassStatus_event.Text = "Searching...";

            try 
            {
                // Performs WMI object query on 
                // the selected namespace.
                ManagementObjectSearcher searcher = 
                    new ManagementObjectSearcher(
                    new ManagementScope(
                    "root\\CIMV2"),
                    new WqlObjectQuery(
                    "select * from meta_class"),
                    null);

                foreach (ManagementClass wmiClass in
                    searcher.Get()) 
                {
                    // If the class is derived from the __Event class, add it
                    // to the event class list.
                    if(wmiClass.Derivation.Contains("__Event"))
                    {
                        this.ClassList_event.Items.Add(
                            wmiClass["__CLASS"].ToString());
                        classCount_event++;
                    }

                    foreach (QualifierData qd in wmiClass.Qualifiers)
                    {
                        // If the class is dynamic or static, add it to the class
                        // list on the query tab.
                        if(qd.Name.Equals("dynamic") || qd.Name.Equals("static"))
                        {
                            this.ClassList.Items.Add(
                                wmiClass["__CLASS"].ToString());
                            queryClassCount++;

                            // Increment the progress bar on the splash screen.
                            if(queryClassCount < 199)
                            {
                                SplashScreenForm.IncrementProgress();
                            }

                            // If the class has methods, add it to the method class list.
                            if(wmiClass.Methods.Count > 0)
                            {
                                this.ClassList_m.Items.Add(
                                    wmiClass["__CLASS"].ToString());
                                classCount_m++;

                                // Increment the progress bar on the splash screen.
                                if(classCount_m < 110)
                                {
                                    SplashScreenForm.IncrementProgress();
                                }
                            }
                        }

                    }
                }
                // Report the number of WMI classes found.
                this.ClassStatus.Text = 
                    queryClassCount + " classes (dynamic or static) found.";
                this.ClassStatus_m.Text = 
                    classCount_m + " classes with methods found.";
                this.ClassStatus_event.Text = 
                    classCount_event + " classes derived from the __Event class found.";

                SplashScreenForm.CloseForm();
                
            }
                // Report problems during the population of the class lists.
            catch (System.Management.ManagementException ex) 
            {
                this.ClassStatus.Text = ex.Message;
                this.ClassStatus_m.Text = ex.Message;
                this.ClassStatus_event.Text = ex.Message;
            }
            catch (System.ArgumentOutOfRangeException rangeException)
            {
                this.ClassStatus.Text = rangeException.Message;
                this.ClassStatus_m.Text = rangeException.Message;
                this.ClassStatus_event.Text = rangeException.Message;
            }
            catch (System.ArgumentException argException)
            {
                this.ClassStatus.Text = argException.Message;
                this.ClassStatus_m.Text = argException.Message;
                this.ClassStatus_event.Text = argException.Message;
            }
        }

        //-------------------------------------------------------------------------
        // Adds the namespaces to the namespace lists
        // starting from the "root" namespace.
        //-------------------------------------------------------------------------
        private void AddNamespacesToList(object o) 
        {
            this.NamespaceCount = 0;
            AddNamespacesToListRecursive("root");
        }

        //-------------------------------------------------------------------------
        // Adds the namespaces to the namespace starting from the root
        // namespace passed into the root in-parameter.
        //-------------------------------------------------------------------------
        private void AddNamespacesToListRecursive(string root) 
        {
            
            this.BrowseNamespaceResults.Text = "Searching...";
            try 
            {
                // Enumerates all WMI instances of 
                // __namespace WMI class.
                ManagementClass nsClass = 
                    new ManagementClass(
                    new ManagementScope(root),
                    new ManagementPath("__namespace"),
                    null);
                foreach(ManagementObject ns in 
                    nsClass.GetInstances())
                {
                    // Adds the namespaces to the namespace lists.
                    string namespaceName = root + "\\" + ns["Name"].ToString();
                    this.BrowseNamespaceList.Items.
                        Add(namespaceName);
                    this.NamespaceValue_m.Items.Add(
                        namespaceName);
                    this.NamespaceValue.Items.Add(
                        namespaceName);
                    this.NamespaceList_event.Items.Add(
                        namespaceName);
                    SplashScreenForm.IncrementProgress();
                    NamespaceCount++;
                    AddNamespacesToListRecursive(namespaceName);
                }
                // Reports the number of namespaces found.
                this.BrowseNamespaceResults.Text = 
                    NamespaceCount + " namespaces found.";
            }
            catch (ManagementException e) 
            {
                this.BrowseNamespaceResults.Text = e.Message;
            }
        }

        //-------------------------------------------------------------------------
        // Calls the AddNamespacesToTargetListRecursive method to start with the
        // "root" namespace.
        //-------------------------------------------------------------------------
        private void AddNamespacesToTargetList(object o)
        {
            AddNamespacesToTargetListRecursive("root");
        }

        //-------------------------------------------------------------------------
        // Adds the namespaces to the TargetClassList_event list on the event tab
        // when the user selects the __Namespace*Event class.
        //-------------------------------------------------------------------------
        private void AddNamespacesToTargetListRecursive(string root)
        {
            try 
            {
                // Enumerates all WMI instances of 
                // __namespace WMI class.
                ManagementClass nsClass = 
                    new ManagementClass(
                    new ManagementScope(root),
                    new ManagementPath("__namespace"),
                    null);
                foreach(ManagementObject ns in 
                    nsClass.GetInstances())
                {
                    // Add namespaces to the list.
                    string namespaceName = root + "\\" + ns["Name"].ToString();
                    this.TargetClassList_event.Items.
                        Add(namespaceName);
                    
                    AddNamespacesToTargetListRecursive(namespaceName);
                }
                
            }
            catch (ManagementException e)
            {
                MessageBox.Show("Error creating a list of namespaces: " + e.Message);
            }


        }

        //-------------------------------------------------------------------------
        // Populates the query tab's class list.
        //
        //-------------------------------------------------------------------------
        private void AddClassesToList(object o) 
        {   

            int classCount = 0;
            this.ClassStatus.Text = "Searching...";
            try 
            {
                // Performs WMI object query on 
                // selected namespace.
                ManagementObjectSearcher searcher = 
                    new ManagementObjectSearcher(
                    new ManagementScope(
                    NamespaceValue.Text),
                    new WqlObjectQuery(
                    "select * from meta_class"),
                    null);

                foreach (ManagementClass wmiClass in
                    searcher.Get()) 
                {
                    foreach (QualifierData qd in wmiClass.Qualifiers)
                    {
                        // If the class is dynamic, add it to the list.
                        if(qd.Name.Equals("dynamic") || qd.Name.Equals("static"))
                        {
                            this.ClassList.Items.Add(
                                wmiClass["__CLASS"].ToString());
                            classCount++;
                        }
                    }
                }
                // Report the number of classes found.
                this.ClassStatus.Text = 
                    classCount + " classes (dynamic or static) found.";
                
            }
            catch (ManagementException ex) 
            {
                this.ClassStatus.Text = ex.Message;
            }			
        }

        //-------------------------------------------------------------------------
        // Populates the method tab's class list.
        //
        //-------------------------------------------------------------------------
        private void AddClassesToMethodPageList(object o) 
        {

            int classCount_m = 0;
            this.ClassStatus_m.Text = "Searching...";
            try 
            {
                // Performs WMI object query on the
                // selected namespace.
                ManagementObjectSearcher searcher = 
                    new ManagementObjectSearcher(
                    new ManagementScope(
                    NamespaceValue_m.Text),
                    new WqlObjectQuery(
                    "select * from meta_class"),
                    null);				
                foreach (ManagementClass wmiClass in
                    searcher.Get()) 
                {
                    foreach (QualifierData qd in wmiClass.Qualifiers)
                    {
                        if(qd.Name.Equals("dynamic") || qd.Name.Equals("static"))
                        { 
                            // If the class has methods, add it to the list.
                            if(wmiClass.Methods.Count > 0)
                            {
                                this.ClassList_m.Items.Add(
                                    wmiClass["__CLASS"].ToString());
                                classCount_m++;
                            }
                        }
                    }
                }
                this.ClassStatus_m.Text = 
                    classCount_m + " classes with methods found.";
                
            }
            catch (ManagementException ex) 
            {
                this.ClassStatus_m.Text = ex.Message;
            }			
        }

        //-------------------------------------------------------------------------
        // Populates the event tab's TargetClassList_event list with classes
        // that contain methods. This method should be called when the user
        // selects the __MethodInvocationEvent event class.
        //-------------------------------------------------------------------------
        private void AddMethodClassesToTargetClassList(object o)
        {
            try 
            {
                // Performs WMI object query on the
                // selected namespace.
                ManagementObjectSearcher searcher = 
                    new ManagementObjectSearcher(
                    new ManagementScope(
                    this.NamespaceList_event.Text),
                    new WqlObjectQuery(
                    "select * from meta_class"),
                    null);				
                foreach (ManagementClass wmiClass in
                    searcher.Get()) 
                {
                    foreach (QualifierData qd in wmiClass.Qualifiers)
                    {
                        if(qd.Name.Equals("dynamic") || qd.Name.Equals("static"))
                        { 
                            // If the class has methods, send it to the list.
                            if(wmiClass.Methods.Count > 0)
                            {
                                this.TargetClassList_event.Items.Add(
                                    wmiClass["__CLASS"].ToString());
                            }
                        }
                    }
                }
                
            }
            catch (ManagementException e)
            {
                MessageBox.Show("Error creating a list of classes with methods: " + e.Message);
            }
			
        }

        //-------------------------------------------------------------------------
        // Populates the event tab's class list with classes derived from the
        // __Event class.
        //-------------------------------------------------------------------------
        private void AddClassesToEventPageList(object o) 
        {
            int classCount_event = 0;
            this.ClassStatus_event.Text = "Searching...";
            try 
            {
                // Performs WMI object query on the
                // selected namespace.
                ManagementObjectSearcher searcher = 
                    new ManagementObjectSearcher(
                    new ManagementScope(
                    NamespaceList_event.Text),
                    new WqlObjectQuery(
                    "select * from meta_class"),
                    null);
				
                foreach (ManagementClass wmiClass in
                    searcher.Get()) 
                { 
                    // If the class is derived from an event class,
                    // send it to the list.
                    if(wmiClass.Derivation.Contains("__Event"))
                    {
                        this.ClassList_event.Items.Add(
                            wmiClass["__CLASS"].ToString());
                        classCount_event++;
                    }
                }
                this.ClassStatus_event.Text = 
                    classCount_event + " classes derived from the __Event class found.";
                
            }
            catch (ManagementException ex) 
            {
                this.ClassStatus_event.Text = ex.Message;
            }			
        }

        //-------------------------------------------------------------------------
        // Populates the event tab's target class list with classes
        // that contain methods.
        //-------------------------------------------------------------------------
        private void AddClassesToTargetClassList(object o) 
        {
            try 
            {
                // Performs WMI object query on the
                // selected namespace.
                ManagementObjectSearcher searcher = 
                    new ManagementObjectSearcher(
                    new ManagementScope(
                    this.NamespaceList_event.Text),
                    new WqlObjectQuery(
                    "select * from meta_class"),
                    null);				
                foreach (ManagementClass wmiClass in
                    searcher.Get()) 
                {
                    this.TargetClassList_event.Items.Add(
                        wmiClass["__CLASS"].ToString());
                }
                
            }
            catch (ManagementException e)
            {
                MessageBox.Show("Error creating a list of classes: " + e.Message);
            }		
        }

        //-------------------------------------------------------------------------
        // Populates the browse tab's class list with all the classes
        // from the selected namespace.
        //-------------------------------------------------------------------------
        private void AddClassesToBrowserList(object o) 
        {
            int classCount_b = 0;
            this.BrowseClassResults.Text = "Searching...";
            try 
            {
                // Performs WMI object query on the
                // selected namespace.
                ManagementObjectSearcher searcher = 
                    new ManagementObjectSearcher(
                    new ManagementScope(
                    this.BrowseNamespaceList.SelectedItem.ToString()),
                    new WqlObjectQuery(
                    "select * from meta_class"),
                    null);				
                foreach (ManagementClass wmiClass in
                    searcher.Get()) 
                {
                    this.BrowseClassList.Items.Add(
                        wmiClass["__CLASS"].ToString());
                    classCount_b++;
                }
                this.BrowseClassResults.Text = 
                    classCount_b + " classes found.";
            }
            catch (ManagementException ex) 
            {
                this.BrowseClassResults.Text = ex.Message;
            }			
        }

        //-------------------------------------------------------------------------
        // Populates the query tab's property list with properties from 
        // the class in the class list.
        //-------------------------------------------------------------------------
        private void AddPropertiesToList(object o)
        {
	
            int propertyCount = 0;
            this.PropertyStatus.Text = "Searching...";

            try
            {
                // Gets the property qualifiers.
                ObjectGetOptions op = new ObjectGetOptions(null, System.TimeSpan.MaxValue, true);

                ManagementClass mc = new ManagementClass(this.NamespaceValue.Text,
                    this.ClassList.Text, op);
                mc.Options.UseAmendedQualifiers = true;

                foreach (PropertyData dataObject in
                    mc.Properties)
                {
                    this.PropertyList.Items.Add(
                        dataObject.Name);
                    propertyCount++;
                }

                this.PropertyStatus.Text = 
                    propertyCount + " properties found.";
            }
            catch (ManagementException ex) 
            {
                this.PropertyStatus.Text = ex.Message;
            }			
        }

        //-------------------------------------------------------------------------
        // Populates the browse tab's property list with properties from the
        // class in the class list.
        //-------------------------------------------------------------------------
        private void AddPropertiesToBrowserList(object o)
        {
            int propertyCount_b = 0;
            this.BrowsePropertyStatus.Text = "Searching...";

            try
            {
                // Gets the property qualifiers.
                ObjectGetOptions op = new ObjectGetOptions(null, System.TimeSpan.MaxValue, true);

                ManagementClass mc = new ManagementClass(this.BrowseNamespaceList.Text,
                    this.BrowseClassList.Text, op);
                mc.Options.UseAmendedQualifiers = true;

                foreach (PropertyData dataObject in
                    mc.Properties)
                {
                    this.BrowsePropertyList.Items.Add(
                        dataObject.Name);
                    propertyCount_b++;
                }

                this.BrowsePropertyStatus.Text = 
                    propertyCount_b + " properties found.";
            }
            catch (ManagementException ex) 
            {
                this.BrowsePropertyStatus.Text = ex.Message;
            }			
        }

        //-------------------------------------------------------------------------
        // Populates the browse tab's qualifier list with qualifiers from the
        // class in the class list.
        //-------------------------------------------------------------------------
        private void AddQualifiersToBrowserList(object o)
        {
            int qualifierCount_b = 0;
            this.BrowseQualiferStatus.Text = "Searching...";

            try
            {
                // Gets the property qualifiers.
                ObjectGetOptions op = new ObjectGetOptions(null, System.TimeSpan.MaxValue, true);

                ManagementClass mc = new ManagementClass(this.BrowseNamespaceList.Text,
                    this.BrowseClassList.Text, op);
                mc.Options.UseAmendedQualifiers = true;

                foreach (QualifierData dataObject in
                    mc.Qualifiers)
                {
                    this.BrowseQualifierList.Items.Add(
                        dataObject.Name);
                    qualifierCount_b++;
                }


                this.BrowseQualiferStatus.Text = 
                    qualifierCount_b + " qualifiers found.";
            }
            catch (ManagementException ex) 
            {
                this.BrowsePropertyStatus.Text = ex.Message;
            }			
        }

        //-------------------------------------------------------------------------
        // Populates the method tab's method list with methods from the
        // class in the class list.
        //-------------------------------------------------------------------------
        private void AddMethodsToList(object o)
        {
            int methodCount = 0;
            this.MethodStatus.Text = "Searching...";

            try 
            {
                ManagementClass c = new ManagementClass(this.NamespaceValue_m.Text, this.ClassList_m.Text, null);
                foreach (MethodData m in c.Methods)
                {
                    this.MethodList.Items.Add(
                        m.Name);
                    methodCount++;

                }
				
                this.MethodStatus.Text = 
                    methodCount + " methods found.";
            }
            catch (ManagementException ex) 
            {
                this.MethodStatus.Text = ex.Message;
            }
            
        }

        //-------------------------------------------------------------------------
        // Populates the browse tab's method list with methods from the
        // class in the class list.
        //-------------------------------------------------------------------------
        private void AddMethodsToBrowserList(object o)
        {
            int methodCount_b = 0;
            this.BrowseMethodStatus.Text = "Searching...";

            try 
            {   
                ObjectGetOptions options = new ObjectGetOptions();
                ManagementClass c = new ManagementClass(this.BrowseNamespaceList.Text,
                    this.BrowseClassList.Text, options);
                c.Options.UseAmendedQualifiers = true;

                foreach (MethodData m in c.Methods)
                {
                    this.BrowseMethodList.Items.Add(
                        m.Name);
                    methodCount_b++;

                }
				
                this.BrowseMethodStatus.Text = 
                    methodCount_b + " methods found.";
            }
            catch (ManagementException ex) 
            {
                this.BrowseMethodStatus.Text = ex.Message;
            }
            
        }

        //-------------------------------------------------------------------------
        // Populates the query tab's property value list with values from the
        // selected properties in the property list.
        //-------------------------------------------------------------------------
        private void AddValuesToList(object o)
        {
            string buffer = "";
            int valueCount = 0;
            this.ValueStatus.Text = "Searching...";
            try 
            {
                // Performs WMI object query on the
                // selected class.
                string query = "select * from " + this.ClassList.Text;
                ManagementObjectSearcher searcher = 
                    new ManagementObjectSearcher(
                    new ManagementScope(
                    NamespaceValue.Text),
                    new WqlObjectQuery(query),
                    null);
  
                bool instanceCounter = true;
                foreach (ManagementObject wmiObject in
                    searcher.Get()) 
                {
                    foreach (object property in this.PropertyList.SelectedItems)
                    {
                        if(wmiObject.Properties[property.ToString()].IsArray)
                        {
                            // Do nothing.
                        }
                        else
                        {
                            // Set buffer string used to separate instances in the list.
                            if(instanceCounter)
                            {
                                buffer = "";
                            }
                            else
                            {
                                buffer = "          ";
                            }

                            // Property is not an array.
                            if(wmiObject.Properties[property.ToString()].Type.ToString().Equals("String"))
                            {	
                                // Property is a string.
                                this.ValueList.Items.Add(buffer + property.ToString() + " = '" +
                                    wmiObject.GetPropertyValue(
                                    property.ToString()) + "'" );
								
                                valueCount++;
                            }
                            else
                            {
                                // Property is not a string.
                                this.ValueList.Items.Add(buffer + property.ToString() + " = " +
                                    wmiObject.GetPropertyValue(
                                    property.ToString()));
                                valueCount++;
                            }
                        }
                    }
                    
                    if(instanceCounter)
                    {
                        instanceCounter = false;
                    }
                    else
                    {
                        instanceCounter = true;
                    }
                }
                this.ValueStatus.Text = 
                    valueCount + " values found. Properties with an array data type are not listed (can't be used in a query).";
            }
            catch (ManagementException ex) 
            {
                this.ValueStatus.Text = ex.Message;
            }			
        }

        //-------------------------------------------------------------------------
        // Handles the event when a property is selected in the query tab property
        // list.
        //-------------------------------------------------------------------------
        private void PropertyList_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if(this.PropertyList.SelectedItems.Count.Equals(0))
            {
                this.CodeText.Clear();
                this.ValueList.Items.Clear();
            }
            else if(this.PropertyList.SelectedItems.Count >= 1)
            {
                GenerateQueryCode();
            }
     
        }

        //-------------------------------------------------------------------------
        // Generates the code in the query tab's generated code text box.
        // 
        //-------------------------------------------------------------------------
        private void GenerateQueryCode()
        {
            try
            {
                if(!this.ClassList.Text.Equals("")) 
                {
                    if(this.VbNetMenuItem.Checked)
                    {
                        GenerateVBNetQueryCode();
                    }
                    else if(this.CSharpMenuItem.Checked)
                    {
                        GenerateCSharpQueryCode();
                    }
                    else if(this.VbsMenuItem.Checked)
                    {
                        GenerateVBSQueryCode();
                    }
                }
            }
            catch (ManagementException mErr)
            {
                if(mErr.Message.Equals("Not found "))
                    MessageBox.Show("WMI class or method not found.");
                else
                    MessageBox.Show(mErr.Message.ToString());
            }
        }

        //-------------------------------------------------------------------------
        // Generates the VBScript in the query tab's generated code area.
        // 
        //-------------------------------------------------------------------------
        private void GenerateVBSQueryCode()
        {
            try 
            {
                string code = "";

                if(this.RemoteComputerMenu.Checked)
                {
                    code = code + "strComputer = \"" + this.TargetWindow.GetRemoteComputerName() + "\" " 
                        + Environment.NewLine +
                        "strDomain = \"" + this.TargetWindow.GetRemoteComputerDomain() + "\" " 
                        + Environment.NewLine +
                        "Wscript.StdOut.Write \"Please enter your user name:\"" +
                        Environment.NewLine +
                        "strUser = Wscript.StdIn.ReadLine "
                        + Environment.NewLine +
                        "Set objPassword = CreateObject(\"ScriptPW.Password\")" 
                        + Environment.NewLine +
                        "Wscript.StdOut.Write \"Please enter your password:\""
                        + Environment.NewLine +
                        "strPassword = objPassword.GetPassword()"
                        + Environment.NewLine +
                        "Wscript.Echo"
                        + Environment.NewLine + Environment.NewLine +
                        "Set objSWbemLocator = CreateObject(\"WbemScripting.SWbemLocator\") " 
                        + Environment.NewLine +
                        "Set objWMIService = objSWbemLocator.ConnectServer(strComputer, _ "
                        + Environment.NewLine +
                        "    \"" + this.NamespaceValue.Text +"\", _ " 
                        + Environment.NewLine +
                        "    strUser, _ "
                        + Environment.NewLine +
                        "    strPassword, _ "
                        + Environment.NewLine +
                        "    \"MS_409\", _ "
                        + Environment.NewLine +
                        "    \"ntlmdomain:\" + strDomain) "
                        + Environment.NewLine;
                }
                else if(this.GroupRemoteComputerMenu.Checked)
                {
                    string delimStr = " ,\n";
                    char [] delimiter = delimStr.ToCharArray();
                    string [] split = this.TargetWindow.GetArrayOfComputers().Split(delimiter);


                    code = code + "arrComputers = Array(\"";
                    foreach (string s in split) 
                    {
                        code = code + s.Trim() + "\",\"";
                    }
                    string trimStr = ",\"";
                    char [] trim = trimStr.ToCharArray();
                    code = code.TrimEnd(trim) + "\")" +
                        Environment.NewLine +
                        "For Each strComputer In arrComputers" +
                        Environment.NewLine +
                        "   WScript.Echo" +
                        Environment.NewLine +
                        "   WScript.Echo \"==========================================\"" +
                        Environment.NewLine +
                        "   WScript.Echo \"Computer: \" & strComputer" +
                        Environment.NewLine +
                        "   WScript.Echo \"==========================================\"" +
                        Environment.NewLine + 
                        Environment.NewLine +
                       
                        "Set objWMIService = GetObject(\"winmgmts:\\\\\" & strComputer & \"\\" +
                        this.NamespaceValue.Text + "\") " 
                        + Environment.NewLine;
                }
                else
                {
                
                    code = code + "strComputer = \".\" " 
                        + Environment.NewLine +
                        "Set objWMIService = GetObject(\"winmgmts:\\\\\" & strComputer & \"\\" +
                        this.NamespaceValue.Text + "\") " 
                        + Environment.NewLine;
                }
 
                code = code + "Set colItems = objWMIService.ExecQuery( _" + Environment.NewLine +
                    "    \"SELECT * FROM " +
                    // Class from selection.
                    this.ClassList.Text;

                if(this.ValueList.SelectedItems.Count >= 1)
                {
                    string updatedValue = ValueList.SelectedItems[0].ToString().Replace("\\", "\\\\").Trim();
                    code = code + " WHERE " + updatedValue;
                }
                
                code = code + "\",,48) " + Environment.NewLine +
                    "For Each objItem in colItems " + Environment.NewLine +
                    "    Wscript.Echo \"-----------------------------------\"" +
                    Environment.NewLine +
                    "    Wscript.Echo \"" + this.ClassList.Text + " instance\"" +
                    Environment.NewLine +
                    "    Wscript.Echo \"-----------------------------------\"" +
                    Environment.NewLine;

                ManagementClass m = new ManagementClass(this.NamespaceValue.Text, this.ClassList.Text, null);

                
                for( int i=0; i < PropertyList.SelectedItems.Count; i++)
                {
                    if(m.Properties[PropertyList.SelectedItems[i].ToString()].IsArray)
                    {
                        code = code + "    If isNull(objItem." + PropertyList.SelectedItems[i].ToString() + ") Then" + Environment.NewLine +
                            "        Wscript.Echo \"" + PropertyList.SelectedItems[i].ToString() + ": \"" + Environment.NewLine +
                            "    Else" + Environment.NewLine +
                            "        Wscript.Echo \"" + PropertyList.SelectedItems[i].ToString() + ": \" & Join(objItem." + PropertyList.SelectedItems[i].ToString() +
                            ", \",\")" + System.Environment.NewLine +
                            "    End If" +
                            Environment.NewLine;
                    }
                    else
                    {
                        code = code + "    Wscript.Echo \"" + 
                            // Property from selection.
                            this.PropertyList.SelectedItems[i].ToString() +
                            ": \" & objItem." +
                            this.PropertyList.SelectedItems[i].ToString() +
                            Environment.NewLine;
                    }
                }

                if(this.GroupRemoteComputerMenu.Checked)
                {
                    code = code + "Next" + Environment.NewLine;
                }

                code = code + "Next";

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

        //-------------------------------------------------------------------------
        // Generates the C# code in the query tab's generated code area.
        // 
        //-------------------------------------------------------------------------
        private void GenerateCSharpQueryCode()
        {
            try
            {
                string code = "";

                if(this.LocalComputerMenu.Checked)
                {
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
                }
                else if(this.RemoteComputerMenu.Checked)
                {
                    code = "using System;" + Environment.NewLine +
                        "using System.Drawing;" + Environment.NewLine +
                        "using System.Collections;" + Environment.NewLine +
                        "using System.ComponentModel;" + Environment.NewLine +
                        "using System.Windows.Forms;" + Environment.NewLine +
                        "using System.Data;" + Environment.NewLine +
                        "using System.Management;" + Environment.NewLine +
                        Environment.NewLine +
                        "namespace WMISample" + Environment.NewLine +
                        "{" + Environment.NewLine +
                        "    public class MyQuerySample : System.Windows.Forms.Form" + Environment.NewLine +
                        "    {" + Environment.NewLine +
                        "        private System.Windows.Forms.Label userNameLabel;" + Environment.NewLine +
                        "        private System.Windows.Forms.TextBox userNameBox;" + Environment.NewLine +
                        "        private System.Windows.Forms.TextBox passwordBox;" + Environment.NewLine +
                        "        private System.Windows.Forms.Label passwordLabel;" + Environment.NewLine +
                        "        private System.Windows.Forms.Button OKButton;" + Environment.NewLine +
                        "        private System.Windows.Forms.Button cancelButton;" + Environment.NewLine +
                        "        " + Environment.NewLine +
                        "        private System.ComponentModel.Container components = null;" + Environment.NewLine +
                        Environment.NewLine +
                        "        public MyQuerySample()" + Environment.NewLine +
                        "        {" + Environment.NewLine +
                        "            InitializeComponent();" + Environment.NewLine +
                        "        }" + Environment.NewLine +
                        Environment.NewLine +
                        "        protected override void Dispose( bool disposing )" + Environment.NewLine +
                        "        {" + Environment.NewLine +
                        "            if( disposing )" + Environment.NewLine +
                        "            {" + Environment.NewLine +
                        "                if (components != null)" + Environment.NewLine + 
                        "                {" + Environment.NewLine +
                        "                    components.Dispose();" + Environment.NewLine +
                        "                }" + Environment.NewLine +
                        "            }" + Environment.NewLine +
                        "            base.Dispose( disposing );" + Environment.NewLine +
                        "        }" + Environment.NewLine +
                        Environment.NewLine +
                        "        private void InitializeComponent()" + Environment.NewLine +
                        "        {" + Environment.NewLine +
                        "            this.userNameLabel = new System.Windows.Forms.Label();" + Environment.NewLine +
                        "            this.userNameBox = new System.Windows.Forms.TextBox();" + Environment.NewLine +
                        "            this.passwordBox = new System.Windows.Forms.TextBox();" + Environment.NewLine +
                        "            this.passwordLabel = new System.Windows.Forms.Label();" + Environment.NewLine +
                        "            this.OKButton = new System.Windows.Forms.Button();" + Environment.NewLine +
                        "            this.cancelButton = new System.Windows.Forms.Button();" + Environment.NewLine +
                        "            this.SuspendLayout();" + Environment.NewLine +
                        "            // " + Environment.NewLine +
                        "            // userNameLabel" + Environment.NewLine +
                        "            // " + Environment.NewLine +
                        "            this.userNameLabel.Location = new System.Drawing.Point(16, 8);" + Environment.NewLine +
                        "            this.userNameLabel.Name = \"userNameLabel\";" + Environment.NewLine +
                        "            this.userNameLabel.Size = new System.Drawing.Size(160, 32);" + Environment.NewLine +
                        "            this.userNameLabel.TabIndex = 0;" + Environment.NewLine +
                        "            this.userNameLabel.Text = \"Enter the user name for the remote computer:\";" + Environment.NewLine +
                        "            // " + Environment.NewLine +
                        "            // userNameBox" + Environment.NewLine +
                        "            // " + Environment.NewLine +
                        "            this.userNameBox.Location = new System.Drawing.Point(160, 16);" + Environment.NewLine +
                        "            this.userNameBox.Name = \"userNameBox\";" + Environment.NewLine +
                        "            this.userNameBox.Size = new System.Drawing.Size(192, 20);" + Environment.NewLine +
                        "            this.userNameBox.TabIndex = 1;" + Environment.NewLine +
                        "            this.userNameBox.Text = \"\";" + Environment.NewLine +
                        "            // " + Environment.NewLine +
                        "            // passwordBox" + Environment.NewLine +
                        "            // " + Environment.NewLine +
                        "            this.passwordBox.Location = new System.Drawing.Point(160, 48);" + Environment.NewLine +
                        "            this.passwordBox.Name = \"passwordBox\";" + Environment.NewLine +
                        "            this.passwordBox.PasswordChar = '*';" + Environment.NewLine +
                        "            this.passwordBox.Size = new System.Drawing.Size(192, 20);" + Environment.NewLine +
                        "            this.passwordBox.TabIndex = 3;" + Environment.NewLine +
                        "            this.passwordBox.Text = \"\";" + Environment.NewLine +
                        "            // " + Environment.NewLine +
                        "            // passwordLabel" + Environment.NewLine +
                        "            // " + Environment.NewLine +
                        "            this.passwordLabel.Location = new System.Drawing.Point(16, 48);" + Environment.NewLine +
                        "            this.passwordLabel.Name = \"passwordLabel\";" + Environment.NewLine +
                        "            this.passwordLabel.Size = new System.Drawing.Size(160, 32);" + Environment.NewLine +
                        "            this.passwordLabel.TabIndex = 2;" + Environment.NewLine +
                        "            this.passwordLabel.Text = \"Enter the password for the remote computer:\";" + Environment.NewLine +
                        "            // " + Environment.NewLine +
                        "            // OKButton" + Environment.NewLine +
                        "            // " + Environment.NewLine +
                        "            this.OKButton.Location = new System.Drawing.Point(40, 88);" + Environment.NewLine +
                        "            this.OKButton.Name = \"OKButton\";" + Environment.NewLine +
                        "            this.OKButton.Size = new System.Drawing.Size(128, 23);" + Environment.NewLine +
                        "            this.OKButton.TabIndex = 4;" + Environment.NewLine +
                        "            this.OKButton.Text = \"OK\";" + Environment.NewLine +
                        "            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);" + Environment.NewLine +
                        "            // " + Environment.NewLine +
                        "            // cancelButton" + Environment.NewLine +
                        "            // " + Environment.NewLine +
                        "            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;" + Environment.NewLine +
                        "            this.cancelButton.Location = new System.Drawing.Point(200, 88);" + Environment.NewLine +
                        "            this.cancelButton.Name = \"cancelButton\";" + Environment.NewLine +
                        "            this.cancelButton.Size = new System.Drawing.Size(128, 23);" + Environment.NewLine +
                        "            this.cancelButton.TabIndex = 5;" + Environment.NewLine +
                        "            this.cancelButton.Text = \"Cancel\";" + Environment.NewLine +
                        "            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);" + Environment.NewLine +
                        "            // " + Environment.NewLine +
                        "            // MyQuerySample" + Environment.NewLine +
                        "            // " + Environment.NewLine +
                        "            this.AcceptButton = this.OKButton;" + Environment.NewLine +
                        "            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);" + Environment.NewLine +
                        "            this.CancelButton = this.cancelButton;" + Environment.NewLine +
                        "            this.ClientSize = new System.Drawing.Size(368, 130);" + Environment.NewLine +
                        "            this.ControlBox = false;" + Environment.NewLine +
                        "            this.Controls.Add(this.cancelButton);" + Environment.NewLine +
                        "            this.Controls.Add(this.OKButton);" + Environment.NewLine +
                        "            this.Controls.Add(this.passwordBox);" + Environment.NewLine +
                        "            this.Controls.Add(this.passwordLabel);" + Environment.NewLine +
                        "            this.Controls.Add(this.userNameBox);" + Environment.NewLine +
                        "            this.Controls.Add(this.userNameLabel);" + Environment.NewLine +
                        "            this.Name = \"MyQuerySample\";" + Environment.NewLine +
                        "            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;" + Environment.NewLine +
                        "            this.Text = \"Remote Connection\";" + Environment.NewLine +
                        "            this.ResumeLayout(false);" + Environment.NewLine +
                        Environment.NewLine +
                        "        }" + Environment.NewLine +
                        Environment.NewLine +
                        "        [STAThread]" + Environment.NewLine +
                        "        static void Main() " + Environment.NewLine +
                        "        {" + Environment.NewLine +
                        "            Application.Run(new MyQuerySample());" + Environment.NewLine +
                        "        }" + Environment.NewLine +
                        Environment.NewLine +
                        "        private void OKButton_Click(object sender, System.EventArgs e)" + Environment.NewLine +
                        "        {" + Environment.NewLine +
                        "            try" + Environment.NewLine +
                        "            {" + Environment.NewLine +
                        "                ConnectionOptions connection = new ConnectionOptions();" + Environment.NewLine +
                        "                connection.Username = userNameBox.Text;" + Environment.NewLine +
                        "                connection.Password = passwordBox.Text;" + Environment.NewLine +
                        "                connection.Authority = \"ntlmdomain:" + this.TargetWindow.GetRemoteComputerDomain() + "\";" + Environment.NewLine +
                        Environment.NewLine +
                        "                ManagementScope scope = new ManagementScope(" + Environment.NewLine +
                        "                    \"\\\\\\\\" + this.TargetWindow.GetRemoteComputerName() + "\\\\" + this.NamespaceValue.Text.Replace("\\", "\\\\") + "\", connection);" + Environment.NewLine +
                        "                scope.Connect();" + Environment.NewLine +
                        Environment.NewLine +
                        "                ObjectQuery query= new ObjectQuery(" + Environment.NewLine +
                        "                    \"SELECT * FROM " + this.ClassList.Text;
				
                    if(this.ValueList.SelectedItems.Count >= 1)
                    {
                        string updatedValue = ValueList.SelectedItems[0].ToString().Replace("\\", "\\\\").Trim();
                        code = code + " WHERE " + updatedValue;
                    }
                
                    code = code + "\"); " + Environment.NewLine + Environment.NewLine +
                        "                ManagementObjectSearcher searcher = " + Environment.NewLine +
                        "                    new ManagementObjectSearcher(scope, query);" + Environment.NewLine + Environment.NewLine +
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
                            code = code + "                    Console.WriteLine(\"" + 
                                // Property from selection.
                                this.PropertyList.SelectedItems[i].ToString() +
                                ": {0}\", queryObj[\"" +
                                this.PropertyList.SelectedItems[i].ToString() + "\"]);" +
                                Environment.NewLine;
                        }
                    }

                    code = code + 
                        "                }" + Environment.NewLine + 
                        "                Close();" + Environment.NewLine +
                        "            }" + Environment.NewLine +
                        "            catch(ManagementException err)" + Environment.NewLine +
                        "            {" + Environment.NewLine +
                        "                MessageBox.Show(\"An error occurred while querying for WMI data: \" + err.Message);" + Environment.NewLine +
                        "            }" + Environment.NewLine +
                        "            catch(System.UnauthorizedAccessException unauthorizedErr)" + Environment.NewLine +
                        "            {" + Environment.NewLine +
                        "                MessageBox.Show(\"Connection error (user name or password might be incorrect): \" + unauthorizedErr.Message);" + Environment.NewLine +
                        "            }" + Environment.NewLine +
                        "        }" + Environment.NewLine +
                        Environment.NewLine +
                        "        private void cancelButton_Click(object sender, System.EventArgs e)" + Environment.NewLine +
                        "        {" + Environment.NewLine +
                        "            Close();" + Environment.NewLine +
                        "        }" + Environment.NewLine +
                        "    }" + Environment.NewLine +
                        "}" + Environment.NewLine;

                }
                else if(this.GroupRemoteComputerMenu.Checked)
                {
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
                        "                string[] arrComputers = {\"";

                    string delimStr = " ,\n";
                    char [] delimiter = delimStr.ToCharArray();
                    string [] split = this.TargetWindow.GetArrayOfComputers().Split(delimiter);

                    foreach (string s in split) 
                    {
                        code = code + s.Trim() + "\",\"";
                    }
                    string trimStr = ",\"";
                    char [] trim = trimStr.ToCharArray();
                    code = code.TrimEnd(trim) + "\"};" +
                        Environment.NewLine + 
                        "                foreach (string strComputer in arrComputers)" + Environment.NewLine +
                        "                {" + Environment.NewLine +
                        "                    Console.WriteLine(\"==========================================\");" + Environment.NewLine +
                        "                    Console.WriteLine(\"Computer: \" + strComputer);" + Environment.NewLine +
                        "                    Console.WriteLine(\"==========================================\");" + Environment.NewLine + Environment.NewLine +
                        "                    ManagementObjectSearcher searcher = " + Environment.NewLine +
                        "                        new ManagementObjectSearcher(" + Environment.NewLine +
                        "                        \"\\\\\\\\\" + strComputer + \"\\\\" + this.NamespaceValue.Text.Replace("\\", "\\\\") + "\", " + Environment.NewLine +
                        "                        \"SELECT * FROM " + this.ClassList.Text;

                    if(this.ValueList.SelectedItems.Count >= 1)
                    {
                        string updatedValue = ValueList.SelectedItems[0].ToString().Replace("\\", "\\\\").Trim();
                        code = code + " WHERE " + updatedValue;
                    }
                
                    code = code + "\"); " + Environment.NewLine + Environment.NewLine +
                        "                    foreach (ManagementObject queryObj in searcher.Get())" + Environment.NewLine +
                        "                    {" + Environment.NewLine +
                        "                        Console.WriteLine(\"-----------------------------------\");" + Environment.NewLine +
                        "                        Console.WriteLine(\"" + this.ClassList.Text + " instance\");" + Environment.NewLine +
                        "                        Console.WriteLine(\"-----------------------------------\");" + Environment.NewLine;

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
                                "                        if(queryObj[\"" + PropertyList.SelectedItems[i].ToString() + "\"] == null)" + Environment.NewLine +
                                "                            Console.WriteLine(\"" + PropertyList.SelectedItems[i].ToString() + ": {0}\", queryObj[\"" + PropertyList.SelectedItems[i].ToString() + "\"]);" + Environment.NewLine +
                                "                        else" + System.Environment.NewLine +
                                "                        {" + System.Environment.NewLine +
                                "                            " + type + "[] arr" + PropertyList.SelectedItems[i].ToString() + " = (" + type + "[])(queryObj[\"" + PropertyList.SelectedItems[i].ToString() + "\"]);" + Environment.NewLine +
                                "                            foreach (" + type + " arrValue in arr" + PropertyList.SelectedItems[i].ToString() + ")" + System.Environment.NewLine +
                                "                            {" + System.Environment.NewLine +
                                "                                Console.WriteLine(\"" + PropertyList.SelectedItems[i].ToString() + ": {0}\", arrValue);" + Environment.NewLine +
                                "                            }" + System.Environment.NewLine +
                                "                        }" +
                                Environment.NewLine;
                        }
                        else
                        {
                            code = code + "                        Console.WriteLine(\"" + 
                                // Property from selections.
                                this.PropertyList.SelectedItems[i].ToString() +
                                ": {0}\", queryObj[\"" +
                                this.PropertyList.SelectedItems[i].ToString() + "\"]);" +
                                Environment.NewLine;
                        }
                    }

                    code = code + "                    }" + Environment.NewLine +
                        "                }" + Environment.NewLine +
                        "            }" + Environment.NewLine +
                        "            catch(ManagementException err)" + Environment.NewLine +
                        "            {" + Environment.NewLine +
                        "                MessageBox.Show(\"An error occurred while querying for WMI data: \" + err.Message);" + Environment.NewLine +
                        "            }" + Environment.NewLine +
                        "        }" + Environment.NewLine +
                        "    }" + Environment.NewLine +
                        "}";
                }

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

        //-------------------------------------------------------------------------
        // Generates the VB code in the query tab's generated code area.
        // 
        //-------------------------------------------------------------------------
        private void GenerateVBNetQueryCode()
        {
            try
            {
                string code = "";

                if(this.LocalComputerMenu.Checked)
                {
                    code =  
                        "Imports System" + Environment.NewLine +
                        "Imports System.Management" + Environment.NewLine +
                        "Imports System.Windows.Forms" +Environment.NewLine +
                        Environment.NewLine +
                        "Namespace WMISample" + Environment.NewLine +
                        Environment.NewLine +
                        "    Public Class MyWMIQuery" + Environment.NewLine +
                        Environment.NewLine +
                        "        Public Overloads Shared Function Main() As Integer" + Environment.NewLine +
                        Environment.NewLine +
                        "            Try" + Environment.NewLine +
                        "                Dim searcher As New ManagementObjectSearcher( _" + Environment.NewLine +
                        "                    \"" + this.NamespaceValue.Text + "\", _" + Environment.NewLine +
                        "                    \"SELECT * FROM " + this.ClassList.Text;

                    if(this.ValueList.SelectedItems.Count >= 1)
                    {
                        string updatedValue = ValueList.SelectedItems[0].ToString().Replace("\\", "\\\\").Trim();
                        code = code + " WHERE " + updatedValue;
                    }
                
                    code = code + "\") " + Environment.NewLine + Environment.NewLine +
                        "                For Each queryObj As ManagementObject in searcher.Get()" + Environment.NewLine +
                        Environment.NewLine +
                        "                    Console.WriteLine(\"-----------------------------------\")" + Environment.NewLine +
                        "                    Console.WriteLine(\"" + this.ClassList.Text + " instance\")" + Environment.NewLine +
                        "                    Console.WriteLine(\"-----------------------------------\")" + Environment.NewLine;

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

                            code = code + Environment.NewLine + "                    If queryObj(\"" + PropertyList.SelectedItems[i].ToString() + "\") Is Nothing Then" + Environment.NewLine +
                                "                        Console.WriteLine(\"" + PropertyList.SelectedItems[i].ToString() + ": {0}\", queryObj(\"" + PropertyList.SelectedItems[i].ToString() + "\"))" + Environment.NewLine +
                                "                    Else" + System.Environment.NewLine +
                                "                        Dim arr" + PropertyList.SelectedItems[i].ToString() + " As " + type + "()" + Environment.NewLine +
                                "                        arr" + PropertyList.SelectedItems[i].ToString() + " = queryObj(\"" + PropertyList.SelectedItems[i].ToString() + "\")" + Environment.NewLine +
                                "                        For Each arrValue As " + type + " In arr" + PropertyList.SelectedItems[i].ToString() + "" + System.Environment.NewLine +
                                "                            Console.WriteLine(\"" + PropertyList.SelectedItems[i].ToString() + ": {0}\", arrValue)" + Environment.NewLine +
                                "                        Next" + System.Environment.NewLine +
                                "                    End If" +
                                Environment.NewLine;
                        }
                        else
                        {
                            code = code + "                    Console.WriteLine(\"" + 
                                // Property from selection.
                                this.PropertyList.SelectedItems[i].ToString() +
                                ": {0}\", queryObj(\"" +
                                this.PropertyList.SelectedItems[i].ToString() + "\"))" +
                                Environment.NewLine;
                        }
                    }

                    code = code + "                Next" + Environment.NewLine +
                        "            Catch err As ManagementException" + Environment.NewLine +
                        "                MessageBox.Show(\"An error occurred while querying for WMI data: \" & err.Message)" + Environment.NewLine +
                        "            End Try" + Environment.NewLine +
                        "        End Function" + Environment.NewLine +
                        "    End Class" + Environment.NewLine +
                        "End Namespace";
                }
                else if(this.RemoteComputerMenu.Checked)
                {
                    code = "Imports System" + Environment.NewLine +
                        "Imports System.Drawing" + Environment.NewLine +
                        "Imports System.Collections" + Environment.NewLine +
                        "Imports System.ComponentModel" + Environment.NewLine +
                        "Imports System.Windows.Forms" + Environment.NewLine +
                        "Imports System.Data" + Environment.NewLine +
                        "Imports System.Management" + Environment.NewLine +
                        Environment.NewLine +
                        "Namespace WMISample" + Environment.NewLine +
                        Environment.NewLine +
                        "    Public Class MyQuerySample " + Environment.NewLine + "        Inherits System.Windows.Forms.Form" + Environment.NewLine +
                        Environment.NewLine +
                        "        Friend WithEvents userNameLabel As System.Windows.Forms.Label" + Environment.NewLine +
                        "        Friend WithEvents userNameBox As System.Windows.Forms.TextBox" + Environment.NewLine +
                        "        Friend WithEvents passwordBox As System.Windows.Forms.TextBox" + Environment.NewLine +
                        "        Friend WithEvents passwordLabel As System.Windows.Forms.Label" + Environment.NewLine +
                        "        Friend WithEvents OKButton As System.Windows.Forms.Button" + Environment.NewLine +
                        "        Friend WithEvents closeButton As System.Windows.Forms.Button" + Environment.NewLine +
                        "        " + Environment.NewLine +
                        "        Private components As System.ComponentModel.IContainer" + Environment.NewLine +
                        Environment.NewLine +
                        "        Public Sub New()" + Environment.NewLine + 
                        "            MyBase.New()" + Environment.NewLine +
                        Environment.NewLine +
                        "            InitializeComponent()" + Environment.NewLine +
                        "        End Sub" + Environment.NewLine +
                        Environment.NewLine +
                        "        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)" + Environment.NewLine +
                        "        " + Environment.NewLine +
                        "            If disposing Then" + Environment.NewLine +
						
                        "                If Not (components Is Nothing) Then" + Environment.NewLine + 
						
                        "                    components.Dispose()" + Environment.NewLine +
                        "                End If" + Environment.NewLine +
                        "            End If" + Environment.NewLine +
                        "            MyBase.Dispose(disposing)" + Environment.NewLine +
                        "        End Sub" + Environment.NewLine +
                        Environment.NewLine +
                        "        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()" + Environment.NewLine +
                        Environment.NewLine +
                        "            Me.userNameLabel = new System.Windows.Forms.Label" + Environment.NewLine +
                        "            Me.userNameBox = new System.Windows.Forms.TextBox" + Environment.NewLine +
                        "            Me.passwordBox = new System.Windows.Forms.TextBox" + Environment.NewLine +
                        "            Me.passwordLabel = new System.Windows.Forms.Label" + Environment.NewLine +
                        "            Me.OKButton = new System.Windows.Forms.Button" + Environment.NewLine +
                        "            Me.closeButton = new System.Windows.Forms.Button" + Environment.NewLine +
                        "            Me.SuspendLayout()" + Environment.NewLine +
                        "            ' " + Environment.NewLine +
                        "            ' userNameLabel" + Environment.NewLine +
                        "            ' " + Environment.NewLine +
                        "            Me.userNameLabel.Location = New System.Drawing.Point(16, 8)" + Environment.NewLine +
                        "            Me.userNameLabel.Name = \"userNameLabel\"" + Environment.NewLine +
                        "            Me.userNameLabel.Size = New System.Drawing.Size(160, 32)" + Environment.NewLine +
                        "            Me.userNameLabel.TabIndex = 0" + Environment.NewLine +
                        "            Me.userNameLabel.Text = \"Enter the user name for the remote computer:\"" + Environment.NewLine +
                        "            ' " + Environment.NewLine +
                        "            ' userNameBox" + Environment.NewLine +
                        "            ' " + Environment.NewLine +
                        "            Me.userNameBox.Location = New System.Drawing.Point(160, 16)" + Environment.NewLine +
                        "            Me.userNameBox.Name = \"userNameBox\"" + Environment.NewLine +
                        "            Me.userNameBox.Size = New System.Drawing.Size(192, 20)" + Environment.NewLine +
                        "            Me.userNameBox.TabIndex = 1" + Environment.NewLine +
                        "            Me.userNameBox.Text = \"\"" + Environment.NewLine +
                        "            ' " + Environment.NewLine +
                        "            ' passwordBox" + Environment.NewLine +
                        "            ' " + Environment.NewLine +
                        "            Me.passwordBox.Location = New System.Drawing.Point(160, 48)" + Environment.NewLine +
                        "            Me.passwordBox.Name = \"passwordBox\"" + Environment.NewLine +
                        "            Me.passwordBox.PasswordChar = \"*\"" + Environment.NewLine +
                        "            Me.passwordBox.Size = new System.Drawing.Size(192, 20)" + Environment.NewLine +
                        "            Me.passwordBox.TabIndex = 3" + Environment.NewLine +
                        "            Me.passwordBox.Text = \"\"" + Environment.NewLine +
                        "            ' " + Environment.NewLine +
                        "            ' passwordLabel" + Environment.NewLine +
                        "            ' " + Environment.NewLine +
                        "            Me.passwordLabel.Location = new System.Drawing.Point(16, 48)" + Environment.NewLine +
                        "            Me.passwordLabel.Name = \"passwordLabel\"" + Environment.NewLine +
                        "            Me.passwordLabel.Size = new System.Drawing.Size(160, 32)" + Environment.NewLine +
                        "            Me.passwordLabel.TabIndex = 2" + Environment.NewLine +
                        "            Me.passwordLabel.Text = \"Enter the password for the remote computer:\"" + Environment.NewLine +
                        "            ' " + Environment.NewLine +
                        "            ' OKButton" + Environment.NewLine +
                        "            ' " + Environment.NewLine +
                        "            Me.OKButton.Location = New System.Drawing.Point(40, 88)" + Environment.NewLine +
                        "            Me.OKButton.Name = \"OKButton\"" + Environment.NewLine +
                        "            Me.OKButton.Size = new System.Drawing.Size(128, 23)" + Environment.NewLine +
                        "            Me.OKButton.TabIndex = 4" + Environment.NewLine +
                        "            Me.OKButton.Text = \"OK\"" + Environment.NewLine +
                        "            ' " + Environment.NewLine +
                        "            ' closeButton" + Environment.NewLine +
                        "            ' " + Environment.NewLine +
                        "            Me.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel" + Environment.NewLine +
                        "            Me.closeButton.Location = New System.Drawing.Point(200, 88)" + Environment.NewLine +
                        "            Me.closeButton.Name = \"closeButton\"" + Environment.NewLine +
                        "            Me.closeButton.Size = New System.Drawing.Size(128, 23)" + Environment.NewLine +
                        "            Me.closeButton.TabIndex = 5" + Environment.NewLine +
                        "            Me.closeButton.Text = \"Cancel\"" + Environment.NewLine +
                        "            ' " + Environment.NewLine +
                        "            ' MyQuerySample" + Environment.NewLine +
                        "            ' " + Environment.NewLine +
                        "            Me.AcceptButton = Me.OKButton" + Environment.NewLine +
                        "            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)" + Environment.NewLine +
                        "            Me.CancelButton = Me.closeButton" + Environment.NewLine +
                        "            Me.ClientSize = New System.Drawing.Size(368, 130)" + Environment.NewLine +
                        "            Me.ControlBox = false" + Environment.NewLine +
                        "            Me.Controls.Add(Me.closeButton)" + Environment.NewLine +
                        "            Me.Controls.Add(Me.OKButton)" + Environment.NewLine +
                        "            Me.Controls.Add(Me.passwordBox)" + Environment.NewLine +
                        "            Me.Controls.Add(Me.passwordLabel)" + Environment.NewLine +
                        "            Me.Controls.Add(Me.userNameBox)" + Environment.NewLine +
                        "            Me.Controls.Add(Me.userNameLabel)" + Environment.NewLine +
                        "            Me.Name = \"MyQuerySample\"" + Environment.NewLine +
                        "            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen" + Environment.NewLine +
                        "            Me.Text = \"Remote Connection\"" + Environment.NewLine +
                        "            Me.ResumeLayout(false)" + Environment.NewLine +
                        Environment.NewLine +
                        "        End Sub" + Environment.NewLine +
                        Environment.NewLine +
                        "        Public Overloads Shared Function Main() As Integer" + Environment.NewLine +
                        Environment.NewLine +
                        "            Application.Run(New MyQuerySample)" + Environment.NewLine +
                        "        End Function" + Environment.NewLine +
                        Environment.NewLine +
                        "        Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click" + Environment.NewLine +
                        "        " + Environment.NewLine +
                        "            Try" + Environment.NewLine +
                        "                Dim connection As New ConnectionOptions" + Environment.NewLine +
                        "                connection.Username = userNameBox.Text" + Environment.NewLine +
                        "                connection.Password = passwordBox.Text" + Environment.NewLine +
                        "                connection.Authority = \"ntlmdomain:" + this.TargetWindow.GetRemoteComputerDomain() + "\"" + Environment.NewLine +
                        Environment.NewLine +
                        "                Dim scope As New ManagementScope( _" + Environment.NewLine +
                        "                    \"\\\\" + this.TargetWindow.GetRemoteComputerName() + "\\" + this.NamespaceValue.Text + "\", connection)" + Environment.NewLine +
                        "                scope.Connect()" + Environment.NewLine +
                        Environment.NewLine +
                        "                Dim query As New ObjectQuery( _" + Environment.NewLine +
                        "                    \"SELECT * FROM " + this.ClassList.Text;
				
                    if(this.ValueList.SelectedItems.Count >= 1)
                    {
                        string updatedValue = ValueList.SelectedItems[0].ToString().Replace("\\", "\\\\").Trim();
                        code = code + " WHERE " + updatedValue;
                    }
                
                    code = code + "\") " + Environment.NewLine + Environment.NewLine +
                        "                Dim searcher As New ManagementObjectSearcher(scope, query) " + Environment.NewLine +
                        Environment.NewLine +
                        "                For Each queryObj As ManagementObject in searcher.Get()" + Environment.NewLine +
                        Environment.NewLine +
                        "                    Console.WriteLine(\"-----------------------------------\")" + Environment.NewLine +
                        "                    Console.WriteLine(\"" + this.ClassList.Text + " instance\")" + Environment.NewLine +
                        "                    Console.WriteLine(\"-----------------------------------\")" + Environment.NewLine;

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

                            code = code + Environment.NewLine + "                    If queryObj(\"" + PropertyList.SelectedItems[i].ToString() + "\") Is Nothing Then" + Environment.NewLine +
                                "                        Console.WriteLine(\"" + PropertyList.SelectedItems[i].ToString() + ": {0}\", queryObj(\"" + PropertyList.SelectedItems[i].ToString() + "\"))" + Environment.NewLine +
                                "                    Else" + System.Environment.NewLine +
                                "                        Dim arr" + PropertyList.SelectedItems[i].ToString() + " As " + type + "()" + Environment.NewLine +
                                "                        arr" + PropertyList.SelectedItems[i].ToString() + " = queryObj(\"" + PropertyList.SelectedItems[i].ToString() + "\")" + Environment.NewLine +
                                "                        For Each arrValue As " + type + " In arr" + PropertyList.SelectedItems[i].ToString() + "" + System.Environment.NewLine +
                                "                            Console.WriteLine(\"" + PropertyList.SelectedItems[i].ToString() + ": {0}\", arrValue)" + Environment.NewLine +
                                "                        Next" + System.Environment.NewLine +
                                "                    End If" +
                                Environment.NewLine;
                        }
                        else
                        {
                            code = code + "                    Console.WriteLine(\"" + 
                                // Property from selection.
                                this.PropertyList.SelectedItems[i].ToString() +
                                ": {0}\", queryObj(\"" +
                                this.PropertyList.SelectedItems[i].ToString() + "\"))" +
                                Environment.NewLine;
                        }
                    }

                    code = code + "                Next" + Environment.NewLine + Environment.NewLine + "                Close()" + Environment.NewLine +
                        "            Catch err As ManagementException" + Environment.NewLine +
                        "                MessageBox.Show(\"An error occurred while querying for WMI data: \" & err.Message)" + Environment.NewLine +
                        "            Catch unauthorizedErr As System.UnauthorizedAccessException" + Environment.NewLine +
                        Environment.NewLine +
                        "                MessageBox.Show(\"Connection error (user name or password might be incorrect): \" & unauthorizedErr.Message)" + Environment.NewLine +
                        "            End Try" + Environment.NewLine +
                        "        End Sub" + Environment.NewLine +
                        Environment.NewLine +
                        "        Private Sub closeButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles closeButton.Click" + Environment.NewLine +
                        Environment.NewLine +
                        "            Close()" + Environment.NewLine +
                        "        End Sub" + Environment.NewLine +
                        "    End Class" + Environment.NewLine +
                        "End Namespace" + Environment.NewLine;

                }
                else if(this.GroupRemoteComputerMenu.Checked)
                {
                    code =  
                        "Imports System" + Environment.NewLine +
                        "Imports System.Management" + Environment.NewLine +
                        "Imports System.Windows.Forms" + Environment.NewLine +
                        Environment.NewLine +
                        "Namespace WMISample" + Environment.NewLine +
                        Environment.NewLine +
                        "    Public Class MyWMIQuery" + Environment.NewLine +
                        Environment.NewLine +
                        "        Public Overloads Shared Function Main() As Integer" + Environment.NewLine +
                        Environment.NewLine +
                        "            Try" + Environment.NewLine +
                        "                Dim arrComputers As String() = _ " + Environment.NewLine +
                        "                    {\"";

                    string delimStr = " ,\n";
                    char [] delimiter = delimStr.ToCharArray();
                    string [] split = this.TargetWindow.GetArrayOfComputers().Split(delimiter);

                    foreach (string s in split) 
                    {
                        code = code + s.Trim() + "\",\"";
                    }
                    string trimStr = ",\"";
                    char [] trim = trimStr.ToCharArray();
                    code = code.TrimEnd(trim) + "\"}" +
                        Environment.NewLine +
                        "                For Each strComputer As String In arrComputers" + Environment.NewLine +
                        Environment.NewLine +
                        "                    Console.WriteLine(\"==========================================\")" + Environment.NewLine +
                        "                    Console.WriteLine(\"Computer: \" & strComputer)" + Environment.NewLine +
                        "                    Console.WriteLine(\"==========================================\")" + Environment.NewLine + Environment.NewLine +
                        "                    Dim searcher As New ManagementObjectSearcher( _" + Environment.NewLine +
                        "                        \"\\\\\" + strComputer + \"\\" + this.NamespaceValue.Text + "\", _" + Environment.NewLine +
                        "                        \"SELECT * FROM " + this.ClassList.Text;

                    if(this.ValueList.SelectedItems.Count >= 1)
                    {
                        string updatedValue = ValueList.SelectedItems[0].ToString().Replace("\\", "\\\\").Trim();
                        code = code + " WHERE " + updatedValue;
                    }
                
                    code = code + "\") " + Environment.NewLine + Environment.NewLine +
                        "                    For Each queryObj As ManagementObject in searcher.Get()" + Environment.NewLine +
                        Environment.NewLine +
                        "                        Console.WriteLine(\"-----------------------------------\")" + Environment.NewLine +
                        "                        Console.WriteLine(\"" + this.ClassList.Text + " instance\")" + Environment.NewLine +
                        "                        Console.WriteLine(\"-----------------------------------\")" + Environment.NewLine;

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

                            code = code + Environment.NewLine + "                        If queryObj(\"" + PropertyList.SelectedItems[i].ToString() + "\") Is Nothing Then" + Environment.NewLine +
                                "                            Console.WriteLine(\"" + PropertyList.SelectedItems[i].ToString() + ": {0}\", queryObj(\"" + PropertyList.SelectedItems[i].ToString() + "\"))" + Environment.NewLine +
                                "                        Else" + System.Environment.NewLine +
                                "                            Dim arr" + PropertyList.SelectedItems[i].ToString() + " As " + type + "()" + Environment.NewLine +
                                "                            arr" + PropertyList.SelectedItems[i].ToString() + " = queryObj(\"" + PropertyList.SelectedItems[i].ToString() + "\")" + Environment.NewLine +
                                "                            For Each arrValue As " + type + " In arr" + PropertyList.SelectedItems[i].ToString() + "" + System.Environment.NewLine +
                                "                                Console.WriteLine(\"" + PropertyList.SelectedItems[i].ToString() + ": {0}\", arrValue)" + Environment.NewLine +
                                "                            Next" + System.Environment.NewLine +
                                "                        End If" +
                                Environment.NewLine;
                        }
                        else
                        {
                            code = code + "                        Console.WriteLine(\"" + 
                                // Property from selection.
                                this.PropertyList.SelectedItems[i].ToString() +
                                ": {0}\", queryObj(\"" +
                                this.PropertyList.SelectedItems[i].ToString() + "\"))" +
                                Environment.NewLine;
                        }
                    }

                    code = code + "                    Next" + Environment.NewLine +
                        "                Next" + Environment.NewLine +
                        "            Catch err As ManagementException" + Environment.NewLine +
                        "                MessageBox.Show(\"An error occurred while querying for WMI data: \" & err.Message)" + Environment.NewLine +
                        "            End Try" + Environment.NewLine +
                        "        End Function" + Environment.NewLine +
                        "    End Class" + Environment.NewLine +
                        "End Namespace";
                }

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


        //-------------------------------------------------------------------------
        // Returns true if a static method is selected in the method tab's 
        // method list, and returns false otherwise.
        //-------------------------------------------------------------------------
        private bool IsStaticMethodSelected()
        {
            bool staticFlag = false;
            // Checks to see if a static method is selected in the method list.
            
            ManagementClass c = new ManagementClass(this.NamespaceValue_m.Text, this.ClassList_m.Text, null);
            MethodData mData = c.Methods[this.MethodList.Text];

            // Check each qualifier to see if it is static.
            foreach ( System.Management.QualifierData qualifier in mData.Qualifiers)
            {
                if(qualifier.Name.Equals("Static"))
                {
                    staticFlag = true;
                }
            }       
            return staticFlag;
        }

        //-------------------------------------------------------------------------
        // Generates the code in the method tab's generated code area.
        // 
        //-------------------------------------------------------------------------
        private void GenerateMethodCode()
        {
            try
            {
                if(!this.ClassList_m.Text.Equals("")) 
                {
                    if(this.VbNetMenuItem.Checked)
                    {
                        GenerateVBNetMethodCode();
                    }
                    else if(this.CSharpMenuItem.Checked)
                    {
                        GenerateCSharpMethodCode();
                    }
                    else if(this.VbsMenuItem.Checked)
                    {
                        GenerateVBSMethodCode();
                    }
                }
            }
            catch (ManagementException mErr)
            {
                if(mErr.Message.Equals("Not found "))
                    MessageBox.Show("Error creating code: WMI class or method not found.");
                else
                    MessageBox.Show("Error creating code: " + mErr.Message.ToString());
            }
        }

        //-------------------------------------------------------------------------
        // Generates the VB code in the method tab's generated code area.
        // 
        //-------------------------------------------------------------------------
        private void GenerateVBNetMethodCode()
        {
            bool staticFlag = this.IsStaticMethodSelected();
            string buffer = "";
            if(this.GroupRemoteComputerMenu.Checked)
                buffer = "    ";

            if(this.MethodList.Items.Count > 0) 
            {
                string code = "";

                if(this.RemoteComputerMenu.Checked)
                {
                    code = "Imports System" + Environment.NewLine +
                        "Imports System.Drawing" + Environment.NewLine +
                        "Imports System.Collections" + Environment.NewLine +
                        "Imports System.ComponentModel" + Environment.NewLine +
                        "Imports System.Windows.Forms" + Environment.NewLine +
                        "Imports System.Data" + Environment.NewLine +
                        "Imports System.Management" + Environment.NewLine +
                        Environment.NewLine +
                        "Namespace WMISample" + Environment.NewLine +
                        Environment.NewLine +
                        "    Public Class CallWMIMethod " + Environment.NewLine + "        Inherits System.Windows.Forms.Form" + Environment.NewLine +
                        Environment.NewLine +
                        "        Friend WithEvents userNameLabel As System.Windows.Forms.Label" + Environment.NewLine +
                        "        Friend WithEvents userNameBox As System.Windows.Forms.TextBox" + Environment.NewLine +
                        "        Friend WithEvents passwordBox As System.Windows.Forms.TextBox" + Environment.NewLine +
                        "        Friend WithEvents passwordLabel As System.Windows.Forms.Label" + Environment.NewLine +
                        "        Friend WithEvents OKButton As System.Windows.Forms.Button" + Environment.NewLine +
                        "        Friend WithEvents closeButton As System.Windows.Forms.Button" + Environment.NewLine +
                        "        " + Environment.NewLine +
                        "        Private components As System.ComponentModel.IContainer" + Environment.NewLine +
                        Environment.NewLine +
                        "        Public Sub New()" + Environment.NewLine + 
                        "            MyBase.New()" + Environment.NewLine +
                        Environment.NewLine +
                        "            InitializeComponent()" + Environment.NewLine +
                        "        End Sub" + Environment.NewLine +
                        Environment.NewLine +
                        "        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)" + Environment.NewLine +
                        "        " + Environment.NewLine +
                        "            If disposing Then" + Environment.NewLine +
						
                        "                If Not (components Is Nothing) Then" + Environment.NewLine + 
						
                        "                    components.Dispose()" + Environment.NewLine +
                        "                End If" + Environment.NewLine +
                        "            End If" + Environment.NewLine +
                        "            MyBase.Dispose(disposing)" + Environment.NewLine +
                        "        End Sub" + Environment.NewLine +
                        Environment.NewLine +
                        "        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()" + Environment.NewLine +
                        Environment.NewLine +
                        "            Me.userNameLabel = new System.Windows.Forms.Label" + Environment.NewLine +
                        "            Me.userNameBox = new System.Windows.Forms.TextBox" + Environment.NewLine +
                        "            Me.passwordBox = new System.Windows.Forms.TextBox" + Environment.NewLine +
                        "            Me.passwordLabel = new System.Windows.Forms.Label" + Environment.NewLine +
                        "            Me.OKButton = new System.Windows.Forms.Button" + Environment.NewLine +
                        "            Me.closeButton = new System.Windows.Forms.Button" + Environment.NewLine +
                        "            Me.SuspendLayout()" + Environment.NewLine +
                        "            ' " + Environment.NewLine +
                        "            ' userNameLabel" + Environment.NewLine +
                        "            ' " + Environment.NewLine +
                        "            Me.userNameLabel.Location = New System.Drawing.Point(16, 8)" + Environment.NewLine +
                        "            Me.userNameLabel.Name = \"userNameLabel\"" + Environment.NewLine +
                        "            Me.userNameLabel.Size = New System.Drawing.Size(160, 32)" + Environment.NewLine +
                        "            Me.userNameLabel.TabIndex = 0" + Environment.NewLine +
                        "            Me.userNameLabel.Text = \"Enter the user name for the remote computer:\"" + Environment.NewLine +
                        "            ' " + Environment.NewLine +
                        "            ' userNameBox" + Environment.NewLine +
                        "            ' " + Environment.NewLine +
                        "            Me.userNameBox.Location = New System.Drawing.Point(160, 16)" + Environment.NewLine +
                        "            Me.userNameBox.Name = \"userNameBox\"" + Environment.NewLine +
                        "            Me.userNameBox.Size = New System.Drawing.Size(192, 20)" + Environment.NewLine +
                        "            Me.userNameBox.TabIndex = 1" + Environment.NewLine +
                        "            Me.userNameBox.Text = \"\"" + Environment.NewLine +
                        "            ' " + Environment.NewLine +
                        "            ' passwordBox" + Environment.NewLine +
                        "            ' " + Environment.NewLine +
                        "            Me.passwordBox.Location = New System.Drawing.Point(160, 48)" + Environment.NewLine +
                        "            Me.passwordBox.Name = \"passwordBox\"" + Environment.NewLine +
                        "            Me.passwordBox.PasswordChar = \"*\"" + Environment.NewLine +
                        "            Me.passwordBox.Size = new System.Drawing.Size(192, 20)" + Environment.NewLine +
                        "            Me.passwordBox.TabIndex = 3" + Environment.NewLine +
                        "            Me.passwordBox.Text = \"\"" + Environment.NewLine +
                        "            ' " + Environment.NewLine +
                        "            ' passwordLabel" + Environment.NewLine +
                        "            ' " + Environment.NewLine +
                        "            Me.passwordLabel.Location = new System.Drawing.Point(16, 48)" + Environment.NewLine +
                        "            Me.passwordLabel.Name = \"passwordLabel\"" + Environment.NewLine +
                        "            Me.passwordLabel.Size = new System.Drawing.Size(160, 32)" + Environment.NewLine +
                        "            Me.passwordLabel.TabIndex = 2" + Environment.NewLine +
                        "            Me.passwordLabel.Text = \"Enter the password for the remote computer:\"" + Environment.NewLine +
                        "            ' " + Environment.NewLine +
                        "            ' OKButton" + Environment.NewLine +
                        "            ' " + Environment.NewLine +
                        "            Me.OKButton.Location = New System.Drawing.Point(40, 88)" + Environment.NewLine +
                        "            Me.OKButton.Name = \"OKButton\"" + Environment.NewLine +
                        "            Me.OKButton.Size = new System.Drawing.Size(128, 23)" + Environment.NewLine +
                        "            Me.OKButton.TabIndex = 4" + Environment.NewLine +
                        "            Me.OKButton.Text = \"OK\"" + Environment.NewLine +
                        "            ' " + Environment.NewLine +
                        "            ' closeButton" + Environment.NewLine +
                        "            ' " + Environment.NewLine +
                        "            Me.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel" + Environment.NewLine +
                        "            Me.closeButton.Location = New System.Drawing.Point(200, 88)" + Environment.NewLine +
                        "            Me.closeButton.Name = \"closeButton\"" + Environment.NewLine +
                        "            Me.closeButton.Size = New System.Drawing.Size(128, 23)" + Environment.NewLine +
                        "            Me.closeButton.TabIndex = 5" + Environment.NewLine +
                        "            Me.closeButton.Text = \"Cancel\"" + Environment.NewLine +
                        "            ' " + Environment.NewLine +
                        "            ' MyQuerySample" + Environment.NewLine +
                        "            ' " + Environment.NewLine +
                        "            Me.AcceptButton = Me.OKButton" + Environment.NewLine +
                        "            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)" + Environment.NewLine +
                        "            Me.CancelButton = Me.closeButton" + Environment.NewLine +
                        "            Me.ClientSize = New System.Drawing.Size(368, 130)" + Environment.NewLine +
                        "            Me.ControlBox = false" + Environment.NewLine +
                        "            Me.Controls.Add(Me.closeButton)" + Environment.NewLine +
                        "            Me.Controls.Add(Me.OKButton)" + Environment.NewLine +
                        "            Me.Controls.Add(Me.passwordBox)" + Environment.NewLine +
                        "            Me.Controls.Add(Me.passwordLabel)" + Environment.NewLine +
                        "            Me.Controls.Add(Me.userNameBox)" + Environment.NewLine +
                        "            Me.Controls.Add(Me.userNameLabel)" + Environment.NewLine +
                        "            Me.Name = \"MyQuerySample\"" + Environment.NewLine +
                        "            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen" + Environment.NewLine +
                        "            Me.Text = \"Remote Connection\"" + Environment.NewLine +
                        "            Me.ResumeLayout(false)" + Environment.NewLine +
                        Environment.NewLine +
                        "        End Sub" + Environment.NewLine +
                        Environment.NewLine +
                        "        Public Overloads Shared Function Main() As Integer" + Environment.NewLine +
                        Environment.NewLine +
                        "            Application.Run(New CallWMIMethod)" + Environment.NewLine +
                        "        End Function" + Environment.NewLine +
                        Environment.NewLine +
                        "        Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click" + Environment.NewLine +
                        "            Try" + Environment.NewLine +
                        "                Dim connection As New ConnectionOptions" + Environment.NewLine +
                        "                connection.Username = userNameBox.Text" + Environment.NewLine +
                        "                connection.Password = passwordBox.Text" + Environment.NewLine +
                        "                connection.Authority = \"ntlmdomain:" + this.TargetWindow.GetRemoteComputerDomain() + "\"" + Environment.NewLine +
                        Environment.NewLine +
                        "                Dim scope As New ManagementScope( _" + Environment.NewLine +
                        "                    \"\\\\" + this.TargetWindow.GetRemoteComputerName() + "\\" + this.NamespaceValue_m.Text + "\", connection)" + Environment.NewLine +
                        "                scope.Connect()" + Environment.NewLine +Environment.NewLine;
					
                }
                else if(this.GroupRemoteComputerMenu.Checked)
                {
                    code = code +
                        "Imports System" + Environment.NewLine +
                        "Imports System.Management" + Environment.NewLine +
                        "Imports System.Windows.Forms" + Environment.NewLine +
                        Environment.NewLine +
                        "Namespace WMISample" + Environment.NewLine +
                        Environment.NewLine +
                        "    Public Class CallWMIMethod" + Environment.NewLine +
                        Environment.NewLine +
                        "        Public Overloads Shared Function Main() As Integer" + Environment.NewLine +
                        Environment.NewLine +
                        "            Try" + Environment.NewLine +
                        Environment.NewLine +
                        "                Dim arrComputers As String() = {\"";

                    string delimStr = " ,\n";
                    char [] delimiter = delimStr.ToCharArray();
                    string [] split = this.TargetWindow.GetArrayOfComputers().Split(delimiter);

                    foreach (string s in split) 
                    {
                        code = code + s.Trim() + "\",\"";
                    }
                    string trimStr = ",\"";
                    char [] trim = trimStr.ToCharArray();
                    code = code.TrimEnd(trim) + "\"}" +
                        Environment.NewLine +
                        "                For Each strComputer As String In arrComputers" + Environment.NewLine +
                        Environment.NewLine;

                }
                else
                {
                    code = code +
                        "Imports System" + Environment.NewLine +
                        "Imports System.Management" + Environment.NewLine +
                        "Imports System.Windows.Forms" + Environment.NewLine +
                        Environment.NewLine +
                        "Namespace WMISample" + Environment.NewLine +
                        Environment.NewLine +
                        "    Public Class CallWMIMethod" + Environment.NewLine +
                        Environment.NewLine +
                        "        Public Overloads Shared Function Main() As Integer" + Environment.NewLine +
                        Environment.NewLine +
                        "            Try" + Environment.NewLine +
                        Environment.NewLine;
                }

                
                if(staticFlag) // The method is static.
                {
                    if(this.GroupRemoteComputerMenu.Checked)
                    {
                        code = code +
                            "                    Console.WriteLine(\"==========================================\")" + Environment.NewLine +
                            "                    Console.WriteLine(\"  Computer: \" & strComputer)" + Environment.NewLine +
                            "                    Console.WriteLine(\"==========================================\")" + Environment.NewLine + Environment.NewLine +
                            "                    Dim classInstance As New ManagementClass( _" + Environment.NewLine +
                            "                        \"\\\\\" & strComputer & \"\\" + this.NamespaceValue_m.Text + "\", _" + Environment.NewLine +
                            "                        \"" + this.ClassList_m.Text + "\", Nothing)" +
                            Environment.NewLine +
                            Environment.NewLine;
                    }
                    else if(this.LocalComputerMenu.Checked)
                    {
                        code = code +
                            "                Dim classInstance As New ManagementClass( _" + Environment.NewLine +
                            "                    \"" + this.NamespaceValue_m.Text + "\", _" + Environment.NewLine +
                            "                    \"" + this.ClassList_m.Text + "\", Nothing)" +
                            Environment.NewLine +
                            Environment.NewLine;
                    }
                    else if(this.RemoteComputerMenu.Checked)
                    {
                        code = code +
                            "                Dim classInstance As New ManagementClass( _" + Environment.NewLine +
                            "                    scope, _" + Environment.NewLine +
                            "                    New ManagementPath(\"" + this.ClassList_m.Text + "\"), Nothing)" +
                            Environment.NewLine +
                            Environment.NewLine;
                    }
                }
                else // The method is not a static method, and must be executed on an instance.
                {
                    if(this.KeyValueBox.SelectedItems.Count.Equals(0))
                    {
                        if(this.KeyValueBox.Items.Count.Equals(0))
                        {
                            if(this.GroupRemoteComputerMenu.Checked)
                            {
                                code = code +
                                    "                    Console.WriteLine(\"==========================================\")" + Environment.NewLine +
                                    "                    Console.WriteLine(\"  Computer: \" & strComputer)" + Environment.NewLine +
                                    "                    Console.WriteLine(\"==========================================\")" + Environment.NewLine + Environment.NewLine +
                                    "                    Dim classInstance As New ManagementClass( _" + Environment.NewLine +
                                    "                        \"\\\\\" & strComputer & \"\\" + this.NamespaceValue_m.Text + "\", _" + Environment.NewLine +
                                    "                        \"" + this.ClassList_m.Text + "\", Nothing)" +
                                    Environment.NewLine +
                                    Environment.NewLine;
                            }
                            else if(this.LocalComputerMenu.Checked)
                            {
                                code = code +
                                    "                Dim classInstance As New ManagementObject( _" + Environment.NewLine +
                                    "                    \"" + this.NamespaceValue_m.Text + "\", _" + Environment.NewLine +
                                    "                    \"" + this.ClassList_m.Text + "\", Nothing)" +
                                    Environment.NewLine +
                                    Environment.NewLine;
                            }
                            else if(this.RemoteComputerMenu.Checked)
                            {
                                code = code +
                                    "                Dim classInstance As New ManagementObject(scope, _" + Environment.NewLine +
                                    "                    New ManagementPath(\"" + this.ClassList_m.Text + "\"), Nothing)" +
                                    Environment.NewLine +
                                    Environment.NewLine;
                            }
                        }
                        else
                        {
                            if(this.GroupRemoteComputerMenu.Checked)
                            {
                                code = code +
                                    "                    Console.WriteLine(\"==========================================\")" + Environment.NewLine +
                                    "                    Console.WriteLine(\"  Computer: \" & strComputer)" + Environment.NewLine +
                                    "                    Console.WriteLine(\"==========================================\")" + Environment.NewLine + Environment.NewLine +
                                    "                    Dim classInstance As New ManagementObject( _" + Environment.NewLine +
                                    "                        \"\\\\\" & strComputer & \"\\" + this.NamespaceValue_m.Text + "\", _" + Environment.NewLine +
                                    "                        \"" + this.ClassList_m.Text + ".ReplaceKeyPropery='ReplaceKeyPropertyValue'\", _" +
                                    Environment.NewLine + 
                                    "                        Nothing)" +
                                    Environment.NewLine +
                                    Environment.NewLine;
                            }
							
                            else if(this.LocalComputerMenu.Checked)
                            {
                                code = code + 
                                    "                Dim classInstance As New ManagementObject( _" + Environment.NewLine +
                                    "                    \"" + this.NamespaceValue_m.Text + "\", _" + Environment.NewLine +
                                    "                    \"" + this.ClassList_m.Text + ".ReplaceKeyPropery='ReplaceKeyPropertyValue'\", _" +
                                    Environment.NewLine + 
                                    "                    Nothing)" +
                                    Environment.NewLine +
                                    Environment.NewLine;
                            }
                            else if(this.RemoteComputerMenu.Checked)
                            {
                                code = code +
                                    "                Dim classInstance As New ManagementObject(scope, _" + Environment.NewLine +
                                    "                    New ManagementPath(\"" + this.ClassList_m.Text + ".ReplaceKeyPropery='ReplaceKeyPropertyValue'\"), _" +
                                    Environment.NewLine + 
                                    "                    Nothing)" +
                                    Environment.NewLine +
                                    Environment.NewLine;
                            }
                        }
                    }
                    else
                    {
                        if(this.GroupRemoteComputerMenu.Checked)
                        {
                            code = code +
                                "                    Console.WriteLine(\"==========================================\")" + Environment.NewLine +
                                "                    Console.WriteLine(\"  Computer: \" & strComputer)" + Environment.NewLine +
                                "                    Console.WriteLine(\"==========================================\")" + Environment.NewLine + Environment.NewLine + 
                                "                    Dim classInstance As New ManagementObject( _" + Environment.NewLine +
                                "                        \"\\\\\" & strComputer & \"\\" + this.NamespaceValue_m.Text + "\", _" + Environment.NewLine +
                                "                        \"" + this.ClassList_m.Text + "." + this.KeyValueBox.SelectedItem.ToString() + "\", _" +
                                Environment.NewLine + 
                                "                        Nothing)" +
                                Environment.NewLine +
                                Environment.NewLine;
                        }
                        else if(this.LocalComputerMenu.Checked)
                        {
                            code = code + 
                                "                Dim classInstance As New ManagementObject( _" + Environment.NewLine +
                                "                    \"" + this.NamespaceValue_m.Text + "\", _" + Environment.NewLine +
                                "                    \"" + this.ClassList_m.Text + "." + this.KeyValueBox.SelectedItem.ToString() + "\", _" +
                                Environment.NewLine + 
                                "                    Nothing)" +
                                Environment.NewLine +
                                Environment.NewLine;
                        }
                        else if(this.RemoteComputerMenu.Checked)
                        {
                            code = code +
                                "               Dim classInstance As New ManagementObject(scope, _" + Environment.NewLine +
                                "                    New ManagementPath(\"" + this.ClassList_m.Text + "." + this.KeyValueBox.SelectedItem.ToString() + "\"), _" +
                                Environment.NewLine + 
                                "                    Nothing)" +
                                Environment.NewLine +
                                Environment.NewLine;
                        }
                    }
                }

                try
                {
                    ManagementClass c = new ManagementClass(this.NamespaceValue_m.Text, this.ClassList_m.Text, null);

                    foreach (MethodData mData in c.Methods)
                    {
                        if(mData.Name.Equals(this.MethodList.Text))
                        {
                            if(mData.InParameters.Properties.Count.Equals(0))
                            {
                                code = code + buffer + "                ' no method [in] parameters to define" + Environment.NewLine
                                    + Environment.NewLine;	
                            }
                            else
                            {
                                code = code + buffer + "                ' Obtain [in] parameters for the method" +
                                    Environment.NewLine + buffer +
                                    "                Dim inParams As ManagementBaseObject = _" +
                                    Environment.NewLine + buffer +
                                    "                    classInstance.GetMethodParameters(\"" + this.MethodList.Text	+ "\")" +
                                    Environment.NewLine + Environment.NewLine + buffer +
                                    "                ' Add the input parameters." + Environment.NewLine;

                                for(int i = 0; i < InParameterBox.Items.Count; i ++)
                                {
                                    if(InParameterBox.SelectedIndices.Contains(i) && !InParameterArray[i].ReturnParameterValue().Equals(""))
                                    {
										
                                        code = code + buffer +
                                            "                inParams(\"" + InParameterBox.Items[i].ToString().Split(" ".ToCharArray())[0] +
                                            "\") =  " + InParameterArray[i].ReturnParameterValue() + 
                                            Environment.NewLine;
										
                                    }
                                }
                            }
                        }
                    }
                }
                catch (System.NullReferenceException nullError2)
                {	
                    code = code + buffer + "                ' no method [in] parameters to define" + Environment.NewLine
                        + Environment.NewLine;
                }

                code = code + Environment.NewLine + buffer +
                    "                ' Execute the method and obtain the return values." +
                    Environment.NewLine;
				
                if(this.InParameterBox.Items.Count.Equals(0))
                {
                    code = code + buffer + "                Dim outParams As ManagementBaseObject = _" +
                        Environment.NewLine + buffer +
                        "                    classInstance.InvokeMethod(\"" + this.MethodList.Text + "\", Nothing, Nothing)" +
                        Environment.NewLine + Environment.NewLine;
                }
                else
                {
                    code = code + buffer + "                Dim outParams As ManagementBaseObject = _" +
                        Environment.NewLine + buffer +
                        "                    classInstance.InvokeMethod(\"" + this.MethodList.Text + "\", inParams, Nothing)" +
                        Environment.NewLine + Environment.NewLine;
                }

                try
                {
                    ManagementClass c = new ManagementClass(this.NamespaceValue_m.Text, this.ClassList_m.Text, null);
                    foreach (MethodData mData in c.Methods)
                    {
                        if(mData.Name.Equals(this.MethodList.Text))
                        {

                            if(mData.OutParameters.Properties.Count.Equals(0))
                            {
                                code = code + Environment.NewLine + buffer + "                ' No outParams" + Environment.NewLine;
                            }
                            else
                            {
								
                                code = code + buffer +
                                    "                ' List outParams" + Environment.NewLine + buffer +
                                    "                Console.WriteLine(\"Out parameters:\")" + Environment.NewLine;
								

                                foreach(PropertyData p in mData.OutParameters.Properties)
                                {
                                    // Check to see if the out-parameter is not a basic type.
                                    if(p.Type.ToString().Equals("Object"))
                                    {
                                        code = code + buffer + "                Console.WriteLine(\"The " + p.Name +
                                            " out-parameter contains an object.\")" + Environment.NewLine;
                                    }
                                    else
                                    {
                                        code = code + buffer + "                Console.WriteLine(\"" + p.Name +
                                            ": {0}\", outParams(\"" +
                                            p.Name + "\"))" + Environment.NewLine;
                                    }
                                }
                            }
                        }
                    }
                }
                catch (System.NullReferenceException nullError)
                {
					
                    code = code + Environment.NewLine + buffer + "                ' No outParams" + Environment.NewLine;
					
                }

                if(this.RemoteComputerMenu.Checked)
                {
                    code = code + Environment.NewLine + "                Close()" + Environment.NewLine +
                        Environment.NewLine +
                        "            Catch err As ManagementException" + Environment.NewLine +
                        Environment.NewLine +
                        "                MessageBox.Show(\"An error occurred while trying to execute the WMI method: \" & err.Message)" + Environment.NewLine +
                        Environment.NewLine +
                        "            Catch unauthorizedErr As System.UnauthorizedAccessException" + Environment.NewLine +
                        Environment.NewLine +
                        "                MessageBox.Show(\"Connection error (user name or password might be incorrect): \" & unauthorizedErr.Message)" + Environment.NewLine +
                        "            End Try" + Environment.NewLine +
                        "        End Sub" + Environment.NewLine +
                        Environment.NewLine +
                        "        Private Sub closeButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles closeButton.Click" + Environment.NewLine +
                        Environment.NewLine +
                        "            Close()" + Environment.NewLine +
                        "        End Sub" + Environment.NewLine +
                        "    End Class" + Environment.NewLine +
                        "End Namespace" + Environment.NewLine;
                }
                else if(this.GroupRemoteComputerMenu.Checked)
                {
                    code = code + "                Next" +
                        Environment.NewLine + 
                        Environment.NewLine + "            Catch err As ManagementException" + Environment.NewLine +
                        Environment.NewLine +
                        "                MessageBox.Show(\"An error occurred while trying to execute the WMI method: \" & err.Message)" + Environment.NewLine +
                        "            End Try" + Environment.NewLine +
                        Environment.NewLine + "        End Function" +
                        Environment.NewLine + "    End Class" +
                        Environment.NewLine + "End Namespace";
                }
                else
                {
                    code = code + 
                        Environment.NewLine + 
                        "            Catch err As ManagementException" + Environment.NewLine +
                        Environment.NewLine +
                        "                MessageBox.Show(\"An error occurred while trying to execute the WMI method: \" & err.Message)" + Environment.NewLine +
                        "            End Try" + Environment.NewLine +
                        "        End Function" + Environment.NewLine +
                        "    End Class" + Environment.NewLine +
                        "End Namespace";
                }

                this.CodeText_m.Text = code;
            }
        }

        //-------------------------------------------------------------------------
        // Generates the C# code in the method tab's generated code area.
        // 
        //-------------------------------------------------------------------------
        private void GenerateCSharpMethodCode()
        {
            bool staticFlag = this.IsStaticMethodSelected();
            string buffer = "";
            if(this.GroupRemoteComputerMenu.Checked)
                buffer = "    ";

            if(this.MethodList.Items.Count > 0) 
            {
                string code = "";

                if(this.RemoteComputerMenu.Checked)
                {
                    code = "using System;" + Environment.NewLine +
                        "using System.Drawing;" + Environment.NewLine +
                        "using System.Collections;" + Environment.NewLine +
                        "using System.ComponentModel;" + Environment.NewLine +
                        "using System.Windows.Forms;" + Environment.NewLine +
                        "using System.Data;" + Environment.NewLine +
                        "using System.Management;" + Environment.NewLine +
                        Environment.NewLine +
                        "namespace WMISample" + Environment.NewLine +
                        "{" + Environment.NewLine +
                        "    public class CallWMIMethod : System.Windows.Forms.Form" + Environment.NewLine +
                        "    {" + Environment.NewLine +
                        "        private System.Windows.Forms.Label userNameLabel;" + Environment.NewLine +
                        "        private System.Windows.Forms.TextBox userNameBox;" + Environment.NewLine +
                        "        private System.Windows.Forms.TextBox passwordBox;" + Environment.NewLine +
                        "        private System.Windows.Forms.Label passwordLabel;" + Environment.NewLine +
                        "        private System.Windows.Forms.Button OKButton;" + Environment.NewLine +
                        "        private System.Windows.Forms.Button cancelButton;" + Environment.NewLine +
                        "        " + Environment.NewLine +
                        "        private System.ComponentModel.Container components = null;" + Environment.NewLine +
                        Environment.NewLine +
                        "        public CallWMIMethod()" + Environment.NewLine +
                        "        {" + Environment.NewLine +
                        "            InitializeComponent();" + Environment.NewLine +
                        "        }" + Environment.NewLine +
                        Environment.NewLine +
                        "        protected override void Dispose( bool disposing )" + Environment.NewLine +
                        "        {" + Environment.NewLine +
                        "            if( disposing )" + Environment.NewLine +
                        "            {" + Environment.NewLine +
                        "                if (components != null)" + Environment.NewLine + 
                        "                {" + Environment.NewLine +
                        "                    components.Dispose();" + Environment.NewLine +
                        "                }" + Environment.NewLine +
                        "            }" + Environment.NewLine +
                        "            base.Dispose( disposing );" + Environment.NewLine +
                        "        }" + Environment.NewLine +
                        Environment.NewLine +
                        "        private void InitializeComponent()" + Environment.NewLine +
                        "        {" + Environment.NewLine +
                        "            this.userNameLabel = new System.Windows.Forms.Label();" + Environment.NewLine +
                        "            this.userNameBox = new System.Windows.Forms.TextBox();" + Environment.NewLine +
                        "            this.passwordBox = new System.Windows.Forms.TextBox();" + Environment.NewLine +
                        "            this.passwordLabel = new System.Windows.Forms.Label();" + Environment.NewLine +
                        "            this.OKButton = new System.Windows.Forms.Button();" + Environment.NewLine +
                        "            this.cancelButton = new System.Windows.Forms.Button();" + Environment.NewLine +
                        "            this.SuspendLayout();" + Environment.NewLine +
                        "            // " + Environment.NewLine +
                        "            // userNameLabel" + Environment.NewLine +
                        "            // " + Environment.NewLine +
                        "            this.userNameLabel.Location = new System.Drawing.Point(16, 8);" + Environment.NewLine +
                        "            this.userNameLabel.Name = \"userNameLabel\";" + Environment.NewLine +
                        "            this.userNameLabel.Size = new System.Drawing.Size(160, 32);" + Environment.NewLine +
                        "            this.userNameLabel.TabIndex = 0;" + Environment.NewLine +
                        "            this.userNameLabel.Text = \"Enter the user name for the remote computer:\";" + Environment.NewLine +
                        "            // " + Environment.NewLine +
                        "            // userNameBox" + Environment.NewLine +
                        "            // " + Environment.NewLine +
                        "            this.userNameBox.Location = new System.Drawing.Point(160, 16);" + Environment.NewLine +
                        "            this.userNameBox.Name = \"userNameBox\";" + Environment.NewLine +
                        "            this.userNameBox.Size = new System.Drawing.Size(192, 20);" + Environment.NewLine +
                        "            this.userNameBox.TabIndex = 1;" + Environment.NewLine +
                        "            this.userNameBox.Text = \"\";" + Environment.NewLine +
                        "            // " + Environment.NewLine +
                        "            // passwordBox" + Environment.NewLine +
                        "            // " + Environment.NewLine +
                        "            this.passwordBox.Location = new System.Drawing.Point(160, 48);" + Environment.NewLine +
                        "            this.passwordBox.Name = \"passwordBox\";" + Environment.NewLine +
                        "            this.passwordBox.PasswordChar = '*';" + Environment.NewLine +
                        "            this.passwordBox.Size = new System.Drawing.Size(192, 20);" + Environment.NewLine +
                        "            this.passwordBox.TabIndex = 3;" + Environment.NewLine +
                        "            this.passwordBox.Text = \"\";" + Environment.NewLine +
                        "            // " + Environment.NewLine +
                        "            // passwordLabel" + Environment.NewLine +
                        "            // " + Environment.NewLine +
                        "            this.passwordLabel.Location = new System.Drawing.Point(16, 48);" + Environment.NewLine +
                        "            this.passwordLabel.Name = \"passwordLabel\";" + Environment.NewLine +
                        "            this.passwordLabel.Size = new System.Drawing.Size(160, 32);" + Environment.NewLine +
                        "            this.passwordLabel.TabIndex = 2;" + Environment.NewLine +
                        "            this.passwordLabel.Text = \"Enter the password for the remote computer:\";" + Environment.NewLine +
                        "            // " + Environment.NewLine +
                        "            // OKButton" + Environment.NewLine +
                        "            // " + Environment.NewLine +
                        "            this.OKButton.Location = new System.Drawing.Point(40, 88);" + Environment.NewLine +
                        "            this.OKButton.Name = \"OKButton\";" + Environment.NewLine +
                        "            this.OKButton.Size = new System.Drawing.Size(128, 23);" + Environment.NewLine +
                        "            this.OKButton.TabIndex = 4;" + Environment.NewLine +
                        "            this.OKButton.Text = \"OK\";" + Environment.NewLine +
                        "            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);" + Environment.NewLine +
                        "            // " + Environment.NewLine +
                        "            // cancelButton" + Environment.NewLine +
                        "            // " + Environment.NewLine +
                        "            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;" + Environment.NewLine +
                        "            this.cancelButton.Location = new System.Drawing.Point(200, 88);" + Environment.NewLine +
                        "            this.cancelButton.Name = \"cancelButton\";" + Environment.NewLine +
                        "            this.cancelButton.Size = new System.Drawing.Size(128, 23);" + Environment.NewLine +
                        "            this.cancelButton.TabIndex = 5;" + Environment.NewLine +
                        "            this.cancelButton.Text = \"Cancel\";" + Environment.NewLine +
                        "            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);" + Environment.NewLine +
                        "            // " + Environment.NewLine +
                        "            // MyQuerySample" + Environment.NewLine +
                        "            // " + Environment.NewLine +
                        "            this.AcceptButton = this.OKButton;" + Environment.NewLine +
                        "            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);" + Environment.NewLine +
                        "            this.CancelButton = this.cancelButton;" + Environment.NewLine +
                        "            this.ClientSize = new System.Drawing.Size(368, 130);" + Environment.NewLine +
                        "            this.ControlBox = false;" + Environment.NewLine +
                        "            this.Controls.Add(this.cancelButton);" + Environment.NewLine +
                        "            this.Controls.Add(this.OKButton);" + Environment.NewLine +
                        "            this.Controls.Add(this.passwordBox);" + Environment.NewLine +
                        "            this.Controls.Add(this.passwordLabel);" + Environment.NewLine +
                        "            this.Controls.Add(this.userNameBox);" + Environment.NewLine +
                        "            this.Controls.Add(this.userNameLabel);" + Environment.NewLine +
                        "            this.Name = \"MyQuerySample\";" + Environment.NewLine +
                        "            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;" + Environment.NewLine +
                        "            this.Text = \"Remote Connection\";" + Environment.NewLine +
                        "            this.ResumeLayout(false);" + Environment.NewLine +
                        Environment.NewLine +
                        "        }" + Environment.NewLine +
                        Environment.NewLine +
                        "        [STAThread]" + Environment.NewLine +
                        "        static void Main() " + Environment.NewLine +
                        "        {" + Environment.NewLine +
                        "            Application.Run(new CallWMIMethod());" + Environment.NewLine +
                        "        }" + Environment.NewLine +
                        Environment.NewLine +
                        "        private void OKButton_Click(object sender, System.EventArgs e)" + Environment.NewLine +
                        "        {" + Environment.NewLine +
                        "            try" + Environment.NewLine +
                        "            {" + Environment.NewLine +
                        "                ConnectionOptions connection = new ConnectionOptions();" + Environment.NewLine +
                        "                connection.Username = userNameBox.Text;" + Environment.NewLine +
                        "                connection.Password = passwordBox.Text;" + Environment.NewLine +
                        "                connection.Authority = \"ntlmdomain:" + this.TargetWindow.GetRemoteComputerDomain() + "\";" + Environment.NewLine +
                        Environment.NewLine +
                        "                ManagementScope scope = new ManagementScope(" + Environment.NewLine +
                        "                    \"\\\\\\\\" + this.TargetWindow.GetRemoteComputerName() + "\\\\" + this.NamespaceValue_m.Text.Replace("\\", "\\\\") + "\", connection);" + Environment.NewLine +
                        "                scope.Connect();" + Environment.NewLine +Environment.NewLine;
					
                }
                else if(this.GroupRemoteComputerMenu.Checked)
                {
                    code = code +
                        "using System;" + Environment.NewLine +
                        "using System.Management;" + Environment.NewLine +
                        "using System.Windows.Forms;" + Environment.NewLine +
                        Environment.NewLine +
                        "namespace WMISample" + Environment.NewLine +
                        "{" + Environment.NewLine +
                        "    public class CallWMIMethod" + Environment.NewLine +
                        "    {" + Environment.NewLine +
                        "        public static void Main()" + Environment.NewLine +
                        "        {" + Environment.NewLine +
                        "            try" + Environment.NewLine +
                        "            {" + Environment.NewLine +
                        "                string[] arrComputers = {\"";

                    string delimStr = " ,\n";
                    char [] delimiter = delimStr.ToCharArray();
                    string [] split = this.TargetWindow.GetArrayOfComputers().Split(delimiter);

                    foreach (string s in split) 
                    {
                        code = code + s.Trim() + "\",\"";
                    }
                    string trimStr = ",\"";
                    char [] trim = trimStr.ToCharArray();
                    code = code.TrimEnd(trim) + "\"};" +
                        Environment.NewLine +
                        "                foreach (string strComputer in arrComputers)" + Environment.NewLine +
                        "                {" + Environment.NewLine;

                }
                else
                {
                    code = code +
                        "using System;" + Environment.NewLine +
                        "using System.Management;" + Environment.NewLine +
                        "using System.Windows.Forms;" + Environment.NewLine +
                        Environment.NewLine +
                        "namespace WMISample" + Environment.NewLine +
                        "{" + Environment.NewLine +
                        "    public class CallWMIMethod" + Environment.NewLine +
                        "    {" + Environment.NewLine +
                        "        public static void Main()" + Environment.NewLine +
                        "        {" + Environment.NewLine +
                        "            try" + Environment.NewLine +
                        "            {" + Environment.NewLine;
                }

                
                if(staticFlag)
                {
                    if(this.GroupRemoteComputerMenu.Checked)
                    {
                        code = code +
                            "                    Console.WriteLine(\"==========================================\");" + Environment.NewLine +
                            "                    Console.WriteLine(\"  Computer: \" + strComputer);" + Environment.NewLine +
                            "                    Console.WriteLine(\"==========================================\");" + Environment.NewLine + Environment.NewLine +
                            "                    ManagementClass classInstance = " + Environment.NewLine +
                            "                        new ManagementClass(\"\\\\\\\\\" + strComputer + \"\\\\" + this.NamespaceValue_m.Text.Replace("\\", "\\\\") + "\", " + Environment.NewLine +
                            "                        \"" + this.ClassList_m.Text + "\", null);" +
                            Environment.NewLine +
                            Environment.NewLine;
                    }
                    else if(this.LocalComputerMenu.Checked)
                    {
                        code = code +
                            "                ManagementClass classInstance = " + Environment.NewLine +
                            "                    new ManagementClass(\"" + this.NamespaceValue_m.Text.Replace("\\", "\\\\") + "\", " + Environment.NewLine +
                            "                    \"" + this.ClassList_m.Text + "\", null);" +
                            Environment.NewLine +
                            Environment.NewLine;
                    }
                    else if(this.RemoteComputerMenu.Checked)
                    {
                        code = code +
                            "                ManagementClass classInstance = " + Environment.NewLine +
                            "                    new ManagementClass(scope, " + Environment.NewLine +
                            "                    new ManagementPath(\"" + this.ClassList_m.Text + "\"), null);" +
                            Environment.NewLine +
                            Environment.NewLine;
                    }
                }
                else
                {
                    if(this.KeyValueBox.SelectedItems.Count.Equals(0))
                    {
                        if(this.KeyValueBox.Items.Count.Equals(0))
                        {
                            if(this.GroupRemoteComputerMenu.Checked)
                            {
                                code = code +
                                    "                    Console.WriteLine(\"==========================================\");" + Environment.NewLine +
                                    "                    Console.WriteLine(\"  Computer: \" + strComputer);" + Environment.NewLine +
                                    "                    Console.WriteLine(\"==========================================\");" + Environment.NewLine + Environment.NewLine +
                                    "                    ManagementClass classInstance = " + Environment.NewLine +
                                    "                        new ManagementClass(\"\\\\\\\\\" + strComputer + \"\\\\" + this.NamespaceValue_m.Text.Replace("\\", "\\\\") + "\", " + Environment.NewLine +
                                    "                        \"" + this.ClassList_m.Text + "\", null);" +
                                    Environment.NewLine +
                                    Environment.NewLine;
                            }
                            else if(this.LocalComputerMenu.Checked)
                            {
                                code = code +
                                    "                ManagementObject classInstance = " + Environment.NewLine +
                                    "                    new ManagementObject(\"" + this.NamespaceValue_m.Text.Replace("\\", "\\\\") + "\", " + Environment.NewLine +
                                    "                    \"" + this.ClassList_m.Text + "\", null);" +
                                    Environment.NewLine +
                                    Environment.NewLine;
                            }
                            else if(this.RemoteComputerMenu.Checked)
                            {
                                code = code +
                                    "                ManagementObject classInstance = " + Environment.NewLine +
                                    "                    new ManagementObject(scope, " + Environment.NewLine +
                                    "                    new ManagementPath(\"" + this.ClassList_m.Text + "\"), null);" +
                                    Environment.NewLine +
                                    Environment.NewLine;
                            }
                        }
                        else
                        {
                            if(this.GroupRemoteComputerMenu.Checked)
                            {
                                code = code +
                                    "                    Console.WriteLine(\"==========================================\");" + Environment.NewLine +
                                    "                    Console.WriteLine(\"  Computer: \" + strComputer);" + Environment.NewLine +
                                    "                    Console.WriteLine(\"==========================================\");" + Environment.NewLine + Environment.NewLine +
                                    "                    ManagementObject classInstance = " + Environment.NewLine +
                                    "                        new ManagementObject(\"\\\\\\\\\" + strComputer + \"\\\\" + this.NamespaceValue_m.Text.Replace("\\", "\\\\") + "\", " + Environment.NewLine +
                                    "                        \"" + this.ClassList_m.Text + ".ReplaceKeyPropery='ReplaceKeyPropertyValue'\"," +
                                    Environment.NewLine + "                        null);" +
                                    Environment.NewLine +
                                    Environment.NewLine;
                            }
							
                            else if(this.LocalComputerMenu.Checked)
                            {
                                code = code + 
                                    "                ManagementObject classInstance = " + Environment.NewLine +
                                    "                    new ManagementObject(\"" + this.NamespaceValue_m.Text.Replace("\\", "\\\\") + "\", " + Environment.NewLine +
                                    "                    \"" + this.ClassList_m.Text + ".ReplaceKeyPropery='ReplaceKeyPropertyValue'\"," +
                                    Environment.NewLine + "                    null);" +
                                    Environment.NewLine +
                                    Environment.NewLine;
                            }
                            else if(this.RemoteComputerMenu.Checked)
                            {
                                code = code +
                                    "                ManagementObject classInstance = " + Environment.NewLine +
                                    "                    new ManagementObject(scope, " + Environment.NewLine +
                                    "                    new ManagementPath(\"" + this.ClassList_m.Text + ".ReplaceKeyPropery='ReplaceKeyPropertyValue'\")," +
                                    Environment.NewLine + "                    null);" +
                                    Environment.NewLine +
                                    Environment.NewLine;
                            }
                        }
                    }
                    else
                    {
                        if(this.GroupRemoteComputerMenu.Checked)
                        {
                            code = code +
                                "                    Console.WriteLine(\"==========================================\");" + Environment.NewLine +
                                "                    Console.WriteLine(\"  Computer: \" + strComputer);" + Environment.NewLine +
                                "                    Console.WriteLine(\"==========================================\");" + Environment.NewLine + Environment.NewLine + 
                                "                    ManagementObject classInstance = " + Environment.NewLine +
                                "                        new ManagementObject(\"\\\\\\\\\" + strComputer + \"\\\\" + this.NamespaceValue_m.Text.Replace("\\", "\\\\") + "\", " + Environment.NewLine +
                                "                        \"" + this.ClassList_m.Text + "." + this.KeyValueBox.SelectedItem.ToString() + "\"," +
                                Environment.NewLine + "                        null);" +
                                Environment.NewLine +
                                Environment.NewLine;
                        }
                        else if(this.LocalComputerMenu.Checked)
                        {
                            code = code + 
                                "                ManagementObject classInstance = " + Environment.NewLine +
                                "                    new ManagementObject(\"" + this.NamespaceValue_m.Text.Replace("\\", "\\\\") + "\", " + Environment.NewLine +
                                "                    \"" + this.ClassList_m.Text + "." + this.KeyValueBox.SelectedItem.ToString() + "\"," +
                                Environment.NewLine + "                    null);" +
                                Environment.NewLine +
                                Environment.NewLine;
                        }
                        else if(this.RemoteComputerMenu.Checked)
                        {
                            code = code +
                                "                ManagementObject classInstance = " + Environment.NewLine +
                                "                    new ManagementObject(scope, " + Environment.NewLine +
                                "                    new ManagementPath(\"" + this.ClassList_m.Text + "." + this.KeyValueBox.SelectedItem.ToString() + "\")," +
                                Environment.NewLine + "                    null);" +
                                Environment.NewLine +
                                Environment.NewLine;
                        }
                    }
                }

                try
                {
                    ManagementClass c = new ManagementClass(this.NamespaceValue_m.Text, this.ClassList_m.Text, null);

                    foreach (MethodData mData in c.Methods)
                    {
                        if(mData.Name.Equals(this.MethodList.Text))
                        {

                            if(mData.InParameters.Properties.Count.Equals(0))
                            {
								
                                code = code + buffer + "                // no method in-parameters to define" + Environment.NewLine
                                    + Environment.NewLine;
								
                            }
                            else
                            {
                                code = code + buffer +"                // Obtain in-parameters for the method" +
                                    Environment.NewLine + buffer +
                                    "                ManagementBaseObject inParams = " +
                                    Environment.NewLine + buffer +
                                    "                    classInstance.GetMethodParameters(\"" + this.MethodList.Text	+ "\");" +
                                    Environment.NewLine + Environment.NewLine + buffer +
                                    "                // Add the input parameters." + Environment.NewLine;

                                for(int i = 0; i < InParameterBox.Items.Count; i ++)
                                {
                                    if(InParameterBox.SelectedIndices.Contains(i) && !InParameterArray[i].ReturnParameterValue().Equals(""))
                                    {
                                        code = code + buffer +
                                            "                inParams[\"" + InParameterBox.Items[i].ToString().Split(" ".ToCharArray())[0] +
                                            "\"] =  " + InParameterArray[i].ReturnParameterValue() + ";" +
                                            Environment.NewLine;
                                    }
                                }
                            }
                        }
                    }
                }
                catch (System.NullReferenceException nullError2)
                {
                    code = code + buffer+ "                // no method in-parameters to define" + Environment.NewLine
                        + Environment.NewLine;
                }

                code = code + Environment.NewLine + buffer +
                    "                // Execute the method and obtain the return values." +
                    Environment.NewLine;
				

                if(this.InParameterBox.Items.Count.Equals(0))
                {
					
                    code = code + buffer + "                ManagementBaseObject outParams = " +
                        Environment.NewLine + buffer +
                        "                    classInstance.InvokeMethod(\"" + this.MethodList.Text + "\", null, null);" +
                        Environment.NewLine + Environment.NewLine;
                }
                else
                {
                    code = code + buffer + "                ManagementBaseObject outParams = " +
                        Environment.NewLine + buffer +
                        "                    classInstance.InvokeMethod(\"" + this.MethodList.Text + "\", inParams, null);" +
                        Environment.NewLine + Environment.NewLine;
                }

                try
                {
                    ManagementClass c = new ManagementClass(this.NamespaceValue_m.Text, this.ClassList_m.Text, null);
                    foreach (MethodData mData in c.Methods)
                    {
                        if(mData.Name.Equals(this.MethodList.Text))
                        {

                            if(mData.OutParameters.Properties.Count.Equals(0))
                            {
                                code = code + Environment.NewLine + buffer + "                // No outParams" + Environment.NewLine;
                            }
                            else
                            {
                                code = code + buffer + 
                                    "                // List outParams" + Environment.NewLine + buffer +
                                    "                Console.WriteLine(\"Out parameters:\");" + Environment.NewLine;
								
                                foreach(PropertyData p in mData.OutParameters.Properties)
                                {
                                    // Check to see if the out-parameter is not a basic type
                                    if(p.Type.ToString().Equals("Object"))
                                    {
                                        code = code + buffer + "                Console.WriteLine(\"The " + p.Name +
                                            " out-parameter contains an object.\");" + Environment.NewLine;
                                    }
                                    else
                                    {
                                        code = code + buffer + "                Console.WriteLine(\"" + p.Name +
                                            ": \" + outParams[\"" +
                                            p.Name + "\"]);" + Environment.NewLine;
                                    }
                                }
                            }
                        }
                    }
                }
                catch (System.NullReferenceException nullError)
                {
                    code = code + Environment.NewLine + buffer + "                // No outParams" + Environment.NewLine;
                }

                if(this.RemoteComputerMenu.Checked)
                {
                    code = code + Environment.NewLine + "                Close();" + Environment.NewLine +
                        "            }" + Environment.NewLine +
                        "            catch(ManagementException err)" + Environment.NewLine +
                        "            {" + Environment.NewLine +
                        "                MessageBox.Show(\"An error occurred while trying to execute the WMI method: \" + err.Message);" + Environment.NewLine +
                        "            }" + Environment.NewLine +
                        "            catch(System.UnauthorizedAccessException unauthorizedErr)" + Environment.NewLine +
                        "            {" + Environment.NewLine +
                        "                MessageBox.Show(\"Connection error (user name or password might be incorrect): \" + unauthorizedErr.Message);" + Environment.NewLine +
                        "            }" + Environment.NewLine +
                        "        }" + Environment.NewLine +
                        Environment.NewLine +
                        "        private void cancelButton_Click(object sender, System.EventArgs e)" + Environment.NewLine +
                        "        {" + Environment.NewLine +
                        "            Close();" + Environment.NewLine +
                        "        }" + Environment.NewLine +
                        "    }" + Environment.NewLine +
                        "}" + Environment.NewLine;
                }
                else if(this.GroupRemoteComputerMenu.Checked)
                {
                    code = code + "                }" +
                        Environment.NewLine + "            }" +
                        Environment.NewLine + "            catch(ManagementException err)" + Environment.NewLine +
                        "            {" + Environment.NewLine +
                        "                MessageBox.Show(\"An error occurred while trying to execute the WMI method: \" + err.Message);" + Environment.NewLine +
                        "            }" + Environment.NewLine +
                        Environment.NewLine + "        }" +
                        Environment.NewLine + "    }" +
                        Environment.NewLine + "}";
                }
                else
                {
                    code = code + 
                        "            }" + Environment.NewLine + 
                        "            catch(ManagementException err)" + Environment.NewLine +
                        "            {" + Environment.NewLine +
                        "                MessageBox.Show(\"An error occurred while trying to execute the WMI method: \" + err.Message);" + Environment.NewLine +
                        "            }" + Environment.NewLine +
                        "        }" + Environment.NewLine +
                        "    }" + Environment.NewLine +
                        "}";
                }

                this.CodeText_m.Text = code;
            }
        }

        //-------------------------------------------------------------------------
        // Generates the VBScript script in the method tab's generated code area.
        // 
        //-------------------------------------------------------------------------
        private void GenerateVBSMethodCode()
        {

            bool staticFlag = this.IsStaticMethodSelected();

            if(this.MethodList.Items.Count > 0) 
            {
                string code = Environment.NewLine;

                if(this.RemoteComputerMenu.Checked)
                {
                    code = code + "strComputer = \"" + this.TargetWindow.GetRemoteComputerName() + "\" " 
                        + Environment.NewLine +
                        "strDomain = \"" + this.TargetWindow.GetRemoteComputerDomain() + "\" " 
                        + Environment.NewLine +
                        "Wscript.StdOut.Write \"Please enter your user name:\"" +
                        Environment.NewLine +
                        "strUser = Wscript.StdIn.ReadLine "
                        + Environment.NewLine +
                        "Set objPassword = CreateObject(\"ScriptPW.Password\")" 
                        + Environment.NewLine +
                        "Wscript.StdOut.Write \"Please enter your password:\""
                        + Environment.NewLine +
                        "strPassword = objPassword.GetPassword()"
                        + Environment.NewLine +
                        "Wscript.Echo"
                        + Environment.NewLine + Environment.NewLine +
                        "Set objSWbemLocator = CreateObject(\"WbemScripting.SWbemLocator\") " 
                        + Environment.NewLine +
                        "Set objWMIService = objSWbemLocator.ConnectServer(strComputer, _ "
                        + Environment.NewLine +
                        "    \"" + this.NamespaceValue_m.Text +"\", _ " 
                        + Environment.NewLine +
                        "    strUser, _ "
                        + Environment.NewLine +
                        "    strPassword, _ "
                        + Environment.NewLine +
                        "    \"MS_409\", _ "
                        + Environment.NewLine +
                        "    \"ntlmdomain:\" + strDomain) "
                        + Environment.NewLine;
                }
                else if(this.GroupRemoteComputerMenu.Checked)
                {
                    string delimStr = " ,\n";
                    char [] delimiter = delimStr.ToCharArray();
                    string [] split = this.TargetWindow.GetArrayOfComputers().Split(delimiter);


                    code = code + "arrComputers = Array(\"";
                    foreach (string s in split) 
                    {
                        code = code + s.Trim() + "\",\"";
                    }
                    string trimStr = ",\"";
                    char [] trim = trimStr.ToCharArray();
                    code = code.TrimEnd(trim) + "\")" +
                        Environment.NewLine +
                        "For Each strComputer In arrComputers" +
                        Environment.NewLine +
                        "   WScript.Echo" +
                        Environment.NewLine +
                        "   WScript.Echo \"==========================================\"" +
                        Environment.NewLine +
                        "   WScript.Echo \"Computer: \" & strComputer" +
                        Environment.NewLine +
                        "   WScript.Echo \"==========================================\"" +
                        Environment.NewLine + 
                        Environment.NewLine +
                       
                        "Set objWMIService = GetObject(\"winmgmts:\\\\\" & strComputer & \"\\" +
                        this.NamespaceValue_m.Text + "\") " 
                        + Environment.NewLine;

                }
                else
                {
                    code = code + "strComputer = \".\" " 
                        + Environment.NewLine +
                        "Set objWMIService = GetObject(\"winmgmts:\\\\\" & strComputer & \"\\" +
                        this.NamespaceValue_m.Text + "\") " 
                        + Environment.NewLine;
                }
                
                if(staticFlag) // If true, the method is static.
                {
                    code = code + "' Obtain the definition of the class." +
                        Environment.NewLine +
                        "Set objShare = objWMIService.Get(\"" + this.ClassList_m.Text + "\")" +
                        Environment.NewLine + Environment.NewLine;
                }
                else
                {
                    // The method is not static and must be executed on an instance of the WMI class.
                    if(this.KeyValueBox.SelectedItems.Count.Equals(0))
                    {
                        if(this.KeyValueBox.Items.Count.Equals(0))
                        {
                            code = code + "' Obtain an instance of the the class " +
                                Environment.NewLine +
                                "' using a key property value." +
                                Environment.NewLine +
                                "Set objShare = objWMIService.Get(\"" + this.ClassList_m.Text + "\")" +
                                Environment.NewLine + Environment.NewLine;
                        }
                        else
                        {
                            code = code + "' Obtain an instance of the the class " +
                                Environment.NewLine +
                                "' using a key property value." +
                                Environment.NewLine +
                                "Set objShare = objWMIService.Get(\"" + this.ClassList_m.Text + ".ReplaceKeyProperty=ReplacePropertyValue\")" +
                                Environment.NewLine + Environment.NewLine;
                        }
                    }
                    else
                    {
                        code = code + "' Obtain an instance of the the class " +
                            Environment.NewLine +
                            "' using a key property value." +
                            Environment.NewLine +
                            "Set objShare = objWMIService.Get(\"" + this.ClassList_m.Text + "." + this.KeyValueBox.SelectedItem.ToString() + "\")" +
                            Environment.NewLine + Environment.NewLine;
                    }
                }


                try
                {
                    ManagementClass c = new ManagementClass(this.NamespaceValue_m.Text, this.ClassList_m.Text, null);

                    foreach (MethodData mData in c.Methods)
                    {
                        if(mData.Name.Equals(this.MethodList.Text))
                        {

                            if(mData.InParameters.Properties.Count.Equals(0))
                            {
                                code = code + "' no InParameters to define" + Environment.NewLine
                                    + Environment.NewLine;
                            }
                            else
                            {
                                code = code + "' Obtain an InParameters object specific" +
                                    Environment.NewLine +
                                    "' to the method." +
                                    Environment.NewLine +
                                    "Set objInParam = objShare.Methods_(\"" + this.MethodList.SelectedItem.ToString() + "\"). _" +
                                    Environment.NewLine +
                                    "    inParameters.SpawnInstance_()" + Environment.NewLine +
                                    Environment.NewLine + Environment.NewLine +
                                    "' Add the input parameters." + Environment.NewLine;


								
                                for(int i = 0; i < InParameterBox.Items.Count; i ++)
                                {
                                    if(InParameterBox.SelectedIndices.Contains(i) && !InParameterArray[i].ReturnParameterValue().Equals(""))
                                    {
                                        code = code +
                                            "objInParam.Properties_.Item(\"" + InParameterBox.Items[i].ToString().Split(" ".ToCharArray())[0] +
                                            "\") =  " + InParameterArray[i].ReturnParameterValue() +
                                            Environment.NewLine;
                                    }
                                }
                            }
                        }
                    }
                }
                catch (System.NullReferenceException nullError)
                {
                    code = code + "' no InParameters to define"
                        + Environment.NewLine; 
                }

                code = code + Environment.NewLine +
                    "' Execute the method and obtain the return status." +
                    Environment.NewLine +
                    "' The OutParameters object in objOutParams" + 
                    Environment.NewLine +
                    "' is created by the provider." + 
                    Environment.NewLine;
 
                if(staticFlag)
                {
                    code = code + "Set objOutParams = objWMIService.ExecMethod(\"" + this.ClassList_m.Text + "\", \"";     
                }
                else
                {
                    if(!this.KeyValueBox.SelectedItems.Count.Equals(0))
                    {
                        code = code + "Set objOutParams = objWMIService.ExecMethod(\"" + this.ClassList_m.Text + "." + this.KeyValueBox.SelectedItem.ToString() + "\", \"";         
                    }
                    else
                    {
                        if(this.KeyValueBox.Items.Count.Equals(0))
                        {
                            code = code + "Set objOutParams = objWMIService.ExecMethod(\"" + this.ClassList_m.Text + "\", \"";     
                        }
                        else
                        {
                            code = code + "Set objOutParams = objWMIService.ExecMethod(\"" + this.ClassList_m.Text + ".ReplaceKeyProperty=ReplacePropertyValue\", \"";       
                        }
                    }
                }

                if(this.InParameterBox.Items.Count.Equals(0))
                {
                    code = code + this.MethodList.Text +
                        "\")" +
                        Environment.NewLine + Environment.NewLine;

                }
                else
                {
                    code = code + this.MethodList.Text +
                        "\", objInParam)" +
                        Environment.NewLine + Environment.NewLine;
                }



                try
                {
                    ManagementClass c = new ManagementClass(this.NamespaceValue_m.Text, this.ClassList_m.Text, null);
                    foreach (MethodData mData in c.Methods)
                    {
                        if(mData.Name.Equals(this.MethodList.Text))
                        {

                            if(mData.OutParameters.Properties.Count.Equals(0))
                            {
                                code = code + Environment.NewLine + "' No outParams" + Environment.NewLine;
                            }
                            else
                            {
                                code = code + 
                                    "' List OutParams" + Environment.NewLine +
                                    "Wscript.Echo \"Out Parameters: \"" + Environment.NewLine;

                                foreach(PropertyData p in mData.OutParameters.Properties)
                                {
                                    // Check to see if the out-parameter is not a basic type.
                                    if(p.Type.ToString().Equals("Object"))
                                    {
                                        code = code + "Wscript.echo \"The objOutParams." +
                                            p.Name + " variable contains an object.\"" + Environment.NewLine;
                                    }
                                    else
                                    {
                                        code = code + "Wscript.echo \"" + p.Name +
                                            ": \" & objOutParams." +
                                            p.Name + Environment.NewLine;
                                    }
                                }
                            }
                        }
                    }
                }
                catch (System.NullReferenceException nullError2)
                {
                    code = code + Environment.NewLine + "' No outParams" + Environment.NewLine;
                }

                if(this.GroupRemoteComputerMenu.Checked)
                {
                    code = code + "Next" + Environment.NewLine;
                }

                this.CodeText_m.Text = code;

            }

        }

        //-------------------------------------------------------------------------
        // Generates the code in the event tab's generated code area.
        // 
        //-------------------------------------------------------------------------
        private void GenerateEventCode()
        {
            try
            {
                if(!this.ClassList_event.Text.Equals("")) 
                {
                    if(this.VbNetMenuItem.Checked)
                    {
                        GenerateVBNetEventCode();
                    }
                    else if(this.CSharpMenuItem.Checked)
                    {
                        GenerateCSharpEventCode();
                    }
                    else if(this.VbsMenuItem.Checked)
                    {
                        GenerateVBSEventCode();
                    }
                }
            }
            catch (ManagementException mErr)
            {
                if(mErr.Message.Equals("Not found "))
                    MessageBox.Show("WMI class or method not found.");
                else
                    MessageBox.Show(mErr.Message.ToString());
            }
        }

        //-------------------------------------------------------------------------
        // Generates the VBScript script in the event tab's generated code area.
        // 
        //-------------------------------------------------------------------------
        private void GenerateVBSEventCode()
        {
            if(!this.ClassList_event.Text.Equals("")) 
            {
                string code = "";
                string eventQuery = "";

                if(this.RemoteComputerMenu.Checked)
                {
                    code = code + "strComputer = \"" + this.TargetWindow.GetRemoteComputerName() + "\" " 
                        + Environment.NewLine +
                        "strDomain = \"" + this.TargetWindow.GetRemoteComputerDomain() + "\" " 
                        + Environment.NewLine +
                        "Wscript.StdOut.Write \"Please enter your user name:\"" +
                        Environment.NewLine +
                        "strUser = Wscript.StdIn.ReadLine "
                        + Environment.NewLine +
                        "Set objPassword = CreateObject(\"ScriptPW.Password\")" 
                        + Environment.NewLine +
                        "Wscript.StdOut.Write \"Please enter your password:\""
                        + Environment.NewLine +
                        "strPassword = objPassword.GetPassword()"
                        + Environment.NewLine +
                        "Wscript.Echo"
                        + Environment.NewLine + Environment.NewLine +
                        "Set objSWbemLocator = CreateObject(\"WbemScripting.SWbemLocator\") " 
                        + Environment.NewLine +
                        "objSWbemLocator.Security_.ImpersonationLevel = 3  ' wbemImpersonationLevelImpersonate" + 
                        Environment.NewLine +
                        "objSWbemLocator.Security_.Privileges.AddAsString \"SeSecurityPrivilege\", True" + Environment.NewLine +
                        Environment.NewLine +
                        "Set objWMIService = objSWbemLocator.ConnectServer(strComputer, _ "
                        + Environment.NewLine +
                        "    \"" + this.NamespaceList_event.Text +"\", _ " 
                        + Environment.NewLine +
                        "    strUser, _ "
                        + Environment.NewLine +
                        "    strPassword, _ "
                        + Environment.NewLine +
                        "    \"MS_409\", _ "
                        + Environment.NewLine +
                        "    \"ntlmdomain:\" + strDomain) "
                        + Environment.NewLine;
                }
                else if(this.GroupRemoteComputerMenu.Checked)
                {
                    string delimStr = " ,\n";
                    char [] delimiter = delimStr.ToCharArray();
                    string [] split = this.TargetWindow.GetArrayOfComputers().Split(delimiter);


                    code = code + "strComputer = \"";
                    
                    code = code + split[0].Trim() + "\"";
                  
                    code = code +
                        Environment.NewLine +
                        "   WScript.Echo" +
                        Environment.NewLine +
                        "   WScript.Echo \"==========================================\"" +
                        Environment.NewLine +
                        "   WScript.Echo \"Computer: \" & strComputer" +
                        Environment.NewLine +
                        "   WScript.Echo \"==========================================\"" +
                        Environment.NewLine + 
                        Environment.NewLine +
                       
                        "Set objWMIService = GetObject(\"winmgmts:\\\\\" & strComputer & \"\\" +
                        this.NamespaceList_event.Text + "\") " 
                        + Environment.NewLine;

                }
                else // The target computer is the local computer.
                {
                
                    code = code + "strComputer = \".\" " 
                        + Environment.NewLine +
                        "Set objWMIService = GetObject(\"winmgmts:\\\\\" & strComputer & \"\\" +
                        this.NamespaceList_event.Text + "\") " 
                        + Environment.NewLine;
                }

                if(!this.Asynchronous.Checked)  // Semisynchronous or synchrounous event notification.
                {
                    code = code + "Set objEvents = objWMIService.ExecNotificationQuery _" +
                        Environment.NewLine +
                        "(\"SELECT * FROM " + this.ClassList_event.Text ;
                    eventQuery = "select * from " + this.ClassList_event.Text;
											
                    if(this.PropertyList_event.SelectedItems.Count.Equals(1))
                    {
                        code = code + " WHERE " + PropertyList_event.SelectedItem.ToString();
                        eventQuery = eventQuery + " where " + PropertyList_event.SelectedItem.ToString();
                    }
                    else if(this.PropertyList_event.SelectedItems.Count > 0)
                    {		
                        code = code + " WHERE \" & _" + Environment.NewLine + "                    ";
                        eventQuery = eventQuery + " where ";

                        int flag = -1;
                        string instance = "";
                        for(int i=0; i < PropertyList_event.SelectedItems.Count; i++)
                        {
                            // If PropertyList_event contains a selected item that contains ISA.
                            if(PropertyList_event.SelectedItems[i].ToString().IndexOf("ISA", 1, PropertyList_event.SelectedItems[i].ToString().Length -1 ) > 0)
                            {
                                flag = i;
                                instance = PropertyList_event.SelectedItems[i].ToString();
                            }
                        }
                        if(flag > -1)
                        {
                            code = code + "\"" + instance;
                            eventQuery = eventQuery + instance;
                        }
						
                        for(int i=0; i < PropertyList_event.SelectedItems.Count; i++)
                        {
                            if(flag.Equals(-1) && i.Equals(0)) //Do not start off with quotes.
                            {
                                code = code + "\"" + PropertyList_event.SelectedItems[i].ToString();
                                eventQuery = eventQuery + "\"" + PropertyList_event.SelectedItems[i].ToString();
                            }
                            else if(!i.Equals(flag))
                            {
                                code = code + "\" & _" + Environment.NewLine +
                                    "                    \" AND " + PropertyList_event.SelectedItems[i].ToString();
                                eventQuery = eventQuery + " and " + PropertyList_event.SelectedItems[i].ToString();
                            }
                        }
                    }
                    
                    code = code + "\")" + Environment.NewLine;

					// Check to see if the event class is supported by an event provider.
                    if(this.QueryCounter == 0)
                    {
                        EventQuerySupportedByProvider();
                        this.PollLabel.Visible = false;
                        this.SecondsBox.Visible = false;
                        this.PollLabelEnd.Visible = false;
                    }
                    
                    if(this.QueryCounter > 0)
                    {
                        bool addWITHINStatement = true;

                        // If the user selected event query is in the list of event provider supported
                        // event queries, then the WITHIN statement does not need to be used in
                        // the user selected event query.
                        for(int i=0; i < this.QueryCounter; i++)
                        {
                            if(eventQuery.IndexOf(this.SupportedEventQueries[i].
                                Replace("\"", "'").
                                Replace("isa", "ISA")) != -1)
                            {
                                addWITHINStatement = false; // Do not add the WITHIN statement.
                                break; // Get out of the for loop.
                            }
                        }

                        if(addWITHINStatement && !this.ExtrinsicEvent(this.ClassList_event.Text))
                        {
                            code = code.Replace(("SELECT * FROM " + this.ClassList_event.Text), 
                                ("SELECT * FROM " + this.ClassList_event.Text + " WITHIN " + this.SecondsBox.Text));
                            this.PollLabel.Visible = true;
                            this.SecondsBox.Visible = true;
                            this.PollLabelEnd.Visible = true;
                        }
                        else
                        {
                            this.PollLabel.Visible = false;
                            this.SecondsBox.Visible = false;
                            this.PollLabelEnd.Visible = false;
                        }
                    }
                    
                    code = code + 
                        Environment.NewLine +
                        "Wscript.Echo \"Waiting for events ...\"" + Environment.NewLine +
                        "Do While(True)" +
                        Environment.NewLine +
                        "    Set objReceivedEvent = objEvents.NextEvent" +
                        Environment.NewLine + Environment.NewLine +
                        "    'report an event" +
                        Environment.NewLine +
                        "    Wscript.Echo \"" + this.ClassList_event.Text + " event has occurred.\"" +
                        Environment.NewLine + Environment.NewLine +
                        "Loop" + Environment.NewLine;
                }
                else if(this.Asynchronous.Checked) // Asynchronous event notification.
                {
                    code = code + "Set MySink = WScript.CreateObject( _" +
                        Environment.NewLine +
                        "    \"WbemScripting.SWbemSink\",\"SINK_\")" +
                        Environment.NewLine + Environment.NewLine +
                        "objWMIservice.ExecNotificationQueryAsync MySink, _" +
                        Environment.NewLine +
                        "    \"SELECT * FROM " + this.ClassList_event.Text;
                    eventQuery = "select * from " + this.ClassList_event.Text;
						
                    if(this.PropertyList_event.SelectedItems.Count.Equals(1))
                    {
                        code = code + " WHERE " + PropertyList_event.SelectedItem.ToString();
                        eventQuery = eventQuery + " where " + PropertyList_event.SelectedItem.ToString();
                    }
                    else if(this.PropertyList_event.SelectedItems.Count > 0)
                    {		
                        code = code + " WHERE \" & _" + Environment.NewLine + "                    ";
                        eventQuery = eventQuery + " where ";

                        int flag = -1;
                        string instance = "";
                        for(int i=0; i < PropertyList_event.SelectedItems.Count; i++)
                        {
                            // If PropertyList_event contains a selected item that contains ISA.
                            if(PropertyList_event.SelectedItems[i].ToString().IndexOf("ISA", 1, PropertyList_event.SelectedItems[i].ToString().Length -1 ) > 0)
                            {
                                flag = i;
                                instance = PropertyList_event.SelectedItems[i].ToString();
                            }
                        }
                        if(flag > -1)
                        {
                            code = code + "\"" + instance;
                            eventQuery = eventQuery + instance;
                        }
						
                        for(int i=0; i < PropertyList_event.SelectedItems.Count; i++)
                        {
                            if(flag.Equals(-1) && i.Equals(0)) //Do not start off with quotes.
                            {
                                code = code + "\"" + PropertyList_event.SelectedItems[i].ToString();
                                eventQuery = eventQuery + "\"" + PropertyList_event.SelectedItems[i].ToString();
                            }
                            else if(!i.Equals(flag))
                            {
                                code = code + "\" & _" + Environment.NewLine +
                                    "                    \" AND " + PropertyList_event.SelectedItems[i].ToString();
                                eventQuery = eventQuery + " and " + PropertyList_event.SelectedItems[i].ToString();
                            }
                        }
                    }
                    code = code + "\"" + Environment.NewLine;
                    
                    // Check to see if the event class is supported by an event provider.
                    if(this.QueryCounter == 0)
                    {
                        EventQuerySupportedByProvider();
                        this.PollLabel.Visible = false;
                        this.SecondsBox.Visible = false;
                        this.PollLabelEnd.Visible = false;
                    }
                    
                    if(this.QueryCounter > 0)
                    {
                        bool addWITHINStatement = true;

                        // If the user selected event query is in the list of event provider supported
                        // event queries, then the WITHIN statement does not need to be used in
                        // the user selected event query.
                        for(int i=0; i < this.QueryCounter; i++)
                        {
                            if(eventQuery.IndexOf(this.SupportedEventQueries[i].
                                Replace("\"", "'").
                                Replace("isa", "ISA")) != -1)
                            {
                                addWITHINStatement = false; // Do not add the WITHIN statement.
                                break; // Get out of the for loop.
                            }
                        }

                        if(addWITHINStatement && !this.ExtrinsicEvent(this.ClassList_event.Text))
                        {
                            code = code.Replace(("SELECT * FROM " + this.ClassList_event.Text), 
                                ("SELECT * FROM " + this.ClassList_event.Text + " WITHIN " + this.SecondsBox.Text));
                            this.PollLabel.Visible = true;
                            this.SecondsBox.Visible = true;
                            this.PollLabelEnd.Visible = true;
                        }
                        else
                        {
                            this.PollLabel.Visible = false;
                            this.SecondsBox.Visible = false;
                            this.PollLabelEnd.Visible = false;
                        }
                    }
					
                    code = code + Environment.NewLine + Environment.NewLine +
                        "WScript.Echo \"Waiting for events...\"" +
                        Environment.NewLine + Environment.NewLine +
                        "While (True)" + System.Environment.NewLine + "    Wscript.Sleep(1000)" + System.Environment.NewLine + "Wend" + System.Environment.NewLine + System.Environment.NewLine +
                        "Sub SINK_OnObjectReady(objObject, objAsyncContext)" +
                        Environment.NewLine +
                        "    Wscript.Echo \"" + this.ClassList_event.Text + " event has occurred.\"" +
                        Environment.NewLine +
                        "End Sub" +
                        Environment.NewLine + Environment.NewLine +
                        "Sub SINK_OnCompleted(objObject, objAsyncContext)" +
                        Environment.NewLine +
                        "    WScript.Echo \"Event call complete.\"" +
                        Environment.NewLine +
                        "End Sub" +
                        Environment.NewLine;
                }

                this.CodeText_event.Text = code;

            }
        }

		//-------------------------------------------------------------------------
		// If an event query is supported by an event provider for a given namespace,
		// then the event query is stored in the SupportedEventQueries array.
		//-------------------------------------------------------------------------
        public void EventQuerySupportedByProvider()
        {
            try
            {
				ManagementObjectSearcher searcher = 
					new ManagementObjectSearcher(this.NamespaceList_event.Text, 
					"SELECT * FROM __EventProviderRegistration"); 

                foreach (ManagementObject objItem in searcher.Get())
                {
                    string[] queryList = (string[])objItem.Properties["EventQueryList"].Value;

                    foreach (string query in queryList)
                    {
                        // Store the query that is supported by an event provider
                        // in the SupportedEventQueries array.
                        this.SupportedEventQueries[QueryCounter] = query;
                        this.QueryCounter++;
                    }
                }
            }
            catch (ManagementException e)
            {
                 MessageBox.Show("An error occurred while querying for WMI data: " + e.Message);
            } 
        }

        //-------------------------------------------------------------------------
        // Returns true if the eventClass is derived from __ExtrinsicEvent, and 
        // returns false otherwise.
        //-------------------------------------------------------------------------
        public bool ExtrinsicEvent(string eventClass)
        {
            ObjectGetOptions options = new ObjectGetOptions();
            options.UseAmendedQualifiers = true;
            ManagementClass testClass = 
                new ManagementClass(this.NamespaceList_event.Text, 
                eventClass, options);
            
            if(testClass.SystemProperties["__DERIVATION"].Value != null &&
                testClass.SystemProperties["__DERIVATION"].IsArray)
            {
                
                string[] derivationList = (string[])testClass.SystemProperties["__DERIVATION"].Value;

                foreach (string derivationClass in derivationList)
                {
                    // If the event class is derived from __ExtrinsicEvent, then
                    // return true.
                    if(derivationClass.Equals("__ExtrinsicEvent"))
                    {
                        
                        return true;
                    }
                }
            }
            return false;
        }

        //-------------------------------------------------------------------------
        // Generates the VB code in the event tab's generated code area.
        // 
        //-------------------------------------------------------------------------
        private void GenerateVBNetEventCode()
        {

            if(!this.ClassList_event.Text.Equals("")) 
            {
                string code = "";

                if(this.RemoteComputerMenu.Checked)
                {
                    code = "Imports System" + Environment.NewLine +
                        "Imports System.Drawing" + Environment.NewLine +
                        "Imports System.Collections" + Environment.NewLine +
                        "Imports System.ComponentModel" + Environment.NewLine +
                        "Imports System.Windows.Forms" + Environment.NewLine +
                        "Imports System.Data" + Environment.NewLine +
                        "Imports System.Management" + Environment.NewLine +
                        Environment.NewLine +
                        "Namespace WMISample" + Environment.NewLine +
                        Environment.NewLine +
                        "    Public Class WMIReceiveEvent " + Environment.NewLine + "        Inherits System.Windows.Forms.Form" + Environment.NewLine +
                        Environment.NewLine +
                        "        Friend WithEvents userNameLabel As System.Windows.Forms.Label" + Environment.NewLine +
                        "        Friend WithEvents userNameBox As System.Windows.Forms.TextBox" + Environment.NewLine +
                        "        Friend WithEvents passwordBox As System.Windows.Forms.TextBox" + Environment.NewLine +
                        "        Friend WithEvents passwordLabel As System.Windows.Forms.Label" + Environment.NewLine +
                        "        Friend WithEvents OKButton As System.Windows.Forms.Button" + Environment.NewLine +
                        "        Friend WithEvents closeButton As System.Windows.Forms.Button" + Environment.NewLine +
                        "        " + Environment.NewLine +
                        "        Private components As System.ComponentModel.IContainer" + Environment.NewLine +
                        Environment.NewLine +
                        "        Public Sub New()" + Environment.NewLine + 
                        "            MyBase.New()" + Environment.NewLine +
                        Environment.NewLine +
                        "            InitializeComponent()" + Environment.NewLine +
                        "        End Sub" + Environment.NewLine +
                        Environment.NewLine +
                        "        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)" + Environment.NewLine +
                        "        " + Environment.NewLine +
                        "            If disposing Then" + Environment.NewLine +
						
                        "                If Not (components Is Nothing) Then" + Environment.NewLine + 
						
                        "                    components.Dispose()" + Environment.NewLine +
                        "                End If" + Environment.NewLine +
                        "            End If" + Environment.NewLine +
                        "            MyBase.Dispose(disposing)" + Environment.NewLine +
                        "        End Sub" + Environment.NewLine +
                        Environment.NewLine +
                        "        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()" + Environment.NewLine +
                        Environment.NewLine +
                        "            Me.userNameLabel = new System.Windows.Forms.Label" + Environment.NewLine +
                        "            Me.userNameBox = new System.Windows.Forms.TextBox" + Environment.NewLine +
                        "            Me.passwordBox = new System.Windows.Forms.TextBox" + Environment.NewLine +
                        "            Me.passwordLabel = new System.Windows.Forms.Label" + Environment.NewLine +
                        "            Me.OKButton = new System.Windows.Forms.Button" + Environment.NewLine +
                        "            Me.closeButton = new System.Windows.Forms.Button" + Environment.NewLine +
                        "            Me.SuspendLayout()" + Environment.NewLine +
                        "            ' " + Environment.NewLine +
                        "            ' userNameLabel" + Environment.NewLine +
                        "            ' " + Environment.NewLine +
                        "            Me.userNameLabel.Location = New System.Drawing.Point(16, 8)" + Environment.NewLine +
                        "            Me.userNameLabel.Name = \"userNameLabel\"" + Environment.NewLine +
                        "            Me.userNameLabel.Size = New System.Drawing.Size(160, 32)" + Environment.NewLine +
                        "            Me.userNameLabel.TabIndex = 0" + Environment.NewLine +
                        "            Me.userNameLabel.Text = \"Enter the user name for the remote computer:\"" + Environment.NewLine +
                        "            ' " + Environment.NewLine +
                        "            ' userNameBox" + Environment.NewLine +
                        "            ' " + Environment.NewLine +
                        "            Me.userNameBox.Location = New System.Drawing.Point(160, 16)" + Environment.NewLine +
                        "            Me.userNameBox.Name = \"userNameBox\"" + Environment.NewLine +
                        "            Me.userNameBox.Size = New System.Drawing.Size(192, 20)" + Environment.NewLine +
                        "            Me.userNameBox.TabIndex = 1" + Environment.NewLine +
                        "            Me.userNameBox.Text = \"\"" + Environment.NewLine +
                        "            ' " + Environment.NewLine +
                        "            ' passwordBox" + Environment.NewLine +
                        "            ' " + Environment.NewLine +
                        "            Me.passwordBox.Location = New System.Drawing.Point(160, 48)" + Environment.NewLine +
                        "            Me.passwordBox.Name = \"passwordBox\"" + Environment.NewLine +
                        "            Me.passwordBox.PasswordChar = \"*\"" + Environment.NewLine +
                        "            Me.passwordBox.Size = new System.Drawing.Size(192, 20)" + Environment.NewLine +
                        "            Me.passwordBox.TabIndex = 3" + Environment.NewLine +
                        "            Me.passwordBox.Text = \"\"" + Environment.NewLine +
                        "            ' " + Environment.NewLine +
                        "            ' passwordLabel" + Environment.NewLine +
                        "            ' " + Environment.NewLine +
                        "            Me.passwordLabel.Location = new System.Drawing.Point(16, 48)" + Environment.NewLine +
                        "            Me.passwordLabel.Name = \"passwordLabel\"" + Environment.NewLine +
                        "            Me.passwordLabel.Size = new System.Drawing.Size(160, 32)" + Environment.NewLine +
                        "            Me.passwordLabel.TabIndex = 2" + Environment.NewLine +
                        "            Me.passwordLabel.Text = \"Enter the password for the remote computer:\"" + Environment.NewLine +
                        "            ' " + Environment.NewLine +
                        "            ' OKButton" + Environment.NewLine +
                        "            ' " + Environment.NewLine +
                        "            Me.OKButton.Location = New System.Drawing.Point(40, 88)" + Environment.NewLine +
                        "            Me.OKButton.Name = \"OKButton\"" + Environment.NewLine +
                        "            Me.OKButton.Size = new System.Drawing.Size(128, 23)" + Environment.NewLine +
                        "            Me.OKButton.TabIndex = 4" + Environment.NewLine +
                        "            Me.OKButton.Text = \"OK\"" + Environment.NewLine +
						
                        "            ' " + Environment.NewLine +
                        "            ' closeButton" + Environment.NewLine +
                        "            ' " + Environment.NewLine +
                        "            Me.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel" + Environment.NewLine +
                        "            Me.closeButton.Location = New System.Drawing.Point(200, 88)" + Environment.NewLine +
                        "            Me.closeButton.Name = \"closeButton\"" + Environment.NewLine +
                        "            Me.closeButton.Size = New System.Drawing.Size(128, 23)" + Environment.NewLine +
                        "            Me.closeButton.TabIndex = 5" + Environment.NewLine +
                        "            Me.closeButton.Text = \"Cancel\"" + Environment.NewLine +
						
                        "            ' " + Environment.NewLine +
                        "            ' MyQuerySample" + Environment.NewLine +
                        "            ' " + Environment.NewLine +
                        "            Me.AcceptButton = Me.OKButton" + Environment.NewLine +
                        "            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)" + Environment.NewLine +
                        "            Me.cancelButton = Me.closeButton" + Environment.NewLine +
                        "            Me.ClientSize = New System.Drawing.Size(368, 130)" + Environment.NewLine +
                        "            Me.ControlBox = false" + Environment.NewLine +
                        "            Me.Controls.Add(Me.closeButton)" + Environment.NewLine +
                        "            Me.Controls.Add(Me.OKButton)" + Environment.NewLine +
                        "            Me.Controls.Add(Me.passwordBox)" + Environment.NewLine +
                        "            Me.Controls.Add(Me.passwordLabel)" + Environment.NewLine +
                        "            Me.Controls.Add(Me.userNameBox)" + Environment.NewLine +
                        "            Me.Controls.Add(Me.userNameLabel)" + Environment.NewLine +
                        "            Me.Name = \"MyQuerySample\"" + Environment.NewLine +
                        "            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen" + Environment.NewLine +
                        "            Me.Text = \"Remote Connection\"" + Environment.NewLine +
                        "            Me.ResumeLayout(false)" + Environment.NewLine +
                        Environment.NewLine +
                        "        End Sub" + Environment.NewLine +
                        Environment.NewLine +
                        "        Public Overloads Shared Function Main() As Integer" + Environment.NewLine +
                        Environment.NewLine +
                        "            Application.Run(New WMIReceiveEvent)" + Environment.NewLine +
                        "        End Function" + Environment.NewLine +
                        Environment.NewLine +
                        "        Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click" + Environment.NewLine +
                        "        " + Environment.NewLine +
                        "            Try" + Environment.NewLine +
                        Environment.NewLine +
                        "                Dim connection As New ConnectionOptions()" + Environment.NewLine +
                        "                connection.Username = userNameBox.Text" + Environment.NewLine +
                        "                connection.Password = passwordBox.Text" + Environment.NewLine +
                        "                connection.Authority = \"ntlmdomain:" + this.TargetWindow.GetRemoteComputerDomain() + "\"" + Environment.NewLine +
                        Environment.NewLine +
                        "                Dim scope As New ManagementScope( _" + Environment.NewLine +
                        "                    \"\\\\" + this.TargetWindow.GetRemoteComputerName() + "\\" + this.NamespaceList_event.Text + "\", connection)" + Environment.NewLine +
                        "                scope.Connect()" + Environment.NewLine +Environment.NewLine;
                }
                else if(this.GroupRemoteComputerMenu.Checked)
                {
                    code = code +
                        "Imports System" + Environment.NewLine +
                        "Imports System.Management" + Environment.NewLine +
                        "Imports System.Windows.Forms" + Environment.NewLine +
                        Environment.NewLine +
                        "Namespace WMISample" + Environment.NewLine +
                        Environment.NewLine +
                        "    Public Class WMIReceiveEvent" + Environment.NewLine +
                        Environment.NewLine;
                    if(this.Asynchronous.Checked)
                    {
                        code = code +
                            "        Public Sub New()" + Environment.NewLine +
                            Environment.NewLine +
                            "            Try" + Environment.NewLine +
                            Environment.NewLine +
                            "                Dim strComputer As String" + Environment.NewLine;

                        string delimStr = " ,\n";
                        char [] delimiter = delimStr.ToCharArray();
                        string [] split = this.TargetWindow.GetArrayOfComputers().Split(delimiter);


                        code = code + "                strComputer = \"";
                    
                        code = code + split[0].Trim() + "\"" + Environment.NewLine + Environment.NewLine;
                    }
                    else
                    {
                        code = code +
                            "        Public Overloads Shared Function Main() As Integer" + Environment.NewLine +
                            Environment.NewLine +
                            "            Try" + Environment.NewLine +
                            Environment.NewLine +
                            "                Dim strComputer As String" + Environment.NewLine;

                        string delimStr = " ,\n";
                        char [] delimiter = delimStr.ToCharArray();
                        string [] split = this.TargetWindow.GetArrayOfComputers().Split(delimiter);


                        code = code + "                strComputer = \"";
                    
                        code = code + split[0].Trim() + "\"" + Environment.NewLine + Environment.NewLine;
                    }

                }
                else
                {
                    // Target computer is the local computer. 
                    code = code +
                        "Imports System" + Environment.NewLine +
                        "Imports System.Management" + Environment.NewLine +
                        "Imports System.Windows.Forms" + Environment.NewLine +
                        Environment.NewLine +
                        "Namespace WMISample" + Environment.NewLine +
                        Environment.NewLine +
                        "    Public Class WMIReceiveEvent" + Environment.NewLine +
                        Environment.NewLine;
                    if(this.Asynchronous.Checked) // Asynchronous event notification.
                    {
                        code = code + 
                            "        Public Sub New()" + Environment.NewLine +
                            Environment.NewLine +
                            "            Try" + Environment.NewLine +
                            Environment.NewLine ;
                    }
                    else
                    {
                        code = code + 
                            "        Public Overloads Shared Function Main() As Integer" + Environment.NewLine +
                            Environment.NewLine +
                            "            Try" + Environment.NewLine +
                            Environment.NewLine;
                    }
                }

                string eventQuery = "";

                if(this.GroupRemoteComputerMenu.Checked)
                {
                    code = code + 
                        "                Dim scope As String = \"\\\\\" & strComputer & \"\\" + this.NamespaceList_event.Text + "\"" + Environment.NewLine + Environment.NewLine +
                        "                Dim query As String = _" + Environment.NewLine +
                        "                    \"SELECT * FROM " + this.ClassList_event.Text ;
                }
                else
                {
                    code = code + 
                        "                Dim query As New WqlEventQuery( _" + Environment.NewLine +
                        "                    \"SELECT * FROM " + this.ClassList_event.Text ;
                }
                eventQuery = "select * from " + this.ClassList_event.Text;
				
                if(this.PropertyList_event.SelectedItems.Count.Equals(1))
                {
                    code = code + " WHERE " + PropertyList_event.SelectedItem.ToString();
                    eventQuery = eventQuery + " where " + PropertyList_event.SelectedItem.ToString();
                }
                else if(this.PropertyList_event.SelectedItems.Count > 0)
                {		
                    code = code + " WHERE \" & _" + Environment.NewLine + "                    ";
                    eventQuery = eventQuery + " where ";

                    int flag = -1;
                    string instance = "";
                    for(int i=0; i < PropertyList_event.SelectedItems.Count; i++)
                    {
                        // If PropertyList_event contains a selected item that contains ISA.
                        if(PropertyList_event.SelectedItems[i].ToString().IndexOf("ISA", 1, PropertyList_event.SelectedItems[i].ToString().Length -1 ) > 0)
                        {
                            flag = i;
                            instance = PropertyList_event.SelectedItems[i].ToString();
                        }
                    }
                    if(flag > -1)
                    {
                        code = code + "\"" + instance;
                        eventQuery = eventQuery + instance;
                    }
						
                    for(int i=0; i < PropertyList_event.SelectedItems.Count; i++)
                    {
                        if(flag.Equals(-1) && i.Equals(0)) //Do not start off with quotes.
                        {
                            code = code + "\"" + PropertyList_event.SelectedItems[i].ToString();
                            eventQuery = eventQuery + "\"" + PropertyList_event.SelectedItems[i].ToString();
                        }
                        else if(!i.Equals(flag))
                        {
                            code = code + "\" & _" + Environment.NewLine +
                                "                    \" AND " + PropertyList_event.SelectedItems[i].ToString();
                            eventQuery = eventQuery + " and " + PropertyList_event.SelectedItems[i].ToString();
                        }
                    }
                }

                if(this.GroupRemoteComputerMenu.Checked)
                    code = code + "\"";
                else
                    code = code + "\")";

                // Check to see if the event class is supported by an event provider.
                if(this.QueryCounter == 0)
                {
                    EventQuerySupportedByProvider();
                    this.PollLabel.Visible = false;
                    this.SecondsBox.Visible = false;
                    this.PollLabelEnd.Visible = false;
                }
                    
                if(this.QueryCounter > 0)
                {
                    bool addWITHINStatement = true;

                    // If the user selected event query is in the list of event provider supported
                    // event queries, then the WITHIN statement does not need to be used in
                    // the user selected event query.
                    for(int i=0; i < this.QueryCounter; i++)
                    {
                        if(eventQuery.IndexOf(this.SupportedEventQueries[i].
                            Replace("\"", "'").
                            Replace("isa", "ISA")) != -1)
                        {
                            addWITHINStatement = false; // Do not add the WITHIN statement.
                            break; // Get out of the for loop.
                        }
                    }

                    if(addWITHINStatement && !this.ExtrinsicEvent(this.ClassList_event.Text))
                    {
                        code = code.Replace(("SELECT * FROM " + this.ClassList_event.Text), 
                            ("SELECT * FROM " + this.ClassList_event.Text + " WITHIN " + this.SecondsBox.Text));
                        this.PollLabel.Visible = true;
                        this.SecondsBox.Visible = true;
                        this.PollLabelEnd.Visible = true;
                    }
                    else
                    {
                        this.PollLabel.Visible = false;
                        this.SecondsBox.Visible = false;
                        this.PollLabelEnd.Visible = false;
                    }
                }

                if(this.GroupRemoteComputerMenu.Checked)
                {
                    code = code + Environment.NewLine + Environment.NewLine +
                        "                Dim watcher As New ManagementEventWatcher(scope, query)" + Environment.NewLine +
                        "                Console.WriteLine(\"Waiting for an event on \" & strComputer & \" ...\")" + Environment.NewLine + Environment.NewLine;
                }
                else if(this.RemoteComputerMenu.Checked)
                {
                    code = code + Environment.NewLine + Environment.NewLine +
                        "                Dim watcher As New ManagementEventWatcher(scope, query)" + Environment.NewLine +
                        "                Console.WriteLine(\"Waiting for an event on " + this.TargetWindow.GetRemoteComputerName() + " ...\")" + Environment.NewLine + Environment.NewLine;
                }
                else // Target computer is the local computer.
                {
                    code = code + Environment.NewLine + Environment.NewLine +
                        "                Dim watcher As New ManagementEventWatcher(query)" + Environment.NewLine +
                        "                Console.WriteLine(\"Waiting for an event...\")" + Environment.NewLine + Environment.NewLine;
                }

                // Semisynchronous or synchronous event.
                if(!this.Asynchronous.Checked)
                {
                    
                    code = code +
                        "                Dim eventObj As ManagementBaseObject = watcher.WaitForNextEvent()" + Environment.NewLine + Environment.NewLine +
                        "                Console.WriteLine(\"{0} event occurred.\", eventObj(\"__CLASS\"))" + Environment.NewLine + Environment.NewLine +
                        "                ' Cancel the event subscription" + Environment.NewLine +
                        "                watcher.Stop()" + Environment.NewLine;
                        
					
                    if(this.RemoteComputerMenu.Checked)
                    {
                        code = code + Environment.NewLine +
                            "                Close()" + Environment.NewLine +
                            "                Return " + Environment.NewLine +
                            Environment.NewLine +
                            "            Catch err As ManagementException" + Environment.NewLine +
                            Environment.NewLine +
                            "                MessageBox.Show(\"An error occurred while trying to receive an event: \" & err.Message)" + Environment.NewLine +
                            Environment.NewLine +
                            "            Catch unauthorizedErr As System.UnauthorizedAccessException" + Environment.NewLine +
                            Environment.NewLine +
                            "                MessageBox.Show(\"Connection error (user name or password might be incorrect): \" & unauthorizedErr.Message)" + Environment.NewLine +
                            Environment.NewLine +
                            "            End Try" + Environment.NewLine +
                            "        End Sub" + Environment.NewLine +
                            Environment.NewLine +
                            "        Private Sub closeButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles closeButton.Click" + Environment.NewLine +
                            Environment.NewLine +
                            "            Close()" + Environment.NewLine +
                            "        End Sub" + Environment.NewLine +
                            "    End Class" + Environment.NewLine +
                            "End Namespace" + Environment.NewLine;                 
                    }
                    else 
                    {
                        code = code +
                            "                Return 0" + Environment.NewLine +
                            Environment.NewLine +
                            "            Catch err As ManagementException" + Environment.NewLine +
                            Environment.NewLine +
                            "                MessageBox.Show(\"An error occurred while trying to receive an event: \" & err.Message)" + Environment.NewLine +
                            "            End Try" + Environment.NewLine +
                            "        End Function" + Environment.NewLine +
                            Environment.NewLine + "    End Class" +
                            Environment.NewLine + "End Namespace";
                    }
                }
                else   // Asyncronous event.
                {

                    code = code +
                        "                AddHandler watcher.EventArrived, _" + Environment.NewLine +
                        "                    AddressOf HandleEvent" + Environment.NewLine + Environment.NewLine +
                        "                ' Start listening for events" + Environment.NewLine +
                        "                watcher.Start()"  + Environment.NewLine + Environment.NewLine +
                        "                ' Do something while waiting for events" + Environment.NewLine +
                        "                System.Threading.Thread.Sleep(10000)" + Environment.NewLine + Environment.NewLine +
                        "                ' Stop listening for events" + Environment.NewLine +
                        "                watcher.Stop()" + Environment.NewLine +
                        "                Return" + Environment.NewLine +
                        Environment.NewLine +
                        "            Catch err As ManagementException" + Environment.NewLine +
                        Environment.NewLine +
                        "                MessageBox.Show(\"An error occurred while trying to receive an event: \" & err.Message)" + Environment.NewLine +
                        Environment.NewLine;
                        
					
                    if(this.RemoteComputerMenu.Checked)
                    {
                        code = code +
                            "            Catch unauthorizedErr As System.UnauthorizedAccessException" + Environment.NewLine +
                            Environment.NewLine +
                            "                MessageBox.Show(\"Connection error (user name or password might be incorrect): \" & unauthorizedErr.Message)" + Environment.NewLine +
                            Environment.NewLine +
                            "            End Try" + Environment.NewLine +
                            "        End Sub" + Environment.NewLine +
                            Environment.NewLine +
                            Environment.NewLine +
                            "        Private Sub closeButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles closeButton.Click" + Environment.NewLine +
                            Environment.NewLine +
                            "            Close()" + Environment.NewLine +
                            "        End Sub" + Environment.NewLine + Environment.NewLine +
                            "        Private Sub HandleEvent(sender As Object, e As EventArrivedEventArgs)" + Environment.NewLine +
                            Environment.NewLine +
                            "            Console.WriteLine(\"" + this.ClassList_event.Text + " event occurred.\")" + Environment.NewLine +
                            "        End Sub" + Environment.NewLine +
                            "    End Class" + Environment.NewLine +
                            "End Namespace" + Environment.NewLine;
                    }
                    else
                    {
                        code = code +
                            "            End Try" + Environment.NewLine +
                            "        End Sub" + Environment.NewLine +
                            Environment.NewLine +
                            "        Private Sub HandleEvent(sender As Object, e As EventArrivedEventArgs)" + Environment.NewLine +
                            Environment.NewLine +
                            "            Console.WriteLine(\"" + this.ClassList_event.Text + " event occurred.\")" + Environment.NewLine +
                            "        End Sub" + Environment.NewLine + Environment.NewLine +
                            "        Public Overloads Shared Function Main() As Integer" + Environment.NewLine +
                            Environment.NewLine +
                            "            Dim receiveEvent As New WMIReceiveEvent" + Environment.NewLine +
                            "            Return 0" + Environment.NewLine +
                            "        End Function" + Environment.NewLine +
                            Environment.NewLine + "    End Class" +
                            Environment.NewLine + "End Namespace";
                    }

                }
                this.CodeText_event.Text = code;

            }
        }

        //-------------------------------------------------------------------------
        // Generates the C# code in the event tab's generated code area.
        // 
        //-------------------------------------------------------------------------
        private void GenerateCSharpEventCode()
        {
            if(!this.ClassList_event.Text.Equals("")) 
            {
                string code = "";

                if(this.RemoteComputerMenu.Checked)
                {
                    code = "using System;" + Environment.NewLine +
                        "using System.Drawing;" + Environment.NewLine +
                        "using System.Collections;" + Environment.NewLine +
                        "using System.ComponentModel;" + Environment.NewLine +
                        "using System.Windows.Forms;" + Environment.NewLine +
                        "using System.Data;" + Environment.NewLine +
                        "using System.Management;" + Environment.NewLine +
                        Environment.NewLine +
                        "namespace WMISample" + Environment.NewLine +
                        "{" + Environment.NewLine +
                        "    public class WMIReceiveEvent : System.Windows.Forms.Form" + Environment.NewLine +
                        "    {" + Environment.NewLine +
                        "        private System.Windows.Forms.Label userNameLabel;" + Environment.NewLine +
                        "        private System.Windows.Forms.TextBox userNameBox;" + Environment.NewLine +
                        "        private System.Windows.Forms.TextBox passwordBox;" + Environment.NewLine +
                        "        private System.Windows.Forms.Label passwordLabel;" + Environment.NewLine +
                        "        private System.Windows.Forms.Button OKButton;" + Environment.NewLine +
                        "        private System.Windows.Forms.Button cancelButton;" + Environment.NewLine +
                        "        " + Environment.NewLine +
                        "        private System.ComponentModel.Container components = null;" + Environment.NewLine +
                        Environment.NewLine +
                        "        public WMIReceiveEvent()" + Environment.NewLine +
                        "        {" + Environment.NewLine +
                        "            InitializeComponent();" + Environment.NewLine +
                        "        }" + Environment.NewLine +
                        Environment.NewLine +
                        "        protected override void Dispose( bool disposing )" + Environment.NewLine +
                        "        {" + Environment.NewLine +
                        "            if( disposing )" + Environment.NewLine +
                        "            {" + Environment.NewLine +
                        "                if (components != null)" + Environment.NewLine + 
                        "                {" + Environment.NewLine +
                        "                    components.Dispose();" + Environment.NewLine +
                        "                }" + Environment.NewLine +
                        "            }" + Environment.NewLine +
                        "            base.Dispose( disposing );" + Environment.NewLine +
                        "        }" + Environment.NewLine +
                        Environment.NewLine +
                        "        private void InitializeComponent()" + Environment.NewLine +
                        "        {" + Environment.NewLine +
                        "            this.userNameLabel = new System.Windows.Forms.Label();" + Environment.NewLine +
                        "            this.userNameBox = new System.Windows.Forms.TextBox();" + Environment.NewLine +
                        "            this.passwordBox = new System.Windows.Forms.TextBox();" + Environment.NewLine +
                        "            this.passwordLabel = new System.Windows.Forms.Label();" + Environment.NewLine +
                        "            this.OKButton = new System.Windows.Forms.Button();" + Environment.NewLine +
                        "            this.cancelButton = new System.Windows.Forms.Button();" + Environment.NewLine +
                        "            this.SuspendLayout();" + Environment.NewLine +
                        "            // " + Environment.NewLine +
                        "            // userNameLabel" + Environment.NewLine +
                        "            // " + Environment.NewLine +
                        "            this.userNameLabel.Location = new System.Drawing.Point(16, 8);" + Environment.NewLine +
                        "            this.userNameLabel.Name = \"userNameLabel\";" + Environment.NewLine +
                        "            this.userNameLabel.Size = new System.Drawing.Size(160, 32);" + Environment.NewLine +
                        "            this.userNameLabel.TabIndex = 0;" + Environment.NewLine +
                        "            this.userNameLabel.Text = \"Enter the user name for the remote computer:\";" + Environment.NewLine +
                        "            // " + Environment.NewLine +
                        "            // userNameBox" + Environment.NewLine +
                        "            // " + Environment.NewLine +
                        "            this.userNameBox.Location = new System.Drawing.Point(160, 16);" + Environment.NewLine +
                        "            this.userNameBox.Name = \"userNameBox\";" + Environment.NewLine +
                        "            this.userNameBox.Size = new System.Drawing.Size(192, 20);" + Environment.NewLine +
                        "            this.userNameBox.TabIndex = 1;" + Environment.NewLine +
                        "            this.userNameBox.Text = \"\";" + Environment.NewLine +
                        "            // " + Environment.NewLine +
                        "            // passwordBox" + Environment.NewLine +
                        "            // " + Environment.NewLine +
                        "            this.passwordBox.Location = new System.Drawing.Point(160, 48);" + Environment.NewLine +
                        "            this.passwordBox.Name = \"passwordBox\";" + Environment.NewLine +
                        "            this.passwordBox.PasswordChar = '*';" + Environment.NewLine +
                        "            this.passwordBox.Size = new System.Drawing.Size(192, 20);" + Environment.NewLine +
                        "            this.passwordBox.TabIndex = 3;" + Environment.NewLine +
                        "            this.passwordBox.Text = \"\";" + Environment.NewLine +
                        "            // " + Environment.NewLine +
                        "            // passwordLabel" + Environment.NewLine +
                        "            // " + Environment.NewLine +
                        "            this.passwordLabel.Location = new System.Drawing.Point(16, 48);" + Environment.NewLine +
                        "            this.passwordLabel.Name = \"passwordLabel\";" + Environment.NewLine +
                        "            this.passwordLabel.Size = new System.Drawing.Size(160, 32);" + Environment.NewLine +
                        "            this.passwordLabel.TabIndex = 2;" + Environment.NewLine +
                        "            this.passwordLabel.Text = \"Enter the password for the remote computer:\";" + Environment.NewLine +
                        "            // " + Environment.NewLine +
                        "            // OKButton" + Environment.NewLine +
                        "            // " + Environment.NewLine +
                        "            this.OKButton.Location = new System.Drawing.Point(40, 88);" + Environment.NewLine +
                        "            this.OKButton.Name = \"OKButton\";" + Environment.NewLine +
                        "            this.OKButton.Size = new System.Drawing.Size(128, 23);" + Environment.NewLine +
                        "            this.OKButton.TabIndex = 4;" + Environment.NewLine +
                        "            this.OKButton.Text = \"OK\";" + Environment.NewLine +
                        "            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);" + Environment.NewLine +
                        "            // " + Environment.NewLine +
                        "            // cancelButton" + Environment.NewLine +
                        "            // " + Environment.NewLine +
                        "            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;" + Environment.NewLine +
                        "            this.cancelButton.Location = new System.Drawing.Point(200, 88);" + Environment.NewLine +
                        "            this.cancelButton.Name = \"cancelButton\";" + Environment.NewLine +
                        "            this.cancelButton.Size = new System.Drawing.Size(128, 23);" + Environment.NewLine +
                        "            this.cancelButton.TabIndex = 5;" + Environment.NewLine +
                        "            this.cancelButton.Text = \"Cancel\";" + Environment.NewLine +
                        "            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);" + Environment.NewLine +
                        "            // " + Environment.NewLine +
                        "            // MyQuerySample" + Environment.NewLine +
                        "            // " + Environment.NewLine +
                        "            this.AcceptButton = this.OKButton;" + Environment.NewLine +
                        "            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);" + Environment.NewLine +
                        "            this.CancelButton = this.cancelButton;" + Environment.NewLine +
                        "            this.ClientSize = new System.Drawing.Size(368, 130);" + Environment.NewLine +
                        "            this.ControlBox = false;" + Environment.NewLine +
                        "            this.Controls.Add(this.cancelButton);" + Environment.NewLine +
                        "            this.Controls.Add(this.OKButton);" + Environment.NewLine +
                        "            this.Controls.Add(this.passwordBox);" + Environment.NewLine +
                        "            this.Controls.Add(this.passwordLabel);" + Environment.NewLine +
                        "            this.Controls.Add(this.userNameBox);" + Environment.NewLine +
                        "            this.Controls.Add(this.userNameLabel);" + Environment.NewLine +
                        "            this.Name = \"MyQuerySample\";" + Environment.NewLine +
                        "            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;" + Environment.NewLine +
                        "            this.Text = \"Remote Connection\";" + Environment.NewLine +
                        "            this.ResumeLayout(false);" + Environment.NewLine +
                        Environment.NewLine +
                        "        }" + Environment.NewLine +
                        Environment.NewLine +
                        "        [STAThread]" + Environment.NewLine +
                        "        static void Main() " + Environment.NewLine +
                        "        {" + Environment.NewLine +
                        "            Application.Run(new WMIReceiveEvent());" + Environment.NewLine +
                        "        }" + Environment.NewLine +
                        Environment.NewLine +
                        "        private void OKButton_Click(object sender, System.EventArgs e)" + Environment.NewLine +
                        "        {" + Environment.NewLine +
                        "            try" + Environment.NewLine +
                        "            {" + Environment.NewLine +
                        "                ConnectionOptions connection = new ConnectionOptions();" + Environment.NewLine +
                        "                connection.Username = userNameBox.Text;" + Environment.NewLine +
                        "                connection.Password = passwordBox.Text;" + Environment.NewLine +
                        "                connection.Authority = \"ntlmdomain:" + this.TargetWindow.GetRemoteComputerDomain() + "\";" + Environment.NewLine +
                        Environment.NewLine +
                        "                ManagementScope scope = new ManagementScope(" + Environment.NewLine +
                        "                    \"\\\\\\\\" + this.TargetWindow.GetRemoteComputerName() + "\\\\" + this.NamespaceList_event.Text.Replace("\\", "\\\\") + "\", connection);" + Environment.NewLine +
                        "                scope.Connect();" + Environment.NewLine +Environment.NewLine;
                }
                else if(this.GroupRemoteComputerMenu.Checked)
                {
                    code = code +
                        "using System;" + Environment.NewLine +
                        "using System.Management;" + Environment.NewLine +
                        "using System.Windows.Forms;" + Environment.NewLine +
                        Environment.NewLine +
                        "namespace WMISample" + Environment.NewLine +
                        "{" + Environment.NewLine +
                        "    public class WMIReceiveEvent" + Environment.NewLine +
                        "    {" + Environment.NewLine;
                    if(this.Asynchronous.Checked)
                    {
                        code = code +
                            "        public WMIReceiveEvent()" + Environment.NewLine +
                            "        {" + Environment.NewLine +
                            "            try" + Environment.NewLine +
                            "            {" + Environment.NewLine +
                            "                string ";

                        string delimStr = " ,\n";
                        char [] delimiter = delimStr.ToCharArray();
                        string [] split = this.TargetWindow.GetArrayOfComputers().Split(delimiter);


                        code = code + "strComputer = \"";
                    
                        code = code + split[0].Trim() + "\";" + Environment.NewLine + Environment.NewLine;
                    }
                    else
                    {
                        code = code +
                            "        public static void Main()" + Environment.NewLine +
                            "        {" + Environment.NewLine +
                            "            try" + Environment.NewLine +
                            "            {" + Environment.NewLine +
                            "                string ";

                        string delimStr = " ,\n";
                        char [] delimiter = delimStr.ToCharArray();
                        string [] split = this.TargetWindow.GetArrayOfComputers().Split(delimiter);


                        code = code + "strComputer = \"";
                    
                        code = code + split[0].Trim() + "\";" + Environment.NewLine + Environment.NewLine;
                    }

                }
                else
                {
                    // The target computer is the local computer. 
                    code = code +
                        "using System;" + Environment.NewLine +
                        "using System.Management;" + Environment.NewLine +
                        "using System.Windows.Forms;" + Environment.NewLine +
                        Environment.NewLine +
                        "namespace WMISample" + Environment.NewLine +
                        "{" + Environment.NewLine +
                        "    public class WMIReceiveEvent" + Environment.NewLine +
                        "    {" + Environment.NewLine;
                    if(this.Asynchronous.Checked)
                    {
                        code = code + 
                            "        public WMIReceiveEvent()" + Environment.NewLine +
                            "        {" + Environment.NewLine +
                            "            try" + Environment.NewLine +
                            "            {" + Environment.NewLine ;
                    }
                    else
                    {
                        code = code + 
                            "        public static void Main()" + Environment.NewLine +
                            "        {" + Environment.NewLine +
                            "            try" + Environment.NewLine +
                            "            {" + Environment.NewLine;
                    }
                }

                string eventQuery = "";

                if(this.GroupRemoteComputerMenu.Checked)
                {
                    code = code + 
                        "                string scope = \"\\\\\\\\\" + strComputer + \"\\\\" + this.NamespaceList_event.Text.Replace("\\", "\\\\") + "\";" + Environment.NewLine + Environment.NewLine +
                        "                string query = " + Environment.NewLine +
                        "                    \"SELECT * FROM " + this.ClassList_event.Text ;
                }
                else
                {
                    code = code + 
                        "                WqlEventQuery query = new WqlEventQuery(" + Environment.NewLine +
                        "                    \"SELECT * FROM " + this.ClassList_event.Text ;
                }
                eventQuery = "select * from " + this.ClassList_event.Text;
				
                if(this.PropertyList_event.SelectedItems.Count.Equals(1))
                {
                    code = code + " WHERE " + PropertyList_event.SelectedItem.ToString().Replace("\\", "\\\\");
                    eventQuery = eventQuery + " where " + PropertyList_event.SelectedItem.ToString();
                }
                else if(this.PropertyList_event.SelectedItems.Count > 0)
                {
						
                    code = code + " WHERE \" +" + Environment.NewLine + "                    ";
                    eventQuery = eventQuery + " where ";

                    int flag = -1;
                    string instance = "";
                    for(int i=0; i < PropertyList_event.SelectedItems.Count; i++)
                    {
                        // If PropertyList_event contains a selected item that contains ISA.
                        if(PropertyList_event.SelectedItems[i].ToString().IndexOf("ISA", 1, PropertyList_event.SelectedItems[i].ToString().Length -1 ) > 0)
                        {
                            flag = i;
                            instance = PropertyList_event.SelectedItems[i].ToString().Replace("\\", "\\\\");
                        }
                    }
                    if(flag > -1)
                    {
                        code = code + "\"" + instance;
                        eventQuery = eventQuery + instance;
                    }
						
                    for(int i=0; i < PropertyList_event.SelectedItems.Count; i++)
                    {
                        if(flag.Equals(-1) && i.Equals(0)) //Do not start off with quotes.
                        {
                            code = code + "\"" + PropertyList_event.SelectedItems[i].ToString().Replace("\\", "\\\\");
                            eventQuery = eventQuery + "\"" + PropertyList_event.SelectedItems[i].ToString();
                        }
                        else if(!i.Equals(flag))
                        {
                            code = code + "\" +" + Environment.NewLine +
                                "                    \" AND " + PropertyList_event.SelectedItems[i].ToString().Replace("\\", "\\\\");
                            eventQuery = eventQuery + " and " + PropertyList_event.SelectedItems[i].ToString();
                        }
                    }		
                }

                if(this.GroupRemoteComputerMenu.Checked)
                    code = code + "\";";
                else
                    code = code + "\");";
				
                // Check to see if the event class is supported by an event provider.
                if(this.QueryCounter == 0)
                {
                    EventQuerySupportedByProvider();
                    this.PollLabel.Visible = false;
                    this.SecondsBox.Visible = false;
                    this.PollLabelEnd.Visible = false;
                }
                    
                if(this.QueryCounter > 0)
                {
                    bool addWITHINStatement = true;

                    // If the user selected event query is in the list of event provider supported
                    // event queries, then the WITHIN statement does not need to be used in
                    // the user selected event query.
                    for(int i=0; i < this.QueryCounter; i++)
                    {
                        if(eventQuery.IndexOf(this.SupportedEventQueries[i].
                            Replace("\"", "'").
                            Replace("isa", "ISA")) != -1)
                        {
                            addWITHINStatement = false; // Do not add the WITHIN statement.
                            break; // Get out of the for loop.
                        }
                    }

                    if(addWITHINStatement && !this.ExtrinsicEvent(this.ClassList_event.Text))
                    {
                        code = code.Replace(("SELECT * FROM " + this.ClassList_event.Text), 
                            ("SELECT * FROM " + this.ClassList_event.Text + " WITHIN " + this.SecondsBox.Text));
                        this.PollLabel.Visible = true;
                        this.SecondsBox.Visible = true;
                        this.PollLabelEnd.Visible = true;
                    }
                    else
                    {
                        this.PollLabel.Visible = false;
                        this.SecondsBox.Visible = false;
                        this.PollLabelEnd.Visible = false;
                    }
                }

                if(this.GroupRemoteComputerMenu.Checked)
                {
                    code = code + Environment.NewLine + Environment.NewLine +
                        "                ManagementEventWatcher watcher = new ManagementEventWatcher(scope, query);" + Environment.NewLine +
                        "                Console.WriteLine(\"Waiting for an event on \" + strComputer + \" ...\");" + Environment.NewLine + Environment.NewLine;
                }
                else if(this.RemoteComputerMenu.Checked)
                {
                    code = code + Environment.NewLine + Environment.NewLine +
                        "                ManagementEventWatcher watcher = new ManagementEventWatcher(scope, query);" + Environment.NewLine +
                        "                Console.WriteLine(\"Waiting for an event on " + this.TargetWindow.GetRemoteComputerName() + " ...\");" + Environment.NewLine + Environment.NewLine;
                }
                else
                {
                    code = code + Environment.NewLine + Environment.NewLine +
                        "                ManagementEventWatcher watcher = new ManagementEventWatcher(query);" + Environment.NewLine +
                        "                Console.WriteLine(\"Waiting for an event...\");" + Environment.NewLine + Environment.NewLine;
                }

                // Semisynchronous or synchronous event.
                if(!this.Asynchronous.Checked)
                {
                    
                    code = code +
                        "                ManagementBaseObject eventObj = watcher.WaitForNextEvent();" + Environment.NewLine + Environment.NewLine +
                        "                Console.WriteLine(\"{0} event occurred.\", eventObj[\"__CLASS\"]);" + Environment.NewLine + Environment.NewLine +
                        "                // Cancel the event subscription" + Environment.NewLine +
                        "                watcher.Stop();" + Environment.NewLine;
					
                    if(this.RemoteComputerMenu.Checked)
                    {
                        code = code + Environment.NewLine + 
                            "                Close();" + Environment.NewLine +
                            "                return;" + Environment.NewLine +
                            "            }" + Environment.NewLine +
                            "            catch(ManagementException err)" + Environment.NewLine +
                            "            {" + Environment.NewLine +
                            "                MessageBox.Show(\"An error occurred while trying to receive an event: \" + err.Message);" + Environment.NewLine +
                            "            }" + Environment.NewLine +
                            "            catch(System.UnauthorizedAccessException unauthorizedErr)" + Environment.NewLine +
                            "            {" + Environment.NewLine +
                            "                MessageBox.Show(\"Connection error (user name or password might be incorrect): \" + unauthorizedErr.Message);" + Environment.NewLine +
                            "            }" + Environment.NewLine +
                            "        }" + Environment.NewLine +
                            Environment.NewLine +
                            "        private void cancelButton_Click(object sender, System.EventArgs e)" + Environment.NewLine +
                            "        {" + Environment.NewLine +
                            "            Close();" + Environment.NewLine +
                            "        }" + Environment.NewLine +
                            "    }" + Environment.NewLine +
                            "}" + Environment.NewLine;
                    }
                    else 
                    {
                        code = code +
                            "                return;" + Environment.NewLine +
                            "            }" + Environment.NewLine +
                            "            catch(ManagementException err)" + Environment.NewLine +
                            "            {" + Environment.NewLine +
                            "                MessageBox.Show(\"An error occurred while trying to receive an event: \" + err.Message);" + Environment.NewLine +
                            "            }" + Environment.NewLine +
                            "        }" +
                            Environment.NewLine + "    }" +
                            Environment.NewLine + "}";
                    }
                }
                else   // Asyncronous event.
                {

                    code = code +
                        "                watcher.EventArrived += " + Environment.NewLine +
                        "                    new EventArrivedEventHandler(" + Environment.NewLine +
                        "                    HandleEvent);" + Environment.NewLine + Environment.NewLine +
                        "                // Start listening for events" + Environment.NewLine +
                        "                watcher.Start();"  + Environment.NewLine + Environment.NewLine +
                        "                // Do something while waiting for events" + Environment.NewLine +
                        "                System.Threading.Thread.Sleep(10000);" + Environment.NewLine + Environment.NewLine +
                        "                // Stop listening for events" + Environment.NewLine +
                        "                watcher.Stop();" + Environment.NewLine +
                        "                return;" + Environment.NewLine +
                        "            }" + Environment.NewLine +
                        "            catch(ManagementException err)" + Environment.NewLine +
                        "            {" + Environment.NewLine +
                        "                MessageBox.Show(\"An error occurred while trying to receive an event: \" + err.Message);" + Environment.NewLine +
                        "            }" + Environment.NewLine;
                        
					
                    if(this.RemoteComputerMenu.Checked)
                    {
                        code = code +
                            "            catch(System.UnauthorizedAccessException unauthorizedErr)" + Environment.NewLine +
                            "            {" + Environment.NewLine +
                            "                MessageBox.Show(\"Connection error (user name or password might be incorrect): \" + unauthorizedErr.Message);" + Environment.NewLine +
                            "            }" + Environment.NewLine +
                            "        }" +
                            Environment.NewLine +
                            Environment.NewLine +
                            "        private void cancelButton_Click(object sender, System.EventArgs e)" + Environment.NewLine +
                            "        {" + Environment.NewLine +
                            "            Close();" + Environment.NewLine +
                            "        }" + Environment.NewLine + Environment.NewLine +
                            "        private void HandleEvent(object sender," + Environment.NewLine +
                            "            EventArrivedEventArgs e)" + Environment.NewLine +
                            "        {" + Environment.NewLine +
                            "            Console.WriteLine(\"" + this.ClassList_event.Text + " event occurred.\");" + Environment.NewLine +
                            "        }" + Environment.NewLine +
                            "    }" + Environment.NewLine +
                            "}" + Environment.NewLine;
                    }
                    else
                    {
                        code = code +
                            "        }" + Environment.NewLine +
                            "        " + Environment.NewLine +
                            "        private void HandleEvent(object sender," + Environment.NewLine +
                            "            EventArrivedEventArgs e)" + Environment.NewLine +
                            "        {" + Environment.NewLine +
                            "            Console.WriteLine(\"" + this.ClassList_event.Text + " event occurred.\");" + Environment.NewLine +
                            "        }" + Environment.NewLine + Environment.NewLine +
                            "        public static void Main()" + Environment.NewLine +
                            "        {" + Environment.NewLine +
                            "            WMIReceiveEvent receiveEvent = new WMIReceiveEvent();" + Environment.NewLine +
                            "            return;" + Environment.NewLine +
                            "        }" + Environment.NewLine +
                            Environment.NewLine + "    }" +
                            Environment.NewLine + "}";
                    }

                }
                this.CodeText_event.Text = code;

            }
        }
		
        //-------------------------------------------------------------------------
        // Handles the form's load event.
        // 
        //-------------------------------------------------------------------------
        private void WMICodeBuddy_Load(object sender, System.EventArgs e)
        {
        
        }

        //-------------------------------------------------------------------------
        // Handles the event when the ValueButton is clicked. Adds values to the
        // query tab's list of property values.
        //-------------------------------------------------------------------------
        private void ValueButton_Click(object sender, System.EventArgs e)
        {
            this.ValueList.Items.Clear();
            System.Threading.ThreadPool.
                QueueUserWorkItem(
                new System.Threading.WaitCallback(
                this.AddValuesToList));
        }

        //-------------------------------------------------------------------------
        // Generates code whenever a value is selected in the query tab's
        // property value list.
        //-------------------------------------------------------------------------
        private void ValueList_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            GenerateQueryCode();
        }

        //-------------------------------------------------------------------------
        // Adds in-parameters (from the selected method in the method list) to the
        // in-parameter list in the method tab.
        //-------------------------------------------------------------------------
        private void AddInParams()
        {
            try
            {
                ManagementClass c = new ManagementClass(this.NamespaceValue_m.Text, this.ClassList_m.Text, null);

                foreach (MethodData mData in c.Methods)
                {
                    if(mData.Name.Equals(this.MethodList.SelectedItem.ToString()))
                    {
                        if(mData.InParameters.Properties.Count.Equals(0))
                        {
                            // No in-parameters to define.
                        }
                        else
                        {
                            foreach (PropertyData p in mData.InParameters.Properties)
                            {
                                this.InParameterBox.Items.Add(
                                    p.Name + " = " +
                                    " a value of type: " + p.Type.ToString());
                            }
                        }
                    }

                }
            }
            catch (System.NullReferenceException e)
            {
                // No in-parameters to define.
            }
        }

        //-------------------------------------------------------------------------
        // Handles the event when the "list all properties in the class" 
        // button is clicked on the browse tab.
        //-------------------------------------------------------------------------
        private void BrowsePropertyButton_Click(object sender, System.EventArgs e)
        {
            this.PropertyInformation.Text = "";
            this.BrowsePropertyList.Items.Clear();
            this.BrowsePropertyStatus.Text = "";

            // Populate the class list.
            System.Threading.ThreadPool.
                QueueUserWorkItem(
                new System.Threading.WaitCallback(
                this.AddPropertiesToBrowserList));
        }

        //-------------------------------------------------------------------------
        // Handles the event when the "list all methods in the class" 
        // button is clicked on the browse tab.
        //-------------------------------------------------------------------------
        private void BrowseMethodButton_Click(object sender, System.EventArgs e)
        {
            this.BrowseMethodList.Items.Clear();
            this.BrowseMethodStatus.Text = "";
            this.MethodInformation.Text = "";

            // Populate the class list.
            System.Threading.ThreadPool.
                QueueUserWorkItem(
                new System.Threading.WaitCallback(
                this.AddMethodsToBrowserList));
        }

        //-------------------------------------------------------------------------
        // Handles the event when the namespace is changed on the method tab.
        //
        //-------------------------------------------------------------------------
        private void NamespaceValue_m_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.ClassList_m.Items.Clear();
            this.ClassList_m.Text = "";
            this.MethodList.Items.Clear();
            this.MethodList.Text = "";
            this.InParameterBox.Items.Clear();
            this.KeyValueBox.Items.Clear();
            this.KeyValueBox.Visible = false;
            this.KeyValueLabel.Visible = false;
            this.MethodLinkLabel.Visible = false;
            this.MethodStatus.Text = "";
            this.CodeText_m.Text = "";

            // Populate the class list.
            System.Threading.ThreadPool.
                QueueUserWorkItem(
                new System.Threading.WaitCallback(
                this.AddClassesToMethodPageList));
        }

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

        private void MainTabControl_SelectedIndexChanged(object sender, System.EventArgs e)
        {
        
        }

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

        //-------------------------------------------------------------------------
        // Handles the event when the class is changed on the method tab.
        //
        //-------------------------------------------------------------------------
        private void ClassList_m_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.MethodList.Items.Clear();
            this.MethodList.Text = "";
            this.CodeText_m.Text = "";
            this.InParameterBox.Items.Clear();
            this.KeyValueBox.Items.Clear();
            this.KeyValueBox.Visible = false;
            this.KeyValueLabel.Visible = false;
            this.MethodStatus.Text = "";

            // Display the link to the class documentation.
            // Note: This link changes if MSDN changes the URL for the WMI SDK documentation.
            if(this.MethodLinkLabel.Links.Count > 0)
            {
                this.MethodLinkLabel.Links[0].LinkData = "www.msdn.microsoft.com/library/default.asp?url=/library/en-us/wmisdk/wmi/" + this.ClassList_m.Text + ".asp";
            }
            else
            {
                this.MethodLinkLabel.Links.Add(0, this.MethodLinkLabel.Text.Length, "www.msdn.microsoft.com/library/default.asp?url=/library/en-us/wmisdk/wmi/" + this.ClassList_m.Text + ".asp");
            }

            // All the Win32 classes are documented, and have links to the documentation.
            if(this.ClassList_m.Text.StartsWith("Win32"))
            {   
                this.MethodLinkLabel.Visible = true;
            }
            else
            {
                this.MethodLinkLabel.Visible = false;
            }

            System.Threading.ThreadPool.
                QueueUserWorkItem(
                new System.Threading.WaitCallback(
                this.AddMethodsToList));
        }

        //-------------------------------------------------------------------------
        // Handles the event when the method is changed on the method tab.
        //
        //-------------------------------------------------------------------------
        private void MethodList_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                this.CodeText_m.Text = "";
                this.InParameterBox.Items.Clear();
                this.KeyValueBox.Items.Clear();

                AddInParams();

                if(InParameterBox.Items.Count > 0) 
                {
                    // Create a new InParameterArray for all the items in the list. 
                    if(InParameterBox.Items.Count < MAXINPARAMS)
                    {
                        System.Array.Clear(this.InParameterArray, 0, InParameterArray.Length);
                        this.InParameterArray = new InParameterWindow[InParameterBox.Items.Count];

                        for(int i = 0; i < InParameterBox.Items.Count; i++)
                        {
                            InParameterArray[i] = new InParameterWindow(this);
                            InParameterArray[i].SetParameterName((InParameterBox.Items[i].ToString().Split(" ".ToCharArray()))[0]);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Method has too many in-Parameters.  Choose a different method.");
                    }
                }

            
                if(this.IsStaticMethodSelected())
                {
                    GenerateMethodCode();
                }
                else
                {
                    this.KeyValueLabel.Visible = true;
                    this.KeyValueBox.Visible = true;
                    System.Threading.ThreadPool.
                        QueueUserWorkItem(
                        new System.Threading.WaitCallback(
                        this.AddKeyValues_m));
                }
            }
            catch (ManagementException mErr)
            {
                if(mErr.Message.Equals("Not found "))
                    MessageBox.Show("Error creating code: WMI class not found.");
                else
                    MessageBox.Show("Error creating code: " + mErr.Message.ToString());
            }
            
        }


        //-------------------------------------------------------------------------
        // Adds the key property values to a list on the method tab.
        //
        //-------------------------------------------------------------------------
        private void AddKeyValues_m(object o)
        {
			
            this.KeyValueLabel.Text = "Gathering data ...";

            string keyValues = "";

            try 
            {

                ObjectGetOptions options = new ObjectGetOptions();
                ManagementClass wmiObject = new ManagementClass(this.NamespaceValue_m.Text,
                    this.ClassList_m.Text, options);
                wmiObject.Options.UseAmendedQualifiers = true;

                foreach ( ManagementObject c in wmiObject.GetInstances())
                {
                
                    foreach (PropertyData p in c.Properties)
                    {
                        foreach (QualifierData q in p.Qualifiers)
                        {
                            // Gets the key property values.
                            if(q.Name.Equals("key"))
                            {
                                if(keyValues.Length == 0)
                                {
                                    keyValues = p.Name + "='" +
                                        c.GetPropertyValue(
                                        p.Name) + "'";
                                }
                                else
                                {
                                    keyValues = keyValues + "," + p.Name + "='" +
                                        c.GetPropertyValue(
                                        p.Name) + "'";
                                }
                            }
                        }

                    }

                    this.KeyValueBox.Items.Add(keyValues);
                    keyValues = "";
                }
            }
            catch (ManagementException ex) 
            {
                this.KeyValueLabel.Text = ex.Message;
            }
			
            if(this.KeyValueBox.Items.Count > 0)
            {
                this.KeyValueLabel.Text = "Select the instance you want to execute the query on. The values in the list are the values of the key property for this class.";
            }
            else
            {
                this.KeyValueLabel.Visible = false;
                this.KeyValueBox.Visible = false;
            }
			
        }


        //-------------------------------------------------------------------------
        // Handles the event when the namespace is changed on the event tab.
        //
        //-------------------------------------------------------------------------
        private void NamespaceList_event_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.ClassList_event.Items.Clear();
            this.ClassList_event.Text = "";
            this.PropertyList_event.Items.Clear();
            this.PropertyList_event.Text = "";
            this.TargetClassList_event.Items.Clear();
            this.TargetClassList_event.Text = "";
            this.CodeText_event.Text = "";
            this.EventLinkLabel.Visible = false;

            // Reset the QueryCounter so the list of supported event queries is namespace
            // specific
            this.QueryCounter = 0;

            // Populates the class list on the event page.
            System.Threading.ThreadPool.
                QueueUserWorkItem(
                new System.Threading.WaitCallback(
                this.AddClassesToEventPageList));
        }

        //-------------------------------------------------------------------------
        // Handles the event when the class is changed on the event tab.
        //
        //-------------------------------------------------------------------------
        private void ClassList_event_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.PropertyList_event.Items.Clear();
            this.PropertyList_event.Text = "";
            this.CodeText_event.Text = "";
            this.PropertyValueLabel.Text = "";
            this.PropertyValueLabel.Visible = false;
            this.TargetClassList_event.Items.Clear();
            this.TargetClassList_event.Text = "";
            this.TargetClassList_event.Visible = false;
            this.PropertyList_event.Items.Clear();


            if(this.ClassList_event.Text.StartsWith("__Class"))
            {
                this.PropertyValueLabel.Text = "TargetClass:";
                this.PropertyValueLabel.Visible = true;
                this.TargetClassList_event.Visible = true;
                
                // Populates the class list on the event page.
                System.Threading.ThreadPool.
                    QueueUserWorkItem(
                    new System.Threading.WaitCallback(
                    this.AddClassesToTargetClassList));
            }
            if(this.ClassList_event.Text.StartsWith("__MethodInvocationEvent"))
            {
                this.PropertyValueLabel.Text = "TargetInstance:";
                this.PropertyValueLabel.Visible = true;
                this.TargetClassList_event.Visible = true;
                
                // Populates the class list on the event page.
                System.Threading.ThreadPool.
                    QueueUserWorkItem(
                    new System.Threading.WaitCallback(
                    this.AddMethodClassesToTargetClassList));
            }
            else if(this.ClassList_event.Text.StartsWith("__Namespace"))
            {
                this.PropertyValueLabel.Text = "TargetNamespace:";
                this.PropertyValueLabel.Visible = true;
                this.TargetClassList_event.Visible = true;				

                // Populates the class list on the event page.
                System.Threading.ThreadPool.
                    QueueUserWorkItem(
                    new System.Threading.WaitCallback(
                    this.AddNamespacesToTargetList));
            }
            else if(this.ClassList_event.Text.StartsWith("__Instance"))
            {
                this.PropertyValueLabel.Text = "TargetInstance:";
                this.PropertyValueLabel.Visible = true;
                this.TargetClassList_event.Visible = true;

                // Populates the class list on the event page.
                System.Threading.ThreadPool.
                    QueueUserWorkItem(
                    new System.Threading.WaitCallback(
                    this.AddClassesToTargetClassList));
            }
            else
            {
	
                AddEventClassProperties();


                if(this.PropertyList_event.Items.Count > 0) 
                {
                    System.Array.Clear(this.EventConditionArray, 0, this.EventConditionArray.Length);
                    this.EventConditionArray = new EventQueryCondition[PropertyList_event.Items.Count];

                    for(int i = 0; i < PropertyList_event.Items.Count; i++)
                    {
                        EventConditionArray[i] = new EventQueryCondition(this);
                        EventConditionArray[i].SetParameterName((PropertyList_event.Items[i].ToString().Split(" ".ToCharArray()))[0]);

                        if(PropertyList_event.Items[i].ToString().StartsWith("TargetClass ISA") ||
                            PropertyList_event.Items[i].ToString().StartsWith("PreviousClass ISA") ||
                            PropertyList_event.Items[i].ToString().StartsWith("TargetInstance ISA") ||
                            PropertyList_event.Items[i].ToString().StartsWith("PreviousInstance ISA") ||
                            PropertyList_event.Items[i].ToString().StartsWith("TargetNamespace =") ||
                            PropertyList_event.Items[i].ToString().StartsWith("PreviousNamespace ="))
                        {
                            EventConditionArray[i].ChangeOperator((PropertyList_event.Items[i].ToString().Split(" ".ToCharArray()))[1]);
                            EventConditionArray[i].ChangeTextBoxValue((PropertyList_event.Items[i].ToString().Split(" ".ToCharArray()))[2]);
                        }	
						
                    }
					
                }
            }

            // Display the link to the class documentation.
            // Note: This link changes if MSDN changes the URL for the WMI SDK documentation.
            if(this.EventLinkLabel.Links.Count > 0)
            {
                this.EventLinkLabel.Links[0].LinkData = "www.msdn.microsoft.com/library/default.asp?url=/library/en-us/wmisdk/wmi/" + this.ClassList_event.Text + ".asp";
            }
            else
            {
                this.EventLinkLabel.Links.Add(0, this.EventLinkLabel.Text.Length, "www.msdn.microsoft.com/library/default.asp?url=/library/en-us/wmisdk/wmi/" + this.ClassList_event.Text + ".asp");
            }

            // All the event classes in the root\cimv2 namespace are documented.
            if(this.NamespaceList_event.Text.Equals("root\\CIMV2"))
            {   
                this.EventLinkLabel.Visible = true;
            }
            else
            {
                this.EventLinkLabel.Visible = false;
            }

            GenerateEventCode();
        }

        //-------------------------------------------------------------------------
        // Adds properties (from an event class on the event tab) to a list on
        // the event tab.
        //-------------------------------------------------------------------------
        private void AddEventClassProperties()
        {
            try
            {
                ManagementClass c = new ManagementClass(this.NamespaceList_event.Text, this.ClassList_event.Text, null);

                foreach (PropertyData p in c.Properties)
                {
                    this.PropertyList_event.Items.Add(p.Name);
                }
            }
            catch (ManagementException mErr)
            {
                if(mErr.Message.Equals("Not found "))
                    MessageBox.Show("WMI class not found.");
                else
                    MessageBox.Show(mErr.Message.ToString());
            }
        }

        //-------------------------------------------------------------------------
        // Adds properties (from a target class on the event tab) to a list on
        // the event tab.
        //-------------------------------------------------------------------------
        private void AddTargetClassProperties()
        {
            try
            {
                ManagementClass c = new ManagementClass(this.NamespaceList_event.Text, this.ClassList_event.Text, null);

                foreach (PropertyData p in c.Properties)
                {
                    this.PropertyList_event.Items.Add(p.Name);
                }

                if(this.ClassList_event.Text.StartsWith("__Instance"))
                {
                    ManagementClass c2 = new ManagementClass(this.NamespaceList_event.Text, this.TargetClassList_event.Text, null);

                    foreach (PropertyData p2 in c2.Properties)
                    {
                    
                        this.PropertyList_event.Items.Add("TargetInstance." + p2.Name);
                    
                        if(this.ClassList_event.Text.StartsWith("__InstanceModification"))
                        {
                            this.PropertyList_event.Items.Add("PreviousInstance." + p2.Name);
                        }
                    } 
                }

                if(this.PropertyList_event.Items.Contains("TargetInstance"))
                {
                    this.PropertyList_event.Items.Remove("TargetInstance");
                    this.PropertyList_event.Items.Add("TargetInstance ISA '" + 
                        this.TargetClassList_event.Text + "'");
                }
                if(this.PropertyList_event.Items.Contains("PreviousInstance"))
                {
                    this.PropertyList_event.Items.Remove("PreviousInstance");
                    this.PropertyList_event.Items.Add("PreviousInstance ISA '" + 
                        this.TargetClassList_event.Text + "'");
                }
                if(this.PropertyList_event.Items.Contains("TargetClass"))
                {
                    this.PropertyList_event.Items.Remove("TargetClass");
                    this.PropertyList_event.Items.Add("TargetClass ISA '" + 
                        this.TargetClassList_event.Text + "'");
                }
                if(this.PropertyList_event.Items.Contains("PreviousClass"))
                {
                    this.PropertyList_event.Items.Remove("PreviousClass");
                    this.PropertyList_event.Items.Add("PreviousClass ISA '" + 
                        this.TargetClassList_event.Text + "'");
                }
                if(this.PropertyList_event.Items.Contains("TargetNamespace"))
                {
                    this.PropertyList_event.Items.Remove("TargetNamespace");
                    this.PropertyList_event.Items.Add("TargetNamespace = '" + 
                        this.TargetClassList_event.Text + "'");
                }
                if(this.PropertyList_event.Items.Contains("PreviousNamespace"))
                {
                    this.PropertyList_event.Items.Remove("PreviousNamespace");
                    this.PropertyList_event.Items.Add("PreviousNamespace = '" + 
                        this.TargetClassList_event.Text + "'");
                }
            }
            catch (ManagementException mErr)
            {
                if(mErr.Message.Equals("Not found "))
                    MessageBox.Show("WMI class not found.");
                else
                    MessageBox.Show(mErr.Message.ToString());
            }
        }

        //-------------------------------------------------------------------------
        // Handles the event when the link to the WMI class documentation on MSDN
        // is clicked.
        //-------------------------------------------------------------------------
        private void MethodLinkLabel_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            string target = e.Link.LinkData as string;

            // If the value looks like a URL, navigate to it.
            // Otherwise, display it in a message box.
            if(null != target && target.StartsWith("www"))
            {
                System.Diagnostics.Process.Start(target);
            }
            else
            {    
                MessageBox.Show("Item clicked: " + target);
            }
        }

        //-------------------------------------------------------------------------
        // Handles the event when the link to the WMI class documentation on MSDN
        // is clicked.
        //-------------------------------------------------------------------------
        private void QueryLinkLabel_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            string target = e.Link.LinkData as string;

            // If the value looks like a URL, navigate to it.
            // Otherwise, display it in a message box.
            if(null != target && target.StartsWith("www"))
            {
                System.Diagnostics.Process.Start(target);
            }
            else
            {    
                MessageBox.Show("Item clicked: " + target);
				
            }
        }

        //-------------------------------------------------------------------------
        // Handles the event when a method in-parameter is selected.
        // 
        //-------------------------------------------------------------------------
        private void InParameterBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            
            for(int i = 0; i < InParameterBox.Items.Count; i++)
            {
                try
                {
                    if(InParameterBox.SelectedIndices.Contains(i) && !InParameterArray[i].GetOkClicked())
                    {
                    
                        InParameterArray[i].Visible = true;
                        InParameterArray[i].ChangeText(
                            "Assign a value to the " + InParameterArray[i].GetParameterName()
                            + " parameter. The parameter is of type: " +
                            InParameterArray[i].GetParameterType() + ".");
				
                    }
                }
                catch (System.NullReferenceException nullError)
                {
                    // Catches the case if the window was closed.
                    InParameterArray[i] = new InParameterWindow(this);
                    InParameterArray[i].SetParameterName((InParameterBox.Items[i].ToString().Split(" ".ToCharArray()))[0]);
                    InParameterArray[i].Visible = true;
                    InParameterArray[i].ChangeText(
                        "Assign a value to the " + InParameterArray[i].GetParameterName()
                        + " parameter. The parameter is of type: " +
                        InParameterArray[i].GetParameterType() + ".");
                }
                
                
                if(!InParameterBox.SelectedIndices.Contains(i))
                {
                    try
                    {
                        InParameterArray[i].Visible = false;
                        InParameterArray[i].SetOkClicked(false);
                    }
                    catch (System.NullReferenceException nullError)
                    {
                        // Catches the case if the window was closed.
                        InParameterArray[i] = new InParameterWindow(this);
                        InParameterArray[i].SetParameterName((InParameterBox.Items[i].ToString().Split(" ".ToCharArray()))[0]);
                        InParameterArray[i].Visible = false;
                        InParameterArray[i].SetOkClicked(false);
                    }
                }
            }

            this.GenerateMethodCode();
        }

        //-------------------------------------------------------------------------
        // Handles the event when the link to the WMI class documentation on MSDN
        // is clicked.
        //-------------------------------------------------------------------------
        private void EventLinkLabel_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            string target = e.Link.LinkData as string;

            // If the value looks like a URL, navigate to it.
            // Otherwise, display it in a message box.
            if(null != target && target.StartsWith("www"))
            {
                System.Diagnostics.Process.Start(target);
            }
            else
            {    
                MessageBox.Show("Item clicked: " + target);
				
            }
        }

        //-------------------------------------------------------------------------
        // Handles the event when the user changes the event polling interval.
        //
        //-------------------------------------------------------------------------
        private void SecondsBox_TextChanged(object sender, System.EventArgs e)
        {
            GenerateEventCode();
        }

        //-------------------------------------------------------------------------
        // Handles the event when the namespace is changed on the browse tab.
        //
        //-------------------------------------------------------------------------
        private void BrowseNamespaceList_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.BrowseClassList.Items.Clear();
            this.BrowseClassList.Text = "";
            this.BrowseClassResults.Text = "";
            this.BrowseMethodList.Items.Clear();
            this.BrowseMethodStatus.Text = "";
            this.BrowsePropertyList.Items.Clear();
            this.BrowsePropertyStatus.Text = "";
            this.BrowseQualiferStatus.Text = "";
            this.BrowseQualifierList.Items.Clear();
            this.PropertyInformation.Text = "";
            this.BrowseClassDescription.Text = "";
            this.MethodInformation.Text = "";

            // Populates the class list.
            System.Threading.ThreadPool.
                QueueUserWorkItem(
                new System.Threading.WaitCallback(
                this.AddClassesToBrowserList));
        }

        //-------------------------------------------------------------------------
        // Handles the event when the class is changed on the browse tab.
        // 
        //-------------------------------------------------------------------------
        private void BrowseClassList_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.BrowseMethodList.Items.Clear();
            this.BrowseMethodStatus.Text = "";
            this.BrowsePropertyList.Items.Clear();
            this.BrowsePropertyStatus.Text = "";
            this.BrowseQualiferStatus.Text = "";
            this.BrowseQualifierList.Items.Clear();
            this.PropertyInformation.Text = "";
            this.BrowseClassDescription.Text = "";
            this.MethodInformation.Text = "";

            // Gets the class description.
            try
            {
                // Gets the property qualifiers.
                ObjectGetOptions op = new ObjectGetOptions(null, System.TimeSpan.MaxValue, true);

                ManagementClass mc = new ManagementClass(this.BrowseNamespaceList.Text,
                    this.BrowseClassList.Text, op);
                mc.Options.UseAmendedQualifiers = true;

                foreach (QualifierData dataObject in
                    mc.Qualifiers)
                {
                    if(dataObject.Name.Equals("Description"))
                    {
                        this.BrowseClassDescription.Text = 
                            dataObject.Value.ToString();
                    }
                }
            }
            catch (ManagementException mErr)
            {
                if(mErr.Message.Equals("Not found "))
                    MessageBox.Show("WMI class or not found.");
                else
                    MessageBox.Show(mErr.Message.ToString());
            }


        }

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

        //-------------------------------------------------------------------------
        // Handles the event when the OpenMethodText button is clicked. This opens
        // the code (in the CodeText_m text box) in Notepad.
        //-------------------------------------------------------------------------
        private void OpenMethodText_Click(object sender, System.EventArgs e)
        {
            // Creates the file path.
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\WMICodeCreator\\MyWMIMethod.vbs";

            if(this.VbNetMenuItem.Checked)
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\WMICodeCreator\\MyWMIMethod.vb";
            }
            else if(this.CSharpMenuItem.Checked)
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\WMICodeCreator\\MyWMIMethod.cs";
            }
            else if(this.VbsMenuItem.Checked)
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\WMICodeCreator\\MyWMIMethod.vbs";
            };


            OpenTextInNotepad(path, this.CodeText_m.Text);
        }

        //-------------------------------------------------------------------------
        // Handles the event when the OpenEventText button is clicked.  This opens
        // the code (in the CodeText_event text box) in Notepad.
        //-------------------------------------------------------------------------
        private void OpenEventText_Click(object sender, System.EventArgs e)
        {
            // Creates the path to the file to open in Notepad.
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\WMICodeCreator\\MyWMIEvent.vbs";

            if(this.VbNetMenuItem.Checked)
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\WMICodeCreator\\MyWMIEvent.vb";
            }
            else if(this.CSharpMenuItem.Checked)
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\WMICodeCreator\\MyWMIEvent.cs";
            }
            else if(this.VbsMenuItem.Checked)
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\WMICodeCreator\\MyWMIEvent.vbs";
            };

            OpenTextInNotepad(path, this.CodeText_event.Text);
        }

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

		//-------------------------------------------------------------------------
		// Handles the event when the BrowseQualifierButton button is clicked. 
		// This method populates the BrowseQualifierList with class qualifiers.
		//-------------------------------------------------------------------------
        private void BrowseQualifierButton_Click(object sender, System.EventArgs e)
        {
            this.BrowseQualifierList.Items.Clear();
            this.BrowseQualiferStatus.Text = "";

            // Populates the class list.
            System.Threading.ThreadPool.
                QueueUserWorkItem(
                new System.Threading.WaitCallback(
                this.AddQualifiersToBrowserList));
            
        }

		//-------------------------------------------------------------------------
		// Handles the event when the File->Exit menu item is selected.
		//
		//-------------------------------------------------------------------------
        private void ExitMenuItem_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

		//-------------------------------------------------------------------------
		// Handles the event when the Help->Query For WMI Data 
		// menu item is selected. This method opens the help in a .txt file.
		//-------------------------------------------------------------------------
        private void QueryHelpMenuItem_Click(object sender, System.EventArgs e)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\WMICodeCreator\\QueryHelp.txt";

            // Help text.
            string queryHelp = System.Environment.NewLine + System.Environment.NewLine +
                "***************************************" + System.Environment.NewLine + 
                "WMI Code Creator Help" + System.Environment.NewLine +
                System.Environment.NewLine +
                "Querying for Data Using WMI" + System.Environment.NewLine +
                "***************************************" + System.Environment.NewLine +
                System.Environment.NewLine +
                System.Environment.NewLine +
                "One of the main tasks in WMI is querying WMI for information about computer components and software. For example, you can request that WMI return the name and version of an operating system, or the amount of free disk space on a hard disk. The information that you query is made available through WMI classes that are installed in the WMI repository on a computer.  Each class is a part of a namespace, with each namespace holding similar classes.  For example, the root\\CIMV2 namespace contains classes that hold information about the Windows platform and your computer components." + System.Environment.NewLine +
                System.Environment.NewLine +
                "To locate management information through WMI, you use a language similar to SQL called the WMI Query Language (WQL). A basic WQL query remains fairly understandable for people with a basic knowledge of SQL. Therefore, WQL is dedicated to WMI and is designed to perform queries against the WMI repository to retrieve information or receive event notifications." + System.Environment.NewLine +
                System.Environment.NewLine +
                "The following steps describe how to use the WMI Code Creator to query WMI for data:" + System.Environment.NewLine +
                System.Environment.NewLine +
                "1. Select a namespace.  Each namespace holds classes that expose different types of information. The most commonly used namespace is root\\CIMV2 because it contains most of the classes that model Windows managed resources." + System.Environment.NewLine +
                System.Environment.NewLine +
                "2. Select a class from the namespace.  The class list is populated with classes from the selected namespace that have a dynamic qualifier (classes that are instantiated and expose data) or static qualifier." + System.Environment.NewLine +
                System.Environment.NewLine +
                "3. Select each property (from the list of class properties) that you want to get a value for.  You can select multiple properties by using either the SHIFT key or the CTRL key in combination with a left-click." + System.Environment.NewLine +
                System.Environment.NewLine +
                "4. (Optional) Click the Search for Property Values button to get all the values for the properties you selected in the property list.  If the property value list contains more than one value for a property, then there are multiple instances of the class you selected, and each instance has a value displayed in the property value list.  Properties with an array data type are not listed because they cannot be used in a WQL query." + System.Environment.NewLine +
                System.Environment.NewLine +
                "5. (Optional) Narrow the scope of your query. Select one value out of the property value list that you want to include in your WQL query.  By including a value in your query, you can refine your query to return information only from the instances that contain the value you have selected." + System.Environment.NewLine +
                System.Environment.NewLine +
                "6. Select the data source for your query. You can query for information about the computer you are using by selecting Local Computer from the Target Computer menu.  You can query for information about a remote computer by selecting Remote Computer from the Target Computer Menu, or you can query for information about a group of computers by selecting Group of Remote Computers from the Target Computer menu.  If you get the data from a group of computers, each computer must be in the same domain, and you need to be an administrator on each computer in the group (unless you alter the code).  When querying for information about a remote computer, you must enter the full name (or the IP address) of the remote computer. The full computer name can be found by clicking the Start button, right-clicking on My Computer and selecting Properties, and then selecting the Computer Name tab." + System.Environment.NewLine +
                System.Environment.NewLine +
                "7. Select a code language (for the generated code) from the Code Language menu." + System.Environment.NewLine;

            OpenTextInNotepad(path, queryHelp);
        }

		//-------------------------------------------------------------------------
		// Handles the event when the Help->Executing a Method in WMI 
		// menu item is selected. This method opens the help in a .txt file.
		//-------------------------------------------------------------------------
        private void MethodHelpMenuItem_Click(object sender, System.EventArgs e)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\WMICodeCreator\\ExecutingAMethodHelp.txt";
            
            // Help text.
            string methodHelp = System.Environment.NewLine + System.Environment.NewLine +
                "***************************************" + System.Environment.NewLine + 
                "WMI Code Creator Help" + System.Environment.NewLine +
                System.Environment.NewLine +
                "Executing a Method from a WMI Class" + System.Environment.NewLine +
                "***************************************" + System.Environment.NewLine +
                System.Environment.NewLine +
                System.Environment.NewLine +
                "One of the main tasks in WMI is executing a method from a WMI class. For example, you can execute the Reboot method in the Win32_OperatingSystem class to reboot a computer. There is a variety of executable methods available through WMI classes installed in the WMI repository on a computer.  Each class is in a namespace, with each namespace holding similar classes.  For example, the root\\CIMV2 namespace contains classes that hold information about the Windows platform and your computer components." + System.Environment.NewLine +
                System.Environment.NewLine +
                "When executing a method in WMI, you are executing either a static method of a WMI class or a method of a WMI class instance.  When you are executing a method of a class instance, you must specify which instance of the class you will use to execute the method. Each class instance has a set of properties, which includes a key property or a set of key properties.  Each separate instance has a different value for its key property. You specify which instance of the class you want to execute the method from by specifying a specific value of the class' key property." + System.Environment.NewLine +
                System.Environment.NewLine +
                "You must also assign values to a method's in-parameters before you execute a method (unless the method does not have any in-parameters). Not all in-parameters of a method require a value (some can be optional). For example, if you are trying to execute the Create method of the Win32_Process class to start a new process, you can specify a value for the CommandLine in-parameter (such as \"notepad.exe\" to start notepad), but you do not need to assign values to the CurrentDirectory or ProcessStartupInformation in-parameters." + System.Environment.NewLine +
                System.Environment.NewLine +
                "The following steps describe how to use the WMI Code Creator to execute a method from a WMI class:" + System.Environment.NewLine +
                System.Environment.NewLine +
                "1. Select a namespace.  Each namespace holds classes that expose different data. The most commonly used namespace is root\\CIMV2 because it contains most of the classes that model Windows managed resources." + System.Environment.NewLine +
                System.Environment.NewLine +
                "2. Select a class from the namespace.  The class list is populated with classes (only classes that contain methods) from the selected namespace." + System.Environment.NewLine +
                System.Environment.NewLine +
                "3. Select the method you want to execute from the Methods drop-down list. This will populate the in-parameter list with all the in-parameters for the method you selected. If the method you selected is not static, this will also bring up a list of key property values for all the instances of the class." + System.Environment.NewLine +
                System.Environment.NewLine +
                "4. Assign values to the in-parameters.  You must assign a value to each of the required in-parameters that are passed into the method to successfully call the method. For some methods, not all in-parameters in the list may be require a value.  When you select an in-parameter in the list, an input window for the in-parameter will appear.  When you enter the value for the in-parameter into the input window and click the Ok button, the value is entered in the generated code in the WMI Code Creator." + System.Environment.NewLine +
                System.Environment.NewLine +
                "5. Select the instance you want to execute the query on. The values in the list are the values of the key property for this class. The values are gathered from the local computer; thus, if you want to run the code on a remote computer, you may want to enter a value into the code manually." + System.Environment.NewLine +
                System.Environment.NewLine +
                "6. Select the computer you want to execute the method on. You can execute the method on the computer you are using by selecting Local Computer from the Target Computer menu. You can execute a method on one remote computer by selecting Remote Computer from the Target Computer menu, or you can execute a method on a group of computers by selecting Group of Remote Computers from the Target Computer menu.  If you execute a method on a group of computers, each of the computers need to be in the same domain, and you need to be an administrator on each computer in the group (unless you alter the code).  When executing a method on a remote computer, you need to enter in the full name (or the IP address) of the remote computer. The full computer name can be found by clicking the Start button, right-clicking on My Computer and selecting Properties, and then selecting the Computer Name tab." + System.Environment.NewLine +
                System.Environment.NewLine +
                "7. Select a code language (for the generated code) from the Code Language menu." + System.Environment.NewLine;

            OpenTextInNotepad(path, methodHelp);
                
        }

		//-------------------------------------------------------------------------
		// Handles the event when the Help->Browsing WMI namespaces 
		// menu item is selected. This method opens the help in a .txt file.
		//-------------------------------------------------------------------------
        private void BrowseHelpMenuItem_Click(object sender, System.EventArgs e)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\WMICodeCreator\\BrowsingWMINamespacesHelp.txt";

            // Help text
            string browseHelp = System.Environment.NewLine + System.Environment.NewLine +
                "***************************************************" + System.Environment.NewLine + 
                "WMI Code Creator Help" + System.Environment.NewLine +
                System.Environment.NewLine +
                "Browsing the Namespaces on the Local Computer" + System.Environment.NewLine +
                "***************************************************" + System.Environment.NewLine +
                System.Environment.NewLine +
                System.Environment.NewLine +
                "Each class in WMI is in a namespace, with each namespace holding similar classes.  For example, the root\\CIMV2 namespace contains classes that hold information about the Windows platform and your computer components. Each WMI class can have properties, methods, and qualifiers. A qualifier is a modifier that contains information that describes a class, instance, property, method, or parameter. Qualifiers are defined by the Common Information Model (CIM), by the CIM Object Manager, and by developers who create new classes." + System.Environment.NewLine +
                System.Environment.NewLine +
                "The following steps describe how to use the WMI Code Creator to browse the namespaces on a local computer:" + System.Environment.NewLine +
                System.Environment.NewLine +
                "1. Select a namespace.  Each namespace holds classes that expose different data. The most commonly used namespace is root\\CIMV2." + System.Environment.NewLine +
                System.Environment.NewLine +
                "2. Select a class from the namespace.  The class list is populated with all the classes from the selected namespace. If the selected class has a Description qualifier, then the value of that qualifier is displayed in the Class Description text box." + System.Environment.NewLine +
                System.Environment.NewLine +
                "3. Click the List all the properties in the class button to populate the property list with all the properties from the selected class.  When you select a property in the property list, the property description is displayed. The property description comes from the value of the Description qualifier for the selected property." + System.Environment.NewLine +
                System.Environment.NewLine +
                "4. Click the List all the methods in the class button to populate the method list with all the methods from the selected class. When you select a method in the method list, the method description is displayed.  The method description comes from the value of the Description qualifier for the selected method." + System.Environment.NewLine +
                System.Environment.NewLine +
                "5. Click the List all the qualifiers for the class button to populate the qualifier list will all the qualifiers from the selected class." + System.Environment.NewLine +
                System.Environment.NewLine;  

            OpenTextInNotepad(path, browseHelp);
        }

		//-------------------------------------------------------------------------
		// Handles the event when the Help->Receiving an event 
		// menu item is selected. This method opens the help in a .txt file
		//-------------------------------------------------------------------------
        private void EventHelpMenuItem_Click(object sender, System.EventArgs e)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\WMICodeCreator\\ReceivingAnEventHelp.txt";

			// Help text
			string eventHelp = System.Environment.NewLine + System.Environment.NewLine +
				"***************************************" + System.Environment.NewLine + 
				"WMI Code Creator Help" + System.Environment.NewLine +
				System.Environment.NewLine +
				"Receiving Event Notifications" + System.Environment.NewLine +
				"***************************************" + System.Environment.NewLine +
				System.Environment.NewLine +
				System.Environment.NewLine +
                "One of the main tasks in WMI is receiving an event notification that specifies something has happened or changed on a computer. For example, you can receive a notification every time a new process is started, a remote computer is shut down, or when a service is stopped. Event classes in WMI monitor when a specified event happens. Events are monitored either by WMI (intrinsic event classes) or by an event provider (extrinsic events classes). WMI monitors events by polling for changes on a computer during a polling interval.  For example, if you want WMI to notify you every time a process is created, WMI will poll the list of processes on a computer, and if the amount of processes in the list increases, then WMI sends an event notification.  You specify how often WMI polls for an event by specifying a polling interval in an event query. The more often you tell WMI to poll for an event, the more the CPU resources will be used. Some events are monitored by an event provider, in which case you do not have to specify a polling interval because the event provider will take care of all the event monitoring." + Environment.NewLine +
                Environment.NewLine +
                "Each event class is in a namespace, with each namespace holding similar classes.  For example, the root\\CIMV2 namespace contains classes that hold information about the Windows platform and your computer components. To receive an event, you create an event query that specifies an event class and, if necessary, the values of event class properties. The WMI Code Creator walks you through the steps of creating an event query.  A basic event query is formatted as follows: �SELECT * FROM <EventClass> <OptionalPollingInterval> WHERE <EventClassProperty> <operator> <UserDefinedValue>�. For example the event query, �SELECT * FROM __InstanceCreationEvent WITHIN 5 WHERE TargetInstance ISA �Win32_Process� AND TargetInstance.Name = �notepad.exe��, is an event query that polls WMI every 5 seconds for an event where an instance of the Win32_Process class is created (a process is created) that has the Win32_Process.Name property (the process name) equal to notepad.exe." + Environment.NewLine +
                Environment.NewLine +
                "The following steps describe how to use the WMI Code Creator to receive event notifications:" + Environment.NewLine +
                Environment.NewLine +
                "1. Select a namespace.  Each namespace holds classes that expose different data. The most commonly used namespace is root\\CIMV2." + Environment.NewLine +
                Environment.NewLine +
                "2. Select a class from the namespace.  The event class list is populated with classes from the selected namespace that are derived from the __Event class.  These classes can be used to receive event notifications." + Environment.NewLine +
                Environment.NewLine +
                "3. If a new drop-down list appears below the event class drop-down list (after completing step two), select a value for the event class property that is specified to the left of the list. If no new drop-down list appears below the event class drop-down list after completing step two, skip to step 4." + Environment.NewLine +
                Environment.NewLine +
                "If you selected the __ClassCreationEvent, __ClassDeletionEvent, __ClassModificationEvent, or the __ClassOperationEvent event class in step two, select a value for the TargetClass property." + Environment.NewLine +
                Environment.NewLine +
                "If you selected the __InstanceCreationEvent, __InstanceDeletionEvent, __InstanceModificationEvent, or the __InstanceOperationEvent event class in step two, select a value for the TargetInstance property." + Environment.NewLine +
                Environment.NewLine +
                "If you selected the __NamespaceCreationEvent, __NamespaceDeletionEvent, __NamespaceModificationEvent, or the __NamespaceOperationEvent event class in step two, select a value for the TargetNamespace property." + Environment.NewLine +
                Environment.NewLine +
                "If you selected the __MethodInvocationEvent event class in step two, select a value for the TargetInstance property." + Environment.NewLine +
                Environment.NewLine +
                "4. Assign values to event query conditions.  You must select and assign a value to all the event query conditions you want to use in your WQL event query. Not all the event query conditions are required.  Each event query condition in the list that you select will bring up an input window for the event query condition.  When you enter the value for the event query condition into the input window and click the Ok button on the input window, the value is inserted into the generated code in the WMI Code Creator." + Environment.NewLine +
                Environment.NewLine +
                "5. (optional) If prompted, enter the polling interval (how often WMI will poll for the event notification).  The polling interval is defined by the WITHIN statement in the event query in the generated code." + Environment.NewLine +
                Environment.NewLine +
				"6. Select if you want to receive event notifications asynchronously or not.  Receiving event notifications asynchronously allows you to execute code while receiving events (without waiting for a notification)." + Environment.NewLine +
				Environment.NewLine +
                "7. Select the target computer you want to receive events from by selecting a menu item from the Target Computer menu.  You can receive event notifications on the computer you are using by selecting the Local Computer from the Target Computer menu.  You can receive event notifications from a remote computer by selecting Remote Computer from the Target Computer menu, or you can receive event notifications from a group of computers by selecting Group of Remote Computers from the Target Computer menu.  If you receive event notifications from a group of computers, each of the computers need to be in the same domain, and you need to be an administrator on each computer in the group (unless you alter the code).  When receiving event notifications from a remote computer, you need to enter in the full name (or the IP Address) of the remote computer. The full computer name can be found by clicking the Start button, right-clicking on My Computer and selecting Properties, and then selecting the Computer Name tab." + Environment.NewLine +
                Environment.NewLine +
                "8. Select a code language (for the generated code) from the Code Language menu." + Environment.NewLine +
                Environment.NewLine;
					
	            OpenTextInNotepad(path, eventHelp);
        }

		//-------------------------------------------------------------------------
		// Handles the event when the user selects a key property value on 
		// the method tab (from the KeyValueBox list).
		//-------------------------------------------------------------------------
		private void KeyValueBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			GenerateMethodCode();
		}

		//-------------------------------------------------------------------------
		// Handles the event when the user selects one of the properties in the
		// BrowsePropertyList on the browse tab. This displays the property information.
		//-------------------------------------------------------------------------
		private void BrowsePropertyList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string propertyInfo = "Qualifiers: " + System.Environment.NewLine;
			string description = "Description: " + System.Environment.NewLine;

			try
			{
				// Gets the property qualifiers.
				ObjectGetOptions op = new ObjectGetOptions(null, System.TimeSpan.MaxValue, true);

				ManagementClass mc = new ManagementClass(this.BrowseNamespaceList.Text,
					this.BrowseClassList.Text, op);
				mc.Options.UseAmendedQualifiers = true;

				foreach (PropertyData p in mc.Properties)
				{

					if(p.Name.Equals(this.BrowsePropertyList.SelectedItem))
					{
						foreach (QualifierData q in p.Qualifiers)
						{
							propertyInfo = propertyInfo + q.Name + System.Environment.NewLine;


							if(q.Name.Equals("Description"))
							{
								description = description +
									mc.GetPropertyQualifierValue(p.Name, q.Name) + System.Environment.NewLine;
							}
						}
					}             

					this.PropertyInformation.Text = description + System.Environment.NewLine + propertyInfo;
				}
			}
			catch  (ManagementException mErr)
			{
				this.PropertyInformation.Text = "Could not get property information";
            
                if(mErr.Message.Equals("Not found "))
                    MessageBox.Show("WMI class not found.");
                else
                    MessageBox.Show(mErr.Message.ToString());
			}
		}

		//-------------------------------------------------------------------------
		// Handles the event when the user selects one of the methods in the
		// BrowseMethodList on the browse tab. This displays the method information.
		//-------------------------------------------------------------------------
		private void BrowseMethodList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string methodInfo = "Qualifiers: " + System.Environment.NewLine;
			string description = "Description: " + System.Environment.NewLine;

			try
			{
				// Gets the property qualifiers.
				ObjectGetOptions op = new ObjectGetOptions(null, System.TimeSpan.MaxValue, true);

				ManagementClass mc = new ManagementClass(this.BrowseNamespaceList.Text,
					this.BrowseClassList.Text, op);
				mc.Options.UseAmendedQualifiers = true;

				foreach (MethodData m in mc.Methods)
				{

					if(m.Name.Equals(this.BrowseMethodList.SelectedItem))
					{
						foreach (QualifierData q in m.Qualifiers)
						{
							methodInfo = methodInfo + q.Name + System.Environment.NewLine;


							if(q.Name.Equals("Description"))
							{
								description = description +
									q.Value + System.Environment.NewLine;
							}
						}
					}             

					this.MethodInformation.Text = description + System.Environment.NewLine + methodInfo;
				}
			}
			catch  (ManagementException mErr)
			{
				this.MethodInformation.Text = "Could not get method information";

                if(mErr.Message.Equals("Not found "))
                    MessageBox.Show("WMI class or method not found.");
                else
                    MessageBox.Show(mErr.Message.ToString());
			}
		}

		//-------------------------------------------------------------------------
		// Handles the event when the user selects an item in the targetClassList
		// list on the event tab.
		//-------------------------------------------------------------------------
        private void TargetClassList_event_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.PropertyList_event.Items.Clear();
            AddTargetClassProperties();

			if(this.PropertyList_event.Items.Count > 0) 
			{
				System.Array.Clear(this.EventConditionArray, 0, this.EventConditionArray.Length);
				this.EventConditionArray = new EventQueryCondition[PropertyList_event.Items.Count];

				for(int i = 0; i < PropertyList_event.Items.Count; i++)
				{
					EventConditionArray[i] = new EventQueryCondition(this);
					EventConditionArray[i].SetParameterName((PropertyList_event.Items[i].ToString().Split(" ".ToCharArray()))[0]);
				
					if(PropertyList_event.Items[i].ToString().StartsWith("TargetClass ISA") ||
						PropertyList_event.Items[i].ToString().StartsWith("PreviousClass ISA") ||
						PropertyList_event.Items[i].ToString().StartsWith("TargetInstance ISA") ||
						PropertyList_event.Items[i].ToString().StartsWith("PreviousInstance ISA") ||
						PropertyList_event.Items[i].ToString().StartsWith("TargetNamespace =") ||
						PropertyList_event.Items[i].ToString().StartsWith("PreviousNamespace ="))
					{
						EventConditionArray[i].ChangeOperator((PropertyList_event.Items[i].ToString().Split(" ".ToCharArray()))[1]);
						EventConditionArray[i].ChangeTextBoxValue((PropertyList_event.Items[i].ToString().Split(" ".ToCharArray()))[2]);
					}
				}	
			}
        }

		//-------------------------------------------------------------------------
		// Handles the event when the user selects an event class property
		// (from the PropertyList_event list) to include in an event query.
		//-------------------------------------------------------------------------
		private void PropertyList_event_SelectedIndexChanged(object sender, System.EventArgs e)
		{	

			for(int i = 0; i < PropertyList_event.Items.Count; i++)
			{
				try
				{

					if(this.PropertyList_event.SelectedIndices.Contains(i) && !EventConditionArray[i].GetOkClicked())
					{
					
						EventConditionArray[i].Visible = true;
						EventConditionArray[i].ChangeText(
                            "Assign a value to the " + EventConditionArray[i].GetParameterName()
							+ " property. The property is of type: " +
							EventConditionArray[i].GetParameterType() + ".");
					}
				}
				catch (System.NullReferenceException nullError)
				{
					// Catches the case if the window was closed.
					EventConditionArray[i] = new EventQueryCondition(this);
					EventConditionArray[i].SetParameterName((PropertyList_event.Items[i].ToString().Split(" ".ToCharArray()))[0]);
					EventConditionArray[i].Visible = true;
					EventConditionArray[i].ChangeText(
						"Assign a value to the " + EventConditionArray[i].GetParameterName()
						+ " property. The property is of type: " +
						EventConditionArray[i].GetParameterType() + ".");
				
					if(PropertyList_event.Items[i].ToString().StartsWith("TargetClass ISA") ||
						PropertyList_event.Items[i].ToString().StartsWith("PreviousClass ISA") ||
						PropertyList_event.Items[i].ToString().StartsWith("TargetInstance ISA") ||
						PropertyList_event.Items[i].ToString().StartsWith("PreviousInstance ISA") ||
						PropertyList_event.Items[i].ToString().StartsWith("TargetNamespace =") ||
						PropertyList_event.Items[i].ToString().StartsWith("PreviousNamespace ="))
					{
						EventConditionArray[i].ChangeOperator((PropertyList_event.Items[i].ToString().Split(" ".ToCharArray()))[1]);
						EventConditionArray[i].ChangeTextBoxValue((PropertyList_event.Items[i].ToString().Split(" ".ToCharArray()))[2]);
					}
				}
			
				if(!this.PropertyList_event.SelectedIndices.Contains(i))
				{
					try
					{
						EventConditionArray[i].Visible = false;
						EventConditionArray[i].SetOkClicked(false);
					}
					catch (System.NullReferenceException nullError)
					{
						// Catches the case if the window was closed.
						EventConditionArray[i] = new EventQueryCondition(this);
						EventConditionArray[i].SetParameterName((PropertyList_event.Items[i].ToString().Split(" ".ToCharArray()))[0]);
						EventConditionArray[i].Visible = false;
						EventConditionArray[i].SetOkClicked(false);

						if(PropertyList_event.Items[i].ToString().StartsWith("TargetClass ISA") ||
							PropertyList_event.Items[i].ToString().StartsWith("PreviousClass ISA") ||
							PropertyList_event.Items[i].ToString().StartsWith("TargetInstance ISA") ||
							PropertyList_event.Items[i].ToString().StartsWith("PreviousInstance ISA") ||
							PropertyList_event.Items[i].ToString().StartsWith("TargetNamespace =") ||
							PropertyList_event.Items[i].ToString().StartsWith("PreviousNamespace ="))
						{
							EventConditionArray[i].ChangeOperator((PropertyList_event.Items[i].ToString().Split(" ".ToCharArray()))[1]);
							EventConditionArray[i].ChangeTextBoxValue((PropertyList_event.Items[i].ToString().Split(" ".ToCharArray()))[2]);
						}
					}
				}
			}

			this.GenerateEventCode();
		}

		//-------------------------------------------------------------------------
		// Handles the event when the user selects the code language output to
		// be C#.
		//-------------------------------------------------------------------------
		private void CSharpMenuItem_Click(object sender, System.EventArgs e)
		{
            this.CSharpMenuItem.Checked = true;
            this.VbsMenuItem.Checked = false;
            this.VbNetMenuItem.Checked = false;
        
            this.GenerateEventCode();
            this.GenerateQueryCode();
            this.GenerateMethodCode();
		}

		//-------------------------------------------------------------------------
		// Handles the event when the user selects the code language output to
		// be VB .NET.
		//-------------------------------------------------------------------------
		private void VbNetMenuItem_Click(object sender, System.EventArgs e)
		{
			this.CSharpMenuItem.Checked = false;
			this.VbsMenuItem.Checked = false;
			this.VbNetMenuItem.Checked = true;
		
			this.GenerateEventCode();
			this.GenerateQueryCode();
			this.GenerateMethodCode();
		}

		//-------------------------------------------------------------------------
		// Handles the event when the user selects the code language output to
		// be VBScript.
		//-------------------------------------------------------------------------
		private void VbsMenuItem_Click(object sender, System.EventArgs e)
		{
			this.CSharpMenuItem.Checked = false;
			this.VbsMenuItem.Checked = true;
			this.VbNetMenuItem.Checked = false;

			this.GenerateEventCode();
			this.GenerateQueryCode();
			this.GenerateMethodCode();
		}

		//-------------------------------------------------------------------------
		// Handles the event when the user checks or unchecks the Asynchronous
		// check box on the event tab.
		//-------------------------------------------------------------------------
		private void Asynchronous_CheckedChanged(object sender, System.EventArgs e)
		{
		    this.GenerateEventCode();
		}

		//-------------------------------------------------------------------------
		// Handles the event when the user selects the Target Computer-> Local Computer
		// menu item.
		//-------------------------------------------------------------------------
        private void LocalComputerMenu_Click(object sender, System.EventArgs e)
        {
            this.RemoteComputerMenu.Checked = false;
            this.GroupRemoteComputerMenu.Checked = false;
            this.LocalComputerMenu.Checked = true;

            this.GenerateEventCode();
            this.GenerateQueryCode();
            this.GenerateMethodCode();
        }

		//-------------------------------------------------------------------------
		// Handles the event when the user selects the Target Computer-> Remote Computer
		// menu item.
		//-------------------------------------------------------------------------
        private void RemoteComputerMenu_Click(object sender, System.EventArgs e)
        {
            this.RemoteComputerMenu.Checked = true;
            this.GroupRemoteComputerMenu.Checked = false;
            this.LocalComputerMenu.Checked = false;

            this.TargetWindow.SetForRemoteComputerInfo();

            this.TargetWindow.Visible = true;

            this.GenerateEventCode();
            this.GenerateQueryCode();
            this.GenerateMethodCode();
        }

		//-------------------------------------------------------------------------
		// Handles the event when the user selects the Target Computer-> Group of Remote Computers
		// menu item.
		//-------------------------------------------------------------------------
        private void GroupRemoteComputerMenu_Click(object sender, System.EventArgs e)
        {
            this.RemoteComputerMenu.Checked = false;
            this.GroupRemoteComputerMenu.Checked = true;
            this.LocalComputerMenu.Checked = false;

            this.TargetWindow.SetForGroupComputerInfo();

            this.TargetWindow.Visible = true;

            this.GenerateEventCode();
            this.GenerateQueryCode();
            this.GenerateMethodCode();
        }



		//--------------------------------------------------------------------------------
		// The EventQueryCondition class is a windows form that is used by
		// the user to enter values for event query conditions in the WMICodeCreator form.
		// An array of EventQueryCondition objects is created, with one object for
		// each possible event query condition.
        //--------------------------------------------------------------------------------
		[ComVisible(false)]
		private class EventQueryCondition : System.Windows.Forms.Form
		{
			private System.Windows.Forms.Label InputMessage;
			private string StoredValue;
			private string ParameterName;
			private bool OkButtonClicked;
			private System.Windows.Forms.TextBox TextBox;
			private System.Windows.Forms.Button OKbutton;
			private System.Windows.Forms.Button CloseButton;
			private System.Windows.Forms.ComboBox OperatorBox;
			private WMICodeCreator ParentWMIToolForm;
    		
			
			// Required designer variable.
			private System.ComponentModel.Container components = null;

			//-------------------------------------------------------------------------
			// Initializes the EventQueryCondition object.
			// This constructor should not be used.
			//-------------------------------------------------------------------------
			private EventQueryCondition()
			{
				//
				// Required for Windows Form Designer support.
				//
				InitializeComponent();

				this.OperatorBox.Items.Add("=");
				this.OperatorBox.Items.Add("<>");
				this.OperatorBox.Items.Add(">");
				this.OperatorBox.Items.Add("<");
				this.OperatorBox.Items.Add("ISA");
			}

			//-------------------------------------------------------------------------
			// Initializes the EventQueryCondition object, to create a pointer 
			// back to the parent WMICodeCreator form.
			//-------------------------------------------------------------------------
			public EventQueryCondition(WMICodeCreator parent)
			{
				InitializeComponent();
				this.ParameterName = "";
				this.StoredValue = "";
				this.OkButtonClicked = false;
				this.ParentWMIToolForm = parent;
				this.OperatorBox.Items.Add("=");
				this.OperatorBox.Items.Add("<>");
				this.OperatorBox.Items.Add(">");
				this.OperatorBox.Items.Add("<");
				this.OperatorBox.Items.Add("ISA");
			}

		
			// Clean up any resources being used.
			protected override void Dispose( bool disposing )
			{
				for(int j = 0; j < this.ParentWMIToolForm.PropertyList_event.Items.Count; j++)
				{
					if(this.Equals(
						this.ParentWMIToolForm.EventConditionArray[j]))
					{

						// Change the name back to no value.
						string conditionName = this.ParentWMIToolForm.PropertyList_event.Items[j].ToString().Split(" ".ToCharArray())[0];
						// Update the PropertyList_event item with the input value.
						this.ParentWMIToolForm.PropertyList_event.Items.RemoveAt(j);
						this.ParentWMIToolForm.PropertyList_event.Items.Add(conditionName);
						this.ParentWMIToolForm.PropertyList_event.Sorted = true;
	

						// This deselects the in-parameter on the list and then makes a new entry into the array to
						// replace the old in-parameter that is being deleted.
						this.ParentWMIToolForm.PropertyList_event.SetSelected(j, false);       
					}
				        
	
				}

				if( disposing )
				{
					if (components != null) 
					{
						components.Dispose();
					}
				}
				base.Dispose( disposing );

			}
			
			// Required method for Designer support - do not modify
			// the contents of this method with the code editor.
			private void InitializeComponent()
			{
				this.TextBox = new System.Windows.Forms.TextBox();
				this.InputMessage = new System.Windows.Forms.Label();
				this.OKbutton = new System.Windows.Forms.Button();
				this.CloseButton = new System.Windows.Forms.Button();
				this.OperatorBox = new System.Windows.Forms.ComboBox();
				this.SuspendLayout();
				// 
				// TextBox
				// 
				this.TextBox.Location = new System.Drawing.Point(112, 64);
				this.TextBox.Name = "TextBox";
				this.TextBox.Size = new System.Drawing.Size(152, 20);
				this.TextBox.TabIndex = 0;
				this.TextBox.Text = "";
				this.TextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
				// 
				// InputMessage
				// 
				this.InputMessage.Location = new System.Drawing.Point(32, 16);
				this.InputMessage.Name = "InputMessage";
				this.InputMessage.Size = new System.Drawing.Size(240, 40);
				this.InputMessage.TabIndex = 1;
				this.InputMessage.Text = "";
				// 
				// OKbutton
				// 
				this.OKbutton.Location = new System.Drawing.Point(40, 104);
				this.OKbutton.Name = "OKbutton";
				this.OKbutton.Size = new System.Drawing.Size(96, 23);
				this.OKbutton.TabIndex = 2;
				this.OKbutton.Text = "OK";
				this.OKbutton.Click += new System.EventHandler(this.OKButton_Click);
				// 
				// CloseButton
				// 
				this.CloseButton.Location = new System.Drawing.Point(152, 104);
				this.CloseButton.Name = "CloseButton";
				this.CloseButton.Size = new System.Drawing.Size(96, 23);
				this.CloseButton.TabIndex = 3;
				this.CloseButton.Text = "Cancel";
				this.CloseButton.Click += new System.EventHandler(this.CancelButton_Click);
				// 
				// OperatorBox
				// 
				this.OperatorBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
				this.OperatorBox.Location = new System.Drawing.Point(32, 64);
				this.OperatorBox.Name = "OperatorBox";
				this.OperatorBox.Size = new System.Drawing.Size(56, 21);
				this.OperatorBox.TabIndex = 4;
				this.OperatorBox.Text = "=";
				// 
				// EventQueryCondition
				// 
				this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
				this.ClientSize = new System.Drawing.Size(296, 146);
                this.ControlBox = false;
				this.Controls.Add(this.OperatorBox);
				this.Controls.Add(this.CloseButton);
				this.Controls.Add(this.OKbutton);
				this.Controls.Add(this.InputMessage);
				this.Controls.Add(this.TextBox);
				this.Name = "EventQueryCondition";
				this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
				this.Text = "Enter property value";
				this.ResumeLayout(false);

			}

            //-------------------------------------------------------------------------
            // Returns the value of OkButtonClicked
            //-------------------------------------------------------------------------
            public bool GetOkClicked()
            {
                return this.OkButtonClicked;
            }

            //-------------------------------------------------------------------------
            // Sets the value of OkButtonClicked
            //-------------------------------------------------------------------------
            public void SetOkClicked(bool setValue)
            {
                this.OkButtonClicked = setValue;
            }

			//-------------------------------------------------------------------------
			// Handles the event when the user clicks the OK button on the
			// EventQueryCondition form.
			//-------------------------------------------------------------------------
			private void OKButton_Click(object sender, System.EventArgs e)
			{

				// Check to see if it is a string value.
				// If it is a string value, add single quote marks.
				if(this.GetParameterType().Equals("String"))
				{
					this.StoredValue = "'" + this.TextBox.Text + "'";
				}
				else
				{
					this.StoredValue = this.TextBox.Text;
				}

				this.Visible = false;
				this.OkButtonClicked = true;

				for(int j = 0; j < this.ParentWMIToolForm.PropertyList_event.Items.Count; j++)
				{

					if(this.ParameterName.Equals(
						this.ParentWMIToolForm.PropertyList_event.Items[j].ToString().Split(" ".ToCharArray())[0]))
					{
						string conditionName = this.ParentWMIToolForm.PropertyList_event.Items[j].ToString().Split(" ".ToCharArray())[0];
						// Update the PropertyList_event item with the input value.
						this.ParentWMIToolForm.PropertyList_event.Items.RemoveAt(j);
						this.ParentWMIToolForm.PropertyList_event.Items.Add(conditionName + " " + this.OperatorBox.Text + " " + this.StoredValue);
						this.ParentWMIToolForm.PropertyList_event.Sorted = true;
						this.ParentWMIToolForm.PropertyList_event.SetSelected(j, true);
					}
	
				}

				this.ParentWMIToolForm.GenerateEventCode();
			}

			//-------------------------------------------------------------------------
			// Handles the event when the user clicks the Cancel button on the
			// EventQueryCondition form.
			//-------------------------------------------------------------------------
			private void CancelButton_Click(object sender, System.EventArgs e)
			{
				this.StoredValue = "";
				this.TextBox.Text = "";
				this.Visible = false;
				this.OkButtonClicked = false;
	
				for(int j = 0; j < this.ParentWMIToolForm.PropertyList_event.Items.Count; j++)
				{
					if(this.ParameterName.Equals(
						this.ParentWMIToolForm.PropertyList_event.Items[j].ToString().Split(" ".ToCharArray())[0]))
					{
						// Change the name back to no value.
						string conditionName = this.ParentWMIToolForm.PropertyList_event.Items[j].ToString().Split(" ".ToCharArray())[0];
						// Update the PropertyList_event item with the input value.
						this.ParentWMIToolForm.PropertyList_event.Items.RemoveAt(j);
						this.ParentWMIToolForm.PropertyList_event.Items.Add(conditionName);
						this.ParentWMIToolForm.PropertyList_event.Sorted = true;

						this.ParentWMIToolForm.PropertyList_event.SetSelected(j, false);
					}
	
				}			        
				
				this.ParentWMIToolForm.GenerateEventCode();
			}

			//-------------------------------------------------------------------------
			// Handles the event when the user types in a value for an
			// event query condition form.
			//-------------------------------------------------------------------------
			private void TextBox_TextChanged(object sender, System.EventArgs e)
			{
				this.StoredValue = this.TextBox.Text;
				this.ParentWMIToolForm.GenerateEventCode();
			}

			//-------------------------------------------------------------------------
			// Changes the text on the EventQueryCondition form (used as an
			// introduction on the form).
			//-------------------------------------------------------------------------
			public void ChangeText(string newText)
			{
				this.InputMessage.Text = newText;
			}

			//-------------------------------------------------------------------------
			// Changes the value of the event query condition.
			// 
			//-------------------------------------------------------------------------
			public void ChangeTextBoxValue(string textValue)
			{
				this.TextBox.Text = textValue;
			}

			//-------------------------------------------------------------------------
			// Changes the operator used in the event query condition.
			// 
			//-------------------------------------------------------------------------
			public void ChangeOperator(string operatorValue)
			{
				this.OperatorBox.Text = operatorValue;
				this.OperatorBox.SelectedText = operatorValue;
				
			}

			//-------------------------------------------------------------------------
			// Gets the name of the parameter used in the event query condition.
			// 
			//-------------------------------------------------------------------------
			public string GetParameterName()
			{
				return ParameterName;
			}

			//-------------------------------------------------------------------------
			// Sets the name of the parameter in the event query condition.
			// 
			//-------------------------------------------------------------------------
			public void SetParameterName(string inputName)
			{
				this.ParameterName = inputName;
			}

			//-------------------------------------------------------------------------
			// Gets the type of the parameter used in the event query condition.
			// 
			//-------------------------------------------------------------------------
			public string GetParameterType()
			{
				string type = "";
				try
				{
					ManagementClass c = new ManagementClass(this.ParentWMIToolForm.NamespaceList_event.Text, this.ParentWMIToolForm.ClassList_event.Text, null);

					foreach (PropertyData pData in c.Properties)
					{
						if(pData.Name.Equals(this.ParameterName))
						{
							type = pData.Type.ToString();
						}
					}


					if(type.Length == 0)
					{
						ManagementClass c2 = new ManagementClass(this.ParentWMIToolForm.NamespaceList_event.Text, this.ParentWMIToolForm.TargetClassList_event.Text, null);

						foreach (PropertyData p in c2.Properties)
						{
							if(p.Name.Equals(this.ParameterName.Split(".".ToCharArray())[1]))
							{
								type = p.Type.ToString();
							}
						}
					}
				}
				catch (ManagementException e)
				{
					MessageBox.Show("Error getting the type of the event class. The namespace name or event class name is incorrect.");
				}

				return type;
			}

		}


        //------------------------------------------------------------------------------
		// The InParameterWindow class is a windows form that is used by
		// the user to enter values for method in-parameters in the WMICodeCreator form.
		// An Array of InParameterWindow objects is created, with one object for
		// each method in-parameter.
        //------------------------------------------------------------------------------
        [ComVisible(false)]
        private class InParameterWindow : System.Windows.Forms.Form
        {
            private System.Windows.Forms.TextBox textBox1;
            private System.Windows.Forms.Label InputMessage;
            private System.Windows.Forms.Button OKButton;
            private string StoredValue;
            private string ParameterName;
            private bool OkButtonClicked;
            private System.Windows.Forms.Button CloseButton;
            private WMICodeCreator ParentWMIToolForm;
    		
            
            // Required designer variable.
            private System.ComponentModel.Container components = null;

			//-------------------------------------------------------------------------
			// Initializes the InParameterWindow object. 
			// Do not use this default constructor.
			//-------------------------------------------------------------------------
            public InParameterWindow()
            {
                //
                // Required for Windows Form Designer support.
                //
                InitializeComponent();
            }

			//-------------------------------------------------------------------------
			// Initializes the InParameterWindow object, creating a pointer 
			// back to the parent WMICodeCreator form.
			//-------------------------------------------------------------------------
            public InParameterWindow(WMICodeCreator parent)
            {
                InitializeComponent();
                this.ParameterName = "";
                this.StoredValue = "";
                this.OkButtonClicked = false;
                this.ParentWMIToolForm = parent;
            }

            //-------------------------------------------------------------------------
            // Clean up any resources being used.
            //-------------------------------------------------------------------------
            protected override void Dispose( bool disposing )
            {
                for(int j = 0; j < this.ParentWMIToolForm.InParameterBox.Items.Count; j++)
                {
                    if(this.Equals(
                        this.ParentWMIToolForm.InParameterArray[j]))
                    {
                        // This deselects the in-parameter on the list and then makes a new entry into the array to
                        // replace the old in-parameter that is being deleted.
                        this.ParentWMIToolForm.InParameterBox.SetSelected(j, false);       
                    }
                }

                if( disposing )
                {
                    if (components != null) 
                    {
                        components.Dispose();
                    }
                }
                base.Dispose( disposing );

            }

            //-------------------------------------------------------------------------
            // Required method for Designer support - do not modify
            // the contents of this method with the code editor.
            //-------------------------------------------------------------------------
            private void InitializeComponent()
            {
                this.textBox1 = new System.Windows.Forms.TextBox();
                this.InputMessage = new System.Windows.Forms.Label();
                this.OKButton = new System.Windows.Forms.Button();
                this.CloseButton = new System.Windows.Forms.Button();
                this.SuspendLayout();
				this.TopMost = true;
                // 
                // textBox1
                // 
                this.textBox1.Location = new System.Drawing.Point(32, 64);
                this.textBox1.Name = "textBox1";
                this.textBox1.Size = new System.Drawing.Size(224, 20);
                this.textBox1.TabIndex = 0;
                this.textBox1.Text = "";
                this.textBox1.TextChanged += new EventHandler(TextBox_TextChanged);
                // 
                // InputMessage
                // 
                this.InputMessage.Location = new System.Drawing.Point(32, 16);
                this.InputMessage.Name = "InputMessage";
                this.InputMessage.Size = new System.Drawing.Size(224, 40);
                this.InputMessage.TabIndex = 1;
                this.InputMessage.Text = "";
                    
                // 
                // OKButton
                // 
                this.OKButton.Location = new System.Drawing.Point(40, 104);
                this.OKButton.Name = "OKButton";
                this.OKButton.Size = new System.Drawing.Size(96, 23);
                this.OKButton.TabIndex = 2;
                this.OKButton.Text = "OK";
                this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
                // 
                // CloseButton
                // 
                this.CloseButton.Location = new System.Drawing.Point(152, 104);
                this.CloseButton.Name = "CloseButton";
                this.CloseButton.Size = new System.Drawing.Size(96, 23);
                this.CloseButton.TabIndex = 3;
                this.CloseButton.Text = "Cancel";
                this.CloseButton.Click += new System.EventHandler(this.CancelButton_Click);
                // 
                // InParameterWindow
                // 
                this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
                this.ClientSize = new System.Drawing.Size(292, 146);
                this.ControlBox = false;
                this.Controls.Add(this.CloseButton);
                this.Controls.Add(this.OKButton);
                this.Controls.Add(this.InputMessage);
                this.Controls.Add(this.textBox1);
                this.Name = "InParameterWindow";
                this.Text = "Enter in-parameter";
                this.ResumeLayout(false);
                this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            }

			//-------------------------------------------------------------------------
			// Handles the event when the user clicks the OK button on the
			// InParameterWindow form.
			//-------------------------------------------------------------------------
            private void OKButton_Click(object sender, System.EventArgs e)
            {
				if(this.GetParameterType().Equals("String"))
				{
					this.StoredValue = "\"" + this.textBox1.Text + "\"";
				}
				else
				{
					this.StoredValue = this.textBox1.Text;
				}
                
                this.Visible = false;
                this.OkButtonClicked = true;

				for(int j = 0; j < this.ParentWMIToolForm.InParameterBox.Items.Count; j++)
				{

					if(this.ParameterName.Equals(
						this.ParentWMIToolForm.InParameterBox.Items[j].ToString().Split(" ".ToCharArray())[0]))
					{
						string conditionName = this.ParentWMIToolForm.InParameterBox.Items[j].ToString().Split(" ".ToCharArray())[0];
						// Updates the PropertyList_event item with the input value.
						this.ParentWMIToolForm.InParameterBox.Items.RemoveAt(j);
						this.ParentWMIToolForm.InParameterBox.Items.Add(conditionName + " = " + this.StoredValue);
						this.ParentWMIToolForm.InParameterBox.Sorted = true;
						this.ParentWMIToolForm.InParameterBox.SetSelected(j, true);
					}
				}

                this.ParentWMIToolForm.GenerateMethodCode();
            }

            //-------------------------------------------------------------------------
            // Returns the value of OkButtonClicked
            //-------------------------------------------------------------------------
            public bool GetOkClicked()
            {
                return this.OkButtonClicked;
            }

            //-------------------------------------------------------------------------
            // Sets the value of OkButtonClicked
            //-------------------------------------------------------------------------
            public void SetOkClicked(bool setValue)
            {
                this.OkButtonClicked = setValue;
            }

			//-------------------------------------------------------------------------
			// Returns the type of the method in-parameter.
			// 
			//-------------------------------------------------------------------------
			public string GetParameterType()
			{
                string type = " ";

                try
                {
                    ManagementClass c = new ManagementClass(this.ParentWMIToolForm.NamespaceValue_m.Text, this.ParentWMIToolForm.ClassList_m.Text, null);

                    ManagementBaseObject m = c.Methods[this.ParentWMIToolForm.MethodList.Text].InParameters;
                    type = m.Properties[this.ParameterName].Type.ToString();
                }
                catch (ManagementException mErr)
                {
                    if(mErr.Message.Equals("Not found "))
                        MessageBox.Show("WMI class or method not found.");
                    else
                        MessageBox.Show(mErr.Message.ToString());
                }

                return type;
			}

			//-------------------------------------------------------------------------
			// Handles the event when the user clicks the Cancel button on the
			// InParameterWindow form.
			//-------------------------------------------------------------------------
            private void CancelButton_Click(object sender, System.EventArgs e)
            {
                this.StoredValue = "";
                this.textBox1.Text = "";
                this.Visible = false;
                this.OkButtonClicked = false;
                 
                for(int j = 0; j < this.ParentWMIToolForm.InParameterBox.Items.Count; j++)
                {
					if(this.ParameterName.Equals(
						this.ParentWMIToolForm.InParameterBox.Items[j].ToString().Split(" ".ToCharArray())[0]))
					{
						// Change the name back to no value.
						string conditionName = this.ParentWMIToolForm.InParameterBox.Items[j].ToString().Split(" ".ToCharArray())[0];
						// Update the PropertyList_event item with the input value.
						this.ParentWMIToolForm.InParameterBox.Items.RemoveAt(j);
						this.ParentWMIToolForm.InParameterBox.Items.Add(conditionName);
						this.ParentWMIToolForm.InParameterBox.Sorted = true;

						this.ParentWMIToolForm.InParameterBox.SetSelected(j, false);
					}
                }
      
                this.ParentWMIToolForm.GenerateMethodCode();
         
			}

			//-------------------------------------------------------------------------
			// Handles the event when the user enters in a value for a method
			// in-parameter.
			//-------------------------------------------------------------------------
            private void TextBox_TextChanged(object sender, System.EventArgs e)
            {
                this.StoredValue = this.textBox1.Text;
                this.ParentWMIToolForm.GenerateMethodCode();
            }

			//-------------------------------------------------------------------------
			// Changes the introductory text on the
			// InParameterWindow form.
			//-------------------------------------------------------------------------
            public void ChangeText(string newText)
            {
                this.InputMessage.Text = newText;
            }

			//-------------------------------------------------------------------------
			// Returns the in-parameter value that has been entered by a user.
			//
			//-------------------------------------------------------------------------
            public string ReturnParameterValue()
            {
                return StoredValue;
            }

			//-------------------------------------------------------------------------
			// Gets the name of the method in-parameter.
			// 
			//-------------------------------------------------------------------------
            public string GetParameterName()
            {
                return ParameterName;
            }

			//-------------------------------------------------------------------------
			// Sets the name of the method in-parameter.
			// 
			//-------------------------------------------------------------------------
            public void SetParameterName(string inputName)
            {
                this.ParameterName = inputName;
            }

        }

        //---------------------------------------------------------------------------------------
        // The TargetComputerWindow class creates the windows form used
        // to enter in the target computer information used in the WMICodeCreator.
        // The TargetComputerWindow class takes in information (name and domain)
        // about a remote computer, or the name of a list of remote computers in the same domain.
        //---------------------------------------------------------------------------------------
        [ComVisible(false)]
        private class TargetComputerWindow : System.Windows.Forms.Form
        {
            private System.Windows.Forms.Button okButton;
            private System.Windows.Forms.Label remoteIntro;
            private System.Windows.Forms.Label computerNameLabel;
            private System.Windows.Forms.TextBox remoteComputerNameBox;
            private System.Windows.Forms.TextBox remoteComputerDomainBox;
            private System.Windows.Forms.Label computerDomainLabel;
            private System.Windows.Forms.TextBox arrayRemoteComputersBox;
            private System.Windows.Forms.Label arrayRemoteInfoLabel;
            private WMICodeCreator controlWindow;
           
            // Required designer variable.
            private System.ComponentModel.Container components = null;

            public TargetComputerWindow()
            {
                InitializeComponent();   
            }

			//-------------------------------------------------------------------------
			// Constructor for the TargetComputerWindow class. This constructor
			// creates a pointer to the parent WMICodeCreator form.
			//-------------------------------------------------------------------------
            public TargetComputerWindow(WMICodeCreator form)
            {
                this.controlWindow = form;

                InitializeComponent();
            }


           
            // Clean up any resources being used.
            protected override void Dispose( bool disposing )
            {
                if( disposing )
                {
                    if (components != null) 
                    {
                        components.Dispose();
                    }
                }
                base.Dispose( disposing );
            }

       
            // Required method for Designer support - do not modify
            // the contents of this method with the code editor.
            private void InitializeComponent()
            {
                this.okButton = new System.Windows.Forms.Button();
                this.remoteIntro = new System.Windows.Forms.Label();
                this.computerNameLabel = new System.Windows.Forms.Label();
                this.remoteComputerNameBox = new System.Windows.Forms.TextBox();
                this.remoteComputerDomainBox = new System.Windows.Forms.TextBox();
                this.computerDomainLabel = new System.Windows.Forms.Label();
                this.arrayRemoteComputersBox = new System.Windows.Forms.TextBox();
                this.arrayRemoteInfoLabel = new System.Windows.Forms.Label();
                this.SuspendLayout();
                // 
                // okButton
                // 
                this.okButton.Location = new System.Drawing.Point(104, 224);
                this.okButton.Name = "okButton";
                this.okButton.Size = new System.Drawing.Size(136, 23);
                this.okButton.TabIndex = 0;
                this.okButton.Text = "OK";
                this.okButton.Click += new System.EventHandler(this.okButton_Click);
                // 
                // remoteIntro
                // 
                this.remoteIntro.Location = new System.Drawing.Point(16, 24);
                this.remoteIntro.Name = "remoteIntro";
                this.remoteIntro.Size = new System.Drawing.Size(320, 72);
                this.remoteIntro.TabIndex = 1;
                this.remoteIntro.Text = "You have selected to perform a task using WMI on a remote computer. Fill in the i" +
                    "nformation below about the remote computer. This information will be used in the" +
                    " code created by the WMI Code Creator.";
                // 
                // computerNameLabel
                // 
                this.computerNameLabel.Location = new System.Drawing.Point(24, 104);
                this.computerNameLabel.Name = "computerNameLabel";
                this.computerNameLabel.Size = new System.Drawing.Size(300, 16);
                this.computerNameLabel.TabIndex = 2;
                this.computerNameLabel.Text = "Full Name (or IP Address) of the Remote Computer:";
                // 
                // remoteComputerNameBox
                // 
                this.remoteComputerNameBox.Location = new System.Drawing.Point(24, 120);
                this.remoteComputerNameBox.Name = "remoteComputerNameBox";
                this.remoteComputerNameBox.Size = new System.Drawing.Size(288, 20);
                this.remoteComputerNameBox.TabIndex = 3;
                this.remoteComputerNameBox.Text = "FullComputerName";
                this.remoteComputerNameBox.TextChanged += new System.EventHandler(this.remoteComputerNameBox_TextChanged);
                // 
                // remoteComputerDomainBox
                // 
                this.remoteComputerDomainBox.Location = new System.Drawing.Point(24, 168);
                this.remoteComputerDomainBox.Name = "remoteComputerDomainBox";
                this.remoteComputerDomainBox.Size = new System.Drawing.Size(288, 20);
                this.remoteComputerDomainBox.TabIndex = 5;
                this.remoteComputerDomainBox.Text = "DOMAIN";
                this.remoteComputerDomainBox.TextChanged += new System.EventHandler(this.remoteComputerDomainBox_TextChanged);
                // 
                // computerDomainLabel
                // 
                this.computerDomainLabel.Location = new System.Drawing.Point(24, 152);
                this.computerDomainLabel.Name = "computerDomainLabel";
                this.computerDomainLabel.Size = new System.Drawing.Size(240, 16);
                this.computerDomainLabel.TabIndex = 4;
                this.computerDomainLabel.Text = "Remote Computer Domain:";
                // 
                // arrayRemoteComputersBox
                // 
                this.arrayRemoteComputersBox.Location = new System.Drawing.Point(24, 128);
                this.arrayRemoteComputersBox.Multiline = true;
                this.arrayRemoteComputersBox.Name = "arrayRemoteComputersBox";
                this.arrayRemoteComputersBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
                this.arrayRemoteComputersBox.Size = new System.Drawing.Size(288, 80);
                this.arrayRemoteComputersBox.TabIndex = 6;
                this.arrayRemoteComputersBox.Text = "";
                this.arrayRemoteComputersBox.Visible = false;
                this.arrayRemoteComputersBox.TextChanged += new System.EventHandler(this.arrayRemoteComputersBox_TextChanged);
                // 
                // arrayRemoteInfoLabel
                // 
                this.arrayRemoteInfoLabel.Location = new System.Drawing.Point(16, 96);
                this.arrayRemoteInfoLabel.Name = "arrayRemoteInfoLabel";
                this.arrayRemoteInfoLabel.Size = new System.Drawing.Size(320, 32);
                this.arrayRemoteInfoLabel.TabIndex = 7;
                this.arrayRemoteInfoLabel.Visible = false;
                // 
                // TargetComputerWindow
                // 
                this.AllowDrop = true;
                this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
                this.ClientSize = new System.Drawing.Size(344, 266);
                this.ControlBox = false;
                this.Controls.Add(this.arrayRemoteInfoLabel);
                this.Controls.Add(this.arrayRemoteComputersBox);
                this.Controls.Add(this.remoteComputerDomainBox);
                this.Controls.Add(this.computerDomainLabel);
                this.Controls.Add(this.remoteComputerNameBox);
                this.Controls.Add(this.computerNameLabel);
                this.Controls.Add(this.remoteIntro);
                this.Controls.Add(this.okButton);
                this.Name = "TargetComputerWindow";
                this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                this.Text = "Remote Computer Information";
                this.ResumeLayout(false);

            }
          

			//-------------------------------------------------------------------------
			// Handles the event when the user types in the name of a remote computer.
			// 
			//-------------------------------------------------------------------------
            private void remoteComputerNameBox_TextChanged(object sender, System.EventArgs e)
            {
                this.controlWindow.GenerateEventCode();
                this.controlWindow.GenerateQueryCode();
                this.controlWindow.GenerateMethodCode();
            }

			//-------------------------------------------------------------------------
			// Handles the event when the user types in the domain of a remote computer.
			// 
			//-------------------------------------------------------------------------
            private void remoteComputerDomainBox_TextChanged(object sender, System.EventArgs e)
            {
                this.controlWindow.GenerateEventCode();
                this.controlWindow.GenerateQueryCode();
                this.controlWindow.GenerateMethodCode();
            }

			//-------------------------------------------------------------------------
			// Handles the event when the user clicks the OK button on the form.
			// 
			//-------------------------------------------------------------------------
            private void okButton_Click(object sender, System.EventArgs e)
            {
                this.Visible = false;

                this.controlWindow.GenerateEventCode();
                this.controlWindow.GenerateQueryCode();
                this.controlWindow.GenerateMethodCode();
            }

			//-------------------------------------------------------------------------
			// Handles the event when the user types in the names for a
			// group of remote computers.
			//-------------------------------------------------------------------------
            private void arrayRemoteComputersBox_TextChanged(object sender, System.EventArgs e)
            {
                this.controlWindow.GenerateEventCode();
                this.controlWindow.GenerateQueryCode();
                this.controlWindow.GenerateMethodCode();
            }

			//-------------------------------------------------------------------------
			// Sets the window up to allow the user to type in information
			// for a single remote computer.
			//-------------------------------------------------------------------------
            public void SetForRemoteComputerInfo()
            {
                this.remoteIntro.Text = "You have selected to perform a task using WMI on a remote computer. Fill in the i" +
                    "nformation below about the remote computer. This information will be used in the" +
                    " code created by the WMI Code Creator.";
                this.remoteIntro.Visible = true;
                this.computerDomainLabel.Visible = true;
                this.computerNameLabel.Visible = true;
                this.remoteComputerDomainBox.Visible = true;
                this.remoteComputerNameBox.Visible = true;
                this.arrayRemoteInfoLabel.Visible = false;
                this.arrayRemoteComputersBox.Visible = false;
            }

			//-------------------------------------------------------------------------
			// Sets the window up to allow the user to type in information
			// for a group of remote computers.
			//-------------------------------------------------------------------------
            public void SetForGroupComputerInfo()
            {
                this.remoteIntro.Text = "You have selected to perform a task using WMI on a group of remote computers. " +
                    "Your credentials (user name, password, and domain) will be used to connect to each computer. Make sure you are an Administrator on each computer.";
                this.remoteIntro.Visible = true;
                this.computerDomainLabel.Visible = false;
                this.computerNameLabel.Visible = false;
                this.remoteComputerDomainBox.Visible = false;
                this.remoteComputerNameBox.Visible = false;
                this.arrayRemoteInfoLabel.Visible = true;
                this.arrayRemoteInfoLabel.Text = "List one computer name per line with no blank lines between computer names.";
                this.arrayRemoteComputersBox.Visible = true;
            }

			//-------------------------------------------------------------------------
			// Gets the list of the group of remote computers.
			// 
			//-------------------------------------------------------------------------
            public string GetArrayOfComputers()
            {
                return this.arrayRemoteComputersBox.Text;
            }

			//-------------------------------------------------------------------------
			// Gets the name for a single remote computer.
			//
			//-------------------------------------------------------------------------
            public string GetRemoteComputerName()
            {
                return this.remoteComputerNameBox.Text;
            }

			//-------------------------------------------------------------------------
			// Gets the domain for a single remote computer.
			// 
			//-------------------------------------------------------------------------
            public string GetRemoteComputerDomain()
            {
                return this.remoteComputerDomainBox.Text;
            }
        }



		//---------------------------------------------------------------
		// This class is used to find the .NET framework installation
		// folder.
		//---------------------------------------------------------------
        [ComVisible(false)]
		private class NativeMethods
		{
			[DllImport("mscoree.dll")] static extern string GetCORSystemDirectory
				([MarshalAs(UnmanagedType.LPWStr)] System.Text.StringBuilder buffer,Int32
				buflen, ref Int32 numbytes);

			public static string SystemDirectory()
			{
				System.Text.StringBuilder buf = new System.Text.StringBuilder(1024);
				Int32 iBytes=0;
				string ret= GetCORSystemDirectory(buf,buf.Capacity, ref iBytes);
				return buf.ToString().Substring(0,iBytes-1);
			}

            private NativeMethods()
            {
                // Default Constructor
            }
		}
   
    }


    //----------------------------------------------------------------------------
    // This class is the SplashScreenForm class, which creates a
    // start-up splash screen that appears while the WMICodeCreator is loading
    // WMI classes and gathering information about the WMI classes. The 
    // splash screen contains a status bar and text.
    //----------------------------------------------------------------------------
    [ComVisible(false)]
    public class SplashScreenForm : System.Windows.Forms.Form
    {
        private System.ComponentModel.IContainer components;
        static SplashScreenForm sSForm;
        static Thread splashScreenThread;
        private double opacityIncrease = .05;
        private double opacityDecrease = .1;
        private System.Windows.Forms.Timer timer1;
        private const int TIMER_INTERVAL = 50;
        private System.Windows.Forms.Label statusLabel;
        static System.Windows.Forms.ProgressBar progressBar1;
        private string introText;

		//-------------------------------------------------------------------------
		// Default constructor.
		// 
		//-------------------------------------------------------------------------
        public SplashScreenForm()
        {
            //
            // Required for Windows Form Designer support.
            //
            sSForm = null;
            splashScreenThread = null;
            InitializeComponent();

            this.Opacity = .5;
            timer1.Interval = TIMER_INTERVAL;
            timer1.Start();
            introText = "Initializing the WMI Code Creator. Loading WMI classes...";
            progressBar1.Maximum = 41;
            this.ShowInTaskbar = false;
        }

        
        // Clean up any resources being used.
        protected override void Dispose( bool disposing )
        {
            if( disposing )
            {
                if (components != null) 
                {
                    components.Dispose();
                }
            }
            base.Dispose( disposing );
        }

        
        // Required method for Designer support - do not modify
        // the contents of this method with the code editor.
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusLabel = new System.Windows.Forms.Label();
            progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // statusLabel
            // 
            this.statusLabel.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.statusLabel.Location = new System.Drawing.Point(24, 32);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(232, 72);
            this.statusLabel.TabIndex = 0;
            this.statusLabel.Text = "Initializing the WMI Code Creator. Loading WMI classes...";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressBar1
            // 
            progressBar1.Location = new System.Drawing.Point(24, 115);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new System.Drawing.Size(232, 23);
            progressBar1.TabIndex = 1;
            // 
            // SplashScreenForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(292, 168);
            this.Controls.Add(progressBar1);
            this.Controls.Add(this.statusLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SplashScreenForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WMI Code Creator";
            this.ResumeLayout(false);

        }        
   
		//-------------------------------------------------------------------------
		// A static entry point to launch the splash screen.
		//
		//-------------------------------------------------------------------------
        static private void ShowForm()
        {
            sSForm = new SplashScreenForm();
            Application.Run(sSForm);
        }

		//-------------------------------------------------------------------------
		// A static entry point to close the splash screen.
		//
		//-------------------------------------------------------------------------
        static public void CloseForm()
        {
            if( sSForm != null )
            {
                // Start to close.
                sSForm.opacityIncrease = -sSForm.opacityDecrease;
            }
            sSForm = null;
            splashScreenThread = null;  // Not necessary at this point.
        }

		//-------------------------------------------------------------------------
		// A static method that shows the splash screen.
		//
		//-------------------------------------------------------------------------
        static public void ShowSplashScreen()
        {
            // Only launch once.
            if( sSForm != null )
                return;
            splashScreenThread = new Thread( new ThreadStart(SplashScreenForm.ShowForm));
            splashScreenThread.IsBackground = true;
            splashScreenThread.ApartmentState = ApartmentState.STA;
            splashScreenThread.Start();
        }

		//-------------------------------------------------------------------------
		// A static method to set the status of the splash screen.
		//
		//-------------------------------------------------------------------------
        static public void SetStatus(string newStatus)
        {
            if( sSForm == null )
                return;
            sSForm.introText = newStatus;
        }

		//-------------------------------------------------------------------------
		// A static entry point to launch SplashScreen.
		//
		//-------------------------------------------------------------------------
        private void timer1_Tick_1(object sender, System.EventArgs e)
        {
            if( opacityIncrease > 0.0 )
            {
                if( this.Opacity < 1 )
                    this.Opacity += opacityIncrease;
            }
            else
            {
                if( this.Opacity > 0.0 )
                    this.Opacity += opacityIncrease;
                else
                    this.timer1.Stop();
            }
            
        }

        static public void IncrementProgress()
        {
            progressBar1.Increment(1);
        }

        static public void SetProgressMax(int max)
        {
            progressBar1.Maximum = max;
        }
    }
}
	

