using UnityEngine;

public class ObjectClick : MonoBehaviour
{
    private DialogueManager_4 dialogueManager;

    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager_4>();
    }

    void OnMouseDown()
    {
        if (dialogueManager != null)
        {
            dialogueManager.StartDialogue();
        }
    }
}
