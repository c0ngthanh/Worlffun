using UnityEngine;

public class UnitData : CSVData
{
    public static UnitData[] Table { get; private set; }
    public int ID;
    public string unitName;
    public int Time;
    public int MaxValue;
    public int Money;

    public override void Convert(string[] data)
    {
        Table = new UnitData[data.Length-2]; // Adjust size to exclude header and comment
        for (int i = 2; i < data.Length; i++)
        {
            string[] fields = data[i].Split(','); // Split each line by commas

            Table[i-2] = new UnitData
            {
                ID = int.Parse(fields[0]),
                unitName = fields[1],
                Time = int.Parse(fields[2]),
                MaxValue = int.Parse(fields[3]),
                Money = int.Parse(fields[4])
            };
        }
    }
}
