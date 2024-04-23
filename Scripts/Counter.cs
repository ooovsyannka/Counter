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


    private WaitForSecondsRealtime _waitForSeconds;

    private int _coutn = 0;

    private void Start()
    {
        ShowTimer();
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
            _animator.Play(_anim.name);
            _coutn++;

            ShowTimer();

            yield return _waitForSeconds;
        }
    }
}