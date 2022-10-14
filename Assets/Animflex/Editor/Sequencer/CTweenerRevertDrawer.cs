using AnimFlex.Editor;
using AnimFlex.Sequencer;
using AnimFlex.Sequencer.Clips;
using AnimFlex.Sequencer.UserEnd;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace Addons.Animflex.Editor.Sequencer
{
	[CustomPropertyDrawer(typeof(CTweenerRevert))]
	public class CTweenerRevertDrawer : PropertyDrawer
	{
		private ReorderableList _list;

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			ValidateList(property);

			using (new EditorGUI.PropertyScope(position, label, property))
			{
				_list.DoList(position);
			}
		}

		private void ValidateList(SerializedProperty property)
		{
			if (_list == null || _list.list == null)
			{
				var tweenerClipIndecesProp = property.FindPropertyRelative(nameof(CTweenerRevert.tweenerClipIndeces));
				_list = new ReorderableList(property.serializedObject, tweenerClipIndecesProp,
					draggable: true,
					displayHeader: false,
					displayAddButton: true,
					displayRemoveButton: true);
				_list.drawElementCallback = (rect, index, active, focused) =>
				{
					rect.width -= 40;
					EditorGUI.PropertyField(
						rect, tweenerClipIndecesProp.GetArrayElementAtIndex(index),
						new GUIContent(tweenerClipIndecesProp.GetArrayElementAtIndex(index).displayName),
						includeChildren: true);
					rect.x += rect.width + 5;
					rect.width = 30;
					if (GUI.Button(rect, new GUIContent("X", "remove element"), AFStyles.Button))
					{
						tweenerClipIndecesProp.DeleteArrayElementAtIndex(index);
					}
				};
				_list.elementHeightCallback = index =>
				{
					return EditorGUI.GetPropertyHeight(tweenerClipIndecesProp.GetArrayElementAtIndex(index));
				};
			}
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			ValidateList(property);
			return _list.GetHeight();
		}
	}

	[CustomPropertyDrawer(typeof(CTweenerRevert.CTweenerIndex))]
	public class CTweenerRevertIndexDrawer : PropertyDrawer
	{
		private Sequence _sequence;

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			var indexProp = property.FindPropertyRelative(nameof(CTweenerRevert.CTweenerIndex.index));
			_sequence ??= ((SequenceAnim)property.serializedObject.targetObject).sequence;

			var pos = new Rect(position);
			using (new EditorGUI.PropertyScope(position, label, property))
			{
				AFEditorUtils.DrawNodeSelectionPopup<CTweener>(pos, indexProp, GUIContent.none, _sequence);
			}
		}
	}
}
