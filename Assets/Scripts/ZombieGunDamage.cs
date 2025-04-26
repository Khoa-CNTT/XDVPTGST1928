using UnityEngine;

public class ZombieGunDamage : MonoBehaviour
{
    public GameObject zombieDamageObj;
    public void SendGunDamage(Vector3 hitPoint)
    {
        zombieDamageObj.GetComponent<ZobieDamage>().gunDamage(hitPoint);
    }
}
