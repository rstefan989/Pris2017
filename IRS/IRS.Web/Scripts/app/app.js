var app = function () {
    $.ajaxSetup({
        cache: false,
        error: function (jqXHR, textStatus, errorThrown) {
            if (!app.errorMsgDisplayed) {
                app.errorMsgDisplayed = true;
                setTimeout(function() {
                        app.notifications.addError(app.errorMsg);
                    },
                    2000);
            }
        }
    });
    return {
        init: function (errorMsg) {
            this.errorMsg = errorMsg;
        },

        errorMsg: '',
        errorMsgDisplayed: false,
        toLocaleDateTimeFormat: function(datetime){
            return moment(datetime).format("DD-MM-YYYY HH:mm:ss");
        },
        toLocaleDateFormat: function (datetime) {
            return moment(datetime).format("DD-MM-YYYY");
        },
        ajaxGET: function(url, data){
            return $.ajax({
                url: url,
                type: 'GET',
                data: data,
                datatype: 'json',
                contenttype: 'application/json;utf-8'
            }).success(function (result) {
                this.errorMsgDiplayed = false;
            });
        },
        ajaxPOST: function (url, data) {
            return $.ajax({
                url: url,
                type: 'POST',
                data: data,
                contentType: 'application/json; charset=utf-8'
            }).success(function (result) {
                this.errorMsgDiplayed = false;
                app.notifications.show(result.notifications);
            });
        }
    };
}();