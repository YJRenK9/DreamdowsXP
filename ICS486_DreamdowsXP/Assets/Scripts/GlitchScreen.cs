using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;



public class GlitchScreen : MonoBehaviour
{
    // this enum is used to determine which screen to glitch (w/o it, all screens may be glitched at once)
    public enum Screen {
        FRONT,
        LEFT,
        RIGHT,
        BOTTOM
    };
    // to make the enum var public, you must make the enum public
    public Screen displayMode;

    public Texture glitch1;
    public Texture glitch2;
    public Texture glitch3;
    public Texture glitch4;

    RawImage glitchImage;

    List<Texture> glitchArr1;
    // List<RawImage> glitchArr2;
    // List<RawImage> glitchArr3;
    // List<RawImage> glitchArr4;

    int[] randTemp;
    HashSet<Texture> randomTextures;
    
    // Start is called before the first frame update
    void Start()
    {
        glitchImage = GetComponent<RawImage>();

        glitchImage.enabled = false;

        randTemp = new int[4];

        glitchArr1 = new List<Texture>();
        
        glitchArr1.Add(glitch1);
        glitchArr1.Add(glitch2);
        glitchArr1.Add(glitch3);
        glitchArr1.Add(glitch4);

        // glitchArr2 = new List<RawImage>();
        
        // glitchArr2.Add(glitch1);
        // glitchArr2.Add(glitch2);
        // glitchArr2.Add(glitch3);
        // glitchArr2.Add(glitch4);

        // glitchArr3 = new List<RawImage>();
        
        // glitchArr3.Add(glitch1);
        // glitchArr3.Add(glitch2);
        // glitchArr3.Add(glitch3);
        // glitchArr3.Add(glitch4);

        // glitchArr4 = new List<RawImage>();
        
        // glitchArr4.Add(glitch1);
        // glitchArr4.Add(glitch2);
        // glitchArr4.Add(glitch3);
        // glitchArr4.Add(glitch4);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) && displayMode == Screen.FRONT) {
            //Debug.Log("hey");
            glitchImage.enabled = true;
            // for (int i = 0; i < randTemp.Length - 1; i++) {
            //     while (randTemp[i] == randTemp[i + 1]) 
            //         randTemp[i] = Random.Range(0, glitchArr.Count);
            // }
            // randTemp = Random.Range(0, glitchArr.Count);
            // Debug.Log(glitchArr[randTemp]);
            //yield return new WaitForSeconds(1f);
            //glitch1.texture = glitchArr[Random.Range(0, glitchArr.Count)].texture;
           
            // foreach (Texture textures in glitchArr1) {
            //     //yield return new WaitForSeconds(2f);
            //     glitchImage.texture = textures; 
            //     yield return new WaitForSeconds(1f);
            //     // Debug.Log(glitch1.texture);
            // }
            glitchImage.texture = glitchArr1[Random.Range(0, glitchArr1.Count)]; 
            //yield return new WaitForSeconds(1f);
            
        } 
        if (Input.GetKey(KeyCode.A) && displayMode == Screen.LEFT) {
           
            glitchImage.enabled = true;
            // for (int i = 0; i < randTemp.Length - 1; i++) {
            //     while (randTemp[i] == randTemp[i + 1]) 
            //         randTemp[i] = Random.Range(0, glitchArr.Count);
            // }
            // randTemp = Random.Range(0, glitchArr.Count);
            // Debug.Log(glitchArr[randTemp]);
            //yield return new WaitForSeconds(1f);
            //glitch2.texture = glitchArr[Random.Range(0, glitchArr.Count)].texture;
            
            // foreach (Texture textures in glitchArr1) {
            //     //yield return new WaitForSeconds(2f);
            //     glitchImage.texture = textures;
            //     yield return new WaitForSeconds(1f);
            // }
            glitchImage.texture = glitchArr1[Random.Range(0, glitchArr1.Count)]; 
            //yield return new WaitForSeconds(1f);
            
        } 
        if (Input.GetKey(KeyCode.S) && displayMode == Screen.BOTTOM) {
            
            glitchImage.enabled = true;
            //yield return new WaitForSeconds(1f);
            // for (int i = 0; i < randTemp.Length - 1; i++) {
            //     while (randTemp[i] == randTemp[i + 1]) 
            //         randTemp[i] = Random.Range(0, glitchArr.Count);
            // }
            // randTemp = Random.Range(0, glitchArr.Count);
            // Debug.Log(glitchArr[randTemp]);
            //yield return new WaitForSeconds(1f);
            //glitch4.texture = glitchArr[Random.Range(0, glitchArr.Count)].texture;
            
            // foreach (Texture textures in glitchArr1) {
            //     //yield return new WaitForSeconds(2f);
            //     glitchImage.texture = textures;
            //     yield return new WaitForSeconds(1f);
            // }
            
            glitchImage.texture = glitchArr1[Random.Range(0, glitchArr1.Count)]; 
        } 
        if (Input.GetKey(KeyCode.D) && displayMode == Screen.RIGHT) {
            glitchImage.enabled = true;
            // for (int i = 0; i < randTemp.Length - 1; i++) {
            //     while (randTemp[i] == randTemp[i + 1]) 
            //         randTemp[i] = Random.Range(0, glitchArr.Count);
            // }
            // randTemp = Random.Range(0, glitchArr.Count);
            // Debug.Log(glitchArr[randTemp]);
            //yield return new WaitForSeconds(1f);
            //glitch3.texture = glitchArr[Random.Range(0, glitchArr.Count)].texture;
            
            // foreach (Texture textures in glitchArr1) {
            //     //yield return new WaitForSeconds(2f);
            //     glitchImage.texture = textures;
            //     yield return new WaitForSeconds(1f);
            // } 
            //yield return new WaitForSeconds(1f);
            glitchImage.texture = glitchArr1[Random.Range(0, glitchArr1.Count)]; 
                    
        } 

