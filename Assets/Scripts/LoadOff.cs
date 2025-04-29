using UnityEngine;

public class LoadOff : MonoBehaviour
{
    
    void Start()
    {
        Invoke("SwitchOff", 1);
    }

    // Update is called once per frame
    void SwitchOff()
    {
        this.gameObject.SetActive(false);
    }

}
