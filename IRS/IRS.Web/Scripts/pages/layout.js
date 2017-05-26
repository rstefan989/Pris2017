var layout;
(function (layout) {

    var countdownInterval;
    var ajaxSuccessDate = new Date;
    var ajaxResult;
    var authTicketWarningMins;
    var appRoot;

    layout.totalSeconds = ko.observable(0);
    layout.minutes = ko.observable(0);
    layout.seconds = ko.observable(0);
        
    layout.init = function (mins, root) {
        appRoot = (root.length != 1) ? root : "";
        setInterval(layout.checkToken, 30000);
        authTicketWarningMins = parseInt(mins) * 60;
    }
    
    layout.countdown = function () {
        if (ajaxResult != null) {
            var newDate = new Date();
            var timeSinceAjaxCall = (newDate.getTime() - ajaxSuccessDate.getTime()) / 1000;
            layout.totalSeconds(ajaxResult - timeSinceAjaxCall)

            if (layout.totalSeconds() < 0) layout.checkToken();
            else {
                layout.minutes(("0" + Math.floor(layout.totalSeconds() / 60)).slice(-2));
                layout.seconds(("0" + Math.floor(layout.totalSeconds() % 60)).slice(-2));
            }
        }
    }
    
    layout.checkToken = function () {
        app.ajaxGET(appRoot + "/General/GetExpirationTimeInSeconds", null)
        .success(function (result) {
            ajaxSuccessDate = new Date();
            ajaxResult = result;
            if (countdownInterval == undefined) {
                layout.countdown();
                countdownInterval = setInterval(layout.countdown, 1000);
            }           
            if (result < authTicketWarningMins) {
                $('#ticketExpirationModal').modal("show");
            } else {
                $('#ticketExpirationModal').modal("hide");
            }
        }).error(function(){
            layout.redirectToLogin();
        })
    }

    layout.refreshToken = function () {
        clearInterval(countdownInterval);
        countdownInterval = undefined;
        $('#ticketExpirationModal').modal("hide");
        app.ajaxPOST(appRoot + "/General/ExtendTicketExpirationTime", null);
    }

    layout.redirectToLogin = function () {
        window.location = appRoot + "/account/login?ReturnUrl=" + window.location.pathname;
    }
}(layout || (layout = {})));

