using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    // Start is called before the first frame update
    public override void Die()
    {
        base.Die();
        XPManager.instance.AddXP(100);
        //Add ragdoll
        Destroy(this.gameObject);
    }
}
