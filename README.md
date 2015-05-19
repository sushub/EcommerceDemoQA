# EcommerceDemoQA
UI Automation tests

Set up required for automated browser tests for http://store.demoqa.com

Test Environment:
1.	Install Visual Studio 2013 (OS used was Windows 8.0).
2.	Install Selenium web driver and “selenium-dotnet-2.45.0” 
3.	Install latest version of the Chrome browser ()
4.	Download the complete solution from the link and Extract the files.
5.	Open the solution in Visual Studio and build the solution.
6.	In Visual Studio, add the "Test Explorer" (Test / Windows / Test Explorer).
7.	Run the tests in the solutions.

Assumption:
Only a reference to chrome driver has been added to the solution
If the tests are to be run against any other browser, respective references to its drivers need to be added to the solution. 

Issues Found:
1.	State field in Order Form does not have any content. 
2.	Xpaths for some of the controls are embedded as plain text paragraphs which makes it difficult to access them.
        e.g. In Transaction Results page, Shipping Price , Total Price are in a paragraph tag.  
3.	Modal dialogs for check out has static text and does not change with specific product selected.
        e.g.: Modal dialog displays “Mouse selected” even if some other product is selected.
