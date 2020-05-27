using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Este script es para animar la moneda en los creditos ya que no se pueden animar las imagenes del UI de la 
//forma tradicional
//No he hecho este script, lo he sacado de esta pagina: https://gist.github.com/almirage/e9e4f447190371ee6ce9
//todo el crédito va para el creador del script
public class MenuCoinAnimation : MonoBehaviour
{
    
	public Sprite[] sprites;
	public int spritePerFrame = 6;
	public bool loop = true;
	public bool destroyOnEnd = false;

	private int index = 0;
	private Image image;
	private int frame = 0;

	void Awake() {
		image = GetComponent<Image>();
	}

	void Update() {
		if (!loop && index == sprites.Length) return;
		frame++;
		if (frame < spritePerFrame) return;
		image.sprite = sprites[index];
		frame = 0;
		index++;
		if (index >= sprites.Length) {
			if (loop) index = 0;
			if (destroyOnEnd) Destroy(gameObject);
		}
	}

}
