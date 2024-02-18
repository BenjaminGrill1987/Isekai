using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System;
using System.Reflection;

namespace OnValueChange
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class OnValueChangedAttribute : PropertyAttribute
    {
        public string CallbackMethodName { get; private set; }

        public OnValueChangedAttribute(string callbackMethodName)
        {
            CallbackMethodName = callbackMethodName;
        }
    }

#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(OnValueChangedAttribute))]
    public class OnValueChangedDrawer : PropertyDrawer
    {
        private MethodInfo callbackMethod;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            OnValueChangedAttribute onValueChangedAttribute = (OnValueChangedAttribute)attribute;

            UnityEngine.Object targetObject = property.serializedObject.targetObject;

            // Check if target is not null
            if (targetObject != null)
            {
                callbackMethod = targetObject.GetType().GetMethod(onValueChangedAttribute.CallbackMethodName, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

                if (callbackMethod != null)
                {
                    EditorGUI.BeginChangeCheck();
                    EditorGUI.PropertyField(position, property, label);

                    // Value has changed
                    if (EditorGUI.EndChangeCheck())
                    {
                        property.serializedObject.ApplyModifiedProperties(); 
                        callbackMethod.Invoke(targetObject, null);
                    }
                }
            }
        }
    }
#endif
}