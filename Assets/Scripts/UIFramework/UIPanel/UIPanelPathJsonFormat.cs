using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace UIFramework_XAN{

	/// <summary>
	/// 可序列化的类，保存UIPanel Json数据格式的类
	/// </summary>
	[Serializable]
	public class UIPanelPathJsonFormat : ISerializationCallbackReceiver {
		
		[NonSerialized]							//不作序列化处理
		public UIPanelType panelType;			//Panel 的类型参数

		public string panelTypeString;			//字符串类型的Panel 的类型参数
		public string path;						//panel 的路径参数

		/// <summary>
		/// 在反序列化之后执行的函数
		/// </summary>
		public void OnAfterDeserialize(){

			//把字符串类型的UIpanel Type 转为枚举类型
			//并且赋值给 panelType
			UIPanelType type = (UIPanelType) Enum.Parse (typeof(UIPanelType), panelTypeString);
			panelType = type;
		}

		/// <summary>
		/// 在序列化前执行的函数
		/// </summary>
		public void OnBeforeSerialize()
		{

		}
	}
}
