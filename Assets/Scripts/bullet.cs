using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {
	private float timer = 0;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >= 7) {
			Destroy (this.gameObject);
		} 
	
	}
	void OnCollisionEnter (Collision col){
		if (col.gameObject.tag == "Player") {
			col.gameObject.SendMessage("damage");
		}
	}
}
