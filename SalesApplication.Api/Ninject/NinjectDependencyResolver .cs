using System.Web.Http.Dependencies;
using Ninject;
using Ninject.Syntax;
using System.Collections.Generic;
using System;
using SalesApplication.Data.Adapter.Contract;
using SalesApplication.Data.Adapter.Legacy.SQLServer;

namespace SalesApplication.Api.Ninject
{
    /// <summary>
    /// This is boiler plate code to support SalesApplication.Api.csproj's dependency injection via Ninject
    /// </summary>
    /// <remarks>TODO: Move this to a separate assembly?</remarks>
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver()
        {
            kernel = new StandardKernel();
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        public IBindingToSyntax<T> Bind<T>()
        {
            return kernel.Bind<T>();
        }

        public IKernel Kernel
        {
            get { return kernel; }
        }

        private void AddBindings()
        {
            // TODO add API DI/IoC bindings
            kernel.Bind<ISalesAppData>().To<CapwairData>();
        }

        public IDependencyScope BeginScope()
        {
            return new NinjectDependencyScope(kernel);
        }

        public void Dispose()
        {
            IDisposable disposable = (IDisposable)kernel;
            if (disposable != null) disposable.Dispose();
            kernel = null;
        }
    }
}
