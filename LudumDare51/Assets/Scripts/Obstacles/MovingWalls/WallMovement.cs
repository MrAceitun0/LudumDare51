using System.Collections;
using UnityEngine;

public class WallMovement : MonoBehaviour
{
    [SerializeField]
    int closedPhase;

    [SerializeField]
    float closedDoorYValue;

    [SerializeField]
    float openDoorYValue;

    [SerializeField]
    float movementTime;

    public void moveWall(float phase)
    {
        if(phase == closedPhase)
        {
            closeDoor();
        } 
        else
        {
            openDoor();
        }
    }

    private void closeDoor()
    {
        StartCoroutine(LerpFunction(closedDoorYValue, movementTime));
    }

    private void openDoor()
    {
        StartCoroutine(LerpFunction(openDoorYValue, movementTime));
    }

    IEnumerator LerpFunction(float endValue, float duration)
    {
        float time = 0;
        float startValue = transform.position.y;

        while (time < duration)
        {
            transform.position = new Vector3(transform.position.x, Mathf.Lerp(startValue, endValue, time / duration), transform.position.z);
            time += Time.deltaTime;
            yield return null;
        }

        transform.position = new Vector3(transform.position.x, endValue, transform.position.z);
    }
}
