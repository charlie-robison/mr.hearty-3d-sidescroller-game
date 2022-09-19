using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    private GameObject gameObject;
    private GameObject startPoint;
    private GameObject endPoint;
    private float startTime;
    private bool isMovingLeft;

    public MoveEnemy(GameObject gameObject, GameObject start, GameObject end, float startTime, bool isMovingLeft)
    {
        this.gameObject = gameObject;
        this.startPoint = start;
        this.endPoint = end;
        this.startTime = startTime;
        this.isMovingLeft = isMovingLeft;
    }

    public void sideToSideMovement(float velocity, float journeyLength)
    {
        float totalTime = journeyLength / velocity;
        float currentTime = Time.time - this.startTime;

        // Increments and decrements between currentTime and totalTime and gets the distance covered.
        float distanceCovered = Mathf.PingPong(currentTime, totalTime);

        // Checks if enemy covered the distance.
        if (distanceCovered >= (journeyLength - 0.1f))
        {
            this.isMovingLeft = false;
        }
        // Checks if enemy returned to starting position.
        else if (distanceCovered <= 0.1f)
        {
            this.isMovingLeft = true;
        }

        // Gets a fraction of the distance covered over the entire journey length.
        float fractionOfJourney = distanceCovered / journeyLength;

        // Gets current position on the line between the start and end by returning the fraction of the distance from fractionOfJourney.
        this.gameObject.transform.position = Vector3.Lerp(this.startPoint.transform.position, this.endPoint.transform.position, fractionOfJourney);

        rotateEnemySideToSide();
    }

    private void rotateEnemySideToSide()
    {
        if (this.isMovingLeft)
        {
            this.gameObject.transform.eulerAngles = new Vector3(0f, -90f, 0f);
        }
        else
        {
            this.gameObject.transform.eulerAngles = new Vector3(0f, 90f, 0f);
        }
    }

    public int getDirection()
    {
        if (this.isMovingLeft)
        {
            return -1;
        }
        
        return 1;
    }
}
