using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class SaveScript : MonoBehaviour
{
    public static bool inventoryOpen = false;
    public static int weaponID = 0;
    public static bool[] weaponsPickedUp = new bool[8];
    public static int itemID = 0;
    public static bool[] itemsPickedUp = new bool[13];



    void Start()
    {
        weaponsPickedUp[0] = true;
        weaponsPickedUp[1] = true;
        weaponsPickedUp[2] = true;
        weaponsPickedUp[3] = true;
        weaponsPickedUp[4] = true;
        weaponsPickedUp[5] = true;
        weaponsPickedUp[6] = true;
        weaponsPickedUp[7] = true;


        itemsPickedUp[0] = true;
        itemsPickedUp[1] = true;
        itemsPickedUp[2] = true;
        itemsPickedUp[3] = true;
        itemsPickedUp[4] = true;
        itemsPickedUp[5] = true;
        itemsPickedUp[6] = true;
        itemsPickedUp[7] = true;

        
    }

    // Update is called once per frame
    void Update()
    {
        if(FirstPersonController.inventorySwitchedOn == true)
        {
            inventoryOpen = true;
        }
        if(FirstPersonController.inventorySwitchedOn == false)
        {
            inventoryOpen = false;
        }
    }
}
