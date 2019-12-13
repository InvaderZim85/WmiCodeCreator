# WMI Code Creator - Help

**Content**
<!-- TOC -->

- [Query](#query)
    - [Code generation](#code-generation)
    - [Gather values](#gather-values)
- [Browse](#browse)

<!-- /TOC -->

## Query
One of the main tasks in the WMI is querying WMI for information about computer components and software. For example, you can request that WMI return the name and version of an operation system, or the amount of free disk space on a hard disk. The information that you query is made available through WMI classes that are installed in the WMI repository on a computer. Each class is a poart of a namespace, with each namespace holding similar classes. For example, the `root\CIMV2` namespace contains classes that hold information about the Windows platform and you computer components.

To locate management information through WMI, you use a language similar to SQL called the *WMI Query Language* (WQL). A basic WQL query remains fairly understandable for people with basic knowledge of SQL. Therefore, WQL is dedicated to WMI and is designed to perform queries against the WMI repository to retrieve information or receive event notification.

The following steps describe how to use the WMI Code Creator to query WMI for data:

1. Select a namespace. Each namespace holds classes that expose different types of information. The most commonly used namespace is `root\CIMV2` because it contains most of the classes that model Windows managed resources.

2. Select a class from the namespace. THe class list is populated with classes from the selected namespace that have a dynamic qualifier (classes that are instantiated and expose data) or static qualifier.

### Code generation
If you select a property from the list, the property will be automatically added to the generated code.

### Gather values
If you click the *Gather Values* button, all available values for the properties will be loaded.

> **Note**: The query is aborted after 30 seconds to prevent the program from running forever.


## Browse
Each class in WMI is in a namespace, with each namespace holding similar classes. For example the `roo\CIMV2` namespace contains classes that hold information about the Windows platform and your computer components. Each WMI class can have properties, methods and qualifiers. A qualifier is a modifier that contains information that describes a class, instance, property, method or parameter. Qualifiers are defined by the Common Information Model (CIM), by the CIM Object Manager and by developers who create new classes.

The following steps describe how to use the WMI Code Creator to browse the namespace:

1. Select a namespace. Each namespaces holds classes that expose different data. The most commonly used namespace is `root\CIMV2`.

2. Select a class from the namespace. The class list is populated with all classes from the selected namespace. If the selected class has a *Description* qualifier, then the value of the that qualifier is displayed in the Class description box.

3. When you select a property in the property list, the property description is displayed. The property description comes from the value of the *Description* qualifier for the selected property.

### Additional data
Click the *Load additional data* to populate the method and the qualifier list with all the methods and qualifiers from the selected class.

When you select a method in the method list, the method description is displayed. The method description comes from the value of the *Description* qualifier for the selected method.