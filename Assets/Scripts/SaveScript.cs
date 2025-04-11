using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class SaveScript : MonoBehaviour
{
    public static bool inventoryOpen = false;
    public static int weaponID = 0;
    public static bool[] weaponsPickedUp = new bool[8];
    public static int itemID = 0;
    public static bool[] itemsPickedUp = new bool[13];
    public static int[] weaponAmts = new int [8];
    public static int[] itemAmts = new int [13];
    public static bool change = false;
    public static int[] ammoAmts = new int [2];
    public static int[] currentAmmo = new int[9];




    void Start()
    {
        weaponsPickedUp[0] = true;
        


        itemsPickedUp[0] = true;
        itemsPickedUp[1] = true;
        itemAmts[0] = 1;
        itemAmts[1] = 1;
        ammoAmts[0] = 12;
        ammoAmts[1] = 2;

        for(int i =0; i<currentAmmo.Length; i++)
        {
            currentAmmo[i] = 2;
        }
        currentAmmo[4] = 12;
        
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

        if(change == true)
    {
        change = false;
        for(int i = 1; i < weaponAmts.Length; i ++)
        {
            if(weaponAmts[i] > 0)
            {
                weaponsPickedUp[i] = true;
            }
            else if(weaponAmts[i] == 0)
            {
                weaponsPickedUp[i] = false;
            }
        }
        for(int i = 2; i < itemAmts.Length; i ++)
        {
            if(itemAmts[i] > 0)
            {
                itemsPickedUp[i] = true;
            }
            else if(itemAmts[i] == 0)
            {
                itemsPickedUp[i] = false;
            }
        }
    }
    }

    
}
