using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControllerSettings : UIController
{
    public override void Start()
    {
        base.Start();
        ShowSpeed = 8.0f;
        HideSpeed = 4.0f;
    }
}
