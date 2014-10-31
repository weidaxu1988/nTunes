using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MusicControl : MonoBehaviour {

		public GameObject clickArea;
		
		List<MusicItem> musicList = new List<MusicItem>();
		
		MenuControl.MenuState state = MenuControl.MenuState.Music;
		
		void Start()
		{
			CreateMusicItems ();
		}
		
		void CreateMusicItems()
		{
			MusicItem[] musics = GetComponentsInChildren<MusicItem> ();
			musicList.AddRange (musics);
		}
		
		public void SetMenuActive(bool active)
		{
		clickArea.SetActive(!active);
			foreach (MusicItem item in musicList) {
				item.Fadding(!active);
			}
		}
		

}
