var home;//namespace
(function (home) {
    //local variables
    var homeTable = $('#homeTable');
    var table;

    //public object
    home.viewModel = {}

    //public function
    home.init = function (data) {
        home.viewModel = viewModel(data);
        ko.applyBindings(home.viewModel);
        wireEvents();
    }

    //local object
    var viewModel = function (data) {
        var model = ko.mapping.fromJSON(data);
        return model;
    }

    home.getAuctionItems = function () {
        app.ajaxGET('GetAuctionItems', null)
            .success(function (result) {
                home.viewModel.auctionItems(result);
                home.refreshTable();
            })
    }

    home.refreshTable = function () {
        table.clear();
        table.rows.add(home.viewModel.auctionItems());
        table.draw();
    }

    //local function
    var wireEvents = function () {
        table = homeTable.DataTable({
            data: home.viewModel.auctionItems(),
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
                { data: "lastBid" },
                { data: "startingPrice" }
            ]
        });
    }
}(home || (home = {})));
