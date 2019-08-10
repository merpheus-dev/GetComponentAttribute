using System;
using System.Reflection;
using UnityEngine;

namespace Subtegral.DependencyInjection
{
    [Serializable]
    public class DIContainer
    {
        public GetComponentAttribute Attribute;
        public FieldInfo Field;
        public MonoBehaviour Behaviour;
    }
}