using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStatusGui : MonoBehaviour {
    public Text CharacterNameText;
    public RawImage GaugeRawImage;
    public CharacterStatus CharacterStatus;
    public Color GaugeColor;

    private float _gaugeWidth;
    private float _gaugeHeight;

    private void Start()
    {
        _gaugeWidth = GaugeRawImage.rectTransform.rect.width;
        _gaugeHeight = GaugeRawImage.rectTransform.rect.height;
        GaugeRawImage.color = GaugeColor;
    }

    private void Update()
    {
        CharacterNameText.text = CharacterStatus.characterName;
        GaugeRawImage.rectTransform.sizeDelta = new Vector2(_gaugeWidth * CharacterStatus.HP / CharacterStatus.MaxHp, _gaugeHeight);
    }
}
