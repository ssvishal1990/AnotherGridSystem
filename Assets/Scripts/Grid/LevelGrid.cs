using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGrid : MonoBehaviour
{
    [SerializeField] int height = 10;
    [SerializeField] int widhth = 10;
    [SerializeField] float cellSize = 2f;

    private GridSystem gridSystem;
    private Grid[,] grid;

    [SerializeField] private Transform gridDebugObjectPrefab;

    public static LevelGrid Instance { get; private set; }

    public event EventHandler onAnyUnitMovedGridPosition;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("More than 1 unit action system  " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;
        gridSystem = new GridSystem(height, widhth, cellSize);
        gridSystem.CreateDebugObjects(gridDebugObjectPrefab);
        //gridSystem = new GridSystem(10, 10, 2f);
        //gridSystem.CreateDebugObjects(gridDebugObjectPrefab);
    }


    public GridPosition getGridPosition(Vector3 Pos) => gridSystem.GetGridPosition(Pos);

    public Vector3 getWorldPosition(GridPosition Pos) => gridSystem.GetWorldPosition(Pos);

    public bool isValidGridPosition(GridPosition gridPosition) => gridSystem.isValidGridPosition(gridPosition);

    public int getHeight() => gridSystem.getHeight();

    public int getWidth() => gridSystem.getWidhth();

    public GridObject[,] getGrid() => gridSystem.getGrid();

    public GridObject GetGridObject(GridPosition gridPosition) => gridSystem.GetGridObject(gridPosition);

    /// <summary>
    /// Get Grid Object at a specific position
    /// </summary>
    /// <param name="position"></param>
    /// <returns></returns>
    public GridObject GetGridObject(Vector3 position)
    {
        return gridSystem.GetGridObject(gridSystem.GetGridPosition(position));
    }

    /// <summary>
    /// Get Grid Object with a specific index
    /// </summary>
    /// <returns></returns>
    public GridObject GetGridObject(int x, int y) => gridSystem.GetGridObject((int)x, (int)y);

    public List<GridPosition> GetAllGridPositions() => gridSystem.getAllGridPositions();

}
