using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehavior : MonoBehaviour
{
    //movement axis and movement distance for computing open and closed positions
    public Vector3 movementAxis;
    public float distance;

    //open and closed positions of this door
    private Vector3 openPos;
    private Vector3 closedPos;

    // The amount of frames this animation should take
    public float frames;

    private void Start()
    {
        //Assume the door starts closed. how would you fix this if you can't make this assumption?
        closedPos = transform.position;
        openPos = closedPos + (movementAxis * distance);
    }

    public void CloseGate()
    {
        //Without Coroutines
        //transform.Translate(movementAxis * distance * -1f, Space.World);

        StopAllCoroutines();
        StartCoroutine(MoveDoor(transform.position, closedPos, 1 / frames));
    }

    public void OpenGate()
    {
        //Without Coroutines
        //transform.Translate(movementAxis * distance, Space.World);

        StopAllCoroutines();
        StartCoroutine(MoveDoor(transform.position, openPos, 1 / frames));
    }

    public IEnumerator MoveDoor(Vector3 startpos, Vector3 endPosition,float step)
    {
        for (float i = 0; i <= 1; i += step)
        {
            Vector3 newPosition = Vector3.Lerp(startpos, endPosition, i);
            transform.position = newPosition;

            //makes the coroutine pause until the next frame
            yield return null;
        }
    }
}
