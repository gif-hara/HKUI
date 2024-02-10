using System;
using System.Collections.Generic;
using UnityEngine;

namespace HK.UI
{
    public class HKUIDocument : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] elements;

        private readonly Dictionary<string, GameObject> elementMap = new();

        private readonly Dictionary<GameObject, Dictionary<Type, Component>> componentMap = new();

        public T Q<T>(string name) where T : Component
        {
            if (elementMap.Count == 0)
            {
                foreach (var element in elements)
                {
                    elementMap[element.name] = element;
                }
            }

            if (elementMap.TryGetValue(name, out var e))
            {
                if (!componentMap.TryGetValue(e, out var c))
                {
                    c = new Dictionary<Type, Component>();
                    componentMap[e] = c;
                }

                if (!c.TryGetValue(typeof(T), out var t))
                {
                    t = e.GetComponent<T>();
                    c[typeof(T)] = t;
                }

                return (T)t;
            }
            else
            {
                Debug.LogError($"Element not found: {name}");
                return null;
            }
        }
    }
}
