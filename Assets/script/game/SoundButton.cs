using UnityEngine;
using System.Collections;

public class SoundButton : MonoBehaviour
{

    public GameObject play;
    public GameObject playHover;
    public GameObject stop;
    public GameObject stopHover;
    public AudioSource audio;

    void OnMouseEnter()
    {
        if (play.activeSelf)
        {
            play.SetActive(false);
            playHover.SetActive(true);
        }
        else if (stop.activeSelf)
        {
            stop.SetActive(false);
            stopHover.SetActive(true);
        }

    }

    void OnMouseExit()
    {
        if (playHover.activeSelf)
        {
            play.SetActive(true);
            playHover.SetActive(false);
        }
        else if (stopHover.activeSelf)
        {
            stop.SetActive(true);
            stopHover.SetActive(false);
        }
    }

    void OnMouseDown()
    {
        if (audio.isPlaying)
        {
            audio.Stop();
            stop.SetActive(true);
            play.SetActive(false);
            playHover.SetActive(false);
        }
        else
        {
            audio.Play();
            play.SetActive(true);
            stop.SetActive(false);
            stopHover.SetActive(false);
        }
    }
}
