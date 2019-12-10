

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