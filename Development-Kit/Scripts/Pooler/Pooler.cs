﻿using System.Collections.Generic;
using UnityEngine;

namespace Bale007.Pooler
{
    public class Pooler
    {
        protected Stack<GameObject> freeInstances = new Stack<GameObject>();
        protected GameObject original;
    
        public Pooler(GameObject original, int initialSize)
        {     
            this.original = original;
            freeInstances = new Stack<GameObject>(initialSize);

            for (int i = 0; i < initialSize; ++i)
            {
                GameObject obj = Object.Instantiate(original);
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

        public GameObject Get(Vector3 pos,Vector3 scale, Transform parent)
        {
            GameObject ret = freeInstances.Count > 0 ? freeInstances.Pop() : Object.Instantiate(original);

            ret.SetActive(true);
            ret.transform.SetParent(parent);
            ret.transform.localPosition = pos;
            ret.transform.localScale = scale;
        
            return ret;
        }

        public void Free(GameObject obj)
        {
            obj.SetActive(false);
            freeInstances.Push(obj);
        }
    }
}

