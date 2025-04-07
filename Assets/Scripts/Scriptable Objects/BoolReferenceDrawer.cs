#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(BoolReference))]
public class BoolReferenceDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        SerializedProperty useConstant = property.FindPropertyRelative("useConstant");
        SerializedProperty constantValue = property.FindPropertyRelative("constantValue");
        SerializedProperty variable = property.FindPropertyRelative("variable");

        EditorGUI.BeginProperty(position, label, property);

        float lineHeight = EditorGUIUtility.singleLineHeight;
        float spacing = 2f;

        // Draw the main label (e.g., isResized)
        Rect labelRect = new Rect(position.x, position.y, position.width, lineHeight);
        EditorGUI.LabelField(labelRect, label);

        // Draw the "Use Constant" toggle
        Rect toggleRect = new Rect(position.x, position.y + lineHeight + spacing, position.width, lineHeight);
        useConstant.boolValue = EditorGUI.ToggleLeft(toggleRect, "Use Constant", useConstant.boolValue);

        // Draw the appropriate value field
        Rect valueRect = new Rect(position.x, position.y + 2 * (lineHeight + spacing), position.width, lineHeight);
        if (useConstant.boolValue)
        {
            EditorGUI.PropertyField(valueRect, constantValue, new GUIContent("Constant Value"));
        }
        else
        {
            EditorGUI.PropertyField(valueRect, variable, new GUIContent("Variable"));
        }

        EditorGUI.EndProperty();
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        // Total height = 3 lines (label, toggle, value) + spacing
        return (EditorGUIUtility.singleLineHeight + 2f) * 3;
    }
}
#endif
