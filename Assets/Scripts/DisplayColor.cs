using UnityEngine;
using System.Collections;

public class DisplayColor : MonoBehaviour
{
    public Light[] sLight;

    private void Awake()
    {
        sLight = new Light[4];
        sLight[0] = GameObject.Find("Red").GetComponentInChildren<Light>();
        sLight[1] = GameObject.Find("Green").GetComponentInChildren<Light>();
        sLight[2] = GameObject.Find("Blue").GetComponentInChildren<Light>();
        sLight[3] = GameObject.Find("Yellow").GetComponentInChildren<Light>();

        for (int i = 0; i < 4; i++)
        {
            sLight[i].enabled = false;
        }
    }

    public void Display(SColor color)
    {
        switch (color)
        {
            case SColor.Red:
                GetComponent<SoundHandler>().PlaySound("bleep1");
                StartCoroutine(DisplayAnimation(0));
                break;
            case SColor.Green:
                GetComponent<SoundHandler>().PlaySound("bleep2");
                StartCoroutine(DisplayAnimation(1));
                break;
            case SColor.Blue:
                GetComponent<SoundHandler>().PlaySound("bleep3");
                StartCoroutine(DisplayAnimation(2));
                break;
            case SColor.Yellow:
                GetComponent<SoundHandler>().PlaySound("bleep4");
                StartCoroutine(DisplayAnimation(3));
                break;
        }
    }

    private IEnumerator DisplayAnimation(int id)
    {
        sLight[id].enabled = true;
        yield return new WaitForSeconds(0.45f);
        sLight[id].enabled = false;
    }
}
