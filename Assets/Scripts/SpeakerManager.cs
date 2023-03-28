using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewSpeaker", menuName = "Data/New Speaker")]
[System.Serializable]
public class SpeakerManager : ScriptableObject
{
    public string speakerName;
    public Color textColor;
    public Sprite characterSprite;
}
