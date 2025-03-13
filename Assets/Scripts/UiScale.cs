using UnityEngine;

public class UiScale : MonoBehaviour
{
    private float scaleValume = 1;
    void Start()
    {
        if(Screen.width > 1920)
        {
            scaleValume = 2;
        }
        this.transform.localScale = new Vector3(scaleValume, scaleValume, scaleValume);
    }
}
