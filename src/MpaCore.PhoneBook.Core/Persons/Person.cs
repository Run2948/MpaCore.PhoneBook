using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Abp.Domain.Entities.Auditing;
using MpaCore.PhoneBook.PhoneNumbers;

namespace MpaCore.PhoneBook.Persons
{
    /// <summary>
    /// 联系人实体信息
    /// </summary>
    public class Person : FullAuditedEntity
    {
        /// <summary>
        /// 姓名
        /// </summary>
        [Required]
        [MaxLength(PhoneBookConsts.MaxNameLength)]
        public virtual string Name { get; set; }

        /// <summary>
        /// 邮箱地址
        /// </summary>
        [EmailAddress]
        [MaxLength(PhoneBookConsts.MaxEmailAddressLength)]
        public virtual string EmailAddress { get; set; }

        /// <summary>
        /// 家庭住址
        /// </summary>
        [MaxLength(PhoneBookConsts.MaxAddressLength)]
        public virtual string Address { get; set; }


        public virtual ICollection<PhoneNumber> PhoneNumbers { get; set; }
    }
}