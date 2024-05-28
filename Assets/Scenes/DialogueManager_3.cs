using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class DialogueManager_3 : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public Button[] optionButtons;
    private string[] dialogueLines = { "Vai tu velies parunat par filozofiju?", "Tas bus gars stasts.", "Vispar, uzredzesanos." };
    private string[][] options =
    {
        new string[] { "Ja, pastasti?", "Ne, nevelos?", "Ataa." },
        new string[] { "Man loti patiktu.", "Es gaidu.", "Tad neklausisos." },
        new string[] { "Nu ok, ata.", "", "" }
    };

    private int currentDialogueIndex = 0;
    private bool isEndingDialogue = false;

    void Start()
    {
        dialoguePanel.SetActive(false);
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
        dialogueText.text = dialogueLines[currentDialogueIndex];
        for (int i = 0; i < optionButtons.Length; i++)
        {
            if (i < options[currentDialogueIndex].Length && !string.IsNullOrEmpty(options[currentDialogueIndex][i]))
            {
                optionButtons[i].gameObject.SetActive(true);
                optionButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = options[currentDialogueIndex][i];
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
        currentDialogueIndex = index;
        if (currentDialogueIndex >= dialogueLines.Length - 1)
        {
            isEndingDialogue = true;
            DisplayDialogue();
            StartCoroutine(EndDialogueAfterDelay(2f)); // Adjust the delay as needed
        }
        else
        {
            DisplayDialogue();
        }
    }

    IEnumerator EndDialogueAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        dialoguePanel.SetActive(false);
    }
}
