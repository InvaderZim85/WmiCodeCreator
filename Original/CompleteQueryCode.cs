 
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
        #region Controls and so on...
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
        #endregion
        
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
    }
}