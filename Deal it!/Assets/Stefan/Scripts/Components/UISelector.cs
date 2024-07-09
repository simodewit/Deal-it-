using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.Rendering.DebugUI;

public class UISelector : MonoBehaviour
{
    [Header ("References")]
    public UIButton leftArrow;
    public UIButton rightArrow;

    public TextMeshProUGUI textElement;

    public string[] options = new string[]{"1","2","3"};

    private int _currentIndex = 0;

    public UnityEvent<int> OnSelectorUpdate;

    public int CurrentIndex
    {
        get
        {
            return _currentIndex;
        }
        private set
        {
            int newValue = Mathf.Clamp (value, 0, options.Length -1);

            if ( newValue == _currentIndex )
                return;
            _currentIndex = newValue;

            OnIndexChanged ( );
        }
    }

    public void Scroll(int offset )
    {
        CurrentIndex += offset;
    }

    private void OnIndexChanged ( )
    {
        textElement.text = options[_currentIndex];

        OnSelectorUpdate.Invoke (_currentIndex);
    }

    public void SetIndexWithoutSaving (int index)
    {
        _currentIndex = Mathf.Clamp (index, 0, options.Length - 1);

        textElement.text = options[_currentIndex];
    }
}
