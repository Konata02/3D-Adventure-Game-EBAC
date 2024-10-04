using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;


namespace Boss {


    public class BossStates : StateBase
    {
        protected BossBase boss;

        public override void OnStateEnter(params object[] objs)
        {
            base.OnStateEnter(objs);
            boss = (BossBase)objs[0];

        }    


    }

    public class BossStateInit : BossStates
    {
            public override void OnStateEnter(params object[] objs)
            {
                base.OnStateEnter(objs);
                boss.StartInitAnimation();
                Debug.Log("Boss" + boss);
            }
        }

    public class BossStateWalk : BossStates
    {
            public override void OnStateEnter(params object[] objs)
            {
                base.OnStateEnter(objs);
                boss.GoToRandomPoint();
                Debug.Log("Boss" + boss);
            }
        }

    public class BossStateAttack : BossStates
    {
            public override void OnStateEnter(params object[] objs)
            {
                base.OnStateEnter(objs);
                boss.Shoot();
                Debug.Log("Boss" + boss);
            }
        }

}


