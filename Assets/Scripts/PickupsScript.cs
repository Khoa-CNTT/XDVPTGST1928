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
    public Text mainTitle;
    public string[] weaponTitles;
    public string[] itemTitles;


    private int objID = 0;

    private AudioSource audioPlayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pickupPanel.SetActive(false);
        audioPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics.SphereCast(transform.position, 0.5f, transform.forward, out hit, 30, ~excludeLayers))
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
                        audioPlayer.Play();
                        SaveScript.change = true;
                        Destroy(hit.transform.gameObject, 0.2f);
                    }
                }
            }
            else
            {
                pickupPanel.SetActive(false);
            }
        }
    }
}
