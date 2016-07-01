using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomacaoDesktop.Applications
{
    public interface IApplication
    {
        void Goto();
        bool IsAt();
    }

    public abstract class Application<T> where T : IApplication, new()
    {
        private static T _instance = default(T);

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = GetWindow();
                }

                return _instance;
            }
        }

        public static T GetWindow()
        {
            var window = new T();

            return window;
        }
    }
}
