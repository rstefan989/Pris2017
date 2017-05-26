var myItems;//namespace
(function (myItems) {
    //local variables
    var myItemsTable = $('#myItemsTable');
    var table;

    //public object
    myItems.viewModel = {}

    //public function
    myItems.init = function (data) {
        myItems.viewModel = viewModel(data);
        ko.applyBindings(myItems.viewModel);
        wireEvents();
    }

    //local object
    var viewModel = function (data) {
        var model = ko.mapping.fromJSON(data);
        return model;
    }

    myItems.getMyAuctionItems = function () {
        app.ajaxGET('GetMyItems', null)
            .success(function (result) {
                myItems.viewModel.auctionItems(result);
                myItems.refreshTable();
            })
    }

    myItems.refreshTable = function () {
        table.clear();
        table.rows.add(myItems.viewModel.auctionItems());
        table.draw();
    }

    //local function
    var wireEvents = function () {
        table = myItemsTable.DataTable({
            data: myItems.viewModel.auctionItems(),
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
                { data: "name" },
                { data: "startingPrice" },
                {
                    data: "endDate",
                    render: function (data) {
                        return app.toLocaleDateTimeFormat(data());
                    }
                },
                { data: "categoryName" },
                {
                    sortable: false,
                    "render": function (data, type, full, meta) {
                        return "<a href='/Home/AddEditItem/" + full.id() + "'><i class='fa fa-pencil'></i></a>";
                    }
                }
            ]
        });
    }
}(myItems || (myItems = {})));
