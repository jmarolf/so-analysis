using System;
using System.IO;
using System.Threading.Tasks;

class Program{
    static async Task Main(string[] args){
        using var stream = new StreamReader(File.OpenRead(args[0]));
        for (var i = 0; i < 100; i++){
            var line = await stream.ReadLineAsync();
            await Console.Out.WriteLineAsync(line);
        }
    }
}

