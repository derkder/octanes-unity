### 博客：  
https://www.cnblogs.com/murongxiaopifu/p/7250772.html  
### 项目链接：  
https://github.com/chenjd/Render-Crowd-Of-Animated-Characters  

---
## 背景：  
  #### 正常情况下，大家都会使用Animator来管理角色的动画，而角色也必须使用SkinnedMeshRender来进行渲染。 当要渲染的动画角色数量很大时主要会有以下两个巨大的开销：  
    1、CPU在处理动画时的开销。  
    2、每个角色一个Draw Call造成的开销。  
  #### 这样的情况下遇到的瓶颈：  
    1、角色动画的处理都集中在CPU端。因此一个简单的想法就是我们能否将这部分的开销转移到GPU上  
    2、CPU和GPU之间的Draw Call问题。如果利用批处理（包括Static Batching和Dynamic Batching）或是从Unity5.4之后引入的GPU Instancing就可以解决这个问题。但是，不幸的是这两种技术都不支持动画角色的SkinnedMeshRender。  
  #### 解决方法思想：  
    1、将动画相关的内容从CPU转移到GPU，同时由于CPU不需要再处理动画的逻辑了。而是可以用vertex shader来处理动画的逻辑  
    2、CPU不仅省去了这部分的开销而且SkinnedMeshRender也可以替换成一般的Mesh Render，我们就可以很开心的使用GPU Instancing来减少Draw Call了。  
    
---
## 具体实现  
 #### 1、利用vertex shader设置顶点坐标的方式来展现我们的角色动画【AnimMap】【同时还要将角色的Animator或Animation去掉，将SkinnedMeshRender更换为一般的Mesh Render】  
        按照固定的频率对角色动画取样并记录取样点时刻角色网格上各个顶点的位置信息，并利用贴图的纹素的颜色属性保存对应顶点的位置）。这样该贴图就记录了整个动画时间内角色网格顶点在各个取样点时刻的位置，这个贴图我把它称为AnimMap。  
        其中AnimMap纹理贴图的水平方向记录网格各个顶点的位置，垂直方向是时间信息。  
![AnimMap](/动画系统/imgs/AnimMap示意图.png)  
      
 #### 2、GPU Instancing【先要改成meshrenderer因为gpuinstancing不支持SkinnedMeshRender】  
        GPU Instancing的最大优势是可以减少内存使用和CPU开销。当使用GPU Instancing时，不需要打开批处理，GPU Instancing的目的是一个网格可以与一系列附加参数一起被推送到GPU。  
        
