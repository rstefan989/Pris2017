var top5;//namespace
(function (top5) {
    //local variables
    var top5Table = $('#top5Table');
    var table;

    //public object
    top5.viewModel = {}

    //public function
    top5.init = function (data) {
        top5.viewModel = viewModel(data);
        ko.applyBindings(top5.viewModel);
        wireEvents();
    }

    //local object
    var viewModel = function (data) {
        var model = ko.mapping.fromJSON(data);
        return model;
    }

    top5.getUsers = function () {
        app.ajaxGET('GetTop5', null)
            .success(function (result) {
                top5.viewModel.users(result);
                top5.refreshTable();
            })
    }

    top5.refreshTable = function () {
        table.clear();
        table.rows.add(top5.viewModel.users());
        table.draw();
    }

    //local function
    var wireEvents = function () {
        table = top5Table.DataTable({
            data: top5.viewModel.users(),
            order: [[0, "asc"]],
            scrollX: true,
            pageLength: 10,
            language: {
                paginate: {
                    previous: "<span class='fa fa-lg fa-step-backward'></span>",
                    next: "<span class='fa fa-lg fa-step-forward'></span>"
                }
            },
            columns: [
                { data: "firstName" },
                { data: "lastName" }
            ]
        });
    }
}(top5 || (top5 = {})));