        // when none of the specified keys are pressed, disable the glitch image on ALL screens (more effective way of toggling glitch images)
        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D)) 
            glitchImage.enabled = false;
        
        //StartCoroutine("displayGlitch");
        // foreach (Texture t in tee) {
        //     Debug.Log(t);
        // }
    }

    void OnEnable() {
        
    }

    // IEnumerator displayGlitch() {
    //     if (Input.GetKey(KeyCode.W) && displayMode == Screen.FRONT) {
    //         //Debug.Log("hey");
    //         glitchImage.enabled = true;
    //         // for (int i = 0; i < randTemp.Length - 1; i++) {
    //         //     while (randTemp[i] == randTemp[i + 1]) 
    //         //         randTemp[i] = Random.Range(0, glitchArr.Count);
    //         // }
    //         // randTemp = Random.Range(0, glitchArr.Count);
    //         // Debug.Log(glitchArr[randTemp]);
    //         //yield return new WaitForSeconds(1f);
    //         //glitch1.texture = glitchArr[Random.Range(0, glitchArr.Count)].texture;
           
    //         // foreach (Texture textures in glitchArr1) {
    //         //     //yield return new WaitForSeconds(2f);
    //         //     glitchImage.texture = textures; 
    //         //     yield return new WaitForSeconds(1f);
    //         //     // Debug.Log(glitch1.texture);
    //         // }
    //         glitchImage.texture = glitchArr1[Random.Range(0, glitchArr1.Count)]; 
    //         yield return new WaitForSeconds(1f);
            
    //     } else {
    //         glitchImage.enabled = false;
    //     }
    //     if (Input.GetKey(KeyCode.A) && displayMode == Screen.LEFT) {
           
    //         glitchImage.enabled = true;
    //         // for (int i = 0; i < randTemp.Length - 1; i++) {
    //         //     while (randTemp[i] == randTemp[i + 1]) 
    //         //         randTemp[i] = Random.Range(0, glitchArr.Count);
    //         // }
    //         // randTemp = Random.Range(0, glitchArr.Count);
    //         // Debug.Log(glitchArr[randTemp]);
    //         //yield return new WaitForSeconds(1f);
    //         //glitch2.texture = glitchArr[Random.Range(0, glitchArr.Count)].texture;
            
    //         // foreach (Texture textures in glitchArr1) {
    //         //     //yield return new WaitForSeconds(2f);
    //         //     glitchImage.texture = textures;
    //         //     yield return new WaitForSeconds(1f);
    //         // }
    //         glitchImage.texture = glitchArr1[Random.Range(0, glitchArr1.Count)]; 
    //         yield return new WaitForSeconds(1f);
            
    //     } else {
    //         glitchImage.enabled = false;
    //     }
    //     if (Input.GetKey(KeyCode.S) && displayMode == Screen.BOTTOM) {
            
    //         glitchImage.enabled = true;
    //         yield return new WaitForSeconds(1f);
    //         // for (int i = 0; i < randTemp.Length - 1; i++) {
    //         //     while (randTemp[i] == randTemp[i + 1]) 
    //         //         randTemp[i] = Random.Range(0, glitchArr.Count);
    //         // }
    //         // randTemp = Random.Range(0, glitchArr.Count);
    //         // Debug.Log(glitchArr[randTemp]);
    //         //yield return new WaitForSeconds(1f);
    //         //glitch4.texture = glitchArr[Random.Range(0, glitchArr.Count)].texture;
            
    //         // foreach (Texture textures in glitchArr1) {
    //         //     //yield return new WaitForSeconds(2f);
    //         //     glitchImage.texture = textures;
    //         //     yield return new WaitForSeconds(1f);
    //         // }
            
    //         glitchImage.texture = glitchArr1[Random.Range(0, glitchArr1.Count)]; 
    //     } else {
    //         glitchImage.enabled = false;
    //     }
    //     if (Input.GetKey(KeyCode.D) && displayMode == Screen.RIGHT) {
    //         glitchImage.enabled = true;
    //         // for (int i = 0; i < randTemp.Length - 1; i++) {
    //         //     while (randTemp[i] == randTemp[i + 1]) 
    //         //         randTemp[i] = Random.Range(0, glitchArr.Count);
    //         // }
    //         // randTemp = Random.Range(0, glitchArr.Count);
    //         // Debug.Log(glitchArr[randTemp]);
    //         //yield return new WaitForSeconds(1f);
    //         //glitch3.texture = glitchArr[Random.Range(0, glitchArr.Count)].texture;
            
    //         // foreach (Texture textures in glitchArr1) {
    //         //     //yield return new WaitForSeconds(2f);
    //         //     glitchImage.texture = textures;
    //         //     yield return new WaitForSeconds(1f);
    //         // } 
    //         yield return new WaitForSeconds(1f);
    //         glitchImage.texture = glitchArr1[Random.Range(0, glitchArr1.Count)]; 
                    
    //     } else {
    //         glitchImage.enabled = false; 
    //     }
    // }
}
