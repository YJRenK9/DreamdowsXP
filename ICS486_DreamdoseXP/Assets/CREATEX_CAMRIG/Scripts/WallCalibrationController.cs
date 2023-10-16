using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCalibrationController : MonoBehaviour
{
    public void ResetToDefault ()
    {
        if(this.gameObject.tag == "Wall_Left")
        {
            this.gameObject.transform.position = new Vector3(-5.791f, 1.2192f, -3.62f);
            this.gameObject.transform.localScale = new Vector3(10.58f, 2.4384f, 1f);
        }

        if(this.gameObject.tag == "Wall_Right")
        {
            this.gameObject.transform.position = new Vector3(5.791f, 1.2192f, -2.86f);
            this.gameObject.transform.localScale = new Vector3(9.022f, 2.4384f, 1f);
        }

        if(this.gameObject.tag == "Wall_Front")
        {
            this.gameObject.transform.position = new Vector3(0f, 1.2192f, 1.6765f);
            this.gameObject.transform.localScale = new Vector3(11.582f, 2.4384f, 1f);
        }

        if(this.gameObject.tag == "Wall_Floor")
        {
            this.gameObject.transform.position = new Vector3(0, 0f, 0f);
            this.gameObject.transform.localScale = new Vector3(11.582f, 3.353f, 1f);
        }
        
    }
}
