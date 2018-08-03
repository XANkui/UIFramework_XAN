using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UIFramework_XAN
{
    /// <summary>
    /// 一个不继承 MonoBehaviour 的单例，不可以 new
    /// 1、定义静态对象，外界可以访问
    /// 2、设置属性单例引用为空时，属性里面自己 new
    /// </summary>

    ///一个用来管理UIPanel的类
    public class UIManager  {

        /// <summary>
        /// UIManager 静态单例属性，只有 get 属性
        /// </summary>
        public static UIManager Instance {
            get {
                //单例为空，则 new 一个
                if (instance == null) {
                    instance = new UIManager();
                }

                return instance;
            }
        }

        /// <summary>
        /// 把UIPanel入栈，显示UI，如果之前有UI则暂停当前UIPanel
        /// </summary>
        /// <param name="panelType">UIPanel 的哪个UIPanel</param>
        public void PushUIPanel(UIPanelType panelType) {

			//安全校验，如果栈为空， new 一个
            if (panelStack == null) {
                panelStack = new Stack<BaseUIPanel>();
            }

			//判断栈内是否有成员，有则获得当前UIPanel，暂停当前 UIPanel
            if (panelStack.Count > 0) {
                BaseUIPanel topPanel = panelStack.Peek();
                topPanel.OnPauseCallBack();
            }

			//根据 UIPanelType 获得 UIPanel 实体
			//引进该 UIPanel 并且显示
			//把该 UIPanel 入栈
            BaseUIPanel panel = GetUIPanelByPanelType(panelType);
            panel.OnEnterCallBack();
            panelStack.Push(panel);
        }

        /// <summary>
        /// 出栈 UIPanel，隐藏当前的UIPanel，并恢复上一界面的状态
        /// </summary>
        public void PopUIPanel() {

			//安全校验，如果栈为空， new 一个
            if (panelStack == null)
                panelStack = new Stack<BaseUIPanel>();

			// 安全校验，因为是出栈，所以先判断，栈是否为空，空则返回，不进行出栈
            if (panelStack.Count <= 0) return;

			//出栈，并获得栈顶的 UIPanel
			//栈顶的 UIPanel，进行退出回调操作
            BaseUIPanel topPanel = panelStack.Pop();
            topPanel.OnExitCallBack();

			// 安全校验，因为是出栈，所以先判断，栈是否为空，空则返回，不进行出栈
            if (panelStack.Count <= 0) return;

			// 出栈后，获取新栈顶成员，并进行恢复操作
            topPanel = panelStack.Peek();
            topPanel.OnResumeCallBack();
        }

        /// <summary>
        /// 通过 UIPanelType 获取对应的实体上的 BaseUIPanel 组件
        /// </summary>
        /// <param name="panelType">UIPanel 的枚举类型，代表哪个UIPanel</param>
        /// <returns>BaseUIPanel 组件</returns>
        private BaseUIPanel GetUIPanelByPanelType(UIPanelType panelType) {
			// 安全校验，如果 panelDic 字典为空，则 new 一个
            if (panelDic == null) {
                panelDic = new Dictionary<UIPanelType, BaseUIPanel>();
            }

			// 尝试获取对应 UIPanelType 对象 （这里可以使用扩展方法，一步操作）
            BaseUIPanel panel;
            panelDic.TryGetValue(panelType, out panel);

			//如果未得到对应的 UIPanelType 对象，则
            if (panel == null) {
				// 尝试获取对应 UIPanelType 对象路径 （这里可以使用扩展方法，一步操作）
                string path;
                panelPathDic.TryGetValue(panelType, out path);

				//加载生成对应 UIPanel 实体
				//设置 UIPanel 实体父对象
				//获取 UIPanel 上的 BaseUIPanel 组件，并添加到字典中
                GameObject panelGo = GameObject.Instantiate(Resources.Load(path)) as GameObject;
                panelGo.transform.SetParent(CanvasTransform, false);
                panel = panelGo.GetComponent<BaseUIPanel>();
                panelDic.Add(panelType, panel);
            }

			// 返回获得的 baseUIPanel
            return panel;
        }


        /// <summary>
        /// Canvas 画布的 属性，只有 get 属性
        /// </summary>
        private Transform CanvasTransform {
            get {
                //如果 canvasTransform 为空，则寻找赋值，虚招名称与具体的画布名称为依据
                if (canvasTransform == null) {
                    canvasTransform = GameObject.Find("Canvas").transform;
                }

                return canvasTransform;
            }
        }

        /// <summary>
        /// UIManager 私有化构造函数，外界不能直接 new
        /// </summary>
        private UIManager() {
            // 构造时获取 UIPanel 路径，存入字典
            ParseUIPanelTypeJson();
        }

        /// <summary>
        /// 解析UIPanel 路径 Json 数据的接收类
        /// </summary>
		[Serializable]
        class UIPanelTypeJson {
            public List<UIPanelPathJsonFormat> jsonInfoList;		//这个名称与Json数据的包装名称一致，不然会读不到数据
        }

        /// <summary>
        /// 解析获取 UIPanel 的路径信息
        /// </summary>
        private void ParseUIPanelTypeJson() {
            //UIPanel 字典初始化
            //Resources 加载 UIPanel 的路径 Json 数据，名称根据自己爆粗你的名称填写
            //Json 获取数据 
            panelPathDic = new Dictionary<UIPanelType, string>();
            TextAsset ta = Resources.Load<TextAsset>("UIPanelPathData");
			UIPanelTypeJson jsonObject = JsonUtility.FromJson<UIPanelTypeJson> (ta.text);

            //逐个解析Json数据，并添加进 UIPanel 路径字典
            foreach (UIPanelPathJsonFormat jsonData in jsonObject.jsonInfoList) {
                panelPathDic.Add(jsonData.panelType, jsonData.path);
            }

        }


        private static UIManager instance;      //UIManager 静态单例
        private Transform canvasTransform;      //Canvas 画布的Transform参数，后面作为UIPanel的父物体
        private Dictionary<UIPanelType, string> panelPathDic;   //存储 Panel 的路径的字典
        private Dictionary<UIPanelType, BaseUIPanel> panelDic;  //存储 Panel 实体的字典
        private Stack<BaseUIPanel> panelStack;      //存储 Panel 实体的栈，显示入栈，隐藏出栈
	}
}
