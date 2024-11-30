using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class CustomButton : MonoBehaviour
{
    [SerializeField] private Animator _closeAnimator = null;
    [SerializeField] private Animator _openAnimator = null;

    [SerializeField] private float _waitTime = 0f;
    [SerializeField] private string _animationKey = "UI_STATE_KEY";

    private Button _button = null;
    private IButtonFuction _buttonFuction = null;

    public static bool isClicked = false;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _buttonFuction = GetComponent<IButtonFuction>();
        _button.onClick.AddListener(OnButtonPressed);
    }

    private void OnButtonPressed()
    {
        if (isClicked)
            return;
        isClicked = true;
        StartCoroutine(PageOpen());
    }

    private IEnumerator PageOpen()
    {
        if (_closeAnimator != null)
            _closeAnimator.SetBool(_animationKey,true);
        yield return new WaitForSeconds(_waitTime);
        if (_openAnimator != null)
            _openAnimator.gameObject.SetActive(true);
        if (_closeAnimator != null)
            _closeAnimator.gameObject.SetActive(false);
        if (_buttonFuction != null)
            _buttonFuction.LaunchButtonCallback();
        isClicked = false;
    }
}
