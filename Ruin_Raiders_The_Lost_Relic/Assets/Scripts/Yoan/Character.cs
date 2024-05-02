using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    protected float _xPos;
    private int _yPos;
    [SerializeField]
    protected int _jumpStrength;
    [SerializeField]
    protected float _speed;
    public int _life { get; set; }

    public virtual void Movement(float x)
    {

    }

    public virtual void Jump()
    {
    }

    public virtual void Attack() {}

}
