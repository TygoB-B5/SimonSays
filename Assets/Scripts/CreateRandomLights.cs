using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum SColor { Red, Green, Blue, Yellow };

public class CreateRandomLights : MonoBehaviour
{
    public static bool enableInput;
    private DisplayColor displayColor;

    private static int _currentLightNumber = 0;
    public static int currentLightNumber
    {
        get { return _currentLightNumber; }
        set { _currentLightNumber = Mathf.Clamp(value, 0, 999); }
    }

    public List<SColor> ColorPattern;

    private void Awake()
    {
        displayColor = GetComponent<DisplayColor>();
    }

    private void Start()
    {
        StartCoroutine(StartWithDelay());
    }

    private IEnumerator StartWithDelay()
    {
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(StartRound());
    }

    public IEnumerator StartRound()
    {
        enableInput = false;
        yield return new WaitForSeconds(0.25f);

        while (currentLightNumber < ColorPattern.Count)
        {
            yield return new WaitForSeconds(0.5f);
            displayColor.Display(ColorPattern[currentLightNumber]);
            currentLightNumber++;
        }

        yield return new WaitForSeconds(0.5f);
        currentLightNumber = 0;
        AddRandomColor();
        enableInput = true;
    }

    private void AddRandomColor()
    {
        int rand = UnityEngine.Random.Range(0, 4 + 1);

        switch (rand)
        {
            case 1:
                ColorPattern.Add(SColor.Red);
                displayColor.Display(SColor.Red);
                break;
            case 2:
                ColorPattern.Add(SColor.Green);
                displayColor.Display(SColor.Green);
                break;
            case 3:
                ColorPattern.Add(SColor.Blue);
                displayColor.Display(SColor.Blue);
                break;
            case 4:
                ColorPattern.Add(SColor.Yellow);
                displayColor.Display(SColor.Yellow);
                break;
        }
    }
}
