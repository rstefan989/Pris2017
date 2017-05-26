var allItems;//namespace
(function (allItems) {
    //local variables
    var allItemsTable = $('#allItemsTable');
    var table;

    //public object
    allItems.viewModel = {}

    //public function
    allItems.init = function (data) {
        allItems.viewModel = viewModel(data);
        ko.applyBindings(allItems.viewModel);
        wireEvents();
    }

    //local object
    var viewModel = function (data) {
        var model = ko.mapping.fromJSON(data);
        return model;
    }

    allItems.getOpenedAuctionItems = function () {
        app.ajaxGET('GetOpenedItems', null)
            .success(function(result) {
                allItems.viewModel.auctionItems(result);
                allItems.refreshTable();
            });
    }

    allItems.refreshTable = function () {
        table.clear();
        table.rows.add(allItems.viewModel.auctionItems());
        table.draw();
    }

    //local function
    var wireEvents = function () {
        table = allItemsTable.DataTable({
            data: allItems.viewModel.auctionItems(),
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
                    render: function(data) {
                        return app.toLocaleDateTimeFormat(data());
                    }
                },
                { data: "userFullName" },
                { data: "categoryName" },
                {
                    sortable: false,
                    "render": function (data, type, full, meta) {
                        return "<a href='/Home/Bid/" + full.userId() + "'>Bid</a>";
                    }
                },
                {
                    sortable: false,
                    "render": function (data, type, full, meta) {
                        return "<a href='/Home/Rate/" + full.id() + "'><i class='fa fa-star-o'></i></a>";
                    }
                }
            ]
        });
    }
}(allItems || (allItems = {})));
