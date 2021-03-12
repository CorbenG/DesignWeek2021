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
    public AudioClip[] parkAudioClips;
    public AudioClip[] streetAudioClips;
    public AudioClip[] downtownAudioClips;

    float stillTimer;
    bool isStill;


    bool hallwayStillSaid = false;
    bool kitchenStillSaid = false;
    bool livingStillSaid = false;
    bool parkStillSaid1 = false;
    bool parkStillSaid2 = false;
    bool dogStillSaid = false;
    bool flowersStillSaid = false;
    bool carStillSaid = false;

    bool returningHome = false;
    bool hasLeftBefore = false;
    bool hasReachedParkEndBefore = false;
    bool hasGoneBackParkBefore = false;
    bool hasSaidExercise = false;
    bool comingFromHome = true;
    bool seenRatKing = false;
    bool comingFromLeftSewer = true;

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
            stillTimer = 0;
        }

        if(prevScene != currentScene.name)
        {
            stillTimer = 0;
            //Movement cues
            if (prevScene == "Bedroom" && currentScene.name == "Hallway")
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
            else if (prevScene == "Living Room" && currentScene.name == "Entrance" && !hasLeftBefore)
            {
                returningHome = false;
                subtitles.newText = "And then off to work I went.";
                soundPlayer.PlayOneShot(audioClips[11]);
            }
            else if (prevScene == "Living Room" && currentScene.name == "Entrance" && hasLeftBefore)
            {
                returningHome = false;
                subtitles.newText = "And I headed out once more.";
                soundPlayer.PlayOneShot(audioClips[22]);
            }
            else if (prevScene == "Entrance" && currentScene.name == "Living Room" && !returningHome)
            {
                subtitles.newText = "Oh I forgot, I didn't leave quite yet.";
                soundPlayer.PlayOneShot(audioClips[12]);
            }
            else if (prevScene == "Entrance" && currentScene.name == "Park 1")
            {
                hasLeftBefore = true;
                subtitles.newText = "I got to the park by my house.";
                soundPlayer.PlayOneShot(parkAudioClips[0]);
            }
            else if (prevScene == "Park 1" && currentScene.name == "Entrance")
            {
                returningHome = true;
                subtitles.newText = "I returned home.";
                soundPlayer.PlayOneShot(audioClips[21]);
            }
            else if (prevScene == "Park 1" && currentScene.name == "Park 2" && !dogStillSaid)
            {
                dogStillSaid = true;
                subtitles.newText = "Where I saw this person walking their dog.";
                soundPlayer.PlayOneShot(parkAudioClips[1]);
            }
            else if (prevScene == "Park 3" && currentScene.name == "Park 4")
            {
                comingFromHome = true;
                hasReachedParkEndBefore = true;
                subtitles.newText = "I got near the end of the park.";
                soundPlayer.PlayOneShot(parkAudioClips[6]);
            }
            else if (prevScene == "Park 4" && currentScene.name == "Park 3" && !hasGoneBackParkBefore && comingFromHome)
            {
                hasGoneBackParkBefore = true;
                subtitles.newText = "But something else caught my eye.";
                soundPlayer.PlayOneShot(parkAudioClips[8]);
            }
            else if (prevScene == "Park 4" && currentScene.name == "Park 3" && hasGoneBackParkBefore && comingFromHome)
            {
                subtitles.newText = "But then I started going backwards again.";
                soundPlayer.PlayOneShot(parkAudioClips[9]);
            }
            else if (prevScene == "Park 2" && currentScene.name == "Park 1" && hasReachedParkEndBefore && !hasSaidExercise)
            {
                hasSaidExercise = true;
                subtitles.newText = "I thought I might as well get some exercise this morning, so I just ran back and forth along the path.";
                soundPlayer.PlayOneShot(parkAudioClips[10]);
            }
            else if (prevScene == "Park 4" && currentScene.name == "Street 1")
            {
                comingFromHome = false;
                subtitles.newText = "And I continued on my way to midtown.";
                soundPlayer.PlayOneShot(parkAudioClips[7]);
            }
            else if (prevScene == "Street 1" && currentScene.name == "Park 4")
            {
                subtitles.newText = "I went back into the park.";
                soundPlayer.PlayOneShot(parkAudioClips[15]);
            }
            else if (prevScene == "Street 1" && currentScene.name == "Street 2")
            {
                subtitles.newText = "I kept walking.";
                soundPlayer.PlayOneShot(streetAudioClips[1]);
            }
            else if (prevScene == "Street 2" && currentScene.name == "Street Top 1")
            {
                subtitles.newText = "And for some reason I just really felt like climbing the fire escape this morning.";
                soundPlayer.PlayOneShot(streetAudioClips[2]);
            }
            else if (prevScene == "Street Top 1" && currentScene.name == "Street 2")
            {
                subtitles.newText = "Then I climbed back down the fire escape.";
                soundPlayer.PlayOneShot(streetAudioClips[7]);
            }
            else if (prevScene == "Street Top 1" && currentScene.name == "Street Top 2")
            {
                subtitles.newText = "On top of the roof of the building, I found a homeless guy!";
                soundPlayer.PlayOneShot(streetAudioClips[5]);
            }
            else if (prevScene == "Street 2" && currentScene.name == "Street 3")
            {
                subtitles.newText = "I passed by an old man feeding the birds.";
                soundPlayer.PlayOneShot(streetAudioClips[4]);
            }
            else if (prevScene == "Street 3" && currentScene.name == "Street 4")
            {
                subtitles.newText = "And on the next street, there was a guy selling hotdogs.";
                soundPlayer.PlayOneShot(streetAudioClips[16]);
            }
            else if (prevScene == "Street 4" && currentScene.name == "Sewer 1")
            {
                subtitles.newText = "And I couldn't tell you why, but I jumped down into an open manhole.";
                soundPlayer.PlayOneShot(streetAudioClips[3]);
            }
            else if (prevScene == "Sewer 1" && currentScene.name == "Sewer 2" && comingFromLeftSewer)
            {
                subtitles.newText = "I walked further into the sewer.";
                soundPlayer.PlayOneShot(streetAudioClips[8]);
            }
            else if (prevScene == "Sewer 2" && currentScene.name == "Sewer 3" && !seenRatKing)
            {
                subtitles.newText = "I thought I saw something further in...";
                soundPlayer.PlayOneShot(streetAudioClips[9]);
            }
            else if (prevScene == "Sewer 3" && currentScene.name == "Sewer 4" && !seenRatKing)
            {
                comingFromLeftSewer = false;
                seenRatKing = true;
                subtitles.newText = "And I walked right into the throne room of the sewer rat king! He was already dead, but I wondered how long he was down here.";
                soundPlayer.PlayOneShot(streetAudioClips[10]);
            }
            else if (prevScene == "Sewer 3" && currentScene.name == "Sewer 4" && seenRatKing)
            {
                comingFromLeftSewer = false;
                subtitles.newText = "But first I wanted to take another look at the rat king.";
                soundPlayer.PlayOneShot(streetAudioClips[14]);
            }
            else if (prevScene == "Sewer 4" && currentScene.name == "Sewer 3")
            {
                subtitles.newText = "And so I headed back towards the ladder.";
                soundPlayer.PlayOneShot(streetAudioClips[13]);
            }
            else if (prevScene == "Sewer 2" && currentScene.name == "Sewer 1")
            {
                comingFromLeftSewer = true;
            }
            else if (prevScene == "Sewer 1" && currentScene.name == "Street 4")
            {
                subtitles.newText = "I climbed my way out of the sewer.";
                soundPlayer.PlayOneShot(streetAudioClips[15]);
            }
            else if (prevScene == "Street 4" && currentScene.name == "downtown 1")
            {
                subtitles.newText = "And I continued walking all the way to downtown.";
                soundPlayer.PlayOneShot(streetAudioClips[19]);
            }
            else if (prevScene == "downtown 1" && currentScene.name == "downtown 2")
            {
                subtitles.newText = "I passed by this guy with a fancy looking car.";
                soundPlayer.PlayOneShot(downtownAudioClips[5]);
            }
            else if (prevScene == "downtown 1" && currentScene.name == "Inside Bagel Shop")
            {
                subtitles.newText = "I entered the bagel shop I pass by on my way.";
                soundPlayer.PlayOneShot(downtownAudioClips[0]);
            }
            else if (prevScene == "downtown 2" && currentScene.name == "downtown 3")
            {
                subtitles.newText = "And I finally reached my destination, my work.";
                soundPlayer.PlayOneShot(downtownAudioClips[6]);
            }
            else if (prevScene == "downtown 3" && currentScene.name == "downtown 2")
            {
                subtitles.newText = "But I wasn't ready to start yet.";
                soundPlayer.PlayOneShot(downtownAudioClips[7]);
            }
        }

        //Waiting cues
        if (currentScene.name == "Hallway" && stillTimer > 3f && !hallwayStillSaid)
        {
            subtitles.newText = "I stopped to look at the very interesting walls of the hallway";
            soundPlayer.PlayOneShot(audioClips[3]);
            hallwayStillSaid = true;
        }
        else if (currentScene.name == "Kitchen" && stillTimer > 3f && !kitchenStillSaid)
        {
            subtitles.newText = "I was just standing around for a bit, admiring the beatiful countertop?";
            soundPlayer.PlayOneShot(audioClips[6]);
            kitchenStillSaid = true;
        }
        else if (currentScene.name == "Living Room" && stillTimer > 3f && !livingStillSaid)
        {
            subtitles.newText = "Oh, y'know it was Spongebrett squareshorts on TV this morning";
            soundPlayer.PlayOneShot(audioClips[9]);
            livingStillSaid = true;
        }
        else if (currentScene.name == "Park 1" && stillTimer > 5f && !parkStillSaid1)
        {
            subtitles.newText = "I stopped to breathe in the fresh air.";
            soundPlayer.PlayOneShot(parkAudioClips[12]);
            parkStillSaid1 = true;
        }
        else if (stillTimer > 10f && !parkStillSaid2 && currentScene.name != "Park 2")
        {
            subtitles.newText = "I was already running late, but I just stood there for a bit.";
            soundPlayer.PlayOneShot(parkAudioClips[13]);
            parkStillSaid2 = true;
        }
        else if (currentScene.name == "Park 2" && stillTimer > 7f && !dogStillSaid)
        {
            subtitles.newText = "Then I just kind of stared at the stranger until they ran away.";
            soundPlayer.PlayOneShot(parkAudioClips[3]);
            dogStillSaid = true;
            currentScene.transform.GetChild(5).gameObject.SetActive(false);
            currentScene.transform.GetChild(6).gameObject.SetActive(false);
        }
        else if (currentScene.name == "Park 4" && stillTimer > 3f && !flowersStillSaid)
        {
            subtitles.newText = "I stopped to smell the flowers.";
            soundPlayer.PlayOneShot(parkAudioClips[14]);
            flowersStillSaid = true;
        }
        else if (currentScene.name == "downtown 2" && stillTimer > 3f && !carStillSaid)
        {
            subtitles.newText = "I stood and stared at the car";
            soundPlayer.PlayOneShot(downtownAudioClips[4]);
            carStillSaid = true;
        }

        prevScene = currentScene.name;
    }
}
