using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.DbInitializer
{
    public interface IDbInitializer
    {
        /// <summary>
        /// This method is responsable for creating admin user and roles of our website.
        /// </summary>
        void Initialize();
    }
}
