using UnityEngine;
using UnityEngine.UI;

public class PickupsScript : MonoBehaviour
{
    private RaycastHit hit;
    public LayerMask excludeLayers;
    public GameObject pickupPanel;
    public float pickupDisplayDistance = 3;

    public Image mainImage;
    public Sprite[] weaponIcons;
    public Sprite[] itemIcons;
    public Sprite[] ammoIcons;
    
    public Text mainTitle;
    public string[] weaponTitles;
    public string[] itemTitles;
    public string[] ammoTitles;


    private RaycastHit gunHit;
    private RaycastHit[] shotgunHits;

    private int objID = 0;

    private AudioSource audioPlayer;

    public GameObject doorMessageObj;
    public Text doorMessage;
    public AudioClip[] pickupSounds;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pickupPanel.SetActive(false);
        audioPlayer = GetComponent<AudioSource>();
        doorMessageObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics.SphereCast(transform.position, 0.3f, transform.forward, out hit, 30, ~excludeLayers))
        {
            if(Vector3.Distance(transform.position, hit.transform.position) < pickupDisplayDistance)
            {
                if (hit.transform.gameObject.CompareTag("weapon"))
                {
                    pickupPanel.SetActive(true);
                    objID = (int)hit.transform.gameObject.GetComponent<WeaponType>().chooseWeapon;
                    mainImage.sprite = weaponIcons[objID];
                    mainTitle.text = weaponTitles[objID];

                    if(Input.GetKeyDown(KeyCode.E))
                    {
                        SaveScript.weaponAmts[objID]++;
                        audioPlayer.clip = pickupSounds[3];
                        audioPlayer.Play();
                        SaveScript.change = true;
                        Destroy(hit.transform.gameObject, 0.2f);
                    }
                }
                else if (hit.transform.gameObject.CompareTag("item"))
                {
                    pickupPanel.SetActive(true);
                    objID = (int)hit.transform.gameObject.GetComponent<ItemsType>().chooseItem;
                    mainImage.sprite = itemIcons[objID];
                    mainTitle.text = itemTitles[objID];

                    if(Input.GetKeyDown(KeyCode.E))
                    {
                        SaveScript.itemAmts[objID]++;
                        audioPlayer.clip = pickupSounds[3];
                        audioPlayer.Play();
                        SaveScript.change = true;
                        Destroy(hit.transform.gameObject, 0.2f);
                    }
                }
                else if (hit.transform.gameObject.CompareTag("ammo"))
                {
                    pickupPanel.SetActive(true);
                    objID = (int)hit.transform.gameObject.GetComponent<AmmoType>().chooseAmmo;
                    mainImage.sprite = ammoIcons[objID];
                    mainTitle.text = ammoTitles[objID];

                    if(Input.GetKeyDown(KeyCode.E))
                    {
                        if(objID == 0)
                        {
                            SaveScript.ammoAmts[0] += 12;
                        }
                        if(objID == 1)
                        {
                            SaveScript.ammoAmts[1] += 8;
                        }
                        
                        audioPlayer.clip = pickupSounds[3];
                        audioPlayer.Play();
                        SaveScript.change = true;
                        Destroy(hit.transform.gameObject, 0.2f);
                    }
                }
                else if (hit.transform.gameObject.CompareTag("door"))
                {
                    SaveScript.doorObject = hit.transform.gameObject;
                    objID = (int)hit.transform.gameObject.GetComponent<DoorType>().chooseDoor;
                    if(hit.transform.gameObject.GetComponent<DoorType>().locked == true)
                    {
                        hit.transform.gameObject.GetComponent<DoorType>().message = "Locked. You need to use the " + hit.transform.gameObject.GetComponent<DoorType>().chooseDoor + " key";
                    }
                    if(hit.transform.gameObject.GetComponent<DoorType>().locked == false)
                    {
                        hit.transform.gameObject.GetComponent<DoorType>().message = "Press E to close the door" ;
                    }
                    
                    doorMessageObj.SetActive(true);
                    doorMessage.text = hit.transform.gameObject.GetComponent<DoorType>().message;
                    if(Input.GetKeyDown(KeyCode.E) && hit.transform.gameObject.GetComponent<DoorType>().locked == false)
                    {
                        audioPlayer.clip = pickupSounds[objID];
                        audioPlayer.Play();
                        if(hit.transform.gameObject.GetComponent<DoorType>().opened == false)
                        {
                            hit.transform.gameObject.GetComponent<DoorType>().message = "Press E to close the door";
                            hit.transform.gameObject.GetComponent<DoorType>().opened = true;
                            hit.transform.gameObject.GetComponent<Animator>().SetTrigger("Open");
                        }
                        else if(hit.transform.gameObject.GetComponent<DoorType>().opened == true)
                        {
                            hit.transform.gameObject.GetComponent<DoorType>().message = "Press E to open the door";
                            hit.transform.gameObject.GetComponent<DoorType>().opened = false;
                            hit.transform.gameObject.GetComponent<Animator>().SetTrigger("Close");
                        }
                        
                       
                        
                        
                    }
                }
            }
            else
            {
                pickupPanel.SetActive(false);
                doorMessageObj.SetActive(false);
                SaveScript.doorObject = null;
            }
        }

        if(Physics.SphereCast(transform.position, 0.01f, transform.forward, out gunHit, 300))
        {
            if(gunHit.transform.gameObject.name == "Body" && SaveScript.weaponID == 4)
            {
                if(Input.GetMouseButtonDown(0) && SaveScript.currentAmmo[4]>0)
                {
                    gunHit.transform.gameObject.GetComponent<ZombieGunDamage>().SendGunDamage(gunHit.point);
                }
            }
        }
        if(SaveScript.weaponID == 5 && SaveScript.weaponAmts[5]>0)
        {
            shotgunHits = Physics.SphereCastAll(transform.position, 0.3f, transform.forward, 50);
            for(int i = 0; i < shotgunHits.Length; i++)
            {
                if(shotgunHits[i].transform.gameObject.name == "Body")
                {
                    if(Input.GetMouseButtonDown(0))
                    {
                        shotgunHits[i].transform.gameObject.GetComponent<ZombieGunDamage>().SendGunDamage(shotgunHits[i].point);
                    }
                }
            }
        }
    }
}
