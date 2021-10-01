
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public enum Suits
    {
        Hearts,
        Diamonds,
        Spades,
        Clubs
    }

    public enum Colors
    {
        Red,
        Black
    }

    public bool picked;
    public int num;
    public Suits suit;
    public Colors color;
    private Sprite _coverImg;
    private Sprite _realImg;
    private StartManager _sm;
    private Canvas _canvas;
    private Image _img;

    private void Awake()
    {
        _canvas = GetComponentInChildren<Canvas>();
        _img = GetComponentInChildren<Image>();
        _sm = FindObjectOfType<StartManager>();
    }

    private void Update()
    {
        if (picked)
        {
            FollowMouse();
        }
    }

    private void FollowMouse()
    {
        if (Camera.main is null) return;
        var mPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mPos.x, mPos.y, 3);
    }

    public void GenCard(int v)
    {
        switch (Mathf.Ceil(f: v/13))
        {
            case 0:
                suit = Suits.Clubs;
                color = Colors.Black;
                num = v;
                break;
            case 1:
                suit = Suits.Diamonds;
                color = Colors.Red;
                num = v - 13;
                break;
            case 2:
                suit = Suits.Hearts;
                color = Colors.Red;
                num = v - 26;
                break;
            case 3:
                suit = Suits.Spades;
                color = Colors.Black;
                num = v - 39;
                break;
        }

        _coverImg = _sm.sprites[0];
        _realImg = _sm.sprites[v+1];
        _img.sprite = _coverImg;
    }

    public void SetParent(Transform p0, int n)
    {
        transform.parent = p0;
        transform.localPosition = new Vector3(n*30, 0, 0 );
    }

    public void ChangeOrder(int i)
    {
        _canvas.sortingOrder = i;
        _img.sprite = _realImg;
    }

    public void TurnDown()
    {
        _img.sprite = _coverImg;
    }

    public void PushUp()
    {
        _canvas.sortingOrder = 60;
    }
        
    public void MiddleCard()
    {
        _canvas.sortingOrder= num;
        _img.sprite = _realImg;
    }
}