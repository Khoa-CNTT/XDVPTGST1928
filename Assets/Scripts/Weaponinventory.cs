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
    public Button[] weaponButtons;

    private AudioSource audioPlayer;
    public AudioClip click, select;
    private int chosenWeaponNumber;

    void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
        
    }


    
    private void OnEnable()
    {
        for(int i = 0; i < weaponButtons.Length; i++)
        {
            if(SaveScript.weaponsPickedUp[i] == false)
            {
                weaponButtons[i].image.color = new Color(1,1,1,0.06f);
                weaponButtons[i].image.raycastTarget = false;
            }
            if(SaveScript.weaponsPickedUp[i] == true)
            {
                weaponButtons[i].image.color = new Color(1,1,1,1);
                weaponButtons[i].image.raycastTarget = true;
            }
        }
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
        chosenWeaponNumber = weaponnumber;
    }

    public void AssignWeapon()
    {
        SaveScript.weaponID = chosenWeaponNumber;
        audioPlayer.clip = select;
        audioPlayer.Play();
    }
}
