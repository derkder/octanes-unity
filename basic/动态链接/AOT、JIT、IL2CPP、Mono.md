## Mono与IL2CCPP
Unity的跨平台技术是通过一个Mono虚拟机实现的。而这个虚拟机更新太慢，不能很好地适应众多的平台。  
unity公司就自行研发了IL2cpp，把本来应该在mono的虚拟机上跑的中间代码转换成cpp代码，这样再把生成的cpp代码，利用c++的跨平台特性  
①Mono VM在各个平台移植，维护非常耗时，有时甚至不可能完成  
②Mono版本授权受限  
③提高运行效率  
④有了IL2CPP，程序尺寸可以相对缩小，运行速度可以提高！  
⑤使用了IL2CPP在堆内存分配方面和Mono 相比，Reserved Total 是可以下降的，而 Mono的 Reserved Total 只会上升不会下降。  
(mono打包快但最后的包还是用il2cpp?)  
https://blog.csdn.net/cgExplorer/article/details/107029630    
![mono&IL2CPP](basic/动态链接/imgs/mono&IL2CPP.png)    


##  IL：intermediate language中间语言  
C#或者VB这样遵循CLI规范的高级语言，被先被各自的编译器编译成中间语言：IL（CIL），等到需要真正执行的时候，这些IL会被加载到运行时库，也就是VM中，由VM动态的编译成汇编代码（JIT）然后在执行。  






## JIT
即Just-in-time,动态(即时)编译，边运行边编译；AOT，Ahead Of Time，指运行前编译，是两种程序的编译方式
当程序需要支持动态链接时，只能使用JIT，但占用运行时资源，会导致进程卡顿
