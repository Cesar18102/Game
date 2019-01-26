using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Static : MonoBehaviour {

    public static int kicked = 0;
    public delegate void Complete();
    public static Complete Completed;
    public static bool BoxesKilled = false;

    public static int TopChestsOpened = 0;
    public static bool LastChestRead = false;
    public static bool KeyGot = false;
    public static bool MysteryRoomOpened = false;
    public static bool MainChestOpened = false;

	// Use this for initialization
	void Start () {

        Completed += CMP;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void CMP() {

        UpdateProgress.Message = "Отлично! вы справились, теперь исследуйте сундук";
        Static.BoxesKilled = true;
    }
}
