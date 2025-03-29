using UnityEngine;

public class InventorySwitch : MonoBehaviour
{
    public GameObject weaponPanel, itemsPanel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        weaponPanel.SetActive(true);
        itemsPanel.SetActive(false);

    }

   public void SwitchItemsOn()
   {
        weaponPanel.SetActive(false);
        itemsPanel.SetActive(true);
   }

   public void SwitchWeaponsOn()
   {
        weaponPanel.SetActive(true);
        itemsPanel.SetActive(false);
   }
}
