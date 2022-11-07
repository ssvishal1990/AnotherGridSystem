using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridObject 
{
    GridPosition gridPosition;
    GameObject gameObjectOnTopOfThisGrid;
    GridSystem gridSystem;


    public GridObject(GridPosition gridPosition, GameObject gameObjectOnTopOfThisGrid)
    {
        this.gridPosition = gridPosition;
        this.gameObjectOnTopOfThisGrid = gameObjectOnTopOfThisGrid;
    }

    public GridObject(GridSystem gridSystem, GridPosition gridPosition)
    {
        this.gridSystem = gridSystem;
        this.gridPosition = gridPosition;
    }

    public string getGridObjectPosition()
    {
        if (gameObjectOnTopOfThisGrid == null)
        {
            return gridPosition.ToString();
        }else
        {
            return gridPosition.ToString() + gameObjectOnTopOfThisGrid.name;
        }
    }

    public GridPosition GetGridPosition()
    {
        return gridPosition;
    }
}
