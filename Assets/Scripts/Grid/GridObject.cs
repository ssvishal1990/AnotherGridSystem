using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridObject 
{
    public GridPosition gridPosition;
    public GridPosition cameFromGridPosition;
    public GridObject cameFromGridObject;

    GameObject gameObjectOnTopOfThisGrid;
    GridSystem gridSystem;


    GridObject cameFromNode;


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

    public override bool Equals(object obj)
    {
        return obj is GridObject position &&
               gridPosition == position.gridPosition;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override string ToString()
    {
        return gridPosition.ToString();
    }
}
