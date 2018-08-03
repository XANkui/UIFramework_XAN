using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UIFramework_XAN;

/// <summary>
/// Setting panel.
/// </summary>
public class SettingPanel : BaseUIPanel {

	/// <summary>
	/// UIPanle 进入时的回调函数
	/// </summary>
	public override void OnEnterCallBack ()
	{
		base.OnEnterCallBack ();

		#if DebugState

		Debug.Log (" SettingPanel 进入");

		#endif
	}

	/// <summary>
	/// UIPanle 暂停时的回调函数
	/// </summary>
	public override void OnPauseCallBack ()
	{
		base.OnPauseCallBack ();

		#if DebugState

		Debug.Log (" SettingPanel 暂停");

		#endif
	}

	/// <summary>
	/// UIPanle 恢复时的回调函数
	/// </summary>
	public override void OnResumeCallBack ()
	{
		base.OnResumeCallBack ();

		#if DebugState

		Debug.Log (" SettingPanel 恢复");

		#endif
	}

	/// <summary>
	/// UIPanle 退出时的回调函数
	/// </summary>
	public override void OnExitCallBack ()
	{
		base.OnExitCallBack ();

		#if DebugState

		Debug.Log (" SettingPanel 退出");

		#endif
	}


}
