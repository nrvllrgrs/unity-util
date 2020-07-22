namespace UnityEngine
{
	public static class CanvasExt
	{
		public static Vector3 WorldToCanvasPoint(this Canvas canvas, Vector3 worldPosition, Camera camera = null)
		{
			if (camera == null)
			{
				camera = Camera.main;
			}
			return canvas.ViewportToCanvasPoint(camera.WorldToViewportPoint(worldPosition));
		}

		public static Vector3 ScreenToCanvasPoint(this Canvas canvas, Vector3 screenPosition)
		{
			return canvas.ViewportToCanvasPoint(new Vector3(screenPosition.x / Screen.width, screenPosition.y / Screen.height, 0f));
		}

		public static Vector3 ViewportToCanvasPoint(this Canvas canvas, Vector3 viewportPosition)
		{
			return Vector3.Scale(viewportPosition - new Vector3(0.5f, 0.5f, 0), canvas.GetComponent<RectTransform>().sizeDelta);
		}
	}
}