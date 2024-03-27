using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private int _xPos;
    private int _yPos;
    private int _jumpStrength;
    protected int _speed;
    protected int _life;

    public virtual void Movement()
    {

    }

    public virtual void Jump()
    {
    }

    public virtual void Attack() {}

}
