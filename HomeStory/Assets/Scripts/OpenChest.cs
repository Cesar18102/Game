using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest : MonoBehaviour {

    public GameObject key;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Collider[] C = Physics.OverlapSphere(this.transform.position, 1f);

        foreach (Collider CL in C) {

            if(CL.name.StartsWith("MainBox") && Static.BoxesKilled && Input.GetKey(KeyCode.E)) {

                CL.GetComponent<Animator>().SetTrigger("Open");
                Static.MainChestOpened = true;
            }

            if (CL.name.StartsWith("MysChest") && Input.GetKey(KeyCode.E) && !CL.GetComponent<TopChestState>().opened) {

                CL.GetComponent<TopChestState>().opened = true;
                Static.TopChestsOpened++;
                CL.GetComponent<Animator>().SetTrigger("Open");
                UpdateProgress.Message = "Ухты!!!";
            }

            if (CL.name.StartsWith("LastMysChest") && Input.GetKey(KeyCode.E) && Static.TopChestsOpened == 5) {

                Static.LastChestRead = true;
                CL.GetComponent<Animator>().SetTrigger("Open");
                UpdateProgress.Message = "Интересно, что тут зашифровано??";
            }

            if (CL.name.StartsWith("fireplace") && Input.GetKey(KeyCode.E) && Static.LastChestRead) {

                Static.KeyGot = true;
                key.GetComponent<Rigidbody>().useGravity = true;
                UpdateProgress.Message = "Невероятно, что же он открывает??";
            }
        }
	}
}
