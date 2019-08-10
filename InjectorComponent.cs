using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Subtegral.DependencyInjection
{
    public class InjectorComponent : MonoBehaviour
    {
        private void Awake()
        {
           
        }

        #region Editor Hooks
        private void OnValidate()
        {
            SearchForAttributeUsages();
        }

        private void SearchForAttributeUsages()
        {
           var monoObjects = GetComponents<MonoBehaviour>();
           foreach (var monoObject in monoObjects)
           {
               
           }
        }
        #endregion
    }
}