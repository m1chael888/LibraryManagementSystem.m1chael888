using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.m1chael888.Controllers
{
    internal class BaseController
    {
        internal interface IBaseController
        {
            void ViewItems();
            void AddItem();
            void DeleteItem();
        }
    }
}
