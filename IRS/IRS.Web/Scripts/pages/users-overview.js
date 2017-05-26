var usersOverview;//namespace
(function (usersOverview) {
    //local variables
    var dialog = $("#usersOverviewModal");
    var dialogChangePassword = $("#changePasswordModal");
    var table = $('#usersOverviewTable');

    //public object
    usersOverview.viewModel = {}

    //public function
    usersOverview.init = function (data) {
        usersOverview.viewModel = viewModel(data);
        ko.applyBindings(usersOverview.viewModel);
        wireEvents();
    }

    //local object
    var viewModel = function (data) {
        var model = ko.mapping.fromJSON(data);
        model.editItem = ko.observable();
        model.newPasswordPartialModel = ko.observable();

        model.edit = function (itemId) {
            dialog.find(".modal-title").html((itemId == 0) ? usersOverview.viewModel.resources.addNewUser().toUpperCase() : usersOverview.viewModel.resources.editUser().toUpperCase());
            app.ajaxGET('../GetUserForEdit', { id: itemId })
            .success(function (result) {
                model.editItem(result);
                dialog.modal("show");
            });
        }

        model.save = function (data) {
            if (data.editItem().id == 0) {
                app.ajaxPOST('../AddUser', ko.toJSON(data.editItem)).success(function (result) {
                    if (result.successful) {
                        dialog.modal("hide");
                        model.refreshTable();
                    };
                });
            } else {
                app.ajaxPOST('../SaveUser', ko.toJSON(data.editItem)).success(function (result) {
                    if (result.successful) {
                        dialog.modal("hide");
                        model.refreshTable();
                    };
                });
            }
        }

        model.editPassword = function (itemId) {
            $('#changePasswordModal .modal-title').text(usersOverview.viewModel.resources.changePassword().toUpperCase());
            app.ajaxGET('../ChangePassword', { id: itemId })
            .success(function (result) {
                model.newPasswordPartialModel(result);
                dialogChangePassword.modal("show");
            });
        }

        model.saveNewPassword = function (data) {
            app.ajaxPOST('../SaveNewPassword', ko.toJSON(data.newPasswordPartialModel)).success(function (result) {
                if (result.successful) {
                    dialogChangePassword.modal("hide");
                    model.refreshTable();
                };
            });
        }

        model.refreshTable = function () {
            table.DataTable().draw();
        }

        return model;
    }

    //local function
    var wireEvents = function () {
        $(document).on("click", "#editBtn, #addBtn", function () {
            usersOverview.viewModel.edit($(this).data('id'));
        });

        $(document).on("click", "#changePassBtn", function () {
            usersOverview.viewModel.editPassword($(this).data('id'));
        });

        $('#roleFilterSelector').change(function () {
            usersOverview.viewModel.refreshTable();
        });

        table.DataTable({            
            order: [[0, "asc"]],
            processing: true,
            serverSide: true,
            scrollX: true,
            ajax: {
                url: "../GetUsers",
                type: "POST",
                datatype: "json",
                data: function (d) {
                    return $.extend({}, d, ko.toJS(usersOverview.viewModel.usersOverviewFilter));
                },
            },
            columns: [
                { data: "FullName", name: "FullName" },
                { data: "Email", name: "Email" },
                { data: "UserRoleName", name: "UserRoleName" },
                { data: "SeniorityLevel", name: "SeniorityLevel" },
                {
                    data: "IsLocked",
                    name: "IsLocked",
                    sortable: false,
                    "render": function (data, type, full, meta) {
                        return (data) ? "<i class='fa fa-lg fa-check-square-o' aria-hidden='true'></i>" : "";
                    }
                },
                { data: "FailedAttempts", name: "FailedAttempts" },
                {
                    sortable: false,
                    "render": function (data, type, full, meta) {
                        return "<a id ='editBtn' title='" + usersOverview.viewModel.resources.editUser() + "' class='btn table-btn fa fa-lg fa-pencil-square-o' data-id='" + full.Id + "' data-toggle='modal' data-target='#usersOverviewModal'></a>" +
                            "<a id ='changePassBtn' title='" + usersOverview.viewModel.resources.changePassword() + "' class='btn table-btn fa fa-key' data-id='" + full.Id + "' data-toggle='modal' data-target='#changePasswordModal'></a>";
                    }
                }
            ]
        });
    }
}(usersOverview || (usersOverview = {})));

