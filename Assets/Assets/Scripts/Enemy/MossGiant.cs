﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy, IDamageable
{
    public int Health { get; set; }

    //Use for initialize
    public override void Init()
    {
        base.Init();
    }

    public void Damage()
    {

    }
}
