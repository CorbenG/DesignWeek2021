using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public GameObject leftRoom;
    public GameObject rightRoom;
    public GameObject interactRoom;
    public enum Inside { Indoors,Outdoors }
    public Inside inside;
    BoxCollider2D leftCol;
    BoxCollider2D rightCol;

    GameObject player;
    SceneManager sceneManager;

    // Start is called before the first frame update
    void Start()
    {
        leftCol = transform.GetChild(0).GetComponent<BoxCollider2D>();
        rightCol = transform.GetChild(1).GetComponent<BoxCollider2D>();

        player = GameObject.FindGameObjectWithTag("Player");
        sceneManager = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToRoom(string direction)
    {
        if(direction == "left" || direction == "Left")
        {
            if(leftRoom != null)
            {
                leftRoom.SetActive(true);
                sceneManager.currentScene = leftRoom;
                player.transform.position = new Vector3(4, player.transform.position.y, 0);
                gameObject.SetActive(false);
            }
            
        }
        else if (direction == "right" || direction == "Right")
        {
            if (rightRoom != null)
            {
                rightRoom.SetActive(true);
                sceneManager.currentScene = rightRoom;
                player.transform.position = new Vector3(-4, player.transform.position.y, 0);
                gameObject.SetActive(false);
            }
        }
        else if (direction == "interact" || direction == "Interact")
        {
            if (interactRoom != null)
            {
                interactRoom.SetActive(true);
                sceneManager.currentScene = interactRoom;
                player.transform.position = new Vector3(-4, player.transform.position.y, 0);
                gameObject.SetActive(false);
            }
        }

    }
}
