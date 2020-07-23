using System;
using System.Collections.Generic;
using System.Text;

namespace OA_DataAccess
{
    public class EmployeeParameters
    {
        const int maxPageSize = int.MaxValue;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 10;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
    }
}
