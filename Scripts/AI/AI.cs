using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(FieldOfView))]
[RequireComponent(typeof(ChaseTarget))]
[RequireComponent(typeof(SearchTarget))]
public class AI : MonoBehaviour {

    // Controller 

    public MovingController moving;
    public ActionController action;

    // Target

    public LayerMask targetMask;

    private GameObject fovTarget;
    private GameObject actualTarget;

    // Scripts

    private FieldOfView fov;
    private SearchTarget st;
    private ChaseTarget ct;
    private PathFollower pf;

    // Timer 

    public float timerToSearch = 10;
    private float timer = 0 ;

    // Attack

    private bool CanAttack;
    public int attackRange;

    void Start()
    {
        fov = GetComponent<FieldOfView>();
        st = GetComponent<SearchTarget>();
        ct = GetComponent<ChaseTarget>();
        pf = GetComponent<PathFollower>();

        fov.setTargetMask(targetMask);
    }

    void Update()
    {

        actualTarget = getActualTarget();
        if (actualTarget)
        {
            action = ActionController.Chase;
            timer = timerToSearch;
        }
        if (!actualTarget && timer > 0)
        {
            action = ActionController.Search;
        }

        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            timer = 0;
            action = ActionController.Move;
        }

        if (action == ActionController.Idle)
        {
            // une animation joué quand il reste sur place 
        }
        if (action == ActionController.Chase)
        {
            ct.setTarget(actualTarget);
            ct.Move();
        }
        if (action == ActionController.Search)
        {
            st.Move();
        }
        if (action == ActionController.Move)
        {
            if(moving == MovingController.Path_Follower && pf)
            {
                pf.Move();
            }
            if(moving == MovingController.Random_Move)
            {
                //RandomMove rm = GetComponent<RandomMove>();
                //rm.Move();
            }


        }




    }

    private GameObject getActualTarget()
    {

        fovTarget = fov.getTarget();
        if (fovTarget)
        {
            var result = targetMask == (targetMask | (1 << fovTarget.gameObject.layer));
            if (result)
                {
                    return fovTarget;
                }
        }
        return null;
    }

}
