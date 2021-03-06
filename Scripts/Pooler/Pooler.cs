﻿using System.Collections.Generic;
using Bale007.Util;
using UnityEngine;

namespace Bale007.Pooler
{
    public class Pooler
    {
        private static GameObject root;
        
        private readonly Stack<GameObject> freeInstances;
        private readonly GameObject original;
      
        public Pooler(GameObject original, int initialSize)
        {
            this.original = original;
            freeInstances = new Stack<GameObject>(initialSize);

            for (var i = 0; i < initialSize; ++i)
            {
                var obj = Object.Instantiate(original, Root, true);
                obj.name = original.name;
                obj.SetActive(false);
                freeInstances.Push(obj);
            }
        }

        public GameObject Get(Vector3 pos)
        {
            return Get(pos, Vector3.one, null);
        }

        public GameObject Get()
        {
            return Get(Vector3.zero, Vector3.one, null);
        }

        public GameObject Get(Vector3 pos, Vector3 scale, Transform parent)
        {
            var ret = freeInstances.Count > 0 ? freeInstances.Pop() : Object.Instantiate(original);

            ret.SetActive(true);
            ret.transform.SetParent(parent);
            ret.transform.localPosition = pos;
            ret.transform.localScale = scale;

            return ret;
        }

        public void Free(GameObject obj)
        {
            obj.transform.SetParent(Root);
            obj.SetActive(false);
            freeInstances.Push(obj);
        }

        public Transform Root
        {
            get
            {
                if (root == null)
                {
                    root = new GameObject("_POOL");
                }

                return root.transform;
            }
        }
    }
}