## mipmap怎么决定用哪张贴图的
~深度信息~
根据当前纹理的纹理坐标（UV）以及 GPU 计算的两个内部值：DDX 和 DDY（提供有关当前像素旁边和上方像素的 UV 的信息，包括距离和角度）。    
GPU 使用这些值来确定相机可以看到多少纹理的细节。当前像素与其相邻像素之间的距离越远，角度越极端，意味着 GPU 会选择分辨率较低的 mipmap 级别;更短的距离和更小的极端角度意味着 GPU 会选择具有更高分辨率的 MIPMAP 级别。   
## 三线性过滤
GPU 还可以通过三线性过滤将来自两个 mipmap 级别的纹理信息混合在一起。在采样时混合 mipmap 级别可以使从一个 mipmap 级别到另一个 mipmap 级别的过渡不那么明显。为了混合 mipmap 级别，GPU 从一个 mipmap 级别获取特定百分比的纹理信息，从另一个 mipmap 级别获取其余纹理信息。   

## mipmap bias   
根据采样器设置，称为 mipmap bias 的设置可以在采样时执行两项操作：     
1. mipmap 偏差可以更改 GPU 的阈值，为样本选择较低或较高的 mipmap 级别。当您在采样器中使用点和线性滤波时，GPU 会选择特定的 mipmap 级别。例如，GPU 可能会决定一组 UV 下的纹理使用 mipmap 级别 3 的样本。如果 mipmap 偏差为 –2，则 GPU 将改用更高分辨率的 mipmap 级别 1 作为样本。
 
2. 在混合来自不同 mipmap 级别的样本时，mipmap 偏差可以告诉 GPU 优先选择一个 mipmap 级别而不是另一个 mipmap 级别.当您在采样器中使用三线性过滤时，GPU 会混合 mipmap 级别。例如，GPU 的计算可能会返回值 0.5。0.5 值告诉 GPU 从一个 mipmap 级别获取所需的 50% 的纹理信息，从下一个 mipmap 级别获取剩余的 50% 纹理信息。如果添加 mipmap 偏差 0.2，则 0.5 值将更改为 0.7，GPU 将从第一个 mipmap 级别获取 70% 的纹理信息，而从第二个级别获取 30% 的纹理信息。


## The Mipmap Streaming system
该系统强制 Unity 仅加载渲染当前相机所需的 mipmap 级别位置，而不是默认加载所有。   
[https://blog.csdn.net/UWA4D/article/details/129314695]
