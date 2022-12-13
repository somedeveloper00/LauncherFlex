using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineMaker : MonoBehaviour
{
	private static CoroutineMaker _instance;

	private static CoroutineMaker getInstance() {
		if ( _instance != null ) return _instance;
		var go = new GameObject( "__coroutine-maker" );
		return (_instance = go.AddComponent<CoroutineMaker>());
	}

	public static Coroutine StartCoroutine(IEnumerator enumerator) => ((MonoBehaviour)getInstance()).StartCoroutine( enumerator );
	public static void StopCoroutine(Coroutine coroutine) => ((MonoBehaviour)getInstance()).StopCoroutine( coroutine );
	public static void StopAllCoroutines() => ((MonoBehaviour)getInstance()).StopAllCoroutines();
}