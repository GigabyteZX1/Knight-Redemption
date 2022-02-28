using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Message[] messages;
    [SerializeField] private AudioClip openDialogueSound;

   // public void StartDialogue()
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            FindObjectOfType<DialogueManager>().OpenDialogue(messages);
            SoundManager.instance.PlaySound(openDialogueSound);
        }
    }
}

[System.Serializable]
public class Message{
    public string message;
    //public int boardId;
}
