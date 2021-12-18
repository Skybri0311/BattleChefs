using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovablePlatform : MonoBehaviour
{
    public List<Transform> points;
    public int nextID = 0;
    int idChangeValue = 1;
    public int speed = 2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        MoveToNextPoint();
    }

    void MoveToNextPoint()
    {
        //Get the next point transform
        Transform goalPoint = points[nextID];
        //move the enemy towards the goal point
        transform.position = Vector2.MoveTowards(transform.position, goalPoint.position, speed * Time.deltaTime);
        //check the distance between platform and goal point to trigger next point
        if (Vector2.Distance(transform.position, goalPoint.position) < 1f)
        {
            //Check if we are at the end of the line (make the change -1)
            if (nextID == points.Count - 1)
                idChangeValue = -1;
            //Check if we are at the start of the line (make the change 1)
            if (nextID == 0)
                idChangeValue = 1;
            //Apply the change on the nextID
            nextID += idChangeValue;
        }
    }
}
