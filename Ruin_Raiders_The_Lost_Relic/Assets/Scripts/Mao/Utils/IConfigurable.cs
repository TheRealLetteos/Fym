using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fym
{

    public interface IConfigurable
    {

        public int GetInt(string key);

        public float GetFloat(string key);

        public string GetString(string key);

        public bool GetBool(string key);

        public GameObject GetGameObject(string key);

        public T Get<T>(string key);

        public void SetInt(string key, int value);

        public void SetFloat(string key, float value);

        public void SetString(string key, string value);

        public void SetBool(string key, bool value);

        public void SetGameObject(string key, GameObject value);

        public void Set<T>(string key, T value);

    }

}