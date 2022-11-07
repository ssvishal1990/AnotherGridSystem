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

    public List<GridPosition> GetAllGridPositions() => gridSystem.getAllGridPositions();

}
