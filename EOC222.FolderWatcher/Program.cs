using System.IO;
namespace EOC222.FolderWatcher
{
    internal class Program
    {
       

        static void Main(string[] args)
        {
            Console.WriteLine("File System Watcher");
            string path = @"C:\Users\david\Desktop\OEC222";
            using var watcher = new FileSystemWatcher(path);

            watcher.NotifyFilter = NotifyFilters.Attributes
                | NotifyFilters.CreationTime
                | NotifyFilters.DirectoryName
                | NotifyFilters.FileName
                | NotifyFilters.LastAccess
                | NotifyFilters.LastWrite
                | NotifyFilters.Security
                | NotifyFilters.Size;

            watcher.Changed += OnChanged;
            watcher.Changed += (sender, e) =>
            {
                Console.WriteLine("Secondo Handler");
                Console.WriteLine(e.ToString());
            };
            watcher.Created += OnCreated;
            watcher.Deleted += OnDeleted;
            watcher.Renamed += (sender, e) =>
            {
                Console.WriteLine("Renamed:");
                Console.WriteLine($"\t\tOld: {e.OldFullPath}\n\t\tNew: {e.FullPath}");
            };
            watcher.Error += OnError;

            watcher.Changed -= OnChanged;
            

            watcher.IncludeSubdirectories = true;
            watcher.EnableRaisingEvents = true;

            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();
        }

        private static void OnChanged(object sender, FileSystemEventArgs e)
        {
            if(e.ChangeType != WatcherChangeTypes.Changed)
            {
                return;
            }
            Console.WriteLine($"Changed: {e.FullPath}");
        }

        private static void OnCreated(object sender, FileSystemEventArgs e)
        {
            string value = $"Created: {e.FullPath}";
            Console.WriteLine(value);
        }

        private static void OnDeleted(object sender, FileSystemEventArgs e)
        {
            string value = $"Deleted: {e.FullPath}";
            Console.WriteLine(value);
        }

        private static void OnError(object sender, ErrorEventArgs e)
        {
            var exc = e.GetException();
            if (exc != null)
            {
                Console.WriteLine($"Message: {exc.Message}");
                Console.WriteLine($"Stacktrace: {exc.StackTrace}");
            }
        }

    }
}