using UnityEngine;
using System;

public class InputSColors : MonoBehaviour
{
    public int currentGuess = 0;
    private DisplayColor displayColor;
    private CreateRandomLights crl;

    private void Awake()
    {
        displayColor = GetComponent<DisplayColor>();
        crl = FindObjectOfType<CreateRandomLights>();
        FindObjectOfType<GetColorInput>().OnClickOnColor += InputColor;
    }

    private void InputColor(SColor color)
    {
        if (!CreateRandomLights.enableInput)
            return;

        CheckIfWrong(color);

        displayColor.Display(color);

        CheckIfDone();
    }

    private void CheckIfWrong(SColor color)
    {
        if (color != crl.ColorPattern[currentGuess] || crl.ColorPattern.Count == 0)
        {

            GetComponent<ResetGame>().Die();
        }
    }

    private void CheckIfDone()
    {
        currentGuess++;
        if (currentGuess == crl.ColorPattern.Count)
        {
            currentGuess = 0;
            StartCoroutine(crl.StartRound());
        }
    }
}
