using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentinelMovement : MonoBehaviour
{
    public GameObject obj;
    float yPos = 0;
    bool hoverState = true;
    
    // Start is called before the first frame update
    void Start()
    {
        //obj = this.GetComponent<Transform>;
    }

    // Update is called once per frame
    void Update()
    {
        if ((obj.transform.position.y > 2 && obj.transform.position.y < 4) && hoverState) {
            yPos = obj.transform.position.y;
            yPos += 0.5f;
            obj.transform.position = new Vector3(0, yPos, 0);
        }
        if (obj.transform.position.y > 4) {
            yPos = obj.transform.position.y;
            yPos -= 0.5f;
            obj.transform.position = new Vector3(0, yPos, 0);
            hoverState = false;
        }
        if (obj.transform.position.y < 2 && hoverState == false) {
            hoverState = true;
            yPos = obj.transform.position.y;
            yPos += 0.5f;
            obj.transform.position = new Vector3(0, yPos, 0);
        }
    }
}
