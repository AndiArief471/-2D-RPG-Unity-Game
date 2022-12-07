using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDialogue : MonoBehaviour
{
    public KeyCode primaryKey;
    public KeyCode secondaryKey;
    public KeyCode tertiaryKey;

    public void Start(){
        
    }
    public void Update()
    {
        if(Input.GetKeyDown(primaryKey) | Input.GetKeyDown(secondaryKey) | Input.GetKeyDown(tertiaryKey)){
            FindObjectOfType<DialogueManager>().DisplayNextSentence();
        }
    }
}
