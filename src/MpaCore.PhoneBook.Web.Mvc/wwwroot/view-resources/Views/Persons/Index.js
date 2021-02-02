(function($) {
    var _personService = abp.services.app.person,
        l = abp.localization.getSource('PhoneBook'),
        _$modal = $('#PersonCreateModal'),
        _$form = _$modal.find('form'),
        _$table = $('#PersonsTable');

    console.log(_personService);

    var _$personsTable = _$table.DataTable({
        paging: true,
        serverSide: true,
        ajax: function(data, callback, settings) {
            var filter = $('#PersonsSearchForm').serializeFormToObject(true);
            filter.maxResultCount = data.length;
            filter.skipCount = data.start;

            abp.ui.setBusy(_$table);
            _personService.getPagedPersons(filter).done(function(result) {
                callback({
                    recordsTotal: result.totalCount,
                    recordsFiltered: result.totalCount,
                    data: result.items
                });
            }).always(function() {
                abp.ui.clearBusy(_$table);
            });
        },
        buttons: [
            {
                name: 'refresh',
                text: '<i class="fas fa-redo-alt"></i>',
                action: () => _$personsTable.draw(false)
            }
        ],
        responsive: {
            details: {
                type: 'column'
            }
        },
        columnDefs: [
            {
                targets: 0,
                className: 'control',
                defaultContent: '',
            },
            {
                targets: 1,
                data: 'name',
                sortable: false
            },
            {
                targets: 2,
                data: 'emailAddress',
                sortable: false
            },
            {
                targets: 3,
                data: 'address',
                sortable: false
            },
            {
                targets: 4,
                data: 'creationTime',
                sortable: false
            },
            {
                targets: 5,
                data: null,
                sortable: false,
                autoWidth: false,
                defaultContent: '',
                render: (data, type, row, meta) => {
                    return [
                        `   <button type="button" class="btn btn-sm bg-secondary edit-person" data-person-id="${row.id
                        }" data-toggle="modal" data-target="#PersonEditModal">`,
                        `       <i class="fas fa-pencil-alt"></i> ${l('Edit')}`,
                        '   </button>',
                        `   <button type="button" class="btn btn-sm bg-danger delete-person" data-person-id="${row.id
                        }" data-person-name="${row.name}">`,
                        `       <i class="fas fa-trash"></i> ${l('Delete')}`,
                        '   </button>'
                    ].join('');
                }
            }
        ]
    });

    _$form.validate({
        rules: {
            Name: "required",
            EmailAddress: "required"
        }
    });

    _$form.find('.save-button').on('click',
        (e) => {
            e.preventDefault();

            if (!_$form.valid()) {
                return;
            }

            var person = _$form.serializeFormToObject();
            abp.ui.setBusy(_$modal);
            _personService.createPerson(person).done(function() {
                _$modal.modal('hide');
                _$form[0].reset();
                abp.notify.info(l('SavedSuccessfully'));
                _$personsTable.ajax.reload();
            }).always(function() {
                abp.ui.clearBusy(_$modal);
            });
        });

    $(document).on('click', '.delete-person', function() {
        var personId = $(this).attr("data-person-id");
        var personName = $(this).attr('data-person-name');

        deletePerson(personId, personName);
     });

    function deletePerson(personId, personName) {
        abp.message.confirm(abp.utils.formatString(l('AreYouSureWantToDelete'), personName), null, (isConfirmed) => {
                if (isConfirmed) {
                    _personService.deletePerson({
                        id: personId
                    }).done(() => {
                        abp.notify.info(l('SuccessfullyDeleted'));
                        _$personsTable.ajax.reload();
                    });
                }
            }
        );
    }

    $(document).on('click', '.edit-person', function (e) {
        var personId = $(this).attr("data-person-id");

        e.preventDefault();
        abp.ajax({
            url: abp.appPath + 'Persons/EditModal?personId=' + personId,
            type: 'POST',
            dataType: 'html',
            success: function (content) {
                $('#PersonEditModal div.modal-content').html(content);
            },
            error: function (e) { }
        });
    });

    abp.event.on('person.edited', (data) => {
        _$personsTable.ajax.reload();
    });

    _$modal.on('shown.bs.modal', () => {
        _$modal.find('input:not([type=hidden]):first').focus();
    }).on('hidden.bs.modal', () => {
        _$form.clearForm();
    });

    $('.btn-search').on('click', (e) => {
        _$personsTable.ajax.reload();
    });

    $('.txt-search').on('keypress', (e) => {
        if (e.which == 13) {
            _$personsTable.ajax.reload();
            return false;
        }
    });
})(jQuery);