using UnityEngine;
using UnityEngine.EventSystems;

public class scr_UI_SimpleJoystick : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public float Horizontal { get; private set; }
    public float Vertical { get; private set; }
    public Vector2 Direction { get { return new Vector2(Horizontal, Vertical); } }

    [SerializeField] private RectTransform background;
    [SerializeField] private RectTransform handle;
    [SerializeField] private float handleRange = 100f;
    [SerializeField] private float deadZone = 0.1f;

    private Vector2 input = Vector2.zero;
    private Vector2 backgroundStartPosition;

    private void Start()
    {
        backgroundStartPosition = background.anchoredPosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 position = RectTransformUtility.WorldToScreenPoint(null, background.position);
        input = (eventData.position - position) / handleRange;
        input = Vector2.ClampMagnitude(input, 1);

        if (input.magnitude < deadZone)
        {
            input = Vector2.zero;
        }

        handle.anchoredPosition = input * handleRange;
        Horizontal = input.x;
        Vertical = input.y;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        input = Vector2.zero;
        handle.anchoredPosition = Vector2.zero;
        Horizontal = 0;
        Vertical = 0;
    }
}
