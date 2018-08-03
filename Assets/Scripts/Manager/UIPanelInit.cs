using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UIFramework_XAN;

/// <summary>
/// 游戏启动加载 主菜单
/// </summary>
public class UIPanelInit : MonoBehaviour {

	// Use this for initialization
	void Start () {

		// UIManager 入栈加载主菜单
		UIManager.Instance.PushUIPanel (UIPanelType.MainMenu);
	}
	

}
