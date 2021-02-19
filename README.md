# Memory leak by event handler and how to solve it

### Spec
.NET Framework 4.6.2
Built in 32-bit, so the memory usage will be max 2GB per process

## Tests
A is subscriber; B is publisher
* Test1: baseline
* Test2: demo for memory leak
* Test3: use Dispose() method on subscriber; it will work if called manually; it will not work passively in Finalizer
* Test4: reset event on publisher; it will work if called manually
* Test5 (TODO): use weak reference