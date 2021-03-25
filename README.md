[![Version](https://img.shields.io/nuget/v/MyNihongo.Option?style=plastic)](https://www.nuget.org/packages/MyNihongo.Option/)  
A very simple implementation of the optional pattern with a few extension methods.
### Create an Optional&#60;T&#62;
```cs
// Explicitly
var optional = Optional<int>.Of(123);

// Implicitly
Optional<int> optional = 123;

// Extension method
var optional = 123.AsOptional();

// From Task/ValueTask
var optional = Task.FromResult(123).AsOptionalAsync();
var optional = new ValueTask(123).AsOptionalAsync();

// None
var none = Optional<int>.None();
```
### Handle values of Optional&#60;T&#62;
```cs
var value = Optional<int>.Of(123).ValueOr(321);
var convertOptional = Optional<int>.Of(123).Convert(x => (long)x);
var convertValue = Optional<int>.Of(123).ConvertOr(x => (long)x, 321L);
```
### Invoke functions if a value is present or not
Both synchronous (void) and asynchronous (Task and ValueTask) can be invoked.
```cs
Optional<int>.Of(123)
    .IfHasValue(x => { /* do something with the value */ })
    .OrElse(() => { /* do something if no value */ });

await Optional<int>.None()
    .IfHasValueAsync(x => new ValueTask())
    .OrElseAsync(() => new ValueTask());
```
### Create an Optional&#60;T&#62; from IEnumerable&#60;T&#62;
FirstOrOptional
```cs
var items = new [] { 1, 2, 3 };

var item = items.FirstOrOptional();
var item = items.FirstOrOptional(x => x % 2 == 0);
```
LastOrOptional
```cs
var items = new [] { 1, 2, 3 };

var item = items.LastOrOptional();
var item = items.LastOrOptional(x => x % 2 == 0);
```
SingleOrOptional
```cs
var items = new [] { 1, 2, 3 };

var item = items.SingleOrOptional();
var item = items.SingleOrOptional(x => x % 2 == 0);
```
ElementAtOrOptional
```cs
var items = new [] { 1, 2, 3 };
var item = items.SingleOrOptional(3);
```
MinOrOptional
```cs
var items = new [] { 1, 2, 3 };
var item = items.MinOrOptional();
```
```cs
var items = new []
{
    new { Number = "1" },
    new { Number = "2" }
};

var item = items.MinOrOptional(x => x.Number);
```
MaxOrOptional
```cs
var items = new [] { 1, 2, 3 };
var item = items.MaxOrOptional();
```
```cs
var items = new []
{
    new { Number = "1" },
    new { Number = "2" }
};

var item = items.MaxOrOptional(x => x.Number);
```
