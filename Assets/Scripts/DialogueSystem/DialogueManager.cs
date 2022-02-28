using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text messageText;
    public RectTransform backgroundBox;
    public static bool isActive = false;
    [SerializeField] private AudioClip endDialogueSound;
    [SerializeField] private AudioClip nextDialogueSound;

    Message[] currentMessages;
    int activeMessages = 0;

    public void OpenDialogue(Message[] messages){
        currentMessages = messages;
        activeMessages = 0;
        isActive = true;

        DisplayMessage();
        backgroundBox.LeanScale(Vector3.one, 0.5f).setEaseInOutExpo();

    }
    void DisplayMessage(){
        Message messageToDisplay = currentMessages[activeMessages];
        messageText.text = messageToDisplay.message;
    }

    public void NextMessage()
    {
        activeMessages ++;
        if(activeMessages < currentMessages.Length)
        {
            DisplayMessage();
        } else{
            isActive = false;
            backgroundBox.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
        }
    }

    void Start(){
        backgroundBox.transform.localScale = Vector3.zero;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && isActive == true){
            SoundManager.instance.PlaySound(nextDialogueSound);
            NextMessage();
        }
        if(Input.GetKeyDown(KeyCode.R) && isActive == true)
        {
            SoundManager.instance.PlaySound(endDialogueSound);
            activeMessages = currentMessages.Length;
            NextMessage();
        }
    }
}
