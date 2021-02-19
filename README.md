# Memory leak by event handler and how to solve it

### Spec
.NET Framework 4.6.2
Built in 32-bit, so the memory usage will be max 2GB per process

## Tests
* Test1: baseline
* Test2: demo for memory leak
* Test3: use Dispose() method
* Test4 (unfinished): use weak reference