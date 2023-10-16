using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateAllDisplays : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       /* Debug.Log ("displays connected: " + Display.displays.Length);
        Display.displays[0].Activate();
        Display.displays[1].Activate(5760, 1080, 60);*/

        for(int i = 1; i <Display.displays.Length; i++){
            Display.displays[i].Activate();
        }
/*
        //Screen.SetResolution(7680, 2160, false);
        //Display.displays[].Activate(7680, 2160, 60);
        //Display.displays[2].Activate(7680, 2160, 60);


        // Display.displays[0] is the primary, default display and is always ON, so start at index 1.
        //Activate(width, height, refreshRate)
    */
    
        //Screen.SetResolution(7680, 2160, false);

        //Display.displays[2].SetParams(7680, 2160, 0, 0);
    
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

/*
To do so, I have followed the previous advice, I have included in my code:

Screen.SetResolution(3840, 1080, false);

and set the following options in my PlayerSettings:

Resolution: Default is Full Screen: Unchecked. Default is Native Resolution: Unchecked. Default Width: I have written my desired width (3840), but it does not seem to matter as the setResolution() method seems to overwrite it. Default Height: Same as above.

Standalone Player Options I have disabled the "Display Resolution Dialog" I left the rest as it was.

Then I built and ran my project. The outcomes appeared shared between my both screens but in a window. To get rid of the window, I ran my project from the console using as:

C:\myProject.exe -popupwindow
*/

