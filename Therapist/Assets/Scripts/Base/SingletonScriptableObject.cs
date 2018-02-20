using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[ExecuteInEditMode]
public abstract class SingletonScriptableObject<T> : ScriptableObject where T : ScriptableObject
{
   static T _instance = null;
    public static T Instance
    {
        get
        {
            if (!_instance)
            {
                _instance = Resources.FindObjectsOfTypeAll<T>().FirstOrDefault();
                if(_instance == null)
                {
                    _instance = Resources.LoadAll<T>("Objects/ScriptableObjects").FirstOrDefault();
                    //_instance = Resources.FindObjectsOfTypeAll<T>().FirstOrDefault();
                }
            }
            return _instance;
        }
    }
}
