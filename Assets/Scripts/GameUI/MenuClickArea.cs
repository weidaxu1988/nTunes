using UnityEngine;
using System.Collections;

public class MenuClickArea : MonoBehaviour {

	public MenuControl control;

	public MenuControl.MenuState definedState;

	void OnClick()
	{
		control.SetMenu(definedState);
	}
}
