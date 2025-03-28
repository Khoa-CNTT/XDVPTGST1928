using UnityEngine;
using UnityEngine.UI;

public class Weaponinventory : MonoBehaviour
{
    public Sprite[] bigIcons;
    public Image bigIcon;
    public string[] titles;
    public Text title;
    public string[] descriptions;
    public Text description;

    private AudioSource audioPlayer;
    public AudioClip click, select;

    void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChooseWeapon (int weaponnumber)
    {
        bigIcon.sprite = bigIcons[weaponnumber];
        title.text = titles[weaponnumber];
        description.text = descriptions[weaponnumber];
        audioPlayer.clip = click;
        audioPlayer.Play();
    }
}
