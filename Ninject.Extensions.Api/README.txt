  ///////////////////////////////////////////////
 //// OVERVIEW               version 0.0.01 ////
///////////////////////////////////////////////

It should be known that Ninject automatically loads NinjectModules with the namespace Ninject.Extensions.*.dll when they exist within the same 
execution directory as its housing assembly... This allows us to define our Ninject bindings in this assembly, add a reference from our App.csproj
and simply retrieve our binds at runtime (the binds are associated to the implementations we define within this Ninject.Extensions.Api.dll).

make sense? More information here:

https://github.com/ninject/ninject/wiki/Modules-and-the-Kernel