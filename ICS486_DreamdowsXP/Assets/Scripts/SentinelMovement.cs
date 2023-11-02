using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentinelMovement : MonoBehaviour
{
    //public GameObject obj;
    float yPos = 0;
    bool hoverState = true;

    public float moveSpeed = 3f;
    float rotateSpeed = 90f;
    bool isWandering = false;
    bool isRotatingLeft = false;
    bool isRotatingRight = false;
    bool isMoving = false;
    
    // Start is called before the first frame update
    void Start()
    {
        //obj = this.GetComponent<Transform>;
    }

    // Update is called once per frame
    void Update()
    {
        // isWandering variable is used so the object doesn't move constantly
        if (!isWandering)   StartCoroutine("Wander");

        // transform.up is y-axis, transform.right is x-axis

        if (isRotatingLeft) transform.Rotate(transform.up * Time.deltaTime * -rotateSpeed);

        if (isRotatingRight) transform.Rotate(transform.up * Time.deltaTime * rotateSpeed);

        if (isMoving)   transform.position += transform.forward * moveSpeed * Time.deltaTime; 

        // if ((obj.transform.position.y > 2 && obj.transform.position.y < 4) && hoverState) {
        //     yPos = obj.transform.position.y;
        //     yPos += 0.5f;
        //     obj.transform.position = new Vector3(0, yPos, 0);
        // }
        // if (obj.transform.position.y > 4) {
        //     yPos = obj.transform.position.y;
        //     yPos -= 0.5f;
        //     obj.transform.position = new Vector3(0, yPos, 0);
        //     hoverState = false;
        // }
        // if (obj.transform.position.y < 2 && hoverState == false) {
        //     hoverState = true;
        //     yPos = obj.transform.position.y;
        //     yPos += 0.5f;
        //     obj.transform.position = new Vector3(0, yPos, 0);
        // }
    }

    IEnumerator Wander() 
    {
        // the time for object to wait, rotate, and move is a minimum of one second
        int waitTime = Random.Range(1, 5);

        // 0 being left, 1 being right, actual range is [0, 1]
        int left_or_right = Random.Range(0, 2);

        int rotateDuration = Random.Range(1, 3);
        int moveDuration = Random.Range(1, 4);

        isWandering = true;

        // before object moves, it must determine its rotation to choose a direction to move
        if (left_or_right == 0) 
        {
            // rotate left for a few seconds
            isRotatingLeft = true;
            yield return new WaitForSeconds(rotateDuration);
            isRotatingLeft = false;
        }
        if (left_or_right == 1) 
        {
            // rotate right for a few seconds
            isRotatingRight = true;
            yield return new WaitForSeconds(rotateDuration);
            isRotatingRight = false;
        }

        //yield return new WaitForSeconds(waitTime);

        // moves forward (based on its chosen rotation) for a few seconds 
        isMoving = true;
        // Debug.Log(isMoving);
        yield return new WaitForSeconds(moveDuration);
        isMoving = false;
        // Debug.Log(isMoving);

        // stays stationary for a few seconds
        yield return new WaitForSeconds(waitTime);
        isWandering = false;
    }
}
