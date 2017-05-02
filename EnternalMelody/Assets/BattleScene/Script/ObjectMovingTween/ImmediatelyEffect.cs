using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImmediatelyEffect : ObjectTween {
	// Use this for initialization
	void Start () {        
        rig = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {

    }

    public override void startMoving() {
        if (target != null)
            transform.position = target.gameObject.transform.position;
        else
            Debug.Log("233");
    }

    public void OnTriggerEnter2D(Collider2D col) { 

            if (col.tag == targetTag)
            {
                BattleHandler.instance.castEffect(attacker, target, sectionEffect);
                Destroy(gameObject);
            }      
    }
}
