using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Abp.UI;
using Microsoft.EntityFrameworkCore;
using MpaCore.PhoneBook.Persons.Dto;

namespace MpaCore.PhoneBook.Persons
{
    public class PersonAppService : PhoneBookAppServiceBase, IPersonAppService
    {
        private readonly IRepository<Person, int> _personRepository;

        public PersonAppService(IRepository<Person, int> personRepository)
        {
            _personRepository = personRepository;
        }

        /// <summary>
        /// 根据查询条件获取联系人分页列表
        /// </summary>
        public async Task<PagedResultDto<PersonListDto>> GetPagedPersonsAsync(GetPersonInput input)
        {
            var query = _personRepository.GetAll();

            // TODO:根据传入的参数添加过滤条件

            var personCount = await query.CountAsync();

            var persons = await query
                .OrderBy(input.Sorting)
                .PageBy(input)
                .ToListAsync();

            var personListDtos = ObjectMapper.Map<List<PersonListDto>>(persons);

            return new PagedResultDto<PersonListDto>(
                personCount,
                personListDtos
            );
        }

        /// <summary>
        /// 通过指定id获取联系人ListDto信息
        /// </summary>
        public async Task<PersonListDto> GetPersonByIdAsync(EntityDto input)
        {
            var entity = await _personRepository.GetAsync(input.Id);
            return ObjectMapper.Map<PersonListDto>(entity);
        }

        /// <summary>
        /// 通过Id获取联系人信息进行编辑或修改 
        /// </summary>
        public async Task<GetPersonForEditOutput> GetPersonForEditAsync(NullableIdDto<int> input)
        {
            var output = new GetPersonForEditOutput();

            PersonEditDto personEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _personRepository.GetAsync(input.Id.Value);
                personEditDto = ObjectMapper.Map<PersonEditDto>(entity);
            }
            else
            {
                personEditDto = new PersonEditDto();
            }

            output.Person = personEditDto;
            return output;
        }

        /// <summary>
        /// 新增或更改联系人
        /// </summary>
        public async Task CreateOrUpdatePersonAsync(CreateOrUpdatePersonInput input)
        {
            if (input.PersonEditDto.Id.HasValue)
            {
                await UpdatePersonAsync(input.PersonEditDto);
            }
            else
            {
                await CreatePersonAsync(input.PersonEditDto);
            }
        }

        /// <summary>
        /// 新增联系人
        /// </summary>
        public async Task<PersonEditDto> CreatePersonAsync(PersonEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            var entity = await _personRepository.InsertAsync(ObjectMapper.Map<Person>(input));
            return ObjectMapper.Map<PersonEditDto>(entity);
        }

        /// <summary>
        /// 更新联系人
        /// </summary>
        public async Task UpdatePersonAsync(PersonEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新

            // var entity = await _personRepository.GetAsync(input.Id.Value);
            await _personRepository.UpdateAsync(ObjectMapper.Map<Person>(input));
        }

        /// <summary>
        /// 删除联系人
        /// </summary>
        public async Task DeletePersonAsync(EntityDto input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            var entity = await _personRepository.GetAsync(input.Id);
            if (entity == null)
            {
                throw new UserFriendlyException("该联系人已经消失在数据库中，无法完成该删除操作");
            }
            await _personRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// 批量删除联系人
        /// </summary>
        public async Task BatchDeletePersonAsync(IEnumerable<int> input)
        {
            //TODO:批量删除前的逻辑判断，是否允许删除
            await _personRepository.DeleteAsync(s => input.Contains(s.Id));
        }
    }
}