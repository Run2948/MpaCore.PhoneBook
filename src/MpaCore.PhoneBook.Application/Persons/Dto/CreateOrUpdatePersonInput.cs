using System;
using System.Collections.Generic;
using System.Text;

namespace MpaCore.PhoneBook.Persons.Dto
{
    /// <summary>
    /// 联系人新增和编辑时用Dto
    /// </summary>
    public class CreateOrUpdatePersonInput
    {
        public PersonEditDto PersonEditDto { get; set; }
    }
}