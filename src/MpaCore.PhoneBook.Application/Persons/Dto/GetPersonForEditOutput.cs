using System;
using System.Collections.Generic;
using System.Text;

namespace MpaCore.PhoneBook.Persons.Dto
{
    /// <summary>
    /// 用于添加或编辑 联系人时使用的Dto
    /// </summary>
    public class GetPersonForEditOutput
    {
        /// <summary>
        /// Person编辑状态的Dto
        /// </summary>
        public PersonEditDto Person { get; set; }
    }
}