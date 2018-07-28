using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    Animator anim;

    [SerializeField]
    GameObject DoorType;

    int stateOfDoor = 1;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();

        if (DoorType.name == "EntryDoor")
           anim.SetFloat("DoorStatus", 3);

        if (DoorType.name == "ExitDoor")
            LockDoor();
    }

    void LockDoor()
    {
        if (DoorType.name == "ExitDoor")
        {
            anim.SetFloat("DoorStatus", 1);
            stateOfDoor = 1;
        }
    }

    void UnLockDoor()
    {
        if (DoorType.name == "ExitDoor")
        {
            anim.SetFloat("DoorStatus", 2);
            stateOfDoor = 2;
        }
    }

    void OpenDoor()
    {
        if (DoorType.name == "ExitDoor")
        {
            anim.SetFloat("DoorStatus", 3);
            stateOfDoor = 3;
        }
    }

    public void SetDoorState(int state)
    {
        if (state == 1 && DoorType.name == "ExitDoor")
            LockDoor();
        if (state == 2 && DoorType.name == "ExitDoor")
            UnLockDoor();
        if (state == 3 && DoorType.name == "ExitDoor")
            OpenDoor();
    }

    public int GetDoorState()
    {
        return stateOfDoor;
    }
}
