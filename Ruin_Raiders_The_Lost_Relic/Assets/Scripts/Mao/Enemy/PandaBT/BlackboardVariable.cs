using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fym.ai.panda
{
    public class BlackboardVariable<T> : MonoBehaviour
    {
        public string variableName;

        public T variableRef;

        public BlackboardVariable()
        {
        }

        public BlackboardVariable(string variableName, T variableRef)
        {
            this.variableName = variableName;
            this.variableRef = variableRef;
        }
    }

    public class BlackboardTransform : BlackboardVariable<Transform>
    {

        public BlackboardTransform(string variableName, Transform variableRef) : base(variableName, variableRef)
        {
        }

    }

    public class BlackboardException : BlackboardVariable<Exception>
    {
        public BlackboardException(Exception exception) : base(exception.Message, exception)
        {
        }
    }

    public class BlackboardVector3 : BlackboardVariable<Vector3>
    {

        public BlackboardVector3(string variableName, Vector3 variableRef) : base(variableName, variableRef)
        {
        }
    }

    public class BlackboardQuaternion : BlackboardVariable<Quaternion>
    {

        public BlackboardQuaternion(string variableName, Quaternion variableRef) : base(variableName, variableRef)
        {
        }
    }

    public class BlackboardVector2 : BlackboardVariable<Vector2>
    {

        public BlackboardVector2(string variableName, Vector2 variableRef) : base(variableName, variableRef)
        {
        }
    }

    public class BlackboardRigidbody2D : BlackboardVariable<Rigidbody2D>
    {

        public BlackboardRigidbody2D(string variableName, Rigidbody2D variableRef) : base(variableName, variableRef)
        {
        }
    }

    public class BlackboardFloat : BlackboardVariable<float>
    {

        public BlackboardFloat(string variableName, float variableRef) : base(variableName, variableRef)
        {
        }
    }

    public class BlackboardInt : BlackboardVariable<int>
    {
        public BlackboardInt(string variableName, int variableRef) : base(variableName, variableRef)
        {
        }
    }

    public class BlackboardBool : BlackboardVariable<bool>
    {
        public BlackboardBool(string variableName, bool variableRef) : base(variableName, variableRef)
        {
        }
    }

    public class BlackboardString : BlackboardVariable<string>
    {
        public BlackboardString(string variableName, string variableRef) : base(variableName, variableRef)
        {
        }
    }

    public class BlackboardGameObject : BlackboardVariable<GameObject>
    {
        public BlackboardGameObject(string variableName, GameObject variableRef) : base(variableName, variableRef)
        {
        }
    }

    public class BlackboardComponent : BlackboardVariable<Component>
    {
        public BlackboardComponent(string variableName, Component variableRef) : base(variableName, variableRef)
        {
        }
    }

    public class BlackboardScriptableObject : BlackboardVariable<ScriptableObject>
    {
        public BlackboardScriptableObject(string variableName, ScriptableObject variableRef) : base(variableName, variableRef)
        {
        }
    }


}