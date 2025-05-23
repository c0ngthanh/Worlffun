using UnityEngine;
using System.IO;
using Unity.VisualScripting;

public class CSVReader
{
    public static CSVReader Instance;
    private const string filePath = "Assets/Resources/Data/";
    public UnitData unitData = new UnitData();
    public void ConvertAll()
    {
        ConvertCSVIntoGame("UnitData.csv", unitData);
    }

    private void ConvertCSVIntoGame(string fileName, CSVData data)
    {
        string fullPath = filePath + fileName;

        if (!File.Exists(fullPath))
        {
            Debug.LogError($"File not found: {fullPath}");
            return;
        }

        string[] lines = File.ReadAllLines(fullPath); // Read file line by line
        data.Convert(lines);
    }
}
