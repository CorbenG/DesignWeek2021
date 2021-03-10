using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class PrototypeSystem : MonoBehaviour
{
    public GameObject rain;
    public GameObject snow;
    public GameObject fog;
    public GameObject sun;

    public InputField input;

    public Text text1;
    public Text text2;
    public Text text3;

    public Color textColor;
    public Color invisColor;

    int storyIndex = 1;
    int lastStoryIndex = 1;
    string weather = "nothing";
    string prevWeather = "nothing";

    public AudioClip voice1;
    public AudioClip voice2;
    public AudioClip voice3;
    public AudioClip voicerainy;
    public AudioClip voicesunny;
    public AudioClip voicesnowy;
    public AudioClip voicefoggy;

    public AudioSource audiosource;

    bool waited = false;

    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        audiosource.PlayOneShot(voice1, 1);
        //audiosource.clip = voice1;
        //audiosource.Play();
        StartCoroutine(playStory(text1, 5));
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(waited);
        if(storyIndex == 2 && lastStoryIndex != storyIndex)
        {
            audiosource.PlayOneShot(voice2);
            text2.gameObject.SetActive(true);
            
        }
        if (storyIndex == 3 && lastStoryIndex != storyIndex && waited)
        {
            text2.gameObject.SetActive(false);
            text3.gameObject.SetActive(true);
            audiosource.PlayOneShot(voice3);
        }
        lastStoryIndex = storyIndex;


        if (input.textComponent.text.ToLower() == "raining" || input.textComponent.text.ToLower() == "rainy")
        {
            weather = "raining";
        }
        else if (input.textComponent.text.ToLower() == "snowing" || input.textComponent.text.ToLower() == "snowy")
        {
            weather = "snowing";
        }
        else if (input.textComponent.text.ToLower() == "clear" || input.textComponent.text.ToLower() == "sunny")
        {
            weather = "sunny";
        }
        else if (input.textComponent.text.ToLower() == "foggy" || input.textComponent.text.ToLower() == "cloudy")
        {
            weather = "foggy";
        }

        if(prevWeather != weather)
        {
            rain.SetActive(false);
            snow.SetActive(false);
            sun.SetActive(false);
            fog.SetActive(false);
            if (weather == "raining")
            {
                audiosource.PlayOneShot(voicerainy);
                rain.SetActive(true);
            }
            else if (weather == "snowing")
            {
                audiosource.PlayOneShot(voicesnowy);
                snow.SetActive(true);
            }
            else if (weather == "sunny")
            {
                audiosource.PlayOneShot(voicesunny);
                sun.SetActive(true);
            }
            else if (weather == "foggy")
            {
                audiosource.PlayOneShot(voicefoggy);
                fog.SetActive(true);
            }
            
            StartCoroutine(wait(3));
        }
        
        prevWeather = weather;
    }

    IEnumerator playStory(Text text, float duration)
    {
        Color currentColor = text.color;
        Color visibleColor = text.color;
        visibleColor.a = 255;

        float counter = 0;
        
        while (counter < 3)
        {
            counter += Time.deltaTime;
            text.color = Color.Lerp(currentColor, visibleColor, counter / 1);
            yield return null;
        }

        while (counter >= 1 && counter < duration)
        {
            counter += Time.deltaTime;
            yield return null;
        }

        while (counter > duration && counter < duration + 1)
        {
            counter += Time.deltaTime;
            text.color = Color.Lerp(visibleColor, currentColor, (counter - duration) / 1);
            yield return text.color;
        }

        storyIndex++;
        
    }

    IEnumerator wait(float duration)
    {
        yield return new WaitForSeconds(duration);
        waited = true;
        storyIndex++;
    }

}
