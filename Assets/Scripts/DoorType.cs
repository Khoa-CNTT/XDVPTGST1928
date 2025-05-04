using UnityEngine;

public class DoorType : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public enum typeOfDoor
    {
        cabinet,
        house, 
        cabin
    }

    public typeOfDoor chooseDoor;
    public bool opened = false;
    public bool locked = false;
    [HideInInspector]
    public string message = "Press E to open the door";
    private Animator anim;
    public bool electricDoor = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        if(opened == true)
        {
            anim.SetTrigger("Open");
            message = "Press E to close the door";
        }
    }
}
