using UnityEngine;
using UnityEngine.Rendering.PostProcessing;  

public class LookMode : MonoBehaviour
{
    private PostProcessVolume vol;
    public PostProcessProfile standard;
    public PostProcessProfile nightVision;
    public PostProcessProfile inventory;
    public GameObject flashLightOverlay;
    public GameObject nightVisionOverlay;
    private Light flashLight;
    private bool nightVisionOn = false; 
    private bool flashLightOn = false; 
    private bool inventoryOn = false; 

    void Start()
    {
        vol = GetComponent<PostProcessVolume>(); 
        flashLight = GameObject.Find("FlashLight").GetComponent<Light>();
        flashLight.enabled = false;
        nightVisionOverlay.SetActive(false);
        flashLightOverlay.SetActive(false);
        vol.profile = standard;
    }

    void Update()
    {
        if(Input.GetKeyUp(KeyCode.N))
        {
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

        if(Input.GetKeyUp(KeyCode.F))
        {
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

        if(Input.GetKeyDown(KeyCode.B))
        {
            if(inventoryOn == false)
            {
                vol.profile = inventory;
                inventoryOn = true;
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
            else if (inventoryOn == true)
            {
                vol.profile = standard;
                inventoryOn = false;
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