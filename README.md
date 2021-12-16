# 自己学习和研究的仓库


## 声明:

**项目内的资源文件都已经标明出处，仅供学习使用**

Unity版本：2019.4.33     (4.31修复了在安卓CPU 大小核分配导致的高端机帧率低的问题)  
URP版本： 7.5.2       (后续需要考虑升级到2020版本Unity  解决了安卓SRP Batch的问题) 

-----------------------

### UI相关
- [5. UI Particle](https://github.com/mob-sakai/ParticleEffectForUGUI)
> 一套优秀的UI粒子特效播放方案 
  


### 编辑器相关

- [Odin](https://assetstore.unity.com/packages/tools/utilities/odin-inspector-and-serializer-89041)
> 非常好用的编辑器工具

### URP相关

基于[tkweizhong-CustomURP](https://github.com/tkweizhong/CustomURP)基础上学习和修改
* 原版：
- [X] 场景相机走Linear渲染; UI相机走Gamma渲染
- [X] 场景相机和ui相机分辨率分离
- [X] 修正FXAA在最后pass渲染，导致UI模糊问题
 ```
已知问题：
1.编辑器下scene界面和Game UI渲染效果不一致 （因为URP代码只会校正 Game窗口的 UI）
2.字体会偏色（多了一次Gamma2Linear校正）
3.多了2张RT 以及两次全屏bilt 在oppoA9 性能大约降低了25% （ 由33fps -> 25fps）
5.项目所有的ui相机贴图、图集都需要去掉勾选 srgb ，而部分场景贴图则需要勾选srgb 
```
* 新增：
- [X] URP Animation-Instancing在 [官方版本](https://github.com/Unity-Technologies/Animation-Instancing)的基础上升级了对URP的支持
- [ ] TODO...
### 其他模块



-----------

