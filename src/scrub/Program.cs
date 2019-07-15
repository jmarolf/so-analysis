#nullable enable
using System;
using System.IO;
using System.Threading.Tasks;

class Program {
    const string header = "Id, PostTypeId, AcceptedAnswerId. ParentId, CreationDate, Score, ViewCount. Body, OwnerUserId, LastEditorUserId, LastEditorDisplayName, LastEditDate, LastActivityDate, Title, Tags, AnswerCount, CommentCount. FavoriteCount, CommunityOwnedDate";


    static async Task Main(string[] args) {
        using var readStream = new StreamReader(File.OpenRead(args[0]));
        using var writeStream = new StreamWriter(File.OpenWrite(Path.GetFileNameWithoutExtension(args[0]) + ".csv"));
        await writeStream.WriteLineAsync(header);
        int i = 0;
        while (!readStream.EndOfStream) {
            var line = await readStream.ReadLineAsync();
            i++;
            if (i < 3) {
                continue;
            }
            var newLine = ParseLineAndGetString(line);
            await writeStream.WriteLineAsync(newLine);
        }
    }

    private static string ParseLineAndGetString(string? line) {
        var elements = line?.Split(' ');
        if (elements is null) {
            return string.Empty;
        }

        var id = Array.Find(elements, e => e.StartsWith("Id"));
        var PostTypeId = Array.Find(elements, e => e.StartsWith("PostTypeId"));
        var AcceptedAnswerId = Array.Find(elements, e => e.StartsWith("AcceptedAnswerId"));
        var ParentId = Array.Find(elements, e => e.StartsWith("ParentId"));
        var CreationDate = Array.Find(elements, e => e.StartsWith("CreationDate"));
        var Score = Array.Find(elements, e => e.StartsWith("Score"));
        var ViewCount = Array.Find(elements, e => e.StartsWith("ViewCount"));
        // ???
        var Body = Array.Find(elements, e => e.StartsWith("Body"));
        var OwnerUserId = Array.Find(elements, e => e.StartsWith("OwnerUserId"));
        var LastEditorUserId = Array.Find(elements, e => e.StartsWith("LastEditorUserId"));
        var LastEditorDisplayName = Array.Find(elements, e => e.StartsWith("LastEditorDisplayName"));
        var LastEditDate = Array.Find(elements, e => e.StartsWith("LastEditDate"));
        var LastActivityDate = Array.Find(elements, e => e.StartsWith("LastActivityDate"));
        var Title = Array.Find(elements, e => e.StartsWith("Title"));
        var Tags = Array.Find(elements, e => e.StartsWith("Tags"));
        var AnswerCount = Array.Find(elements, e => e.StartsWith("AnswerCount"));
        var CommentCount = Array.Find(elements, e => e.StartsWith("CommentCount"));
        var FavoriteCount = Array.Find(elements, e => e.StartsWith("FavoriteCount"));
        var CommunityOwnedDate = Array.Find(elements, e => e.StartsWith("CommunityOwnedDate"));


        return string.Empty;
    }
}
