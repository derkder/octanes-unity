### Job概念  
Job并非线程，他是运行在线程上的一个个任务（理解为方法更方便，但它是个结构体）。  

### JobSystem概念 
JobSystem 管理一组多核中的工作线程(Work Thread)，为避免上下文切换通常一个逻辑核配一个工作线程。  
JobSystem 持有一个 Job 队列，工作线程从该队列中获取 Job 执行  
