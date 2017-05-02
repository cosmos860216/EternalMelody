using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : UIScript {
    public SpriteBattling target;
    public Slider bar;
    // Use this for initialization
    void Start() {
        bar = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update() {
        if (target != null) {
            bar.value = target.nowHP / target.maxHP;
            setPosition(target.getPosition() + new Vector3(0, 1.5f, 0));
        }
    }

    public void updateValue(float value) {
        bar.value = value;
    }

    public void setTarget(SpriteBattling t) {
        target = t;
        t.hpBarController = this;
        t.hpBar = gameObject.GetComponent<Slider>();
    }
}
