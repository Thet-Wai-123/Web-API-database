﻿using In_Memory_Database.Classes;
using Newtonsoft.Json;

public class FileManager
{
    public static void SaveToDisk(DataTable table, string dir)
    {
        string jsonString = JsonConvert.SerializeObject(table);

        Directory.CreateDirectory(Path.GetDirectoryName(dir));
        string path = $"{dir}{table.Name}.json";

        File.WriteAllText(path, jsonString);
    }

    public static List<DataTable> ReadFromDisk(string dir)
    {
        string[] tablesToBeGenerated = Directory.GetFiles(dir);
        List<DataTable> tablesToReturn = [];

        foreach (string tablePath in tablesToBeGenerated)
        {
            using (StreamReader sr = File.OpenText(tablePath))
            {
                string infoJson = sr.ReadToEnd();
                tablesToReturn.Add(JsonConvert.DeserializeObject<DataTable>(infoJson));
            }
        }
        return tablesToReturn;
    }
}
