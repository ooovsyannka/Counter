using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _smoothDecreaseDuration;
    [SerializeField] private Tumbler _tumbler;
    [SerializeField] private TextMeshProUGUI _counterText;
    [SerializeField] private Animator _animator;
    [SerializeField] private AnimationClip _anim;
    [SerializeField] private Image _switcher;
    [SerializeField] private Sprite _switchOn;
    [SerializeField] private Sprite _switchOff;

    private WaitForSecondsRealtime _waitForSeconds;

    private int _coutn = 0;

    private void Start()
    {
        ShowTimer();
        _switcher.GetComponent<Image>().sprite = _switchOff;
    }

    private void Update()
    {
        
    }

    private void OnEnable()
    {
        _tumbler.Switching += OnSwitching;
    }

    private void OnDisable()
    {
        _tumbler.Switching -= OnSwitching;
    }

    private void OnSwitching()
    {
        StartCoroutine(CountUp());
        SwitcherControl(_tumbler.IsOn);
    }

    private void ShowTimer()
    {
        _counterText.text = _coutn.ToString("");
    }

    private IEnumerator CountUp()
    {
        _waitForSeconds = new WaitForSecondsRealtime(_smoothDecreaseDuration);

        while ( _tumbler.IsOn)
        {
            ShowTimer();

            _animator.Play(_anim.name);
            _coutn++;

            yield return _waitForSeconds;
        }
    }

    private void SwitcherControl(bool isWork)
    {
        if (isWork)
            _switcher.GetComponent<Image>().sprite = _switchOn;
        else
            _switcher.GetComponent<Image>().sprite = _switchOff;
    }
}