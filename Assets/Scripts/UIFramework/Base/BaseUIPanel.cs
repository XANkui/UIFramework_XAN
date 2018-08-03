using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UIFramework_XAN{

	/// <summary>
	/// UIPanel 基类
	/// </summary>
	public class BaseUIPanel : MonoBehaviour {

		protected CanvasGroup canvasGroup;		//用来控制UI的显示和交互使能的参数

		// Use this for initialization
		protected virtual void Start () {
			//加载使能UIPanel的时候，判断 canvasGroup是否为空，为空则赋值
			if(canvasGroup == null){
				canvasGroup = this.GetComponent <CanvasGroup> ();
			}
		}

		/// <summary>
		/// UIPanle 进入时的回调函数
		/// </summary>
		public virtual void OnEnterCallBack(){

			//加载使能UIPanel的时候，判断 canvasGroup是否为空，为空则赋值
			if(canvasGroup == null){
				canvasGroup = this.GetComponent <CanvasGroup> ();
			}

			//显示 UIPanel
			canvasGroup.alpha = 1;
		}

		/// <summary>
		/// UIPanle 退出时的回调函数
		/// </summary>
		public virtual void OnExitCallBack(){

			//隐藏 UIPanel
			canvasGroup.alpha = 0;
		}

		/// <summary>
		/// UIPanle 暂停时的回调函数
		/// </summary>
		public virtual void OnPauseCallBack(){

			// UIpanel 界面禁止交互
			canvasGroup.blocksRaycasts = false;
		}

		/// <summary>
		/// UIPanle 恢复时的回调函数
		/// </summary>
		public virtual void OnResumeCallBack(){

			// UIpanel 界面使能交互
			canvasGroup.blocksRaycasts = true;
		}

		/// <summary>
		/// 事件回调 UIManager PushUIPanel 显示 UIPanel 界面
		/// </summary>
		public void OnPushUIpanel(string panelTypeString){
			// 字符串转为对应枚举类型
			UIPanelType panelType = (UIPanelType)System.Enum.Parse (typeof(UIPanelType), panelTypeString);
			UIManager.Instance.PushUIPanel (panelType);
		}

		/// <summary>
		/// 事件回调 UIManager PopUIPanel 关闭 UIPanel 界面
		/// </summary>
		public virtual void OnPopUIPanel(){
			UIManager.Instance.PopUIPanel ();
		}
	}
}
