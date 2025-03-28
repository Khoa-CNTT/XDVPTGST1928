using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class SaveScript : MonoBehaviour
{
    public static bool inventoryOpen = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
