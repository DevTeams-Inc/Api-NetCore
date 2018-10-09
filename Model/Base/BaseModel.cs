using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.Base
{
    public class BaseModel
    {
        [DataType(DataType.DateTime)]
        public DateTime RegisterDate { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime UpdatedDate { get; set; }

        public BaseModel()
        {
            RegisterDate = DateTime.Now;
        }
    }
}
