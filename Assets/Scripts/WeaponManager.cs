using UnityEngine;
using System.Collections;

public class WeaponManager : MonoBehaviour
{
    public enum WeaponSelect
    {
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

    public WeaponSelect chosenWeapon;
    public GameObject[] weapons;
    //private int weaponID = 0;
    private Animator anim;
    private AudioSource audioPlayer;
    public AudioClip[] weaponSounds;
    private int currentWeaponID;
    private bool spraySoundOn = false;
    public GameObject sprayPanel;
    public static bool emptyBottleThrow = false;
    public static bool fireBottleThrow = false;

    private AnimatorStateInfo animInfo;
    private bool canAttack = true;
    private bool sprayEmpty = false;
    private bool stopSpray = false;
    public AudioClip[] reloadSounds;
    void Start()
    {
        SaveScript.weaponID = (int)chosenWeapon;
        anim = GetComponent<Animator>();
        audioPlayer = GetComponent<AudioSource>();
        ChangeWeapons();
    }

    // Update is called once per frame
    void Update()
    {
        animInfo = anim.GetCurrentAnimatorStateInfo(0);
        if (animInfo.IsTag("BottleThrown"))
        {
            canAttack = false;
        }
        else
        {
            canAttack = true;
        }
        if (SaveScript.weaponID != currentWeaponID)
        {
            ChangeWeapons();
        }

        if (Input.GetMouseButtonDown(0) && canAttack == true)
        {
            if (SaveScript.inventoryOpen == false)
            {
                if (SaveScript.currentAmmo[SaveScript.weaponID] > 0 && SaveScript.stamina > 20)
                {
                    anim.SetTrigger("Attack");
                    audioPlayer.clip = weaponSounds[SaveScript.weaponID];
                    audioPlayer.Play();

                    if (SaveScript.weaponID == 4 || SaveScript.weaponID == 5)
                    {
                        SaveScript.currentAmmo[SaveScript.weaponID]--;
                        SaveScript.gunUsed = true;
                    }
                }
                else
                {
                    if (SaveScript.weaponID == 4 || SaveScript.weaponID == 5)
                    {
                        audioPlayer.clip = weaponSounds[9];
                        audioPlayer.Play();
                    }
                }
            }
        }
        if (Input.GetMouseButton(0) && sprayPanel.GetComponent<SprayScripts>().sprayAmount > 0.0f)
        {
            sprayEmpty = false;
            stopSpray = false;
            if (SaveScript.weaponID == 6 && SaveScript.inventoryOpen == false)
            {
                if (spraySoundOn == false)
                {
                    spraySoundOn = true;
                    anim.SetTrigger("Attack");
                    StartCoroutine(StartSpraySound());

                }
            }
        }
        if (Input.GetMouseButtonUp(0) || sprayPanel.GetComponent<SprayScripts>().sprayAmount <= 0.0f)
        {

            if (SaveScript.weaponID == 6 && SaveScript.inventoryOpen == false && stopSpray == false)
            {
                stopSpray = true;
                anim.SetTrigger("Release");
                spraySoundOn = false;
                audioPlayer.Stop();
                audioPlayer.loop = false;
            }
        }
        if (sprayPanel.GetComponent<SprayScripts>().sprayAmount <= 0.0f && sprayEmpty == false)
        {
            sprayEmpty = true;
            SaveScript.weaponAmts[6]--;
            if (SaveScript.weaponAmts[6] == 0)
            {
                SaveScript.weaponsPickedUp[6] = false;
            }
        }


        if (SaveScript.weaponID == 4 || SaveScript.weaponID == 5)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                if (SaveScript.ammoAmts[SaveScript.weaponID - 4] > 0)
                {

                    SaveScript.currentAmmo[SaveScript.weaponID] += SaveScript.ammoAmts[SaveScript.weaponID - 4];
                    SaveScript.ammoAmts[SaveScript.weaponID - 4] = 0;
                    anim.SetTrigger("Reload");
                    audioPlayer.clip = reloadSounds[SaveScript.weaponID - 4];
                    audioPlayer.Play();
                }
            }
        }

    }

    private void ChangeWeapons()
    {
        foreach (GameObject weapon in weapons)
        {
            weapon.SetActive(false);
        }
        weapons[SaveScript.weaponID].SetActive(true);
        chosenWeapon = (WeaponSelect)SaveScript.weaponID;
        anim.SetInteger("WeaponID", SaveScript.weaponID);
        anim.SetBool("weaponChanged", true);
        currentWeaponID = SaveScript.weaponID;

        Move();
        StartCoroutine(WeaponReset());
    }

    private void Move()
    {
        switch (chosenWeapon)
        {
            case WeaponSelect.Knife:
                transform.localPosition = new Vector3(0.02f, -0.193f, 0.66f);
                break;
            case WeaponSelect.Cleaver:
                transform.localPosition = new Vector3(0.02f, -0.193f, 0.66f);
                break;
            case WeaponSelect.Bat:
                transform.localPosition = new Vector3(0.02f, -0.193f, 0.66f);
                break;
            case WeaponSelect.Axe:
                transform.localPosition = new Vector3(0.02f, -0.193f, 0.66f);
                break;
            case WeaponSelect.Pistol:
                transform.localPosition = new Vector3(0.02f, -0.193f, 0.66f);
                break;
            case WeaponSelect.Shotgun:
                transform.localPosition = new Vector3(0.02f, -0.193f, 0.46f);
                break;
            case WeaponSelect.SprayCan:
                transform.localPosition = new Vector3(0.02f, -0.193f, 0.66f);
                break;
            case WeaponSelect.Bottle:
                transform.localPosition = new Vector3(0.02f, -0.193f, 0.66f);
                break;
        }
    }

    public void BottleThrowEmpty()
    {
        emptyBottleThrow = true;
    }

    public void BottleThrowFire()
    {
        fireBottleThrow = true;
    }

    public void LoadAnotherBottle()
    {
        if (SaveScript.weaponID == 7)
        {
            ChangeWeapons();
        }
    }

    public void LoadAnotherFireBottle()
    {
        if (SaveScript.weaponID == 8)
        {
            ChangeWeapons();
        }
    }

    IEnumerator WeaponReset()
    {
        yield return new WaitForSeconds(0.5f);

        anim.SetBool("weaponChanged", false);
    }

    IEnumerator StartSpraySound()
    {
        yield return new WaitForSeconds(0.53f);
        audioPlayer.clip = weaponSounds[SaveScript.weaponID];
        audioPlayer.Play();
        audioPlayer.loop = true;
    }
}
