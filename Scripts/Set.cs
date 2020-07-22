using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

namespace UnityEngine
{
	[System.Serializable]
	public class SetEvent : UnityEvent<GameObject>
	{ }

	public class Set : MonoBehaviour, ICollection<GameObject>, IEnumerable<GameObject>
	{
		#region Fields

		public HashSet<GameObject> m_items = new HashSet<GameObject>();

		#endregion

		#region Events

		public SetEvent onAdded = new SetEvent();
		public SetEvent onRemoved = new SetEvent();
		public UnityEvent onEmpty = new UnityEvent();

		#endregion

		#region Properties

		public int Count => m_items.Count;

		public bool IsReadOnly => false;

		#endregion

		#region Methods

		public void Add(GameObject item)
		{
			bool result = m_items.Add(item);
			onAdded.Invoke(item);
		}

		public bool Remove(GameObject item)
		{
			bool result = m_items.Remove(item);
			onRemoved.Invoke(item);

			if (Count == 0)
			{
				onEmpty.Invoke();
			}

			return result;
		}

		public void Clear()
		{
			m_items.Clear();
		}

		public void DestroyItems()
		{
			m_items.DestroyItems();
		}

		public bool Contains(GameObject item)
		{
			return Contains(item);
		}

		public void CopyTo(GameObject[] array, int arrayIndex)
		{
			m_items.CopyTo(array, arrayIndex);
		}

		public IEnumerator<GameObject> GetEnumerator()
		{
			return m_items.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return m_items.GetEnumerator();
		}

		#endregion
	}
}