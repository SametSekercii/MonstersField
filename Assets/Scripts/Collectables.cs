using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectables : MonoBehaviour, ICollectable
{
    public abstract void OnCollect();

    
}
