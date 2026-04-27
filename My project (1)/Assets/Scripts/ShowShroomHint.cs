using UnityEngine;

public class ShowShroomHint : MonoBehaviour
{
    [SerializeField] private GameObject _bug;
    [SerializeField] private GameObject _arrow;
    [SerializeField] int _outlineWidth;
    private Outline outline;

    public void Start()
    {
        outline = _bug.GetComponent<Outline>();
    }

    public void ShowHint()
    {
        _arrow.SetActive(true);
        outline.OutlineWidth = _outlineWidth;
    }

    public void HideHint()
    {
        _arrow.SetActive(false);
        outline.OutlineWidth = 0;
    }
}
