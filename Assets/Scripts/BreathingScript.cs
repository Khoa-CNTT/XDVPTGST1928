using UnityEngine;

public class BreathingScript : MonoBehaviour
{
    private AudioSource audioPlayer;
    private bool heavyBreathing = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(SaveScript.stamina < 20 && heavyBreathing == false)
        {
            heavyBreathing = true;
            audioPlayer.Play();
        }
        if(SaveScript.stamina > 19)
        {
            heavyBreathing = false;
            audioPlayer.Stop();
        }
    }
}
