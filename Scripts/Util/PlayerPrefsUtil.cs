using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class PlayerPrefsUtil
{
	#region Editor Methods
#if UNITY_EDITOR

		[MenuItem("Tools/PlayerPrefs/Delete")]
		private static void DeletePlayerPrefs()
		{
			PlayerPrefs.DeleteAll();
		}

#endif
	#endregion
}
