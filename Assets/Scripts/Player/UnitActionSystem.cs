using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitActionSystem : MonoBehaviour
{
    [SerializeField] private Transform selectedUnit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleActionSelection();
    }

    private void HandleActionSelection()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitObject = MouseWorld.GetObject();
            switch (hitObject.transform.tag)
            {
                case "Player":
                    HandlePlayerSelect(hitObject);
                    break;
                case "ActionItem":
                    break;
                case "Building":
                    break;
                case "Tranport":
                    break;
                default:
                    Debug.Log("Entering into default");
                    MoveAction(hitObject);
                    break;

            }
        }
    }

    private void MoveAction(RaycastHit hitObject)
    {
        MoveAction moveAction = selectedUnit.GetComponent<MoveAction>();
        moveAction.SetDestination(hitObject.point);
    }

    private void HandlePlayerSelect(RaycastHit hitObject)
    {
        selectedUnit = hitObject.transform;
    }
}
