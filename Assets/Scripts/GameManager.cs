using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public StoryScene currentScene;
    public ChatBox chatBox;
    
    // Start is called before the first frame update
    void Start()
    {
        chatBox.PlayScene(currentScene);
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
                    /** if (item == true) 
                     * {
                     * currentScene = GameObject.Find
                     * }
                     * 
                     */
                    currentScene = currentScene.nextScene;
                    chatBox.PlayScene(currentScene);
                }
                else
                {
                    chatBox.PlayNextSentence();
                }
            }
        }
    }
}
