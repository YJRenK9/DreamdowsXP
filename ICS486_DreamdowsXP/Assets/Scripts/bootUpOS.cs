using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq; // used for a shorter way to iterate through all the elements of the list
using UnityEngine;
using TMPro; // used to import text mesh pro package
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public static class globalVars {
    public static bool initiateSound = false;
}

public class bootUpOS : MonoBehaviour
{
    public Slider loadingBar;
    public GameObject screenContents;
    public RawImage nextScreen;
    public AudioSource theAudio;
    

    GameObject logo1;
    GameObject title;
    GameObject logo2;
    GameObject subtitle;
    GameObject bar;
    GameObject filledProgress;

    Color opacityElement1;
    Color opacityElement2;
    Color opacityElement3;
    Color opacityElement4;
    Color opacityElement5;
    Color opacityElement6;

    Dictionary<GameObject, Color> UI_Elements;

    

    Color temp_color; // used to store the selected Color object in the dictionary to be modified in order to update the original opacity values

    bool doneLoading = false; // used so the fade transition doesn't repeat itself

    //float elapsedTime = 0;

    
    
    // Start is called before the first frame update
    void Start()
    {
        // variables that store the children of the parent game object
        // without '.gameObject', the compiler will think these variables will have Transform objects instead of GameObjects
        // without 'GetComponent<T>()', the compiler will think these variables are game objects instead of UI objects
        logo1 = screenContents.transform.GetChild(0).gameObject;
        title = screenContents.transform.GetChild(1).gameObject;
        logo2 = screenContents.transform.GetChild(2).gameObject;
        subtitle = screenContents.transform.GetChild(3).gameObject;

        // created a GameObject to properly search for children of the Slider object
        GameObject waitingBar = screenContents.transform.GetChild(4).gameObject;
        // use GetChild() twice because the 5th child also has children (one of them is the Image for the bar)
        bar = waitingBar.transform.GetChild(0).gameObject;
        // the child is the Rect Transform game object (Fill Area) and the grandchild is the Image object (Fill)
        filledProgress = waitingBar.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject;

        // logo1.GetComponent<RawImage>().color.a = 0; // can't do this as the LHS is not a variable
        
        opacityElement1 = logo1.GetComponent<RawImage>().color; // stores the color properties of the raw image into a Color variable
        opacityElement1.a = 0; // changes the opacity of the Color variable to transparent
        logo1.GetComponent<RawImage>().color = opacityElement1; // stores the updated Color object into the Raw Image's color 
        
        // (can't use opacityElement1.a on RHS cuz float and Color are incompatiable data types)

        // use TextMeshProUGUI instead of Text since it's the new Text object being used over the previous one
        opacityElement2 = title.GetComponent<TextMeshProUGUI>().color;
        opacityElement2.a = 0;
        title.GetComponent<TextMeshProUGUI>().color = opacityElement2;

        // RawImage are images from local computer and Image are RawImages that got converted to 2D sprites
        opacityElement3 = logo2.GetComponent<RawImage>().color;
        opacityElement3.a = 0;
        logo2.GetComponent<RawImage>().color = opacityElement3;

        opacityElement4 = subtitle.GetComponent<TextMeshProUGUI>().color;
        opacityElement4.a = 0;
        subtitle.GetComponent<TextMeshProUGUI>().color = opacityElement4;
        
        // color property seems to only work for image and text objects
        opacityElement5 = bar.GetComponent<Image>().color;
        opacityElement5.a = 0;
        bar.GetComponent<Image>().color = opacityElement5;

        // can't directly modify component properties because they're read values, which means they can ONLY be returned, NOT modified
        opacityElement6 = filledProgress.GetComponent<Image>().color;
        opacityElement6.a = 0;
        filledProgress.GetComponent<Image>().color = opacityElement6;

        // to initialize the dictionary in order to avoid NullReferenceException (means the elements are null)
        // used to store and update the UI elements' color opacity
        UI_Elements = new Dictionary<GameObject, Color>();

        // since you can't directly change alpha values from the source, create temp elements to update those values 
        UI_Elements.Add(logo1, opacityElement1);
        UI_Elements.Add(title, opacityElement2);
        UI_Elements.Add(logo2, opacityElement3);
        UI_Elements.Add(subtitle, opacityElement4);
        UI_Elements.Add(bar, opacityElement5);
        UI_Elements.Add(filledProgress, opacityElement6);

        temp_color = new Color();

        nextScreen.enabled = false;

        // In this case, must play the sound in the start/setup function (so program will realize the user wants to play the sound, but not just yet)
        theAudio.Play();

        // used to get the component for the auido clip
        //startingSound = GetComponent<AudioSource>();
        
        // putting the coroutine in Start() would start it right after you run the scene (not good if you want to start it at a certain time)
        //StartCoroutine("ActivateWelcomeScreen");

        // won't use StopCoroutine() in Start() as the coroutine will stop automatically after it finished
    }


