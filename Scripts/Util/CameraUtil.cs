using UnityEngine;
using System.Collections;
using System;

public static class CameraUtil
{
	#region Fields

	private static Camera s_camera;

	#endregion

	#region Properties

	public static Camera main
	{
		get
		{
			if (s_camera == null)
			{
				s_camera = Camera.main;
			}
			return s_camera;
		}
	}

	#endregion

	#region Methods

	public static void View(this Camera camera, Bounds bounds)
	{
		if (!camera.orthographic)
		{
			camera.transform.position = bounds.center - camera.GetViewDistance(bounds) * camera.transform.forward;
		}
	}

	public static float GetViewSize(this Camera camera, Bounds bounds, float distance, float margin = 1f)
	{
		return 2.0f * Mathf.Atan(camera.GetFrustrumHeight(bounds, margin) / distance) * Mathf.Rad2Deg;
	}

    public static float GetViewDistance(this Camera camera, Bounds bounds, float margin = 1f)
    {
        return camera.GetFrustrumHeight(bounds, margin) / Mathf.Sin(0.5f * Mathf.Deg2Rad * camera.fieldOfView);
    }

	private static float GetFrustrumHeight(this Camera camera, Bounds bounds, float margin)
	{
		var dimensions = Vector3.ProjectOnPlane(bounds.extents, camera.transform.forward);
		return Mathf.Max(dimensions.x, dimensions.y, dimensions.z) * margin;
	}
	
	public static float GetOrthographicSize(this Camera camera, float distance)
	{
		return distance * Mathf.Tan(camera.fieldOfView * 0.5f * Mathf.Deg2Rad);
	}

    #endregion
}
