using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBattling : SpriteBattling {

    public int autoAttackStep;// 普攻間隔

    public int skillStep;//技能間隔  單位:普攻(非間隔)

    public int state; //現在狀態  0=idle,1=attacking,2=walking,3=dead 4=skill

    public Skill nowSkill;

    public int activeSkillSteps;

    public int nowSkillSteps;

    public int attackSteps;

    public int nowAttackStep;
    

    void Start () {
        buffs = new List<Buff>();
        buffTime = new List<int>();
        skillTime = new int[3];
        skillTime[0] = 0;
        skillTime[1] = 0;
        skillTime[2] = 0;
        damageText = Resources.Load("UI/DamageText") as GameObject;
    }
	
	// Update is called once per frame
	void Update () {
        if (isWalk)
        {
            if ((gameObject.transform.position.x - nowDestination.x) <= 0)
            {
                gameObject.transform.position = nowDestination;
                gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                isWalk = false;
                animator.SetBool("isWalk", false);
                state = 0;
            }
        }
    }
    public override void loadInfo(Sprite sp)//進入戰鬥前，先LOAD
    {
        base.loadInfo(sp);
        Enemy e = sp as Enemy;
        skills = e.skills;
        attackSteps = e.attackStep;
        loadAnim();
    }

    public void loadAnimator() {
        animator = GetComponent<Animator>();
    }

    public override void hitted(float attack, float PEN = 0, float value = 1)
    {
        base.hitted(attack, PEN, value);
    }

    public void loadAnim() {

    }

    public void changeState(int st)
    {
        state = st;
    }

    public override void atkComplete()
    {
        base.atkComplete();
        animator.SetBool("isATK", false);
    }
}
