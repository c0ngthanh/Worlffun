using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCustom : MonoBehaviour
{
    [SerializeField] private GameObject cellPrefab;
    [SerializeField] private int gridWidth = 1;
    [SerializeField] private int gridHeight = 1;
    [SerializeField] private float cellSize = 1.0f;
    private GameObject[][] gridCells;
    private void Start()
    {
        CreateGrid();
    }
    private void CreateGrid()
    {
        gridCells = new GameObject[gridWidth][];
        for (int x = 0; x < gridWidth; x++)
        {
            gridCells[x] = new GameObject[gridHeight];
            for (int y = 0; y < gridHeight; y++)
            {
                Vector3 position = new Vector3(x * cellSize, -y * cellSize,0);
                GameObject cell = Instantiate(cellPrefab, transform);
                cell.transform.localPosition = position;
                gridCells[x][y] = cell;
            }
        }
    }
}
