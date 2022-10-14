using System.Collections;
using UnityEngine;

public class CoroutineMaker : MonoBehaviour
{
	private static CoroutineMaker instance;

	public static void DoCoroutine(IEnumerator enumerator) => instance.StartCoroutine(enumerator);

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
	private static void Initialize()
	{
		if (instance != null) return;
		var go = new GameObject("__coroutine-maker");
		instance = go.AddComponent<CoroutineMaker>();
	}
}