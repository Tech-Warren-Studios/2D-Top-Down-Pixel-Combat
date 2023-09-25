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

    private void Start()
    {
        textComponent.text = string.Empty;
        startDialogue();
        Time.timeScale = 0f; // Pause the game when dialogue starts
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

    private void startDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSecondsRealtime(textSpeed); // Use WaitForSecondsRealtime to wait for seconds while game is paused
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
            Time.timeScale = 1f; // Resume the game when dialogue ends
            gameObject.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        Time.timeScale = 1f; // Ensure that the game is resumed even if the dialogue object is destroyed
    }
}

