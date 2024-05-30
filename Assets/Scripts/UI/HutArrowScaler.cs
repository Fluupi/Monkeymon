using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HutArrowScaler : MonoBehaviour
{
    [SerializeField] private Vector2 _minScale;
    [SerializeField] private Vector2 _maxScale;
    [SerializeField] private float _loopTime;
    [SerializeField] private AnimationCurve _scalingCurve;
    private float _timer = 0f;

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer > _loopTime)
            _timer -= _loopTime;

        transform.localScale = Vector2.Lerp(_minScale, _maxScale, _scalingCurve.Evaluate(_timer / _loopTime));
    }
}
