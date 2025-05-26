using System;
using System.IO;
using System.ServiceProcess;
using System.Timers;

namespace FileBackupService
{
    internal class FileBackupService : ServiceBase
    {
        Timer timer;
        string sourceDirectory = @"C:\Users\vishal waghmode\OneDrive\Desktop\Source";  // Must be a folder
        string backupDirectory = @"C:\Users\vishal waghmode\OneDrive\Desktop\Backup";  // Must be a folder

        public FileBackupService()
        {
            ServiceName = "FileBackupService";
        }

        protected override void OnStart(string[] args)
        {
            Directory.CreateDirectory(sourceDirectory);
            Directory.CreateDirectory(backupDirectory);
            Directory.CreateDirectory(@"C:\temp");

            File.AppendAllText(@"C:\temp\log.txt", $"Service started at {DateTime.Now}{Environment.NewLine}");

            timer = new Timer(60000); // Run every 60 seconds
            timer.Elapsed += OnElapsedTime;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        private void OnElapsedTime(object sender, ElapsedEventArgs e)
        {
            try
            {
                foreach (var file in Directory.GetFiles(sourceDirectory))
                {
                    var fileName = Path.GetFileName(file);
                    var destFile = Path.Combine(backupDirectory, fileName);
                    File.Copy(file, destFile, true);
                }

                File.AppendAllText(@"C:\temp\log.txt", $"Backup performed at {DateTime.Now}{Environment.NewLine}");
            }
            catch (Exception ex)
            {
                File.AppendAllText(@"C:\temp\log.txt", $"Error: {ex.Message}{Environment.NewLine}");
            }
        }

        protected override void OnStop()
        {
            timer.Stop();
            File.AppendAllText(@"C:\temp\log.txt", $"Service stopped at {DateTime.Now}{Environment.NewLine}");
        }
    }
}
