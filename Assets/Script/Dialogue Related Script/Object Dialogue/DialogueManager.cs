using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueScreen;

    public TextMeshProUGUI speekerName;
    public TextMeshProUGUI dialogueText;

    private Queue<string> sentences;

    public int count = 0;

    void Start()
    {
        sentences = new Queue<string>();
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.M)){
            count = count + 1;
            Debug.Log("Key Pressed");
        }
    }

    public void startDialogue(Dialogue dialogue){
         speekerName.text = dialogue.speeker;

         sentences.Clear();

        if(count == 0){
            foreach(string sentence in dialogue.sentences){
             sentences.Enqueue(sentence);
            }
        }
        else{
            foreach(string sentence in dialogue.sentences2){
             sentences.Enqueue(sentence);
            }
        }

         DisplayNextSentence();
    }

    public void DisplayNextSentence(){
        if(sentences.Count == 4 || sentences.Count == 2){
            speekerName.text = "John";
        }
        else{
            speekerName.text = "Ricky";
        }
        
        if(sentences.Count == 0){
            EndDialogue();
            return;
        }
        Debug.Log(sentences.Count);
        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

    public void EndDialogue(){
        dialogueScreen.SetActive(false);
    }
}
