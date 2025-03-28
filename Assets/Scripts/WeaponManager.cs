using UnityEngine;
using System.Collections;

public class WeaponManager : MonoBehaviour
{
    public enum WeaponSelect{
        Knife,
        Cleaver,
        Bat,
        Axe,
        Pistol,
        Shotgun,
        SprayCan,
        Bottle
    }
    
    public WeaponSelect chosenWeapon;
    public GameObject [] weapons;
    private int weaponID = 0;
    private Animator anim;
    private AudioSource audioPlayer;
    public AudioClip[] weaponSounds;


    void Start()
    {
        weaponID = (int)chosenWeapon;
        anim = GetComponent<Animator>();
        audioPlayer = GetComponent<AudioSource>();
        ChangeWeapons();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            if(weaponID < weapons.Length-1)
            {
                weaponID++;
                ChangeWeapons();
            }
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(weaponID > 0)
            {
                weaponID--;
                ChangeWeapons();
            }
        }

        if(Input.GetMouseButtonDown(0))
        {
            if(SaveScript.inventoryOpen == false)
            {
            anim.SetTrigger("Attack");
            audioPlayer.clip = weaponSounds[weaponID];
            audioPlayer.Play();
            }
        }
    }

    private void ChangeWeapons(){
        foreach (GameObject weapon in weapons)
        {
            weapon.SetActive(false);
        }
        weapons[weaponID].SetActive(true);
        chosenWeapon = (WeaponSelect)weaponID;
        anim.SetInteger("WeaponID", weaponID);
        anim.SetBool("weaponChanged", true);
        Move();
        StartCoroutine(WeaponReset());
    }

    private void Move()
    {
        switch (chosenWeapon)
        {
            case WeaponSelect.Knife:
                transform.localPosition = new Vector3 (0.02f, -0.193f, 0.66f);
                break;
            case WeaponSelect.Cleaver:
                transform.localPosition = new Vector3 (0.02f, -0.193f, 0.66f);
                break;
            case WeaponSelect.Bat:
                transform.localPosition = new Vector3 (0.02f, -0.193f, 0.66f);
                break;
            case WeaponSelect.Axe:
                transform.localPosition = new Vector3 (0.02f, -0.193f, 0.66f);
                break;
            case WeaponSelect.Pistol:
                transform.localPosition = new Vector3 (0.02f, -0.193f, 0.66f);
                break;
            case WeaponSelect.Shotgun:
                transform.localPosition = new Vector3 (0.02f, -0.193f, 0.46f);
                break;
            case WeaponSelect.SprayCan:
                transform.localPosition = new Vector3 (0.02f, -0.193f, 0.66f);
                break;
            case WeaponSelect.Bottle:
                transform.localPosition = new Vector3 (0.02f, -0.193f, 0.66f);
                break;
        }
    }

    IEnumerator WeaponReset()
    {
        yield return new WaitForSeconds(0.5f);

        anim.SetBool("weaponChanged", false);
    }
}
