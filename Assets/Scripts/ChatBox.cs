using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ChatBox : MonoBehaviour
{
    public TextMeshProUGUI barText;
    public TextMeshProUGUI personNameText;

    private int sentenceIndex = -1;
    public StoryScene currentScene;
    public Image imageHolder;
    
    
    private State state = State.COMPLETED;

    private enum State
    {
        PLAYING, COMPLETED
    }

    public void PlayScene(StoryScene scene)
    {
        currentScene = scene;
        sentenceIndex = -1;
        PlayNextSentence();
    }

    // Start is called before the first frame update
    public void PlayNextSentence()
    {
        state = State.PLAYING;
        StartCoroutine(TypeText(currentScene.sentences[++sentenceIndex].text));
        personNameText.text = currentScene.sentences[sentenceIndex].speaker.speakerName;
        personNameText.color = currentScene.sentences[sentenceIndex].speaker.textColor;
        imageHolder.sprite = currentScene.sentences[sentenceIndex].speaker.characterSprite;
       
        imageHolder.preserveAspect = true;
       
        
    }

    public bool IsCompleted()
    {
        return state == State.COMPLETED; 
    }

    public bool IsLastSentence()
    {
        return sentenceIndex + 1 == currentScene.sentences.Count;
    }

    private IEnumerator TypeText(string text)
    {
        barText.text = "";
        //state = State.PLAYING;
        int wordIndex = 0;

        while (state != State.COMPLETED)
        {
            barText.text += text[wordIndex];
            yield return new WaitForSeconds(0.05f);
            if (Input.GetKeyDown(KeyCode.V)) //|| Input.GetMouseButtonDown(0)) //if player presses left click, skip to completed dialogue Input.GetMouseButtonDown(0) Input.GetKey(KeyCode.Mouse0)
            {
                barText.text = text;
                state = State.COMPLETED;
                Debug.Log("skip dialogue");
                break;
            }
            else if (++wordIndex == text.Length)
            {
                state = State.COMPLETED;
                break;
            }
            //yield return new WaitForSeconds(0.05f);
            /*
            else if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) //if player presses left click, skip to completed dialogue Input.GetMouseButtonDown(0) Input.GetKey(KeyCode.Mouse0)
            {
                barText.text = text; 
                state = State.COMPLETED;
                Debug.Log("skip dialogue");
                break;
            }
            */
        }
    }
}
