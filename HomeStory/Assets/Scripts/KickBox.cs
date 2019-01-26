using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KickBox : MonoBehaviour {

    public GameObject player;
    public Text TXT;
    private int HP = 2;

	void Start () {
		
	}

    void OnMouseDown() {


        Ray MyRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(MyRay.origin, MyRay.direction * 10, Color.yellow);
        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(MyRay, out hit, 3))
        {

            MeshFilter filter = hit.collider.GetComponent(typeof(MeshFilter)) as MeshFilter;
            if (filter)
            {
                hit.collider.attachedRigidbody.AddExplosionForce(1000, player.transform.position, 100);
                if (--HP == 0)
                {
                    if (++Static.kicked >= 3)
                        Static.Completed();
                    else
                        UpdateProgress.Message = "Очистите кладовку от коробок, кликая на них: " + Static.kicked + "/20\nДоберитесь до центра комнаты";

                    //box destroy animation
                    Destroy(filter.gameObject);
                }
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
