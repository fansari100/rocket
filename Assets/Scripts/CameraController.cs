using UnityEngine;

public class CameraController : MonoBehaviour
{
    private static readonly Vector3 _screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    public static Vector3 ScreenBounds => _screenBounds;
}
