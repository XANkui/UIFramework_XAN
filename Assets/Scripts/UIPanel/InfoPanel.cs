using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UIFramework_XAN;
using DG.Tweening;

/// <summary>
/// Info panel.
/// </summary>
public class InfoPanel : BaseUIPanel {

	private Vector3 originPos;		//UIPanel 的原始位置参数
	private Vector3 targetPos;		//UIPanel 的目标位置参数

	/// <summary>
	/// Awake this instance.
	/// </summary>
	void Awake(){
		
		//UIPanel 的原始位置
		//设置 UIPanel 目标位置
		//把目标位置设置为 UIPanel 的当前位置
		originPos = this.transform.localPosition;
		targetPos = originPos + new Vector3 (0, 600, 0);
		transform.localPosition = targetPos;

	}

	/// <summary>
	/// UIPanle 进入时的回调函数
	/// </summary>
	public override void OnEnterCallBack ()
	{
		//判断 UIPanel 进入前是否移到画布外
		if(originPos == transform.localPosition){
			//UIPanel 的原始位置
			//设置 UIPanel 目标位置
			//把目标位置设置为 UIPanel 的当前位置
			originPos = this.transform.localPosition;
			targetPos = originPos + new Vector3 (0, 600, 0);
			transform.localPosition = targetPos;
				
		}

		base.OnEnterCallBack ();

		//做动画，UIpanel 进入
		transform.DOLocalMove (originPos, 0.5f);

		#if DebugState

		Debug.Log (" InfoPanel 进入");

		#endif
	}

	/// <summary>
	/// UIPanle 暂停时的回调函数
	/// </summary>
	public override void OnPauseCallBack ()
	{
		base.OnPauseCallBack ();

		#if DebugState

		Debug.Log (" InfoPanel 暂停");

		#endif
	}

	/// <summary>
	/// UIPanle 恢复时的回调函数
	/// </summary>
	public override void OnResumeCallBack ()
	{
		base.OnResumeCallBack ();

		#if DebugState

		Debug.Log (" InfoPanel 恢复");

		#endif
	}

	/// <summary>
	/// UIPanle 退出时的回调函数
	/// </summary>
	public override void OnExitCallBack ()
	{
		//执行完动画，再隐藏 UIPanel
		transform.DOLocalMove (targetPos, 0.3f).OnComplete (()=>{
			base.OnExitCallBack ();
		});
			
		#if DebugState

		Debug.Log (" InfoPanel 退出");

		#endif
	}


}
