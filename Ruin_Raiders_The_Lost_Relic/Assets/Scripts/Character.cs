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

    public virtual void movement(int x, int y)
    {

    }

    public virtual bool Jump(bool value)
    {
        return value;
    }

    public virtual bool Attack(bool value) { return value; }

}
