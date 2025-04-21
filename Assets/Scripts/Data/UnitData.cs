using UnityEngine;

public class UnitData : CSVData
{
    public class RowData{
        public int ID;
        public string unitName;
        public int Time;
        public int MaxValue;
        public string animationName;
    }

    public RowData[] Table { get; private set; }
    public override void Convert(string[] data)
    {
        Table = new RowData[data.Length-2]; // Adjust size to exclude header and comment
        for (int i = 2; i < data.Length; i++)
        {
            string[] fields = data[i].Split(','); // Split each line by commas

            Table[i-2] = new RowData
            {
                ID = int.Parse(fields[0]),
                unitName = fields[1],
                Time = int.Parse(fields[2]),
                MaxValue = int.Parse(fields[3]),
                animationName = fields[4]
            };
        }
    }
    public RowData GetUnitData(int id)
    {
        int left = 0;
        int right = Table.Length - 1;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (Table[mid].ID == id)
            {
                return Table[mid];
            }
            else if (Table[mid].ID < id)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }
        return null; // Return null if not found
    }
}
