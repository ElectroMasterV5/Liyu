using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public int moveSpeed;
    private int index;
    private Transform targetPoint;
    // Start is called before the first frame update
    void Start()
    {
        targetPoint = startPoint;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPoint.position, moveSpeed * Time.deltaTime);
        if (Vector2.Distance(transform.position, targetPoint.position) < 0.5f)
        {
            SwitchPoint();
        }
    }

    private void SwitchPoint()
    {
        var position = transform.position;
        targetPoint = Mathf.Abs(startPoint.position.x - position.x) 
                      > Mathf.Abs(endPoint.position.x - position.x) ? startPoint : endPoint;
    }
}
