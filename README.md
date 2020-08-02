# AddInSpy

AddInSpy is a diagnostic tool that discovers all registered Microsoft Office add-ins on a computer, and then reports as much information as it can about those add-ins. The tool works with all versions of all Microsoft Office applications that support COM add-ins, and all types of COM add-ins.

Original AddInSpy tool was [developed by VSTO team][1] in Microsoft.

This source code is based on disassembled version of original AddInSpy.

## Features

**AddInSpy** is a standalone WPF application. **AddInSpy** is a simple front-end for the `AddInScanEngine.dll` – this DLL contains all the main scanning functionality.

The scan engine scans the registry for Office add-ins, and reports the following details:

* Whether the host application is running, and whether the add-in is loaded.
* The type of each add-in: _VSTO_, _managed non-VSTO_, _native_.
* `FriendlyName`, `ProgID`, `CLSID` and `LoadBehavior` of the add-in.
* Manifest path, assembly path, and assembly strong name.
* Registry hive (HKCU or HKLM) where the add-in is registered.
* CLR version the add-in was built against.
* VSTO runtime version used by the add-in.
* Installed date, and publish version.
* Which extensibility interfaces the add-in implements for Ribbon, custom taskpane, etc (including via VSTO wrappers).
* Whether the add-in exposes itself for automation through the COMAddIns collection of the Office host application.
* Whether the add-in is in the disabled items list for the current user, for each selected Office host application.
* Whether the add-in is registered as the provider for any custom form regions.
* Context information: machine name, user/domain name, OS details, VSTO environment variables.

Reports can be displayed in a grid on-screen and can also be logged to an XML file for printing.


## License

**AddInSpy** source code is licensed under [Microsoft Public License](LICENSE.txt)

[1]: https://web.archive.org/web/20140411132835/http://blogs.msdn.com/b/vsto/archive/2008/10/02/diagnosing-troubleshooting-office-add-ins-with-addinspy-beth-massi.aspx
