using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fym.ai.panda
{
    public class PandaBTBlackboard : MonoBehaviour
    {

        private static PandaBTBlackboard instance;

        public static PandaBTBlackboard Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameObject("PandaBTBlackboard").AddComponent<PandaBTBlackboard>();
                }
                return instance;
            }
        }

        private Dictionary<string, object> blackboard = new Dictionary<string, object>();

        public void SetTransformRef(string key, Transform value)
        {
            blackboard[key] = new BlackboardTransform(key, value);
        }

        public void SetVector3Ref(string key, Vector3 value)
        {
            blackboard[key] = new BlackboardVector3(key, value);
        }

        public void SetQuaternionRef(string key, Quaternion value)
        {
            blackboard[key] = new BlackboardQuaternion(key, value);
        }

        public void SetVector2Ref(string key, Vector2 value)
        {
            blackboard[key] = new BlackboardVector2(key, value);
        }

        public void SetRigidbody2DRef(string key, Rigidbody2D value)
        {
            blackboard[key] = new BlackboardRigidbody2D(key, value);
        }

        public void SetFloatRef(string key, float value)
        {
            blackboard[key] = new BlackboardFloat(key, value);
        }

        public void SetIntRef(string key, int value)
        {
            blackboard[key] = new BlackboardInt(key, value);
        }

        public void SetBoolRef(string key, bool value)
        {
            blackboard[key] = new BlackboardBool(key, value);
        }

        public void SetStringRef(string key, string value)
        {
            blackboard[key] = new BlackboardString(key, value);
        }

        public void SetGameObjectRef(string key, GameObject value)
        {
            blackboard[key] = new BlackboardGameObject(key, value);
        }

        public void SetComponentRef(string key, Component value)
        {
            blackboard[key] = new BlackboardComponent(key, value);
        }

        public void SetScriptableObjectRef(string key, ScriptableObject value)
        {
            blackboard[key] = new BlackboardScriptableObject(key, value);
        }

        public BlackboardVector3 GetVector3Ref(string key)
        {
            return (BlackboardVector3)blackboard[key];
        }

        public BlackboardTransform GetTransformRef(string key)
        {
            return (BlackboardTransform)blackboard[key];
        }

        public BlackboardVector2 GetVector2Ref(string key)
        {
            return (BlackboardVector2)blackboard[key];
        }

        public BlackboardQuaternion GetQuaternionRef(string key)
        {
            return (BlackboardQuaternion)blackboard[key];
        }

        public BlackboardRigidbody2D GetRigidbody2DRef(string key)
        {
            return (BlackboardRigidbody2D)blackboard[key];
        }

        public BlackboardFloat GetFloatRef(string key)
        {
            return (BlackboardFloat)blackboard[key];
        }

        public BlackboardInt GetIntRef(string key)
        {
            return (BlackboardInt)blackboard[key];
        }

        public BlackboardBool GetBoolRef(string key)
        {
            return (BlackboardBool)blackboard[key];
        }

        public BlackboardString GetStringRef(string key)
        {
            return (BlackboardString)blackboard[key];
        }

        public BlackboardGameObject GetGameObjectRef(string key)
        {
            return (BlackboardGameObject)blackboard[key];
        }

        public BlackboardComponent GetComponentRef(string key)
        {
            return (BlackboardComponent)blackboard[key];
        }

    }
}