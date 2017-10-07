using UnityEngine;

public enum ColliderType { Box, Circle }

public class HitBoxScaleInit : MonoBehaviour {

    public float ToScreenScale = 5, W = 1, H = 1;
    public ColliderType ColliderT = ColliderType.Box;


    private void Start() {
        float ScreenMax = (Screen.width > Screen.height) ? Screen.width : Screen.height;

        switch (ColliderT) {
            case ColliderType.Box: {
                    GetComponent<BoxCollider2D>().size = new Vector2((ScreenMax / ToScreenScale) * W, (ScreenMax / ToScreenScale) * H);
                } break;
            case ColliderType.Circle: {
                    GetComponent<CircleCollider2D>().radius = (ScreenMax / ToScreenScale);
                } break;
        }
    }
}
