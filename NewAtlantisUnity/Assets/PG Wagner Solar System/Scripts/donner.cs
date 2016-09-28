﻿using UnityEngine;
using System.Collections;

public class donner : MonoBehaviour {
	public AudioClip mysound;
	Vector3 target;
	Vector3 startpos1;
	bool on = false;
    public GameObject myParent;
    GameObject currentParent;
    // Use this for initialization
    void Start () {

		GetComponent<Renderer>().material.color = Color.green;
		target = new Vector3 (-3.3410f, -5.0f, -7.9652214f);
		startpos1 = transform.position;
		
	}
	void StartEvent ()
	{
		GetComponent<Renderer>().material.color = Color.white;
	
		on = true;
		GetComponent<AudioSource>().Play ();
	}

    void OnTriggerEnter(Collider e)
    {

        seekParent(e.transform);

        if (currentParent != myParent) StartEvent();

    }


    void seekParent(Transform t)
    {

        if (t.parent != null)
        {
            seekParent(t.parent);
        }
        else
        {
            currentParent = t.gameObject;
        }

    }

    // Update is called once per frame
    void Update () {

		if (on)
		{
			Vector3 direction = target - transform.localPosition;
			
			
			if (direction.magnitude > 00.0019f)
			{
				direction.Normalize ();
				//transform.Translate (Vector3.forward * Time.deltaTime * 1);
				//transform.Translate (direction * Time.deltaTime * 0.3f);
				Vector3 pos = transform.position;
				pos += direction * Time.deltaTime * 0.31f;
				transform.position = pos;

				//transform.LookAt (target);
				transform.Rotate(new Vector3(Time.deltaTime*-10.0f, Time.deltaTime*-10f, 0));
			}
			else
			{
				on = false;
				GetComponent<AudioSource>().Stop ();
				transform.position = startpos1;
				GetComponent<Renderer>().material.color = Color.green;
				
			}
		}
		
		
		
	}
}