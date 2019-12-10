# WmiCodeCreator

This tool is a new version of the [Microsoft WMI Code Creator](https://www.microsoft.com/en-us/download/details.aspx?id=8572) which is already outdated and apparently no longer being developed further. 
The original WMI Code Creator still uses the .NET Framework 2. Because of some security settings of my company I can't use the original code creator because the .NET Framework 2 / 3.5 is missing on my PC and I can't install it.

Therefore I decided to update the source code of the WMI Code Creator (which is available as a file) and implement it as a WPF application.
I removed all functions that I currently don't need, such as generating VB code, and split the code into several classes to improve readability.

I have divided the development into different phases:
1. Implementation of the main WPF application, the query tab and the help region
2. Implementation of the browse tab
3. Implementation of the method tab
4. Implementation of the event tab

Current state: Phase 1 (10.12.2019)
