using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest : MonoBehaviour {

    public GameObject key;
    public ParticleSystem PS;
    public GameObject WallMystery;
    private float radius = 0.5f;

	// Use this for initialization
	void Start () {

        PS.Stop();
	}
	
	// Update is called once per frame
	void Update () {

        Collider[] C = Physics.OverlapSphere(this.transform.position, radius);

        foreach (Collider CL in C) {

            if(CL.name.StartsWith("MainBox") && Static.BoxesKilled && Input.GetKey(KeyCode.E)) {

                CL.GetComponent<Animator>().SetTrigger("Open");
                Static.FirstChestRead = true;
            }

            if (CL.name.StartsWith("MysChest") && Input.GetKey(KeyCode.E) && Static.FirstChestRead && !CL.GetComponent<TopChestState>().opened) {

                CL.GetComponent<TopChestState>().opened = true;
                Static.TopChestsOpened++;
                CL.GetComponent<Animator>().SetTrigger("Open");
                UpdateProgress.Message = "Ухты!!!";
            }

            if (CL.name.StartsWith("LastMysChest") && Input.GetKey(KeyCode.E) && Static.TopChestsOpened == 5) {

                Static.LastChestRead = true;
                CL.GetComponent<Animator>().SetTrigger("Open");
                UpdateProgress.Message = "Интересно, что тут зашифровано??";

                radius = 1f;
            }

            if (CL.name.StartsWith("fireplace") && Input.GetKey(KeyCode.E) && Static.LastChestRead) {

                Static.KeyGot = true;
                key.GetComponent<Rigidbody>().useGravity = true;
                key.transform.position = new Vector3(-4.5f, 1f, 5f);
                UpdateProgress.Message = "Невероятно, что же он открывает??";
                PS.Play();

                //анимация поднятия ключа
            }

            if (CL.name.StartsWith("Key_Wall") && Input.GetKey(KeyCode.E) && Static.KeyGot) // && Static.QuestAnswered
            {
                moveObj(WallMystery, 0, 0, 1);
                moveObj(key, 0, 0, 1);
                UpdateProgress.Message = "Победа!!! Вы открылитайную комнату!!!";
            }
        }
	}

    void moveObj(GameObject GO, float dx, float dy, float dz) {

        GO.transform.position = new Vector3(GO.transform.position.x + dx, GO.transform.position.y + dy, GO.transform.position.z + dz);
    }
}
