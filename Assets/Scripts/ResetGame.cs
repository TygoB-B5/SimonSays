using UnityEngine;
using System.Collections;

public class ResetGame : MonoBehaviour
{
    public GameObject blackScreen;
    public Light flash;

    public void Die()
    {
        StartCoroutine(Reset());
    }

    private IEnumerator Reset()
    {
        AudioSource[] aud = FindObjectsOfType<AudioSource>();
        for (int i = 0; i < aud.Length; i++)
            aud[i].Stop();

        GetComponent<SoundHandler>().PlaySound("explosion");
        flash.intensity = 4.7f;
        yield return new WaitForSeconds(0.05f);
        blackScreen.SetActive(true);
        yield return new WaitForSeconds(2);
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