    // Update is called once per frame
    void Update()
    {
        // Debug.Log(logo1.TryGetComponent<RawImage>(out RawImage ri));
        // Debug.Log(showUI);
        //Debug.Log(UI_Elements.Values.ToList().Any(color => color.a < 1));
        //Debug.Log(UI_Elements.Values.ToList()[0]);

        // checks if all of the UI element's alpha values are below 1 (in other words, checking if they're not opaque)
        if (UI_Elements.Values.Any(color => color.a < 1) && !doneLoading) {
             //Debug.Log("translucent");
             // need to use .ToList() or else the console will throw InvalidOperationException (can't modify dict elements during traversal)
            foreach (GameObject ui_element in UI_Elements.Keys.ToList()) {
                // if the game object has a Raw Image component
                if (ui_element.TryGetComponent<RawImage>(out RawImage ri)) {
                    // the dict value is stored in the temp variable 
                    temp_color = UI_Elements[ui_element];
                    
                    // increment the opacity value of the temp var
                    temp_color.a += 0.005f;
                    
                    // update both the image's opacity and its alpha value
                    ri.color = temp_color;
                    UI_Elements[ui_element] = temp_color;
                    
                    //Debug.Log(ri.color.a);
                    //Debug.Log(alphaColors[n].a);
                }
                // if the game object has a TextMeshProUGUI component
                if (ui_element.TryGetComponent<TextMeshProUGUI>(out TextMeshProUGUI t)) {
                    temp_color = UI_Elements[ui_element];
                    temp_color.a += 0.005f;
                    t.color = temp_color;
                    UI_Elements[ui_element] = t.color;
                    
                    //Debug.Log(t.color.a);
                }
                // if the game object has an image component
                if (ui_element.TryGetComponent<Image>(out Image i)) {
                    temp_color = UI_Elements[ui_element];
                    temp_color.a += 0.005f;
                    i.color = temp_color;
                    UI_Elements[ui_element] = i.color;
                    
                    //Debug.Log(i.color.a);
                }
                //Debug.Log(showUI[n]);
            }
            // pauses the sound in update function
            theAudio.Pause(); 
        } else {
            // used to not loop through the UI elements fading
            doneLoading = true;
            
            if (loadingBar.value < 100) {
        //Debug.Log(screenContents.transform.GetChild(0).gameObject);
        //Debug.Log(screenContents.transform.GetChild(0).gameObject.GetType());
        //Debug.Log(screenContents.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>());
        //Debug.Log(screenContents.transform.GetChild(0).gameObject.GetType() == logo1.GetType());
                loadingBar.value += 0.1f;
            } else {
                //Debug.Log("Done!");
                foreach (GameObject ui_element in UI_Elements.Keys.ToList()) {
                    // if the game object has a Raw Image component
                    if (ui_element.TryGetComponent<RawImage>(out RawImage ri)) {
                        // the dict value is stored in the temp variable 
                        temp_color = UI_Elements[ui_element];
                        
                        // increment the opacity value of the temp var
                        temp_color.a = 0;
                        
                        // update both the image's opacity and its alpha value
                        ri.color = temp_color;
                        UI_Elements[ui_element] = temp_color;
                        
                        //Debug.Log(ri.color.a);
                        //Debug.Log(alphaColors[n].a);
                    }
                    // if the game object has a TextMeshProUGUI component
                    if (ui_element.TryGetComponent<TextMeshProUGUI>(out TextMeshProUGUI t)) {
                        temp_color = UI_Elements[ui_element];
                        temp_color.a = 0;
                        t.color = temp_color;
                        UI_Elements[ui_element] = t.color;
                        
                        //Debug.Log(t.color.a);
                    }
                    // if the game object has an image component
                    if (ui_element.TryGetComponent<Image>(out Image i)) {
                        temp_color = UI_Elements[ui_element];
                        temp_color.a = 0;
                        i.color = temp_color;
                        UI_Elements[ui_element] = i.color;
                        
                        //Debug.Log(i.color.a);
                    }
                    //Debug.Log(showUI[n]);
                }
                // starts the coroutine right after the UI elements become invisible (again)
                StartCoroutine("ActivateWelcomeScreen");
                // still gets called because StartCoroutine is still being called
                // Debug.Log("evaded");
            }
        }

        // if (loadingBar.value < 100) {
        //     //Debug.Log(screenContents.transform.GetChild(0).gameObject);
        //     //Debug.Log(screenContents.transform.GetChild(0).gameObject.GetType());
        //     //Debug.Log(screenContents.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>());
        //     //Debug.Log(screenContents.transform.GetChild(0).gameObject.GetType() == logo1.GetType());
        //     loadingBar.value += 0.05f;
        // } else {
        //     Debug.Log("Done!");
        // }
    }

    IEnumerator ActivateWelcomeScreen() 
    {
        // iterate and returns seconds for five seconds
        yield return new WaitForSeconds(5f);
        // unhide welcome screen
        nextScreen.enabled = true;
        // upause will let the user hear the sound
        theAudio.UnPause();
        // wait for 5 more seconds
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("MainScene");
        // may be able to print a few times due to how fast Update() runs
        // nothing gets printed into the console once the next scene is loaded
        // Debug.Log("evaded");
    }
}
