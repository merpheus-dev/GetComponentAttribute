using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;
using System.Linq;
using UnityEditor;
using UnityEditor.Callbacks;

//TO-DO:Auto Component insertion
//Check:https://answers.unity.com/questions/34616/is-there-a-way-to-hide-a-monobehaviour-in-the-insp.html
namespace Subtegral.DependencyInjection
{
    public static class InjectionEngine
    {
        public static void Inject(DIContainer container)
        {
            switch (container.Attribute.ComponentAddress)
            {
                case GetComponentFrom.Self:
                    container.Field.SetValue(container.Behaviour,
                        container.Behaviour.GetComponent(container.Field.FieldType));
                    break;
                case GetComponentFrom.SceneObject:
                    container.Field.SetValue(container.Behaviour, Object.FindObjectOfType(container.Field.FieldType));
                    break;
                case GetComponentFrom.TargetGameObject:
                    var foundedObject = GameObject.Find(container.Attribute.TargetName);
                    if (foundedObject != null ||
                        !foundedObject.GetComponent(container.Field.GetValue(container.Behaviour).GetType()))
                        return;
                    container.Field.SetValue(container.Behaviour,
                        foundedObject.GetComponent(container.Field.GetValue(container.Behaviour).GetType()));
                    break;
            }
        }
    }
}