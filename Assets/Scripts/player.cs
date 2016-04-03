using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class player : Photon.MonoBehaviour {
	
	public GameObject bullet;
	public Transform muzzle;
	public float speed = 20;
	private float HP = 100;
	private float flag = 0;
	private float timer;
	public GameObject Hp;
	public Text HPText;
	// Use this for initialization
	void Start () {
		if (photonView.isMine) {
			Hp = GameObject.Find ("Image");
		}
	
	}
	
	// Update is called once per frame
	void Update () {
		if (photonView.isMine) {
			Hp.gameObject.GetComponent<Image> ().fillAmount = HP / 20.0f;
			if (Input.GetKeyDown (KeyCode.Space)) {
				GameObject obj = PhotonNetwork.Instantiate ("bullet", muzzle.position, transform.rotation, 0) as GameObject;
				Rigidbody rd = obj.GetComponent<Rigidbody> ();
				rd.velocity = this.transform.forward * speed;
			}

			if (HP <= 0) {
				this.transform.position = new Vector3 (-5.15f, -16f, -3.38f);
				flag = 1;
			}

			if (flag == 1) {
				timer += Time.deltaTime;
			}

			if (timer >= 7) {
				time ();
			}
		}
	
	}
	void damage (){
		if (photonView.isMine) {
			HP -= 5;
			Hp.gameObject.GetComponent<Image> ().fillAmount = HP / 20.0f;
		}
	}
	void time (){
		if (photonView.isMine) {
			Hp.gameObject.GetComponent<Image> ().fillAmount = 1;
			HP = 100;
			flag = 0;
			timer = 0;
			this.transform.position = new Vector3 (0, 5, -2);
		}
	}
	/*void OnCollisionEnter (Collision col){
		if(col.gameObject.tag == player){
			flag == 1;
		}
	}
	void Update () {
	    if(flag == 1){
			transform.position += new Vector2 (0, -1);
	    }
	}*/

}


