namespace TrainingApp.ConsoleApp
{
    internal class Program
    {
        static void Main(String[] args)
        {
            while (true)
            {
                // there the start of program
                Console.Write(">> ");
                var input = Console.ReadLine().Trim();
                var whiteSpaceIndex = input.IndexOf(' ');
                var command = input.Substring(0, whiteSpaceIndex).ToLower();
                var path = input.Substring(whiteSpaceIndex + 1).Trim();

                if (command == "list")
                {
                    foreach (var entry in Directory.GetDirectories(path))
                        Console.WriteLine($"[dir]\t {entry}");
                    foreach (var entry in Directory.GetFiles(path))
                        Console.WriteLine($"[file]\t {entry}");
                }
                else if (command == "info")
                {
                    if (Directory.Exists(path))
                    {
                        var dirInfo = new DirectoryInfo(path); ;
                        Console.WriteLine("The type is dir");
                        Console.WriteLine($"the dir created At: {dirInfo.CreationTime}");
                        Console.WriteLine($"The dir modified At: {dirInfo.LastWriteTime}");
                    }
                    else if (File.Exists(path))
                    {
                        var fileInfo = new FileInfo(path);
                        Console.WriteLine("The Type : File");
                        Console.WriteLine($"THe time created At : {fileInfo.CreationTime}");
                        Console.WriteLine($"the last modified time at: {fileInfo.LastWriteTime}");
                    }
                    else
                    {
                        Console.WriteLine("the path does't exists!");
                    }



                }
                else if (command == "mkdir")
                {
                    Directory.CreateDirectory(path);

                }
                else if (command == "remove")
                {
                    Directory.Delete(path);

                }
                else if (command == "print")
                {
                    if (File.Exists(path))
                    {
                        var content = File.ReadAllText(path);
                        Console.WriteLine(content);
                    }
                }
                else if (command == "exit")
                {
                    break;
                }
            }
        }

    }
}