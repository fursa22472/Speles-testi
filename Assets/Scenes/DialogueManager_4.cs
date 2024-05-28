using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DialogueManager_4 : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public Button[] optionButtons;
    public List<Dialogue> dialogues = new List<Dialogue>();

    private int currentDialogueIndex = 0;
    private bool isEndingDialogue = false;

    void Start()
    {
        dialoguePanel.SetActive(false);

        // Example dialogues with unique next indices
        dialogues.Add(new Dialogue("Hello there!", new string[] { "Who are you?", "What is this place?", "Farewell." }, new int[] { 1, 2, 3 }));
        dialogues.Add(new Dialogue("I'm the guardian of this place.", new string[] { "Tell me more.", "I need help.", "Nevermind." }, new int[] { 4, 5, 0 }));
        dialogues.Add(new Dialogue("This is a mystical forest.", new string[] { "Tell me more.", "I need help.", "Nevermind." }, new int[] { 4, 5, 0 }));
        dialogues.Add(new Dialogue("Goodbye!", new string[] { "Bye.", "", "" }, new int[] { -1, -1, -1 }));
        dialogues.Add(new Dialogue("There is much to learn here.", new string[] { "Thank you.", "I need help.", "Nevermind." }, new int[] { 0, 5, 0 }));
        dialogues.Add(new Dialogue("How can I assist you?", new string[] { "Tell me about this place.", "Who are you?", "Nevermind." }, new int[] { 2, 1, 0 }));
    }

    public void StartDialogue()
    {
        currentDialogueIndex = 0;
        isEndingDialogue = false;
        dialoguePanel.SetActive(true);
        DisplayDialogue();
    }

    void DisplayDialogue()
    {
        Dialogue currentDialogue = dialogues[currentDialogueIndex];
        dialogueText.text = currentDialogue.text;

        for (int i = 0; i < optionButtons.Length; i++)
        {
            if (i < currentDialogue.options.Length && !string.IsNullOrEmpty(currentDialogue.options[i]))
            {
                optionButtons[i].gameObject.SetActive(true);
                optionButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = currentDialogue.options[i];
                int optionIndex = i;
                optionButtons[i].onClick.RemoveAllListeners();
                optionButtons[i].onClick.AddListener(() => OnOptionSelected(optionIndex));
            }
            else
            {
                optionButtons[i].gameObject.SetActive(false);
            }
        }
    }

    void OnOptionSelected(int index)
    {
        int nextDialogueIndex = dialogues[currentDialogueIndex].nextDialogueIndices[index];
        if (nextDialogueIndex == -1 || nextDialogueIndex >= dialogues.Count)
        {
            StartCoroutine(EndDialogueAfterDelay(2f)); // Adjust the delay as needed
        }
        else
        {
            currentDialogueIndex = nextDialogueIndex;
            DisplayDialogue();
        }
    }

    IEnumerator EndDialogueAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        dialoguePanel.SetActive(false);
    }
}
