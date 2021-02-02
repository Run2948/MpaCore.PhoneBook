using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Abp.AutoMapper;

namespace MpaCore.PhoneBook.Persons.Dto
{
    /// <summary>
    /// 联系人编辑用Dto
    /// </summary>
    [AutoMap(typeof(Person))]
    public class PersonEditDto
    {
        /// <summary>
        ///   主键Id
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [Required]
        [MaxLength(32)]
        public string Name { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [MaxLength(225)]
        public string EmailAddress { get; set; }

        /// <summary>
        /// 家庭住址
        /// </summary>
        [MaxLength(225)]
        public string Address { get; set; }
    }
}