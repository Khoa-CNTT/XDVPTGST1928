using UnityEngine;

public class UiScale : MonoBehaviour
{
    public float scaleValume = 1;
    public float UHDScale = 2;
    void Start()
    {
        if(Screen.width > 1920)
        {
            scaleValume = UHDScale;
        }
        this.transform.localScale = new Vector3(scaleValume, scaleValume, scaleValume);
    }
}
