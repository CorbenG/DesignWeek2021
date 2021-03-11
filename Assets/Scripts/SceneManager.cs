using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SceneManager : MonoBehaviour
{
    public GameObject currentScene;
    public Subtitles subtitles;
    public AudioSource soundPlayer;
    string prevScene;

    public AudioClip[] audioClips;

    float stillTimer;
    bool isStill;

    bool hallwayStillSaid = false;

    // Start is called before the first frame update
    void Start()
    {
        soundPlayer = GetComponent<AudioSource>();
        soundPlayer.PlayOneShot(audioClips[0]);
        subtitles.newText = "So, it all started this morning when I got out of bed.";
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxisRaw("Horizontal") == 0 && !isStill)
        {
            stillTimer = 0;
            isStill = true;
        }
        if (Input.GetAxisRaw("Horizontal") == 0 && isStill)
        {
            stillTimer += Time.deltaTime;
        }
        else
        {
            isStill = false;
        }

        if(prevScene != currentScene.name)
        {
            //Movement cues
            if(prevScene == "Bedroom" && currentScene.name == "Hallway")
            {
                subtitles.newText = "I left my room.";
                soundPlayer.PlayOneShot(audioClips[1]);
            }
            else if (prevScene == "Hallway" && currentScene.name == "Bedroom")
            {
                subtitles.newText = "Then I went back into my room?";
                soundPlayer.PlayOneShot(audioClips[2]);
            }
            else if (prevScene == "Hallway" && currentScene.name == "Kitchen")
            {
                subtitles.newText = "And I walked into the kitchen";
                soundPlayer.PlayOneShot(audioClips[4]);
            }
            else if (prevScene == "Kitchen" && currentScene.name == "Living Room")
            {
                subtitles.newText = "Then I went into the living room.";
                soundPlayer.PlayOneShot(audioClips[7]);
            }
            else if (prevScene == "Living Room" && currentScene.name == "Kitchen")
            {
                subtitles.newText = "I went back into the kitchen.";
                soundPlayer.PlayOneShot(audioClips[8]);
            }
            else if (prevScene == "Living Room" && currentScene.name == "Entrance")
            {
                subtitles.newText = "And then off to work I went.";
                soundPlayer.PlayOneShot(audioClips[11]);
            }
            else if (prevScene == "Entrance" && currentScene.name == "Living Room")
            {
                subtitles.newText = "Oh I forgot, I didn't leave quite yet.";
                soundPlayer.PlayOneShot(audioClips[12]);
            }


            //Waiting cues
            if (currentScene.name == "Hallway" && stillTimer > 3f)
            {
                Debug.Log("YUP");
                subtitles.newText = "I stopped to look at the very interesting walls of the hallway";
                soundPlayer.PlayOneShot(audioClips[3]);
                hallwayStillSaid = true;
            }
        }

        prevScene = currentScene.name;
    }
}
