# 🗂️ FileBackupService (Windows Service in C#)

This project is a **Windows Service** built in **C#** that performs **automatic file backups** at specified intervals. It demonstrates how to create, install, and run a Windows Service using .NET Framework.

---

## 🚀 Features

- Built using the `ServiceBase` class
- Custom **backup logic** for files or directories
- Uses `ServiceProcessInstaller` and `ServiceInstaller` for deployment
- Can be installed via `InstallUtil.exe`
- Writes logs for backup operations

---

## 🔧 Technologies Used

- C# (.NET Framework)
- Windows Service infrastructure
- InstallUtil.exe
- System.IO for file handling
- System.Timers for scheduling
- Visual Studio (for development and service design)

---

## 🏗️ Project Structure

```

/FileBackupService/
├── FileBackupService.cs           # Main service logic (inherits ServiceBase)
├── ProjectInstaller.cs            # Contains ServiceInstaller and ServiceProcessInstaller
├── Program.cs                     # Main entry point (ServiceBase.Run)
├── FileBackupServiceInstaller.bat # Optional: Batch file to install the service
├── FileBackupService.sln          # Visual Studio solution file
└── README.md                      # Project documentation

````

---

## 📦 Key Components

### ✅ Service Base Class

`FileBackupService.cs` inherits from `ServiceBase` and overrides:

```csharp
protected override void OnStart(string[] args)
{
    // Start timer or backup logic
}

protected override void OnStop()
{
    // Clean up resources
}
````

---

### ✅ Service Installer

`ProjectInstaller.cs` adds two installer classes:

```csharp
public class ProjectInstaller : Installer
{
    public ProjectInstaller()
    {
        ServiceInstaller serviceInstaller = new ServiceInstaller
        {
            ServiceName = "FileBackupService",
            StartType = ServiceStartMode.Automatic
        };

        ServiceProcessInstaller processInstaller = new ServiceProcessInstaller
        {
            Account = ServiceAccount.LocalSystem
        };

        Installers.Add(serviceInstaller);
        Installers.Add(processInstaller);
    }
}
```

---

## 🧪 How to Install the Service

### 1. Build the project in **Release** mode

The output will be in:

```
/bin/Release/FileBackupService.exe
```

### 2. Open **Command Prompt as Administrator**

### 3. Install the service using `InstallUtil.exe`

```bash
C:\Windows\Microsoft.NET\Framework\v4.0.30319\InstallUtil.exe FileBackupService.exe
```

> 📝 Tip: Make sure to use the correct .NET version path.

### 4. Start the service

```bash
net start FileBackupService
```

---

## 📤 Uninstall the Service

```bash
C:\Windows\Microsoft.NET\Framework\v4.0.30319\InstallUtil.exe /u FileBackupService.exe
```

---

## 📁 File Backup Logic

You can implement your backup logic inside `OnStart`, for example:

```csharp
private void BackupFiles()
{
    string sourcePath = @"C:\SourceFolder";
    string backupPath = @"D:\BackupFolder";

    foreach (var file in Directory.GetFiles(sourcePath))
    {
        File.Copy(file, Path.Combine(backupPath, Path.GetFileName(file)), true);
    }
}
```

---

## 🛠️ Future Improvements

* Make file paths configurable (from config file)
* Add logging to a text file or Event Viewer
* Add email notifications on failure/success
* Schedule backup using `System.Timers.Timer`

---

## 📄 License

This project is for educational and demonstration purposes.

---

## 📩 Contact

**Author**: Vishal Waghmode
**Email**: vishalwaghmode247@gmail.com.

