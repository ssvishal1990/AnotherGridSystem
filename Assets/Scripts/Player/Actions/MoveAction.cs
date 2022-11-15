using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAction : MonoBehaviour
{
    [SerializeField] private float stoppingDistance = 0.5f;
    [SerializeField] private float speed = 5f;

    Vector3 targetPosition;
    // Start is called before the first frame update
    void Start()
    {
        targetPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        CheckAndMove();
    }

    private void CheckAndMove()
    {
        float distance = Vector3.Distance(transform.position, targetPosition);
        if (distance > stoppingDistance)
        {
            targetPosition.y = transform.position.y;
            Vector3 moveDirection = (transform.position - targetPosition).normalized * -1;
            transform.position += moveDirection * Time.deltaTime * speed;
        }else
        {
            return;
        }
    }

    public void SetDestination(Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;
    }
}
