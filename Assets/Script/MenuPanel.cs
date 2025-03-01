using System.Collections;
using System.Text.RegularExpressions;
using UnityEngine;

[RequireComponent(typeof(Canvas), typeof(CanvasGroup))]

public class MenuPanel : MonoBehaviour
{
    [SerializeField] private PanelType type;

    [Header ("Animation")]
    [SerializeField] private float animationTime;
    [SerializeField] private AnimationCurve animationCurve = new AnimationCurve();


    private bool state;
    private Canvas canvas;
    private CanvasGroup canvasGroup;
    private void Awake()
    {
        canvas = GetComponent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    private void UpdateState(bool _animate)
    {
        StopAllCoroutines();
        if (_animate){
            StartCoroutine(Animate(state));
        }
        else{
            canvas.enabled = state;
        }
    }

    private IEnumerator Animate(bool _state){
        canvas.enabled = true;

        float _t = _state ? 0 : 1;
        float _target = _state ? 1 : 0;
        int _factor = _state ? 1 : -1;

        bool run = true;

        while (run){
            yield return null;
            _t += Time.deltaTime * _factor / animationTime;
            canvasGroup.alpha = animationCurve.Evaluate(_t) ;

            if((state && _t >= _target)||(!state && _t <= _target)){
                canvasGroup.alpha = _target;
                run = false;
            }
        }
        canvas.enabled = _state;
    }

    public void ChangeState(bool _animate){
        state = !state;
        UpdateState(_animate);
    }

    public void ChangeState(bool _state, bool _animate){
        state = _state;
        UpdateState(_animate);
    }

    #region Getter
    public PanelType GetPanelType(){return type;}
    #endregion
}
