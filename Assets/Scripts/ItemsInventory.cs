using UnityEngine;
using UnityEngine.UI;

public class ItemsInventory : MonoBehaviour
{

    public Sprite[] bigIcons;
    public Image bigIcon;
    public string[] titles;
    public Text title;
    public string[] descriptions;
    public Text description;
    public Button[] itemButtons;
    public GameObject useButton;
    public Text amtsText;

    private AudioSource audioPlayer;
    public AudioClip click, select;
    private int chosenItemNumber;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioPlayer = GetComponent<AudioSource>();

        bigIcon.sprite = bigIcons[0];
        title.text = titles[0];
        description.text = descriptions[0];
        useButton.SetActive(false);
    }

    private void OnEnable()
    {
        for(int i = 0; i < itemButtons.Length; i++)
        {
            if(SaveScript.itemsPickedUp[i] == false)
            {
                itemButtons[i].image.color = new Color(1,1,1,0.06f);
                itemButtons[i].image.raycastTarget = false;
            }
            if(SaveScript.itemsPickedUp[i] == true)
            {
                itemButtons[i].image.color = new Color(1,1,1,1);
                itemButtons[i].image.raycastTarget = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChooseItem (int itemNumber)
    {
        bigIcon.sprite = bigIcons[itemNumber];
        title.text = titles[itemNumber];
        description.text = descriptions[itemNumber];
        audioPlayer.clip = click;
        audioPlayer.Play();
        chosenItemNumber = itemNumber;
        amtsText.text = "Amounts: " + SaveScript.itemAmts[itemNumber];

        if(itemNumber < 4)
        {
            useButton.SetActive(false);
        }
        else
        {
            useButton.SetActive(true);
        }
    }

    public void AssignItem()
    {
        SaveScript.itemID = chosenItemNumber;
        audioPlayer.clip = select;
        audioPlayer.Play();
    }

}
