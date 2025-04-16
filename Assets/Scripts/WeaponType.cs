using UnityEngine;

public class WeaponType : MonoBehaviour
{
    public enum typeOfWeapon{
        Knife,
        Cleaver,
        Bat,
        Axe,
        Pistol,
        Shotgun,
        SprayCan,
        Bottle,
        BottleWithCloth
        
    }
    
    public typeOfWeapon chooseWeapon;
}
