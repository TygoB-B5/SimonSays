using UnityEngine;

public class SoundHandler : MonoBehaviour
{
    public AudioClip[] bleep;
    public AudioClip explosion;
    public AudioSource aud;

    private bool enableSound = true;

    public void PlaySound(string name)
    {
        if (!enableSound)
            return;

        if (name == "bleep1")
            aud.PlayOneShot(bleep[0]);
        else if (name == "bleep2")
            aud.PlayOneShot(bleep[1]);
        else if (name == "bleep3")
            aud.PlayOneShot(bleep[2]);
        else if (name == "bleep4")
            aud.PlayOneShot(bleep[3]);
        else if (name == "explosion")
        {
            aud.PlayOneShot(explosion);
            enableSound = false;
        }
    }
}
