using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public StoryScene currentScene;
    public Animator animat;
    public int index;
    public string levelName;
    public Image black;
    private int levelToLoad;
    public ChatBox chatBox;
    private bool gotIt;
    

    // Start is called before the first frame update
    void Start()
    {
        chatBox.PlayScene(currentScene);
        gotIt = ItemCollector.items;
        Debug.Log(gotIt.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (chatBox.IsCompleted())
            {
                if (chatBox.IsLastSentence())
                {

                    if (gotIt.ToString() == "True" && currentScene.name.Equals("NPCScene1"))
                    {
                        currentScene = currentScene.possibleOne;
                        chatBox.PlayScene(currentScene);

                    }
                    else if (gotIt.ToString().Equals("False") && currentScene.name.Equals("NPCScene1"))
                    {
                        currentScene = currentScene.possibleTwo;
                        chatBox.PlayScene(currentScene);
                    }
                    else if (currentScene.nextScene != null) 
                    {
                        currentScene = currentScene.nextScene;
                        chatBox.PlayScene(currentScene);
                    }
                    else
                    {
                        StartCoroutine(Fading());
                    }

                    
                }
                else
                {

                    chatBox.PlayNextSentence();
                }
            }
        }
    }

    IEnumerator Fading()
    {
        animat.SetBool("Fader", true);
        yield return new WaitUntil(() => black.color.a == 1);
        SceneManager.LoadScene(index);

    }
}
