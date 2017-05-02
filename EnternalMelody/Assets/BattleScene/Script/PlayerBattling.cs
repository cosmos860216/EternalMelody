using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBattling : SpriteBattling {
    // Use this for initialization
    public float blockRatio;
    public Buff comboBuff;
    public GameObject attackSE;

    public bool isBlock;

    public GameObject blockSE;

    public bool blockSuccess;
    void Awake()
    {
        animator = GetComponent<Animator>();
        damageText = Resources.Load("UI/DamageText") as GameObject;
        damageBalance = 0.9f;
    }

    void Start() {
        buffs = new List<Buff>();
        buffTime = new List<int>();
        skillTime = new int[3];
        skillTime[0] = 0;
        skillTime[1] = 0;
        skillTime[2] = 0;

        attackEffect = new effect();
        attackEffect.species = 3;
        attackEffect.value = 1;
        attackEffect.attackerEffectObj = Resources.Load("Skill/testImmediately") as GameObject;

        buffs.Add(comboBuff = new Buff(0, 1f, 1000));

        //  Anim = GetComponent<Animator>();

        //  animOverride = GetComponent<Animator>().runtimeAnimatorController as AnimatorOverrideController;
        //  animOverride["Attack"] = Resources.Load("Skill1") as AnimationClip;
    }

    // Update is called once per frame
    void Update() {
        if (isWalk)
        {
            if ((Vector3.Distance(gameObject.transform.position, nowDestination) <= 0.2))
            {
                gameObject.transform.position = nowDestination;
                gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                isWalk = false;
                animator.SetBool("isWalk", false);
            }
        }
    }


    public override void loadInfo(Sprite sp)
    {
        base.loadInfo(sp);
        Player ply = sp as Player;
        CRI = ply.CRI;
        PEN = ply.PEN;
        skills = ply.skills;
        loadAnim();
    }

    public override float attack()
    {
        return base.attack();
    }    

    public void loadAnim() {
        animator = GetComponent<Animator>();
        AnimatorOverrideController animOverride = new AnimatorOverrideController();
        animOverride.runtimeAnimatorController = animator.runtimeAnimatorController;
        animOverride["attack"] = Resources.Load("attack") as AnimationClip;
        animator.runtimeAnimatorController = animOverride;
    }

    public override void hitted(float attack, float PEN = 0, float value = 1)
    {
        if (!isBlock)
            base.hitted(attack, PEN, value);
        else
        {
            Instantiate(blockSE);
            float dmg = Mathf.Round((attack - DEF * (1 - PEN)) * value * 0.5f);
            nowHP -= dmg > 0 ? dmg : 1;
            Debug.Log("Blocked");
            animator.SetBool("isBlock", true);

            damgeTextCreate(dmg.ToString());
            blockSuccess = true;
            return;
        }
    }

    public override void atkComplete()
    {
        base.atkComplete();
        animator.SetBool("isATK", false);
        animator.SetBool("isATK2", false);
    }

    public void move(float value) {
        transform.position += new Vector3(value, 0, 0);
    }

    public override Vector3 getPosition()
    {
        return (transform.position + Vector3.right * 1f);
    }

    public void stopAnim(string animateName) {
        animator.SetBool(animateName, false);
    }
}
