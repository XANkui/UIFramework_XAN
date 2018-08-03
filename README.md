# UIFramework_XAN
UIFramework_XAN 简单好用的 UI框架

特色：

1、使用 Stack 管理加载的 UIPanel；

2、添加新的UIPanel，只需继承 BaseUIPanel即可，可重写基类函数；

3、UIManager PushUIPanel 管理UIPanel 显示， PopUIPanel 管理 UIPanel 隐藏；

4、能够很方便使用 DOTween 进行 UIPanel 动画；


使用方法：

1、新建 UIPanel，添加 CanvasGroup 组件，新建脚本继承基类 BaseUIPanel ；

2、添加对应显示 OnPushUIPanel 和隐藏 OnPopUIPanel 事件，并把 UIPanel 做成预制体；

3、在 UIPanelType 中添加枚举值，在 UIPanelPathData.Json 数据中，添加对应属性；

4、新建脚本继承基类 BaseUIPanel 的脚本，需要进行添加动画或其他动作，重载基类函数；

4、运行场景即可使用；

