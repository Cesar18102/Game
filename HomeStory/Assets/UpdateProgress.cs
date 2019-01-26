using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateProgress : MonoBehaviour {


    private Text TXT;

    public static string Message = "Очистите кладовку от коробок, кликая на них: 0/20\nДоберитесь до центра комнаты";

	// Use this for initialization
	void Start () {

        TXT = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {

        TXT.text = Message;
	}
}
