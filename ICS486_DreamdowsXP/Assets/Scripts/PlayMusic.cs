using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    AudioSource dj;

    public AudioClip newClip1;
    public AudioClip newClip2;
    public AudioClip newClip3;
    public AudioClip newClip4;
    
    int songIndex;
    List<AudioClip> queue;

    // Start is called before the first frame update
    void Start()
    {
        dj = GetComponent<AudioSource>();
        queue = new List<AudioClip>();
        songIndex = 0;

        queue.Add(newClip1);
        queue.Add(newClip2);
        queue.Add(newClip3);
        queue.Add(newClip4);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            songIndex++;
            //Debug.Log("right");
            if (songIndex == queue.Count)  songIndex = 0;
            
            dj.clip = queue[songIndex];
            dj.Play();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            songIndex--;
            //Debug.Log("left");
            if (songIndex < 0)  songIndex = queue.Count - 1;

            dj.clip = queue[songIndex];
            dj.Play();
        }
    }
}
