using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ninject;
using Atom.Model.Abstract;
using Atom.Model.Concrete;

namespace Atom.Infrastructure
{
    public class NinjectDependencyResolver:IDependencyResolver{
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
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
        private void AddBindings()
        {
            kernel.Bind<IArticlesRepository>().To<EFArticlesRepository>();
            kernel.Bind<IPicturesRepository>().To<EFPicturesRepository>();
        }
        }

}