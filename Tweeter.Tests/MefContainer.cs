using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Tweeter.Tests
{
    public static class MefContainer
    {
        private static CompositionContainer _compositionContainer;

        public static CompositionContainer Container
        {
            get
            {
                if (_compositionContainer == null)
                {
                    var directoryCatalog = new DirectoryCatalog(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                    _compositionContainer = new CompositionContainer(directoryCatalog);
                }

                return _compositionContainer;
            }
        }

        public static void Dispose()
        {
            if (_compositionContainer != null)
            {
                _compositionContainer.Dispose();
                _compositionContainer = null;
            }
        }
    }
}
