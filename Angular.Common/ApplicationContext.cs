using System;

namespace Angular.Common
{
    public class ApplicationContext
    {
        private static IContext _context;
        public static void SetContext(IContext context) {
            _context = context;
        }

        public static IContext Context {
            get {
                return _context;
            }
        }
    }
}
