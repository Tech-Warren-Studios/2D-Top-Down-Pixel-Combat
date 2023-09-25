using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    public int index;

    private void OnEnable()
    {
        // Pause the game when the dialogue starts
        Time.timeScale = 0;
        textComponent.text = string.Empty;
        StartDialogue();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    private void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSecondsRealtime(textSpeed); // Use WaitForSecondsRealtime while game is paused
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false); // Make sure to set the gameObject inactive after unpausing the game
            Time.timeScale = 1; // Resume the game when the dialogue is over
        }
    }

    private void OnDisable()
    {
        // Just in case if the object is disabled without finishing the dialogue
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }
}

