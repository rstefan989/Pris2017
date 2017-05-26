var countryLps;//namespace
(function (countryLps) {
    //local variables
    var countryLpsTable = $('#countryLpsTable');
    var table;

    //public object
    countryLps.viewModel = {}

    //public function
    countryLps.init = function (data) {
        countryLps.viewModel = viewModel(data);
        ko.applyBindings(countryLps.viewModel);
        wireEvents();
        countryLps.getCountries();
    }

    //local object
    var viewModel = function (data) {
        var model = ko.mapping.fromJSON(data);

        model.lockButtons = ko.observable();
        model.uploading = ko.observable();

        model.uploading(false);

        return model;
    }

    countryLps.upload = function (data, event) {
        app.notifications.addInfo(countryLps.viewModel.resources.importStarted());
        countryLps.viewModel.uploading(true);

        //FormData object
        var formdata = new FormData();
        var fileInput = document.getElementById('fileInput');
        if (fileInput.files[0] != null) {
            formdata.append(fileInput.files[0].name, fileInput.files[0]);
        }
        //Creating an XMLHttpRequest and sending
        var xhr = new XMLHttpRequest();
        xhr.open('POST', 'Upload');
        xhr.send(formdata);
        xhr.onreadystatechange = function () {
            if (xhr.readyState == 4 && xhr.status == 200) {
                $("#uploadModal").modal("hide");
                app.notifications.show(JSON.parse(xhr.response).notifications);
                countryLps.viewModel.uploading(false);
                countryLps.getCountries();
            } else {
                app.notifications.addError(app.errorMsg);
                countryLps.viewModel.uploading(false);
            }
        }
    }

    countryLps.getCountries = function () {
        app.ajaxGET('GetCountries', null)
            .success(function (result) {
                countryLps.viewModel.countries(result);
                countryLps.refreshTable();
            })
            .error(function (jqXHR, textStatus, errorThrown) {
            });
    }

    countryLps.refreshTable = function () {
        table.clear();
        table.rows.add(countryLps.viewModel.countries());
        table.draw();
    }

    //local function
    var wireEvents = function () {
        table = countryLpsTable.DataTable({
            data: countryLps.viewModel.countries(),
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
                { data: "orderNum" },
                { data: "lpCode" },
                { data: "name" },
                { data: "numOfChars" }
            ]
        });
    }
}(countryLps || (countryLps = {})));

$(function () {

    // We can attach the `fileselect` event to all file inputs on the page
    $(document).on('change', ':file', function () {
        var input = $(this),
            numFiles = input.get(0).files ? input.get(0).files.length : 1,
            label = input.val().replace(/\\/g, '/').replace(/.*\//, '');
        input.trigger('fileselect', [numFiles, label]);
    });

    // We can watch for our custom `fileselect` event like this
    $(document).ready(function () {
        $(':file').on('fileselect', function (event, numFiles, label) {

            var input = $(this).parents('.input-group').find(':text'),
                log = numFiles > 1 ? numFiles + ' files selected' : label;

            if (input.length) {
                input.val(log);
            } else {
                if (log) alert(log);
            }

        });
    });

});
