using AnimFlex.Sequencer.Clips;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace AnimFlex.Editor.Tweener
{
	[CustomPropertyDrawer(typeof(CTweener), true)]
	public class CTweenerDrawer : PropertyDrawer
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			var playNextOnStartProp = property.FindPropertyRelative(nameof(CTweener.playNextOnStart));
			var revertOnEndProp = property.FindPropertyRelative(nameof(CTweener.revertOnEnd));
			var tweenerGeneratorProp = property.FindPropertyRelative(nameof(CTweenerPosition.tweenerGenerator));

			var pos = new Rect(position);
			pos.height = EditorGUIUtility.singleLineHeight;

			EditorGUI.BeginProperty(position, label, property);

			pos.width /= 2f;
			EditorGUI.PropertyField(pos, playNextOnStartProp);

			pos.x += pos.width;
			EditorGUI.PropertyField(pos, revertOnEndProp);

			pos.x = position.x;
			pos.width = position.width;
			pos.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;

			EditorGUI.PropertyField(pos, tweenerGeneratorProp);

			EditorGUI.EndProperty();
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			var tweenerGeneratorProp = property.FindPropertyRelative(nameof(CTweenerPosition.tweenerGenerator));

			float height = EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
			height += EditorGUI.GetPropertyHeight(tweenerGeneratorProp);
			return height;
		}
	}
}
