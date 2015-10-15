using UnityEngine;
using System.Collections;

public class scrollTxt: MonoBehaviour {

public float scroll = 0.025f;  // scrolling velocity
public float duration = 1.5f; // time to die
private float alpha;
public Camera m_Camera;

void Start(){
	alpha = 1;
}

void Update(){
		m_Camera = Camera.main;
	if (alpha>0){
		transform.position+= new Vector3(0,scroll,0); 
		alpha -= Time.deltaTime/duration;
		transform.LookAt(transform.position + m_Camera.transform.rotation * Vector3.forward, m_Camera.transform.rotation * Vector3.up);
	} else {
		Destroy(gameObject); // text vanished - destroy itself
	}

		

}
}