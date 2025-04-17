using UnityEngine;
using UnityEngine.Rendering.PostProcessing;  

public class LookMode : MonoBehaviour
{
    private PostProcessVolume vol;
    public PostProcessProfile standard;
    public PostProcessProfile nightVision;
    public PostProcessProfile inventory;
    public GameObject flashLightOverlay;
    public GameObject inventoryMenu;
    public GameObject nightVisionOverlay;
    public GameObject combinePanel;
    private Light flashLight;
    private bool nightVisionOn = false; 
    private bool flashLightOn = false; 
    public GameObject pointer;
    

    void Start()
    {
        vol = GetComponent<PostProcessVolume>(); 
        flashLight = GameObject.Find("FlashLight").GetComponent<Light>();
        flashLight.enabled = false;
        nightVisionOverlay.SetActive(false);
        flashLightOverlay.SetActive(false);
        inventoryMenu.SetActive(false);
        vol.profile = standard;
    }

    void Update()
    {
        if(Input.GetKeyUp(KeyCode.N))
        {
            if (SaveScript.inventoryOpen == false){
            if(nightVisionOn == false)
            {
                vol.profile = nightVision;
                nightVisionOverlay.SetActive(true);
                nightVisionOn = true;
                NightVisionOff();
            }
            else if(nightVisionOn == true)
            {
                vol.profile = standard;
                nightVisionOverlay.SetActive(false);
                nightVisionOverlay.GetComponent<NightVision>().StopDrain();
                this.gameObject.GetComponent<Camera>().fieldOfView = 60;
                nightVisionOn = false;
            }
            }
        }

        if(Input.GetKeyUp(KeyCode.F))
        {
            if (SaveScript.inventoryOpen == false){
            if(flashLightOn == false)
            {
                
                flashLightOverlay.SetActive(true);
                flashLight.enabled = true;
                flashLightOn = true;
                FlashLightOff();
                
            }
            else if(flashLightOn == true)
            {
                flashLightOverlay.SetActive(false);
                flashLight.enabled = false;
                flashLightOverlay.GetComponent<FlashLightScript>().StopDrain();
                flashLightOn = false;
            }
            }
        }

        if(Input.GetKeyDown(KeyCode.B))
        {
            if(SaveScript.inventoryOpen == false)
            {
                vol.profile = inventory;
                inventoryMenu.SetActive(true);

                if(flashLightOn == true)
                {
                    flashLightOverlay.SetActive(false);
                    flashLight.enabled = false;
                    flashLightOverlay.GetComponent<FlashLightScript>().StopDrain();
                }
                if(nightVisionOverlay == true)
                {
                    nightVisionOverlay.SetActive(false);
                    nightVisionOverlay.GetComponent<NightVision>().StopDrain();
                    this.gameObject.GetComponent<Camera>().fieldOfView = 60;
                    nightVisionOn = false;
                }
            }
            else if (SaveScript.inventoryOpen == true)
            {
                vol.profile = standard;
                combinePanel.SetActive(false);
                inventoryMenu.SetActive(false);
            }
        }

        if(nightVisionOn == true)
        {
            NightVisionOff();
        }

        if(flashLightOn == true)
        {
            FlashLightOff();
        }

        if(SaveScript.inventoryOpen == true)
        {
            Cursor.visible = true;
            pointer.SetActive(false);
        }
        else
        {
            Cursor.visible = false;
            pointer.SetActive(true);
        }

    }

    private void NightVisionOff()
    {
        if(nightVisionOverlay.GetComponent<NightVision>().batteryPower <= 0)
        {
            vol.profile = standard;
                nightVisionOverlay.SetActive(false);
                this.gameObject.GetComponent<Camera>().fieldOfView = 60;
                nightVisionOn = false;
        }
    }
    private void FlashLightOff()
    {
        if(flashLightOverlay.GetComponent<FlashLightScript>().batteryPower <= 0)
        {
            flashLightOverlay.SetActive(false);
            flashLight.enabled = false;
            flashLightOverlay.GetComponent<FlashLightScript>().StopDrain();
            flashLightOn = false;
        }
    }
}