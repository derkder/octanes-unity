## Job概念  
Job并非线程，他是运行在线程上的一个个任务（理解为方法更方便，但它是个结构体）。  

## JobSystem概念 
JobSystem 管理一组多核中的工作线程(Work Thread)，为避免上下文切换通常一个逻辑核配一个工作线程。  
JobSystem 持有一个 Job 队列，工作线程从该队列中获取 Job 执行  

## NativeContainer
### 定义： 
复制数据来保证线程安全的弊端就是任务的结果也是独立的，因此使用NativeContainer将结果储存在**公共内存**中.
### 详述：
NativeContainer以相对安全的托管类型的方式指向一个非托管的内存地址，使Job 可以直接访问主线程数据而非复制  
Unity 自带 NativeContainer类型为 NativeArray，ECS 包又扩展了NativeList、NativeHashMap、NativeMultiHashMap和NativeQueue  
默认情况下，Job 同时拥有NativeContainer的读写权限，但 C# Job System 不允许多个 Job 同时拥有对一个NativeContainer的写权限，因此对不需要写权限的NativeContainer加上[ReadOnly]特性，以减少性能影响  
