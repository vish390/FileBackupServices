using System.ComponentModel;
using System.ServiceProcess;
using System.Configuration.Install;

[RunInstaller(true)]
public class ProjectInstaller : Installer
{
    public ProjectInstaller()
    {
        ServiceProcessInstaller processInstaller = new ServiceProcessInstaller();
        ServiceInstaller serviceInstaller = new ServiceInstaller();

        processInstaller.Account = ServiceAccount.LocalSystem;

        serviceInstaller.ServiceName = "FileBackupService";
        serviceInstaller.StartType = ServiceStartMode.Automatic;

        Installers.Add(processInstaller);
        Installers.Add(serviceInstaller);
    }
}
